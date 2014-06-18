﻿namespace RustPP.Commands
{
    using RustPP;
    using RustPP.Permissions;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ReloadCommand : ChatCommand
    {
        public override void Execute(ref ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
        {
            Core.LoadConfig();
            TimedEvents.startEvents();
            if (File.Exists(Helper.GetAbsoluteFilePath("admins.xml")))
            {
                Administrator.AdminList = Helper.ObjectFromXML<List<Administrator>>(Helper.GetAbsoluteFilePath("admins.xml"));
            }
            if (File.Exists(Helper.GetAbsoluteFilePath("whitelist.xml")))
            {
                Core.whiteList = new PList(Helper.ObjectFromXML<List<PList.Player>>(Helper.GetAbsoluteFilePath("whitelist.xml")));
            }
            else
            {
                Core.whiteList = new PList();
            }
            if (File.Exists(Helper.GetAbsoluteFilePath("bans.xml")))
            {
                Core.blackList = new PList(Helper.ObjectFromXML<List<PList.Player>>(Helper.GetAbsoluteFilePath("bans.xml")));
            }
            else
            {
                Core.blackList = new PList();
            }
        }
    }
}
