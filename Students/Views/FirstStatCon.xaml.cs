using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for FirstStatCon.xaml
    /// </summary>
    public partial class FirstStatCon : UserControl
    {
       
        public FirstStatCon()
        {
            InitializeComponent();
            SecondSeriesCollection = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "المعدلات",
                    Values = new ChartValues<double> {80.5 , 84 , 78, 85 , 90},
                    PointGeometry = null
                }

            };
            LabelsTrans = new[]
            {
                "الاولى", "الثانية", "الثالثة", "الرابعة", "الخامسة",
            };

            //YFormatter = value => value.ToString("N1");

            DataContext = this;
      
    }
        public SeriesCollection SecondSeriesCollection { get; set; }
        public string[] LabelsTrans { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
