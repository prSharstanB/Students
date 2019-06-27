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

namespace Students.Views
{
    /// <summary>
    /// Interaction logic for OperationsCon.xaml
    /// </summary>
    public partial class OperationsCon : UserControl
    {
        private RegesterCon RegesterCon;
        private IntroductiveCon IntroductiveCon;
        public OperationsCon()
        {
            InitializeComponent();
            RegesterCon = new RegesterCon();
            MyGrid.Children.Add(RegesterCon);
           
            var bc = new BrushConverter();
            RegesterCard.Background = (Brush)bc.ConvertFrom("#ff80ab");
        }

        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void RegesterCard_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
         RegesterCon = new RegesterCon();
            MyGrid.Children.Add(RegesterCon);
            var bc = new BrushConverter();
            RegesterCard.Background = (Brush)bc.ConvertFrom("#ff80ab");
            IntroCart.Background = Brushes.LightPink;

        }

        private void IntroCart_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           IntroductiveCon = new IntroductiveCon();
            MyGrid.Children.Add(IntroductiveCon);
            var bc = new BrushConverter();
            IntroCart.Background = (Brush)bc.ConvertFrom("#ff80ab");
            RegesterCard.Background = Brushes.LightPink;
        }
    }
}
