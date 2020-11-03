using Autofac;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beeper.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ////var dateipfad = @"C:\Users\rulan\source\repos\Beeper\Beeper.ConsolenBeep\bin\Debug\Beeper.ConsolenBeep.dll";
            var dateipfad = @"C:\Users\rulan\source\repos\Beeper\Beeper.SystemBeep\bin\Debug\Beeper.SystemBeep.dll";
            var ass = Assembly.LoadFrom(dateipfad);

            #region mit AutoFac

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(ass).Where(x => typeof(IBeep).IsAssignableFrom(x)).As<IBeep>();

            var container = builder.Build();


            Beeper = container.Resolve<IBeep>();

            #endregion


            #region IoC Dependency Injection by Hand


            //foreach (var item in ass.GetTypes())
            //{
            //    Debug.WriteLine(item.Name);
            //}

            ////ersten type der das IBeeper interface implementiert
            //var beeperType = ass.GetTypes().FirstOrDefault(x => typeof(IBeep).IsAssignableFrom(x));

            //Beeper = Activator.CreateInstance(beeperType) as IBeep;

            #endregion
            //Beeper = new ConsolenBeeper();
        }

        public IBeep Beeper { get; private set; }

        private void BeepClick(object sender, RoutedEventArgs e)
        {
            Beeper.Beep();
        }
    }
}
