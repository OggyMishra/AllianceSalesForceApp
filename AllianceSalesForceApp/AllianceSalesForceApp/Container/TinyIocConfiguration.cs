using AllianceSalesForceApp.Base;
using AllianceSalesForceApp.Views.SplashScreen;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianceSalesForceApp.Container
{
    /// <summary>
    /// This class is used for configuring the object for other class.
    /// 1. Create the object keeping the view of memory utilization.
    /// 2. Don't make every object as singleinstance.
    /// 3. If Possible try to make it PerRequest so that GC will automatically collect it.
    /// 
    /// </summary>

    public class TinyIocConfiguration:IMainAppConfiguration
    {
        // private static IContainer _container;
        private ContainerBuilder _containerBuilder;
        public TinyIocConfiguration()
        {
            _containerBuilder = new ContainerBuilder();
        }
       public void ConfigureForPostSplashScreen()
        {
            //Single Instance work like static object.
            _containerBuilder.RegisterType<SplashScreenViewModel>().SingleInstance().As<ISplashScreenViewModel>();

        }
    }
}
