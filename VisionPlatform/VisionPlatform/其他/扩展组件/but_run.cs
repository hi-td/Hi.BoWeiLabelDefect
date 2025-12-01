using System;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class but_run : UserControl
    {
        public but_run()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
        }

        private void ButRun_Click(object sender, EventArgs e)
        {
            StaticFun.Run.LoadRun(this.butRun);
        }
    }
}
