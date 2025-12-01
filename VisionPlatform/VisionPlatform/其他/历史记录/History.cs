using Hi.Ltd.SqlServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using VisionPlatform.Auxiliary;
using VisionPlatform.Tables;

namespace VisionPlatform.多线插.历史记录
{
    public partial class History : Form
    {
        List<ProduceInfo> Infos = new List<ProduceInfo>();
        //private List<ContentTable> contents;
        // private List<ExportData> table;
        private int _splitterDistance = 400;
        private int _initHeight = 0;
        private int _rowindex = -1;
        private int queryIndex = -1;
        private int _panelHeigt = 0;
        private int  _contentId =0;
        private string _code = string.Empty;
        public History()
        {
            InitializeComponent();
            Infos = new List<ProduceInfo>();
            //contents = new List<ContentTable>();
            //table = new List<ExportData>();
            //_panelHeigt = sc_Message.Panel2.Height;
            //_initHeight = sc_Message.Height;
            //_splitterDistance = sc_Message.SplitterDistance;

        }

        private void History_Load(object sender, EventArgs e)
        {
            dgv_Rubber.InitRubberTable();
            // dgv_Content.InitContentTable();
            dtp_Start.Value = DateTime.Today;
            dtp_End.Value = DateTime.Today;
            //sc_Message.Panel2Collapsed = true;
        }

        private void btn_Inqure_Click(object sender, EventArgs e)
        {
            var start = dtp_Start.Value;
            var end = dtp_End.Value;
            if (cb_DateTimeEnabled.Checked)
            {
                var startRub = new ProduceInfo()
                {
                    DateTime = start
                };
                var endRub = new ProduceInfo()
                {
                    DateTime = end
                };
                Infos = Variable.sqlServer.InqureTable<ProduceInfo>(startRub, endRub);
            }
            else
            {
                Infos = Variable.sqlServer.InqureTable<ProduceInfo>();
            }
            dgv_Rubber.BindingDataSource(Infos);
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            //var startDate = dateTimePicker1.Value;
            var startTime = dtp_Start.Value;
            //var endDate = dateTimePicker2.Value;
            var endTime = dtp_End.Value; 
            //获取起始查询时间
            var start = new DateTime(startTime.Year, startTime.Month, startTime.Day);
            //获取结束查询时间
            var end = new DateTime(endTime.Year, endTime.Month, endTime.Day);

            //var produceName = comboBox1.Text ?? null;

            var startConditon = new ProduceInfo()
            {
                DateTime = start,
               // Name = produceName
            };
            var endConditon = new ProduceInfo()
            {
                DateTime = end
            };
            Infos =Variable . sqlServer.InqureTable(startConditon, endConditon);
            Update();




            //var sql = SqlEntities.Create;
            //sql.InitialCatalog = "VisionPlatform";
            //var start = dtp_Start.Value;
            //var end = dtp_End.Value;
            //if (cb_DateTimeEnabled.Checked)
            //{

            //    table = sql.InqureTable(start, end);

            //}
            //else
            //{

            //    table = sql.GetExportData();

            //}
            //if (Infos?.Count <= 0)
            //{
            //    MessageBox.Show("当前无任何数据信息可以导出,请进行查询后,再进行导出操作!", "导出操作失败提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog
            {
                Title = "历史报警另存为",
                //默认文件后缀   
                DefaultExt = "csv",
                //文件后缀列表   
                Filter = "CSV 工作簿(*.csv)|*.CSV",
                //默然路径是D盘指定文件路径   
                InitialDirectory = GlobalPath.SavePath.CsvPath,
                //默认文件名
                FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"
            };

            DialogResult DR = dlg.ShowDialog();
            //打开保存对话框   
            if (DR != DialogResult.Cancel)
            {
                //返回文件路径   
                string fileNameString = dlg.FileName;

                //验证strFileName是否为空或值无效   
                if (fileNameString != string.Empty && Infos?.Count > 0)
                {
                    using (FileStream filestream = new FileStream(fileNameString, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter streamwriter = new StreamWriter(filestream, System.Text.Encoding.UTF8))
                        {
                            //文件列标题头
                            streamwriter.WriteLine(ProduceInfo .TitleHeadMessage);

                            foreach (ProduceInfo data in Infos)
                            {

                                streamwriter.WriteLine(data.ToString());

                            }
                            MessageBox.Show(fileNameString + "创建成功!", "保存文件提示");
                        }
                    }
                }
            }
        }
        //private void dgv_Rubber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (sender is not DataGridView dataGridView) return;
        //    if (e.RowIndex == -1) return;
        //    var rowindex = e.RowIndex;
        //    var columnindex = e.ColumnIndex;
        //    if (rowindex == -1 || columnindex == -1 || rowindex >= metalDomes?.Count) return;
        //    if (columnindex == (int)RubberIndex.ContentId )
        //    {
        //        if (!sc_Message.Panel2Collapsed && rowindex == _rowindex)
        //        {
        //            sc_Message.Panel2Collapsed = true;
        //            sc_Message.SplitterDistance = _splitterDistance;
        //            sc_Message.Height = _splitterDistance;
        //            //Height = _splitterDistance;
        //        }
        //        else if (sc_Message.Panel2Collapsed)
        //        {
        //            sc_Message.Panel2Collapsed = false;
        //            sc_Message.Height = _panelHeigt;
        //            // Height = _initHeight;
        //            sc_Message.SplitterDistance = _splitterDistance;
        //        }
        //    }
        //    else
        //    {
        //        if (!sc_Message.Panel2Collapsed)
        //        {
        //            sc_Message.Panel2Collapsed = true;
        //            sc_Message.SplitterDistance = _splitterDistance;
        //            sc_Message.Height = _splitterDistance;
        //            // Height = _splitterDistance;
        //        }
        //    }
        //    //if (_rowindex != rowindex)
        //    //{
        //       // sql.DataTable = "ContentTable";
        //    //    _contentId = metalDomes[rowindex].ContentId;
        //    //    _code = metalDomes[rowindex].ContentId ;
        //    //    txt_Code.Text = _code;
        //    //    //var contents = sql.GetContentTables(_contentId);
        //    //    //dgv_Content.BindingDataSource(contents);
        //    //}
        //    _rowindex = rowindex;
        //}

        private void tsmi_Delete_Click(object sender, EventArgs e)
        {
            if (_rowindex > 0 && _contentId==0 && !string.IsNullOrEmpty(_code))
            {
                var deleteRub = new ProduceInfo ()
                {
                    Id = _contentId,
                };
                Variable.SqlServer.DeleteTable<ProduceInfo>(deleteRub);
                //sql.DeleteContentData(_contentId);
                btn_Inqure_Click(null, null);
                _code = string.Empty;
                _contentId = 0;
                _rowindex = -1;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var start = dtp_Start.Value;
            var end = dtp_End.Value;
            Infos.Clear();
            if (cb_DateTimeEnabled.Checked)
            {
                //  metalDomes = sql.GetRubberTables(start, end);
            }

            if (Infos?.Count > 0)
            {

                if (cb_DateTimeEnabled.Checked)
                {
                    // sql.DeleteRubberData(start, end);
                    for (int i = 0; i < Infos.Count; i++)
                    {
                        // sql.DeleteContentData(metalDomes[i].ContentId);
                    }
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("没有可以删除的数据！");
                }
            }
            else
            {
                MessageBox.Show("没有可以删除的数据！");
            }
        }



        //private void cb_CodeEnabled_CheckedChanged(object sender, EventArgs e)
        //{

        //}
    }
}
