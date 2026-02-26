//using Mewtocol;
using Hi.Ltd;
using Newtonsoft.Json;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormReadGlobalData : Form
    {
        string selectFile;                   //选中的文件
        Label tsLabel_SerialName;
        Label tsLabel_SerialName1;
        public FormReadGlobalData(Label lable_SerialName, Label lable_SerialName1)
        {
            InitializeComponent();
            tsLabel_SerialName = lable_SerialName;
            tsLabel_SerialName1 = lable_SerialName1;
            StaticFun.LoadConfig.LoadJsonData(this.listView1);
        }

        private void FormReadGlobalData_Load(object sender, EventArgs e)
        {
            StaticFun.LoadConfig.LoadJsonData(this.listView1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            else
            {
                selectFile = listView1.SelectedItems[0].SubItems[1].Text;
                label_FileName.Text = selectFile;
            }
        }

        private void but_import_Click(object sender, EventArgs e)
        {
            try
            {
                //保存最新的序列化文件名称
                System.IO.File.WriteAllText(GlobalPath.SavePath.NewestFile, JsonConvert.SerializeObject(selectFile));
                StaticFun.LoadConfig.LoadTMData(selectFile);
                StaticFun.LoadConfig.LoadModelID(selectFile);
                //将导入的序列化参数名称显示到主页面
                tsLabel_SerialName.Text = selectFile;
                tsLabel_SerialName1.Text = selectFile;

                //将配方中的轴位置信息写入PLC
                List<Hi.Ltd.Data.Address> listAddress = new List<Hi.Ltd.Data.Address>();
                foreach (string addr in DataSerializer._globalData.addressList)
                {
                    //var address = Hi.Ltd.Data.Address.Deserialize(addr);
                    var address = VisionPlatform.Auxiliary.Parse.Deserialize(addr);
                    listAddress.Add(address);
                }
                try
                {
                    foreach (var addr in listAddress)
                    {
                        FormMainUI._plc.WriteDevice(addr);
                    }
                    //移动轴位置
                    FormMainUI.MoveAxises();
                }
                catch(Exception ex)
                {
                    MessageFun.ShowMessage(ex.Message);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
                MessageBox.Show(ex.Message);
            }
        }

        private void but_Delete_Click(object sender, EventArgs e)
        {
            StaticFun.DelectData.DelectJsonFile(selectFile, this.listView1);
        }
    }
}
