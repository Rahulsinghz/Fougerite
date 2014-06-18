﻿namespace RustPP.Commands
{
    using Zumwalt;
    using RustPP;
    using System;

    public class LoadoutCommand : ChatCommand
    {
        public override void Execute(ref ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
        {
            try
            {
                for (int i = 1; i < int.Parse(Core.config.GetSetting("AdminLoadout", "items") + 1); i++)
                {
                    Arguments.Args = new string[] { Core.config.GetSetting("AdminLoadout", "item" + i + "_name"), Core.config.GetSetting("AdminLoadout", "item" + i + "_amount") };
                    inv.give(ref Arguments);
                }
            }
            catch (Exception)
            {
            }
            Util.sayUser(Arguments.argUser.networkPlayer, "You have spawned an Admin Loadout!");
        }
    }
}

