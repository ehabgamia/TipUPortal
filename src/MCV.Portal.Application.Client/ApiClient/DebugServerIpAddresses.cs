﻿namespace MCV.Portal.ApiClient
{
    public static class DebugServerIpAddresses
    {
        /*
         * This field is being used for setting IP address for debugging the clients (eg: Xamarin application)
         * It's being set in
         *  - SplashActivity.cs (StartApplication method) in *.Mobile.Droid project,
         *  - AppDelegate.cs (FinishedLaunching method) in *.Mobile.iOS project.
         */
        public static string Current = LocalhostIp;// "localhost";
        private const string LocalhostIp = Emulators.Android;//"192.168.1.48";

        public static class Emulators
        {
            public const string Android = "10.0.2.2";
           
        }
    }
}