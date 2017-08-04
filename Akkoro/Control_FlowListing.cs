using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Akkoro
{
    public partial class Control_FlowListing : Panel
    {
        private static int _lastIndex = 1;

        private Panel _componentStatus;
        private Button _componentOperationButton;
        private Button _componentTerminateButton;
        private Label _componentTitleText;
        private Label _componentStatusText;

        private ScriptEnvironment _env;
        private Thread _thread;

        private bool _disposing;

        public int ListingIndex { get; private set; }
        public string FilePath { get; private set; }
        public bool IsActive { get; private set; }

        public Control_FlowListing(string path)
        {
            ListingIndex = _lastIndex++;
            FilePath = path;

            InitializeComponent();
            ApplyStyling();
            ConstructChildComponents();
        }

        private void ApplyStyling()
        {
            Location = new Point(0, 0);
            Margin = new Padding(0, 0, 0, 5);
            Name = "uiFlowListing" + ListingIndex;
            Size = new Size(689, 34);
        }

        private Button ConstructButtonComponent()
        {
            Button button = new Button();
            button.BackgroundImageLayout = ImageLayout.Center;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Size = new Size(31, 34);
            button.Cursor = Cursors.Hand;
            return button;
        }

        private Label ConstructLabelComponent()
        {
            Label label = new Label();
            label.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.BackColor = Color.Transparent;
            return label;
        }

        private void ConstructChildComponents()
        {
            // Component: Status display.
            _componentStatus = new Panel();
            _componentStatus.BackgroundImage = Properties.Resources.listing_backdrop;
            _componentStatus.BackgroundImageLayout = ImageLayout.Center;
            _componentStatus.Location = new Point(0, 0);
            _componentStatus.Margin = new Padding(0, 0, 0, 5);
            _componentStatus.Name = Name + "_statusComponent";
            _componentStatus.Size = new Size(620, 34);

            // Component: Title text
            _componentTitleText = ConstructLabelComponent();
            _componentTitleText.AutoSize = true;
            _componentTitleText.Name = Name + "_titleTextComponent";
            _componentTitleText.Location = new Point(8, 8);
            _componentTitleText.Size = new Size(165, 18);
            _componentTitleText.Text = Path.GetFileNameWithoutExtension(FilePath);

            // Component: Status Text
            _componentStatusText = ConstructLabelComponent();
            _componentStatusText.AutoSize = false;
            _componentStatusText.Anchor = AnchorStyles.Right;
            _componentStatusText.TextAlign = ContentAlignment.MiddleRight;
            _componentStatusText.Name = Name + "_statusTextComponent";
            _componentStatusText.Location = new Point(168, 0);
            _componentStatusText.Size = new Size(449, 34);

            // Component: Operation button.
            _componentOperationButton = ConstructButtonComponent();
            _componentOperationButton.BackgroundImage = Properties.Resources.listing_button_start;
            _componentOperationButton.Name = Name + "_operationButtonComponent";
            _componentOperationButton.Location = new Point(623, 0);
            _componentOperationButton.MouseClick += OnOperationButtonClick;

            // Component: Terminate button.
            _componentTerminateButton = ConstructButtonComponent();
            _componentTerminateButton.BackgroundImage = Properties.Resources.listing_button_close;
            _componentTerminateButton.Name = Name + "_terminateButtonComponent";
            _componentTerminateButton.Location = new Point(657, 0);
            _componentTerminateButton.MouseClick += OnTerminateButtonClick;

            // Add top-level controls into the status panel.
            _componentStatus.Controls.Add(_componentTitleText);
            _componentStatus.Controls.Add(_componentStatusText);

            // Add components to this control.
            Controls.Add(_componentStatus);
            Controls.Add(_componentOperationButton);
            Controls.Add(_componentTerminateButton);
        }

        public void SetScriptName(string name)
        {
            _componentTitleText.InvokeIfRequired(c => { c.Text = name; });
        }

        public void SetStatusText(string text)
        {
            _componentStatusText.InvokeIfRequired(c => { c.Text = text; });
        }

        public void EnableScript()
        {
            IsActive = true;
            SetStatusText("Active");
            _componentStatus.InvokeIfRequired(c => { c.BackgroundImage = Properties.Resources.listing_backdrop_active; });
            _componentOperationButton.InvokeIfRequired(c => { c.BackgroundImage = Properties.Resources.listing_button_stop; });
        }

        public void DisableScript()
        {
            IsActive = false;
            SetStatusText("Stopped");
            _componentStatus.InvokeIfRequired(c => { c.BackgroundImage = Properties.Resources.listing_backdrop; });
            _componentOperationButton.InvokeIfRequired(c => { c.BackgroundImage = Properties.Resources.listing_button_start; });

            if (_env != null)
                _env.Flush();

            _env = null;
            _thread = null;

            if (_disposing)
                this.InvokeIfRequired(c => { c.Dispose(); });
        }

        private void BeginTermination()
        {
            SetStatusText("Stopping...");

            if (_thread != null)
                new TerminationThread(_thread, this).Begin();
            else
                DisableScript();
        }

        private void OnOperationButtonClick(object sender, MouseEventArgs e)
        {
            if (!IsActive)
            {
                _env = new ScriptEnvironment(this);
                _thread = new Thread(_env.Activate);
                
                _thread.Start();
            }
            else
            {
                BeginTermination();
            }
        }

        private void OnTerminateButtonClick(object sender, MouseEventArgs e)
        {
            _disposing = true;
            BeginTermination();
        }
    }
}
