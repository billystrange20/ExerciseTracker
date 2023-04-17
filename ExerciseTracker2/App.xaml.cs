using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExerciseTracker2
{
    public partial class App : Application
    {
        private static ExDatabase exdatabase;
        private static WgtDatabase wgtdatabase;

        public static ExDatabase ExDatabase
        {
            get
            {
                if (exdatabase == null)
                {
                    exdatabase = new ExDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "exercise.db3"));
                    return exdatabase;
                }

                return exdatabase;
            }
        }

        public static WgtDatabase WgtDatabase
        {
            get
            {
                if (wgtdatabase == null)
                {
                    wgtdatabase = new WgtDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "weight.db3"));
                }

                return wgtdatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedPage1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
