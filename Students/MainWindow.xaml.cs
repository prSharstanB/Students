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
using Students.Views;

namespace Students
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainCon MainCon;
        private ElementCon ElementCon;
        private OperationsCon OperationsCon;
        private StatCon StatCon;
        public MainWindow()
        {
            InitializeComponent();
            MainCon = new MainCon();
          
            MyGrid.Children.Add(MainCon);

            SeriesCollection = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "المعدلات ",
                    Values = new ChartValues<double> {1, 8, 3, 12, 11, 2, 7, 8, 9, 10, 5, 4},
                    PointGeometry = null
                },

            };
            Labels = new[]
            {
                "كانون الثاني", "شباط", "آذار", "نيسان", "ايار",
                "حزيران",
                "تموز",
                "أب",
                "أيلول",
                "تشرين الاول",
                "تشرين الثاني",
                "كانون الاول"
            };



            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    



private void LabelMain_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Label1_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void ElementCard_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ElementCon = new ElementCon();
          
            MyGrid.Children.Add(ElementCon);
            var bc = new BrushConverter();
            ElementCard.Background = (Brush)bc.ConvertFrom("#ff80ab");
            OpCard.Background = Brushes.LightPink;
            StatCard.Background = Brushes.LightPink;
        }

        private void BtnHome_OnClick(object sender, RoutedEventArgs e)
        {
            MainCon = new MainCon();
          
            MyGrid.Children.Add(MainCon);
            

        }

        private void OpCard_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
           OperationsCon = new OperationsCon();
            MyGrid.Children.Add(OperationsCon);
            ElementCard.Background = Brushes.LightPink;
            StatCard.Background = Brushes.LightPink;
            var bc = new BrushConverter();
            OpCard.Background = (Brush)bc.ConvertFrom("#ff80ab");


        }

        private void StatCart_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            StatCon = new StatCon();
            MyGrid.Children.Add(StatCon);
            ElementCard.Background = Brushes.LightPink;
            OpCard.Background = Brushes.LightPink;
            var bc = new BrushConverter();
            StatCard.Background = (Brush)bc.ConvertFrom("#ff80ab");
        }
    }
}
