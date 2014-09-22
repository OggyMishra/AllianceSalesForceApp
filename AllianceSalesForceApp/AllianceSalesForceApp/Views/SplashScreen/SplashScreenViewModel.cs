using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianceSalesForceApp.Views.SplashScreen
{
    public interface ISplashScreenViewModel
    {
        string ShowSplashScreen();
    }

    class SplashScreenViewModel:ISplashScreenViewModel
    {
        public string ShowSplashScreen()
        {
            return "Test";
        }
    }
}
