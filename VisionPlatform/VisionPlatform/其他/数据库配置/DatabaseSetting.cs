/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：DatabaseSetting
* 机器名称：HLZN
* 命名空间：VisionPlatform.多线插.数据库配置
* 文 件 名：DatabaseSetting
* 创建时间：2023/9/27 11:51:35
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2023 保留所有权利.
***********************************************************/
using Hi.Ltd.Interface;
using Hi.Ltd.Interop;
using System;
using System.IO;
using System.Windows.Forms;

namespace VisionPlatform.Auxiliary
{
    public partial class DatabaseSetting : Form
    {
        private readonly IIni ini;
        public DatabaseSetting()
        {
            InitializeComponent();
            ini = IniHelper.Create;
            Load += DatabaseSetting_Load;
        }

        private void DatabaseSetting_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalPath.SavePath.IniPath))
            {
                ConnectData receive = ini.Deserialize<ConnectData>(GlobalPath.SavePath.IniPath);

                txt_RemoteDatabase.Text = receive.DataBase;
                txt_RemoteHostAddress.Text = receive.Address;
                txt_RemotePassword.Text = receive.Password;
                txt_RemoteUser.Text = receive.User;

                //初始化数据库连接参数
                Variable.SqlServer.DataSource = receive.Address;
                Variable.SqlServer.UserId = receive.User;
                Variable.SqlServer.Password = receive.Password;
                Variable.SqlServer.Timeout = 10;
            }
        }

        bool opened = false;
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_RemoteDatabase.Text) || string.IsNullOrEmpty(txt_RemoteHostAddress.Text) || string.IsNullOrEmpty(txt_RemoteUser.Text
                ) || string.IsNullOrEmpty(txt_RemotePassword.Text))
            {
                MessageBox.Show("请检查数据库服务器名称、数据库名称、用户名、密码是否为空！");
                return;
            }
            if (!opened)
            {
                //初始化数据库连接参数
                Variable.SqlServer.DataSource = txt_RemoteHostAddress.Text;
                Variable.SqlServer.UserId = txt_RemoteUser.Text;
                Variable.SqlServer.Password = txt_RemotePassword.Text;
                Variable.SqlServer.Timeout = 10;
                //测试连接数据库
                opened = Variable.SqlServer.Connection(txt_RemoteDatabase.Text.Trim());
                if (opened)
                {
                    btn_Connect.Text = "断开";
                    btn_Save.Enabled = true;
                    MessageBox.Show("连接数据库成功");
                }
                else
                {
                    MessageBox.Show("连接数据库失败，请检查输入是否有误！");
                }
            }
            else if (btn_Save.Enabled)
            {
                opened = false;
                btn_Connect.Text = "连接";
                btn_Save.Enabled = false;
                MessageBox.Show("连接数据库失败，请检查输入是否有误！");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Variable.RemoteData = new ConnectData()
            {
                DataBase = txt_RemoteDatabase.Text,
                Address = txt_RemoteHostAddress.Text,
                Password = txt_RemotePassword.Text,
                User = txt_RemoteUser.Text,
            };
            ini.Serialize(GlobalPath.SavePath.IniPath, Variable.RemoteData);
            MessageBox.Show("数据库中数据库存在，数据表名正确！");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
