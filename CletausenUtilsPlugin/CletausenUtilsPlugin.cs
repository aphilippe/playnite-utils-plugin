using Playnite.SDK;
using Playnite.SDK.Events;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace CletausenUtilsPlugin
{
    public class CletausenUtilsPlugin : GenericPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private CletausenUtilsPluginSettingsViewModel settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("9c278c87-c78b-4d77-a4d0-c53952a11563");

        public CletausenUtilsPlugin(IPlayniteAPI api) : base(api)
        {
            settings = new CletausenUtilsPluginSettingsViewModel(this);
            Properties = new GenericPluginProperties
            {
                HasSettings = true
            };

            AddConvertersSupport(new AddConvertersSupportArgs()
            {
                SourceName = "CletausenUtils",
                Converters = new List<IValueConverter>
                {
                    new CategoriesToIsDemoConverter(settings.Settings.DemoCategory)
                }
            });
        }

        public override void OnGameInstalled(OnGameInstalledEventArgs args)
        {
            // Add code to be executed when game is finished installing.
        }

        public override void OnGameStarted(OnGameStartedEventArgs args)
        {
            // Add code to be executed when game is started running.
        }

        public override void OnGameStarting(OnGameStartingEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameStopped(OnGameStoppedEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameUninstalled(OnGameUninstalledEventArgs args)
        {
            // Add code to be executed when game is uninstalled.
        }

        public override void OnApplicationStarted(OnApplicationStartedEventArgs args)
        {
            // Add code to be executed when Playnite is initialized.
        }

        public override void OnApplicationStopped(OnApplicationStoppedEventArgs args)
        {
            // Add code to be executed when Playnite is shutting down.
        }

        public override void OnLibraryUpdated(OnLibraryUpdatedEventArgs args)
        {
            // Add code to be executed when library is updated.
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new CletausenUtilsPluginSettingsView();
        }
    }
}