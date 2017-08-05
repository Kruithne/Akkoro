using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akkoro
{
    public partial class MainForm : Form
    {
        private bool _isMouseDown;
        private Point _mouseDownLocation;

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddListing(string path)
        {
            uiFlow.Controls.Add(new Control_FlowListing(path));
            uiEmptyPrompt.Hide();
        }

        private void uiCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uiMinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void uiHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _mouseDownLocation = e.Location;
        }

        private void uiHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void uiHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseDown)
                return;

            Location = new Point((Location.X - _mouseDownLocation.X) + e.X, (Location.Y - _mouseDownLocation.Y) + e.Y);
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dialogOpenFile.ShowDialog();
        }

        private void dialogOpenFile_FileOk(object sender, CancelEventArgs e)
        {
            AddListing(dialogOpenFile.FileName);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Signal for all controls to drop their threads.
            foreach (Control control in uiFlow.Controls)
                if (control is Control_FlowListing)
                    ((Control_FlowListing)control).TerminateScript();

            // Trigger application termination.
            Application.Exit();
        }
    }
}
