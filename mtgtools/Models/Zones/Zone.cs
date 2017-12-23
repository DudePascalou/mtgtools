using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtgtools.Models.Zones
{
    public static class Zone
    {
        public static IZone BattlefieldZone { get; private set; }
        public static IZone ExileZone { get; private set; }
        public static IZone GraveyardZone { get; private set; }
        public static IZone HandZone { get; private set; }
        public static IZone LibraryZone { get; private set; }
        public static IZone OutOfTheGameZone { get; private set; }
        public static IZone StackZone { get; private set; }

        static Zone()
        {
            BattlefieldZone = new BattlefieldZone();
            ExileZone = new ExileZone();
            GraveyardZone = new GraveyardZone();
            HandZone = new HandZone();
            LibraryZone = new LibraryZone();
            OutOfTheGameZone = new OutOfTheGameZone();
            StackZone = new StackZone();
        }
    }
}