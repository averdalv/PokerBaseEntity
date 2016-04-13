using System;
using System.Collections.Generic;
using System.Linq;
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
using PokerBaseEntity.View;
using PokerBaseEntity.ViewModel;
namespace PokerBaseEntity
{
    /// <summary> 
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            GetRequestWindow wnd=new GetRequestWindow();
            wnd.DataContext=new ViewModelGetRequest();
            wnd.Show();
        }
        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            GetRequestWindow wnd=new GetRequestWindow();
            wnd.DataContext = new ViewModelGetTournaments();
            wnd.Show();
        }
    }
}
