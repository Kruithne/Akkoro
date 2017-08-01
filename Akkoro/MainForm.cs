using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLua;

namespace Akkoro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AddFileListing("Test1");
            AddFileListing("Test2");
        }

        private void AddFileListing(string name)
        {
            //uiFlowList.Controls.Add(new FileListing());
        }

        private void uiSelectFileButton_Click(object sender, EventArgs e)
        {
            
        }

        private void uiInnerBackdrop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
