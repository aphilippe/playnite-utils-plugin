using System;
using Playnite.SDK.Models;

namespace CletausenUtilsPlugin.ExtensionClass
{
    public static class GameExtension
    {
        public static bool IsDemo(this Game game)
        {
            var tagIds = game.TagIds;
            
            if (tagIds == null) return false;
            
            return tagIds.Contains(CletausenUtilsPlugin.Instance.Settings.DemoTagId);
        }
    }
}