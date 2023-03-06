using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfAppMvvmToolkit.Core.ViewModels;

namespace WpfAppMvvmToolkit.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            this.DataContext= viewModel;

            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(""); ;        
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(""); ;
        }
    }
}
