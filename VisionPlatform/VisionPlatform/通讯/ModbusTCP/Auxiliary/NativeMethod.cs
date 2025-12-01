using Hi.Ltd;
using Hi.Ltd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionPlatform.Auxiliary.Constant;
namespace VisionPlatform.Auxiliary
{
    public static  class NativeMethod
    {
        #region<!--BindDataSource:将枚举的描述信息和枚举值存入链表中-->
        /// <summary>
        /// 将枚举的描述信息和枚举值存入链表中
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="comboBox">目标下拉框控件</param>
        public static void DataSource<T>(this ComboBox comboBox) where T : Enum
        {
            IList<ComboBoxItem> items = new List<ComboBoxItem>();
            Array array = Enum.GetValues(typeof(T));
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var ms = (T)Enum.Parse(typeof(T), array.GetValue(i).ToString());
                    items.Add(new ComboBoxItem { Text = ms.ToDescription(), Value = array.GetValue(i).ToString() });
                }
            }
            comboBox.DataSource = items;
            comboBox.DisplayMember = DISPLAY_MEMBER;
            comboBox.ValueMember = VALUE_MEMBER;
        }
        public static void DataSource<T>(this DataGridViewComboBoxCell comboBox) where T : Enum
        {
            IList<ComboBoxItem> items = new List<ComboBoxItem>();
            Array array = Enum.GetValues(typeof(T));
            if (array.Length > 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    var ms = (T)Enum.Parse(typeof(T), array.GetValue(i).ToString());
                    items.Add(new ComboBoxItem { Text = ms.ToDescription(), Value = array.GetValue(i).ToString() });
                }
            }
            comboBox.DataSource = items;
            comboBox.DisplayMember = DISPLAY_MEMBER;
            comboBox.ValueMember = VALUE_MEMBER;
        }
        public static void DataSource(this ComboBox comboBox, Dictionary<string, string> source)
        {
            IList<ComboBoxItem> items = new List<ComboBoxItem>();
            if (source.Count > 0)
            {

                foreach (var item in source)
                {
                    items.Add(new ComboBoxItem { Text = item.Key + ASCII.CLN + item.Value, Value = item.Key });
                }
            }
            comboBox.DataSource = items;
            comboBox.DisplayMember = DISPLAY_MEMBER;
            comboBox.ValueMember = VALUE_MEMBER;
        }
        #endregion

    }
}
