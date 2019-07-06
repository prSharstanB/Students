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
    /// Interaction logic for StatCon.xaml
    /// </summary>
    public partial class StatCon : UserControl
    {
        private FirstStatCon FirstStatCon;
        public StatCon()
        {
            InitializeComponent();
            FirstStatCon = new FirstStatCon();
            myGrid.Children.Add(FirstStatCon);
        }

        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Btnleft_OnClick(object sender, RoutedEventArgs e)
        {
           FirstStatCon = new FirstStatCon();
            myGrid.Children.Add(FirstStatCon);
            var bc = new BrushConverter();
            Btnleft.Background = (Brush)bc.ConvertFrom("#ff80ab");
            BtnRight.Background = Brushes.LightPink;
        }


        private void BtnRight_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
