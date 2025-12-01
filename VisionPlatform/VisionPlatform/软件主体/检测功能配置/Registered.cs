using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class Registered : Form
    {
        public Registered()
        {
            InitializeComponent();
            this.textBox_machine.Text = getMNum();
        }
        bool m_bCloseMain = true;
        private void button_login_Click(object sender, EventArgs e)
        {
            if (this.textBox_registration.Text == "")
            {
                MessageBox.Show("注册码为空！");
                return;
            }

            if (this.textBox_registration.Text ==getRNum(getMNum()))
            {
                try
                {
                    bool rst = false;
                    RegistryKey localKey = Registry.LocalMachine;
                    RegistryKey softWareKey = localKey.OpenSubKey("SOFTWARE", true);
                    string[] keys = softWareKey.GetSubKeyNames();
                    foreach (var item in keys)
                    {
                        if (item == "BPY2")
                        {
                            rst = true;

                        }
                    }
                    if (rst == false)
                    {
                        softWareKey.CreateSubKey("BPY2\\PAR");
                    }

                    RegistryKey HLZNKey = softWareKey.OpenSubKey("BPY2\\PAR", true);
                    //写入注册标志位
                    HLZNKey.SetValue("installed", SHA1(getMNum()));
                    m_bCloseMain = false;
                    MessageBox.Show("注册成功！请重新打开软件。");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                m_bCloseMain = true;
                MessageBox.Show("注册码异常！ 注册失败！");
            }
        }
        // 取得设备硬盘的卷标号
        public static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        //获得CPU的序列号
        public static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        //生成机器码
        public static string getMNum()
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码
            strMNum = AESEncrypt(strMNum);
            strMNum = DESEncrypt(strMNum);
            return strMNum;
        }

        //生成机器码(用于和注册码对比)
        public static string getMNum2()
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码
            strMNum = AESEncrypt(strMNum);
            return strMNum;
        }
        //生成注册码
        public static string getRNum(string strMNum)  //根据机器码生成注册码
        {
            string RNum= DESDecrypt(strMNum);
            return RNum;
        }


        #region DES
        private static string DESKey = "19950705";
        /// <summary> 
        /// DES加密 
        /// </summary>
        public static string DESEncrypt(string value, string _deskey = null)
        {
            if (string.IsNullOrEmpty(_deskey))
            {
                _deskey = DESKey;
            }

            byte[] keyArray = Encoding.UTF8.GetBytes(_deskey);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(value);

            DESCryptoServiceProvider rDel = new DESCryptoServiceProvider();
            rDel.IV = keyArray;
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        /// <summary> 
        /// DES解密 
        /// </summary>
        public static string DESDecrypt(string value, string _deskey = null)
        {

            if (string.IsNullOrEmpty(_deskey))
            {
                _deskey = DESKey;
            }

            byte[] keyArray = Encoding.UTF8.GetBytes(_deskey);
            byte[] toEncryptArray = Convert.FromBase64String(value);

            DESCryptoServiceProvider rDel = new DESCryptoServiceProvider();
            rDel.Key = keyArray;
            rDel.IV = keyArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);

        }
        #endregion
        #region Aes
        private static string AesKey = "17190300414996617190300414123456";
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <param name="AesKey">aes密钥，长度必须32位</param>
        /// <returns>加密后的字符串</returns>
        public static string AESEncrypt(string value, string _key = null)
        {
            if (string.IsNullOrEmpty(_key))
            {
                _key = AesKey;
            }
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.Key = Encoding.UTF8.GetBytes(AesKey);
                aesProvider.Mode = CipherMode.ECB;
                aesProvider.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor())
                {
                    byte[] inputBuffers = Encoding.UTF8.GetBytes(value);
                    byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                    aesProvider.Clear();
                    aesProvider.Dispose();
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <param name="AesKey">aes密钥，长度必须32位</param>
        /// <returns>解密后的字符串</returns>
        public static string AESDecrypt(string value, string _key = null)
        {
            if (string.IsNullOrEmpty(_key))
            {
                _key = AesKey;
            }
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.Key = Encoding.UTF8.GetBytes(AesKey);
                aesProvider.Mode = CipherMode.ECB;
                aesProvider.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor())
                {
                    byte[] inputBuffers = Convert.FromBase64String(value);
                    byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                    aesProvider.Clear();
                    return Encoding.UTF8.GetString(results);
                }
            }
        }
        #endregion

        #region SHA1
        /// <summary>  
        /// SHA1加密
        /// </summary>  
        /// <param name="content">需要加密字符串</param>  
        /// <param name="encode">指定加密编码</param>  
        /// <returns>返回40位大写字符串</returns>  
        public static string SHA1(string value)
        {
            //UTF8编码
            var buffer = Encoding.UTF8.GetBytes(value);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            var data = sha1.ComputeHash(buffer);
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                //转换大写十六进制
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
        #endregion
        private void Registered_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
