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
    /// Interaction logic for ElementCon.xaml
    /// </summary>
    public partial class ElementCon : UserControl
    {
        private StudentCon StudentCon;
        private SubjectCon SubjectCon;
        
        public ElementCon()
        {
            InitializeComponent();
           

            StudentCon = new StudentCon();
            MyGrid.Children.Add(StudentCon);
            var bc = new BrushConverter();
            StudentCard.Background = (Brush) bc.ConvertFrom("#ff80ab");

        }

        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void StudentCard_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           StudentCon = new StudentCon();
            MyGrid.Children.Add(StudentCon);
            var bc = new BrushConverter();
            StudentCard.Background = (Brush)bc.ConvertFrom("#ff80ab");
           
            SubjectCart.Background = Brushes.LightPink;
        }

        private void SubjectCart_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
          SubjectCon = new SubjectCon();
            MyGrid.Children.Add(SubjectCon);
            StudentCard.Background = Brushes.LightPink;
            var bc = new BrushConverter();
            SubjectCart.Background = (Brush)bc.ConvertFrom("#ff80ab");
            
        }
    }
}
