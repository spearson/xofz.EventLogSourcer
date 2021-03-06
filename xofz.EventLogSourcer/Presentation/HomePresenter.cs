﻿namespace xofz.EventLogSourcer.Presentation
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using xofz.EventLogSourcer.UI;
    using xofz.Framework;
    using xofz.Presentation;
    using xofz.UI;

    public sealed class HomePresenter : Presenter
    {
        public HomePresenter(
            HomeUi ui, 
            MethodWeb web) 
            : base(ui, null)
        {
            this.ui = ui;
            this.web = web;
        }

        public void Setup()
        {
            if (Interlocked.CompareExchange(ref this.setupIf1, 1, 0) == 1)
            {
                return;
            }

            UiHelpers.Write(
                this.ui,
                () => this.ui.LogName = "Application");
            this.ui.CreateSourceKeyTapped += this.ui_CreateSourceKeyTapped;
            this.ui.DeleteSourceKeyTapped += this.ui_DeleteSourceKeyTapped;
            this.ui.FirstShown += this.ui_FirstShown;
        }

        public override void Start()
        {
        }

        private void ui_CreateSourceKeyTapped()
        {
            var w = this.web;
            var logName = UiHelpers.Read(
                this.ui,
                () => this.ui.LogName);
            if (string.IsNullOrWhiteSpace(logName))
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError("Please enter a valid log name."));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectLogInput);
                return;
            }

            var sourceName = UiHelpers.Read(
                this.ui,
                () => this.ui.SourceName);
            if (string.IsNullOrWhiteSpace(sourceName))
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError(
                            "Please enter a valid source name."));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            bool alreadyExists;
            try
            {
                alreadyExists = EventLog.SourceExists(sourceName);
            }
            catch
            {
                alreadyExists = false;
            }

            if (alreadyExists)
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError(
                            "Source already exists."));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            var notReally = true;
            w.Run<Messenger>(m =>
            {
                var response = UiHelpers.Read(
                    m.Subscriber,
                    () => m.Question(
                        "Really create this source?"));
                if (response == Response.Yes)
                {
                    notReally = false;
                }
            });

            if (notReally)
            {
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            try
            {
                EventLog.CreateEventSource(
                    sourceName,
                    logName);
            }
            catch (Exception ex)
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError(
                            "Error creating source."
                            + Environment.NewLine
                            + ex.GetType()
                            + Environment.NewLine
                            + ex.Message));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            w.Run<Messenger>(m =>
            {
                UiHelpers.Write(
                    m.Subscriber,
                    () => m.Inform(
                        "Source created."));
                m.Subscriber.WriteFinished.WaitOne();
            });
            UiHelpers.Write(
                this.ui,
                this.ui.FocusAndSelectSourceInput);
        }

        private void ui_DeleteSourceKeyTapped()
        {
            var w = this.web;
            var logName = UiHelpers.Read(
                this.ui,
                () => this.ui.LogName);
            if (string.IsNullOrWhiteSpace(logName))
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError("Please enter a valid log name."));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectLogInput);
                return;
            }

            var sourceName = UiHelpers.Read(
                this.ui,
                () => this.ui.SourceName);
            if (string.IsNullOrWhiteSpace(sourceName))
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError(
                            "Please enter a valid source name."));
                    m.Subscriber.WriteFinished.WaitOne();
                });

                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);

                return;
            }

            bool doesNotExist;
            try
            {
                doesNotExist = !EventLog.SourceExists(sourceName);
            }
            catch
            {
                doesNotExist = false;
            }

            if (doesNotExist)
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError(
                            "Source does not exist."));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            var notReally = true;
            w.Run<Messenger>(m =>
            {
                var response = UiHelpers.Read(
                    m.Subscriber,
                    () => m.Question(
                        "Really delete this source?"));
                if (response == Response.Yes)
                {
                    notReally = false;
                }
            });

            if (notReally)
            {
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            try
            {
                EventLog.DeleteEventSource(
                    sourceName);
            }
            catch (Exception ex)
            {
                w.Run<Messenger>(m =>
                {
                    UiHelpers.Write(
                        m.Subscriber,
                        () => m.GiveError(
                            "Error deleting source."
                            + Environment.NewLine
                            + ex.GetType()
                            + Environment.NewLine
                            + ex.Message));
                    m.Subscriber.WriteFinished.WaitOne();
                });
                UiHelpers.Write(
                    this.ui,
                    this.ui.FocusAndSelectSourceInput);
                return;
            }

            w.Run<Messenger>(m =>
            {
                UiHelpers.Write(
                    m.Subscriber,
                    () => m.Inform(
                        "Source deleted."));
                m.Subscriber.WriteFinished.WaitOne();
            });

            UiHelpers.Write(
                this.ui,
                this.ui.FocusAndSelectSourceInput);
        }

        private void ui_FirstShown()
        {
            UiHelpers.Write(
                this.ui,
                this.ui.FocusAndSelectSourceInput);
        }

        private int setupIf1;
        private readonly HomeUi ui;
        private readonly MethodWeb web;
    }
}
