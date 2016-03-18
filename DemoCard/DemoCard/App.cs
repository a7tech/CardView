using Autofac;
using DemoCard.Services;
using DemoCard.ViewModels;
using DemoCard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DemoCard
{
    public class App : Application
    {
        private static IContainer _container;
        private static NavigationService NaviService;
        public App()
        {


            AppSetup appSetup = new AppSetup();
            _container = appSetup.CreateContainer();
            NaviService = _container.Resolve<INavigationService>() as NavigationService;
            // The root page of your application
            
          
            MainPage = new NavigationPage(new CardDataListView());

        }

        #region View Models
        public static CardViewModel MyDealsViewModel
        {
            get
            {
                return
                _container.Resolve<CardViewModel>();
            }
        }
        #endregion
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
