using Playnite.SDK;
using Playnite.SDK.Events;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using CletausenUtilsPlugin.Converters;
using CletausenUtilsPlugin.ExtensionClass;
using Playnite.SDK.Models;

namespace CletausenUtilsPlugin
{
    public class CletausenUtilsPlugin : GenericPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private CletausenUtilsPluginSettingsViewModel settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("9c278c87-c78b-4d77-a4d0-c53952a11563");

        public static CletausenUtilsPlugin Instance { get; private set; }
        public CletausenUtilsPluginSettings Settings => settings.Settings;
        
        public CletausenUtilsPlugin(IPlayniteAPI api) : base(api)
        {
            Instance = this;
            
            settings = new CletausenUtilsPluginSettingsViewModel(this);
            Properties = new GenericPluginProperties
            {
                HasSettings = true
            };

            AddConvertersSupport(new AddConvertersSupportArgs
            {
                SourceName = "CletausenUtils",
                Converters = new List<IValueConverter>
                {
                    new TagsToIsDemoVisibilityConverter()
                }
            });
        }

        public override IEnumerable<GameMenuItem> GetGameMenuItems(GetGameMenuItemsArgs args)
        {
            yield return new GameMenuItem
            {
                Description = "Toggle Demo",
                Action = (a) =>
                {
                    using (PlayniteApi.Database.BufferedUpdate())
                    {
                        foreach (var game in a.Games)
                        {
                            var tagIds = game.TagIds ?? new List<Guid>();
                            
                            if (game.IsDemo())
                            {
                                tagIds.Remove(Settings.DemoTagId);
                            }
                            else
                            {
                                tagIds.Add(Settings.DemoTagId);
                            }

                            game.TagIds = tagIds;
                            PlayniteApi.Database.Games.Update(game);
                        }
                    }
                }
            };
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