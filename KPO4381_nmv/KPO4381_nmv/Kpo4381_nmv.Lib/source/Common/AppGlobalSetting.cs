﻿
using Kpo4381_nmv.Lib;
using Kpo4381_nmv.Utility;
namespace Kpo4381_nmv.Lib
{
    public static class AppGlobalSetting
    {
        private static string _logPath;
        private static string _dataFileName; // = "Cars.txt"; //Для теста 5
        private static string _dataFileName2;
        private static ICarFactory _factory;
        public static string logPath { get { return _logPath; } }
        public static string dataFileName { get { return _dataFileName; } }
        public static string dataFileName2 { get { return _dataFileName2; } }
        public static ICarFactory factory { get { return _factory; } }

        public static void Initialize()
        {
            AppConfigUtility conf = new AppConfigUtility();
            _logPath = conf.AppSettings("logPath");
            _dataFileName = conf.AppSettings("dataFileName");
            _dataFileName2 = conf.AppSettings("dataFileName2");

            if (conf.AppSettings("factory") == "Test") _factory = new CarTestFactory();
            if (conf.AppSettings("factory") == "Loader") _factory = new CarSplitFileFactory();
        }
    }
}