namespace xofz.EventLogSourcer.UI.Forms
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using xofz.UI;
    using xofz.UI.Forms;

    public partial class ShellForm 
        : FormUi, HomeUi
    {
        public ShellForm()
        {
            this.InitializeComponent();

            this.Shown += this.this_Shown;

            var h = this.Handle;
        }

        public event Action CreateSourceKeyTapped;

        public event Action DeleteSourceKeyTapped;

        public event Action FirstShown;

        string HomeUi.LogName
        {
            get => this.logNameTextBox.Text;

            set => this.logNameTextBox.Text = value;
        }

        string HomeUi.SourceName
        {
            get => this.sourceNameTextBox.Text;

            set => this.sourceNameTextBox.Text = value;
        }

        void HomeUi.FocusAndSelectSourceInput()
        {
            this.sourceNameTextBox.Focus();
            this.sourceNameTextBox.SelectAll();
        }

        void HomeUi.FocusAndSelectLogInput()
        {
            this.logNameTextBox.Focus();
            this.logNameTextBox.SelectAll();
        }

        private void createSourceKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.CreateSourceKeyTapped?.Invoke()).Start();
        }

        private void deleteSourceKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.DeleteSourceKeyTapped?.Invoke()).Start();
        }

        private void this_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            new Thread(() => this.FirstShown?.Invoke())
                .Start();
        }

        private void sourceNameTextBox_KeyPress(
            object sender, 
            KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                new Thread(() => this.CreateSourceKeyTapped?.Invoke())
                    .Start();
            }
        }

        private void logNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                new Thread(() => this.CreateSourceKeyTapped?.Invoke())
                    .Start();
            }
        }
    }
}
