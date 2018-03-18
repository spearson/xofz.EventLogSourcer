namespace xofz.EventLogSourcer.UI.Forms
{
    using System;
    using System.Threading;
    using xofz.UI.Forms;

    public partial class ShellForm 
        : FormUi, HomeUi
    {
        public ShellForm()
        {
            this.InitializeComponent();

            var h = this.Handle;
        }

        public event Action CreateSourceKeyTapped;

        public event Action DeleteSourceKeyTapped;

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

        private void createSourceKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.CreateSourceKeyTapped?.Invoke()).Start();
        }

        private void deleteSourceKey_Click(object sender, EventArgs e)
        {
            new Thread(() => this.DeleteSourceKeyTapped?.Invoke()).Start();
        }
    }
}
