namespace xofz.EventLogSourcer.Root.Commands
{
    using xofz.Framework;
    using xofz.Root;

    public class SetupMethodWebCommand : Command
    {
        public virtual MethodWeb Web => this.web;

        public override void Execute()
        {
            this.setWeb(new MethodWeb());
        }

        private void setWeb(MethodWeb web)
        {
            this.web = web;
        }

        private MethodWeb web;
    }
}
