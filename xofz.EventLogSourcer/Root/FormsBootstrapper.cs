namespace xofz.EventLogSourcer.Root
{
    using System.Threading;
    using System.Windows.Forms;
    using xofz.EventLogSourcer.Presentation;
    using xofz.EventLogSourcer.Root.Commands;
    using xofz.EventLogSourcer.UI.Forms;
    using xofz.Root;
    using xofz.UI.Forms;

    public class FormsBootstrapper
    {
        public FormsBootstrapper()
            : this(new CommandExecutor())
        {
        }

        public FormsBootstrapper(
            CommandExecutor executor)
        {
            this.executor = executor;
        }

        public virtual Form MainForm => this.mainForm;

        public virtual void Bootstrap()
        {
            if (Interlocked.CompareExchange(
                    ref this.bootstrappedIf1,
                    1,
                    0) == 1)
            {
                return;
            }

            this.setMainForm(new ShellForm());
            var shell = this.mainForm;
            var e = this.executor;
            e.Execute(new SetupMethodWebCommand());
            var w = e.Get<SetupMethodWebCommand>().Web;
            w.RegisterDependency(
                new FormsMessenger
                {
                    Subscriber = shell
                });

            new HomePresenter(
                    shell,
                    w)
                .Setup();
        }

        private void setMainForm(ShellForm mainForm)
        {
            this.mainForm = mainForm;
        }

        private int bootstrappedIf1;
        private ShellForm mainForm;
        private readonly CommandExecutor executor;
    }
}
