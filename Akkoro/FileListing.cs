using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akkoro
{
    public partial class FileListing : Panel
    {
        private static int _lastInternalID = 1;

        public int ListingIndex { get; private set; }

        public FileListing()
        {
            ListingIndex = _lastInternalID++;

            InitializeComponent();
            ApplyStyling();
            ConstructChildComponents();
        }

        private void ApplyStyling()
        {
            Size = new Size(536, 34);
            Location = new Point(0, 0);
            Name = "uiFileListing" + ListingIndex;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.FromArgb(255, 224, 192);
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabIndex = 0;
        }

        private void ConstructChildComponents()
        {

        }
    }
}
