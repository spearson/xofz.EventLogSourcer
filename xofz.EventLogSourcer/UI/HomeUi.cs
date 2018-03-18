namespace xofz.EventLogSourcer.UI
{
    using System;
    using xofz.UI;

    public interface HomeUi : Ui
    {
        event Action CreateSourceKeyTapped;

        event Action DeleteSourceKeyTapped;

        string LogName { get; set; }

        string SourceName { get; set; }
    }
}
