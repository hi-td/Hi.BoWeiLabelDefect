using Hi.Ltd;
using Newtonsoft.Json;
//using Mewtocol;
using StaticFun;
using System;
using System.IO;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormSaveGlobalData : Form
    {
        string selectFile;
        Label labelNowModel;
        Label labelNowModel1;
        public FormSaveGlobalData(Label labelSerialName, Label labelSerialName1)
        {
            InitializeComponent();
            labelNowModel = labelSerialName;
            labelNowModel1 = labelSerialName1;
            StaticFun.LoadConfig.LoadJsonData(this.listView1);
        }

        private void but_SaveGlobalData_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileName = textBox_SerialDataName.Text.Trim().Replace("\r\n", "-");
                if ("" == strFileName)
                {
                    MessageFun.ShowMessage("请输入要保存的文件名称。", strEnglish: "Please enter the name of the file you want to save.");
                    return;
                }
                //if(strFileName.Contains("\r\n") || strFileName.Contains(" "))
                //{
                //    MessageBox.Show("文件名跨行或有空格，请重新输入。");
                //    return;
                //}
                //保存最新的序列化文件名称
                System.IO.File.WriteAllText(GlobalPath.SavePath.NewestFile, JsonConvert.SerializeObject(strFileName));
                //保存路径 + 序列化文件名称
                string savePath = GlobalPath.SavePath.GlobalDataPath;
                string save = savePath + strFileName + ".json";
                //判断是否已经存在相同的文件名称
                if (System.IO.File.Exists(save))
                {
                    DialogResult dr = DialogResult.OK;
                    if (GlobalData.Config._language == EnumData.Language.english)
                    {
                        dr = MessageBox.Show("The file already exists, do you want to overwrite it?", "Tips:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    else
                    {
                        dr = MessageBox.Show("文件已经存在，是否重盖？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }

                    if (dr != DialogResult.OK)
                    {
                        return;
                    }
                }
                //将模板图片移动到新建的json文件目录下
                MoveFiles(GlobalPath.SavePath.ModelImagePath, strFileName);
                //将模板移动到新建的json文件目录下
                MoveFiles(GlobalPath.SavePath.ModelPath, strFileName);
                //C#对象转Json
                var json = JsonConvert.SerializeObject(DataSerializer._globalData);
                System.IO.File.WriteAllText(save, json);
                StaticFun.LoadConfig.LoadJsonData(this.listView1);
                labelNowModel.Text = strFileName;
                labelNowModel1.Text = strFileName;
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    MessageBox.Show("Save successful!", "Tips:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        //将模板相关文件移动到新建立的json名称文件目录下
        private void MoveFiles(string destFilesPath, string fileName)
        {
            try
            {

                string newPath = System.IO.Path.Combine(destFilesPath, fileName);
                bool pathExists = System.IO.Directory.Exists(newPath);
                if (!pathExists)
                {
                    Directory.CreateDirectory(newPath);
                }
                DirectoryInfo theFolder = new DirectoryInfo(destFilesPath);
                DirectoryInfo[] fileInfo = theFolder.GetDirectories();
                if (0 == fileInfo.Length)
                {
                    MessageFun.ShowMessage("无模板文件，请先示教", strEnglish: "No template file, please teach first");
                    return;
                }
                DirectoryInfo theFolder1 = new DirectoryInfo(newPath);
                foreach (DirectoryInfo NextFile in fileInfo) //遍历文件
                {
                    bool bflag = true;
                    if (NextFile.Name.Contains("相机") || NextFile.Name.Contains("Camera"))
                    {
                        foreach (DirectoryInfo NextFile1 in theFolder1.GetDirectories()) //遍历文件
                        {
                            DirectoryInfo thFolder2 = new DirectoryInfo(Path.Combine(destFilesPath, NextFile.Name));
                            if (NextFile1.Name.Contains(NextFile.Name))
                            {
                                foreach (FileInfo fileInfo1 in thFolder2.GetFiles())
                                {
                                    File.Copy(Path.Combine(Path.Combine(destFilesPath, NextFile.Name), fileInfo1.Name), Path.Combine(newPath, Path.Combine(NextFile.Name, fileInfo1.Name)), true);
                                }
                                NextFile.Delete(true);
                                bflag = false;
                                break;
                            }
                        }
                        if (bflag)
                        {
                            Directory.Move(Path.Combine(destFilesPath, NextFile.Name), Path.Combine(newPath, NextFile.Name));
                        }
                        //break;
                    }
                }
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = listView1.SelectedItems[0].SubItems[1].Text;
                textBox_SerialDataName.Text = str;
                selectFile = str;
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticFun.DelectData.DelectJsonFile(selectFile, this.listView1);
        }
    }
}
