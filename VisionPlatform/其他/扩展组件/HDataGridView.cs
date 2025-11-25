/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：HiDataGridView
* 机器名称：HLZN
* 命名空间：Hi.RL.DTM.UC.Component
* 文 件 名：HiDataGridView
* 创建时间：2022/6/8 10:32:50
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2022  保留所有权利.
***********************************************************/
using Hi.Ltd;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using VisionPlatform.Tables;
using static VisionPlatform.Properties.Resources;

namespace VisionPlatform.Auxiliary
{
    public class HDataGridView : DataGridView
    {
        private readonly SynchronizationContext context;
        public HDataGridView() : base()
        {
            context = SynchronizationContext.Current;
            //设置DGV_DataShow控件的SelectionMode属性，使控件能够整行选择
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //设置DGV_DataShow控件的DefaultCellStyle.SelectionBackColor属性，使其选择行为黄绿色
            //DefaultCellStyle.SelectionBackcolor =systemcolors.control;
            //是否自动创建列
            AutoGenerateColumns = false;
            //同时可以显示横滚动条和竖直滚动条
            ScrollBars = ScrollBars.Both;
            //自动填充列数
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            //
            RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //设置字体大小
            DefaultCellStyle.Font = new Font("黑体", 4);
            //设置所有行高度
            RowTemplate.Height = 45;
            //所有单元格的内容的位置
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadersHeight = 40;
            #region<!--设置标题头的颜色字体及大小-->
            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,  /*设置列标题单元格内容的位置*/
                BackColor = SystemColors.ActiveCaptionText,  /*设置列标题单元格背景颜色*/
                Font = new Font("黑体", 3),  /*设置列标题单元格文本字体*/
                ForeColor = Color.Black,  /*设置列标题单元格文本颜色*/
                SelectionBackColor = SystemColors.Highlight,  /*设置列选中时背景颜色*/
                SelectionForeColor = SystemColors.HighlightText,  /*设置列选中时文本颜色*/
            };  /*定义列标题*/
            ColumnHeadersDefaultCellStyle = dgvcs;  /*设置列标题样式*/
            #endregion
            //不允许用户添加新行
            AllowUserToAddRows = false;
            //行标题不显示
            RowHeadersVisible = false;
            //不允许用户调整列宽度
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ReadOnly = true;
        }
        public void InitRubberTable()
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    context?.Post(x =>
                    {
                        if (x is HDataGridView view)
                        {
                            ProduceInfo produce = new ProduceInfo();
                            view.DataSource = null;
                            view.Columns.Clear();
                            var count = produce.GetDescriptions().Length;
                            for (var i = 0; i < count; i++)
                            {
                                Columns.Add(new DataGridViewTextBoxColumn { HeaderText = produce.GetDescriptions()[i], Name = produce.GetNames()[i], DataPropertyName = produce.GetNames()[i], ValueType = produce.GetTypes()[i], ReadOnly = true });
                            }
                            Columns[0].Width = 30;
                            Columns[1].Width = 80;
                            Columns[2].Width = 80;
                            Columns[3].Width = 80;
                            Columns[4].Width = 30;
                            Columns[5].Width = 30;
                            Columns[6].Width = 30;
                            Columns[7].Width = 150;
                            Columns[8].Width = 150;
                            Columns[9].Width = 150;
                            Columns[10].Width = 150;
                            Columns[11].Width = 150;
                            Columns[12].Width = 150;
                            Columns[13].Width = 150;
                            Columns[14].Width = 150;
                            Columns[15].Width = 150;
                            Columns[16].Width = 150;
                            Columns[17].Width = 150;
                            Columns[18].Width = 150;
                            Columns[19].Width = 30;
                            Columns[20].Width = 30;
                            Columns[21].Width = 30;

                            view.Refresh();
                        }
                    }, this);
                }
                else
                {
                    ProduceInfo produce = new ProduceInfo();
                    DataSource = null;
                    Columns.Clear();
                    var count = produce.GetDescriptions().Length;
                    for (var i=0;i< count;i++)
                    {
                        Columns.Add(new DataGridViewTextBoxColumn { HeaderText = produce.GetDescriptions()[i], Name = produce.GetNames()[i], DataPropertyName = produce.GetNames()[i], ValueType = produce.GetTypes()[i], ReadOnly = true });
                    }
                    Columns[0].Width = 30;
                    Columns[1].Width = 80;
                    Columns[2].Width = 80;
                    Columns[3].Width = 80;
                    Columns[4].Width = 30;
                    Columns[5].Width = 30;
                    Columns[6].Width = 30;
                    Columns[7].Width = 150;
                    Columns[8].Width = 150;
                    Columns[9].Width = 150;
                    Columns[10].Width = 150;
                    Columns[11].Width = 150;
                    Columns[12].Width = 150;
                    Columns[13].Width = 150;
                    Columns[14].Width = 150;
                    Columns[15].Width = 150;
                    Columns[16].Width = 150;
                    Columns[17].Width = 150;
                    Columns[18].Width = 150;
                    Columns[19].Width = 30;
                    Columns[20].Width = 30;
                    Columns[21].Width = 30;
                    Refresh();
                }
            }
        }
        //public void InitContentTable()
        //{
        //    if (IsHandleCreated)
        //    {
        //        if (InvokeRequired)
        //        {
        //            context?.Post(x =>
        //            {
        //                if (x is HDataGridView view)
        //                {
        //                    view.DataSource = null;
        //                    view.Columns.Clear();
        //                    view.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.Id.Description(), Name = ContentIndex.Id.ToString(), DataPropertyName = ContentIndex.Id.ToString(), ValueType = typeof(int), ReadOnly = true });
        //                    view.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.ContentId.Description(), Name = ContentIndex.ContentId.ToString(), DataPropertyName = ContentIndex.ContentId.ToString(), ValueType = typeof(DateTime), Visible = false });
        //                    view.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.DistanceLeft.Description(), Name = ContentIndex.DistanceLeft.ToString(), DataPropertyName = ContentIndex.DistanceLeft.ToString(), ValueType = typeof(double) });
        //                    view.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.DistanceRight.Description(), Name = ContentIndex.DistanceRight.ToString(), DataPropertyName = ContentIndex.DistanceRight.ToString(), ValueType = typeof(double) });
        //                    view.Columns[(int)ContentIndex.Id].Width = 80;
        //                    view.Columns[(int)ContentIndex.DistanceLeft].Width = 300;
        //                    view.Columns[(int)ContentIndex.DistanceRight].Width = 300;
        //                    view.Columns[(int)ContentIndex.DistanceLeft].DefaultCellStyle.Format = "0.00";
        //                    view.Columns[(int)ContentIndex.DistanceRight].DefaultCellStyle.Format = "0.00";
        //                    view.Refresh();
        //                }
        //            }, this);
        //        }
        //        else
        //        {
        //            DataSource = null;
        //            Columns.Clear();

        //            Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.Id.Description(), Name = ContentIndex.Id.ToString(), DataPropertyName = ContentIndex.Id.ToString(), ValueType = typeof(int), ReadOnly = true });
        //            Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.ContentId.Description(), Name = ContentIndex.ContentId.ToString(), DataPropertyName = ContentIndex.ContentId.ToString(), ValueType = typeof(DateTime), Visible = false });
        //            Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.DistanceLeft.Description(), Name = ContentIndex.DistanceLeft.ToString(), DataPropertyName = ContentIndex.DistanceLeft.ToString(), ValueType = typeof(double) });
        //            Columns.Add(new DataGridViewTextBoxColumn { HeaderText = ContentIndex.DistanceRight.Description(), Name = ContentIndex.DistanceRight.ToString(), DataPropertyName = ContentIndex.DistanceRight.ToString(), ValueType = typeof(double) });
        //            Columns[(int)ContentIndex.Id].Width = 80;
        //            Columns[(int)ContentIndex.DistanceLeft].Width = 300;
        //            Columns[(int)ContentIndex.DistanceRight].Width = 300;
        //            Columns[(int)ContentIndex.DistanceLeft].DefaultCellStyle.Format = "0.00";
        //            Columns[(int)ContentIndex.DistanceRight].DefaultCellStyle.Format = "0.00";
        //            Refresh();
        //        }
        //    }
        //}

        //public void BindingDataSource(List<ContentTable> contents)
        //{
        //    if (IsHandleCreated)
        //    {
        //        context?.Post(x =>
        //        {
        //            if (x is DataGridView data)
        //            {
        //                data.DataSource = null;
        //                data.Rows.Clear();
        //                foreach (var content in contents)
        //                {
        //                    content.Id = data.Rows.Count + 1;
        //                    var item = content.ToArray();
        //                    data.Rows.Add(item);
        //                }
        //                data.Refresh();
        //            }
        //        }, this);
        //    }
        //    else
        //    {
        //        DataSource = null;
        //        Rows.Clear();
        //        foreach (var content in contents)
        //        {
        //            content.Id = Rows.Count + 1;
        //            var item = content.ToArray();
        //            Rows.Add(item);
        //        }
        //        Refresh();
        //    }
        //}


        public void BindingDataSource(List<ProduceInfo > contents)
        {
            if (IsHandleCreated)
            {
                context?.Post(x =>
                {
                    if (x is DataGridView data)
                    {
                        data.DataSource = null;
                        data.Rows.Clear();
                        foreach (var content in contents)
                        {
                           content.Id = data.Rows.Count + 1;
                            var item = content.ToArray();
                            data.Rows.Add(item);
                        }
                        data.Refresh();
                    }
                }, this);
            }
            else
            {
                DataSource = null;
                Rows.Clear();
                foreach (var content in contents)
                {
                    //content.Id = Rows.Count + 1;
                    //var item = content.ToArray();
                    //Rows.Add(item);
                }
                Refresh();
            }
        }

    }
}
