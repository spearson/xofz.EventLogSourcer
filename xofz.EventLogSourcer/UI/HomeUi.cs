namespace xofz.EventLogSourcer.UI
{
    using System;
    using xofz.UI;

    public interface HomeUi : ShowableUi
    {
        event Action CreateSourceKeyTapped;

        event Action DeleteSourceKeyTapped;

        string LogName { get; set; }

        string SourceName { get; set; }

        void FocusAndSelectSourceInput();

        void FocusAndSelectLogInput();
    }
}
