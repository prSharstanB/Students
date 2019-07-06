using LiveCharts;
using LiveCharts.Wpf;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using LiveCharts.Definitions.Series;
using LiveCharts.Helpers;

namespace Students.Views
{
    /// <summary>
    /// Interaction logic for FirstStatCon.xaml
    /// </summary>
    public partial class FirstStatCon : UserControl
    {
        private BackgroundWorker Worker = new BackgroundWorker();
        private DataContext Context;
       private ObservableCollection<IntroductiveAvgStudyYear> IntroductiveAvgStudyYears;
        private ObservableCollection<Student> Students;
        private ObservableCollection<IntroductiveForChart> IntroductiveForCharts;
        private ObservableCollection<Introductive> Introductives;
        private int []averages = new int[5];

        public FirstStatCon()
        {
            InitializeComponent();

            SecondSeriesCollection = new SeriesCollection
            {

                new LineSeries
                {
                    Title = "المعدلات",
                    Values = new ChartValues<int> {0 ,0 ,0 , 0, 0} ,
                    PointGeometry = null
                }

            };
            FirstSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "",
                    Values = new ChartValues<double>{0d , 0d , 0d , 0d , 0d},
                    PointGeometry = null
                }
            };
         
            LabelsTrans = new[]
            {
                "الاولى", "الثانية", "الثالثة", "الرابعة", "الخامسة",
            };

            //for (int i = 0; i < Introductives.Count; i++)
            //{
            //    AvgList[i] = Introductives[i].IntDate.Year;
            //}
            DataContext = this;
            Worker.DoWork += WOrkerDO;
            Worker.RunWorkerCompleted += WorkerrunCom;
            Load();
           
      
    }

        public SeriesCollection FirstSeriesCollection { get; set; }
        public SeriesCollection SecondSeriesCollection { get; set; }
        public string[] LabelsTrans { get; set; }
        public List<int> AvgList { get; set; }
        public ObservableCollection<T> TObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
        public void Load()
        {
            dh.IsOpen = true;
            if (!Worker.IsBusy)
            {
                Context = new DataContext();
                Worker.RunWorkerAsync();
            }

        }


        private void WOrkerDO(object sender, DoWorkEventArgs e)
        {
            Students = TObservableCollection(Context.Students.Where(i => !i.isDeleted));

            IntroductiveForCharts = TObservableCollection(Context.Introductives.Where(i => !i.isDeleted)
                .GroupBy(i => new {i.IntDate.Year 
        }).Select( 
                    a => new IntroductiveForChart
                    {
                        TotalAvg = a.Average(o => o.Avg), 
                    }));
            

        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            for (int j = 0; j < FirstSeriesCollection[0].Values.Count; j++)
            {
                FirstSeriesCollection[0].Values[j] = IntroductiveForCharts[j].TotalAvg;
            }

        }
        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < averages.Length; i++)
            {
                averages[i] = 0;
            }

            int StudNum = Convert.ToInt32(TxtChart.Text);
            IntroductiveAvgStudyYears = TObservableCollection(Context.Introductives.Where(s => !s.isDeleted && s.Student.StuNumber== StudNum).Select(
                    a => new IntroductiveAvgStudyYear
                    {
                        Avg = a.Avg,
                        StudYear = a.Subject.StudyYear,
                        isDeleted = a.isDeleted
                    }).OrderBy(t => t.StudYear));
            int  d = IntroductiveAvgStudyYears.Count ;
            for (int j = IntroductiveAvgStudyYears.Count-1; j >= 0 ; j--)
            {
                if (j != 0)
                {
                    if (IntroductiveAvgStudyYears[j].StudYear != IntroductiveAvgStudyYears[j - 1].StudYear)
                    {
                        averages[IntroductiveAvgStudyYears[j].StudYear - 1] += IntroductiveAvgStudyYears[j].Avg;
                        averages[IntroductiveAvgStudyYears[j].StudYear - 1] /= d - j ;
                        d = j;
                        continue;
                    }
                }

                averages[IntroductiveAvgStudyYears[j].StudYear-1] += IntroductiveAvgStudyYears[j].Avg;
                if (j == 0)
                {
                    averages[IntroductiveAvgStudyYears[j].StudYear-1] /= d-j;
                }
            }

            for (int j = 0; j < SecondSeriesCollection[0].Values.Count; j++)
            {
                SecondSeriesCollection[0].Values[j] =  averages[j];
            }
            DataContext = this;
            Load();

        }

       
    }
}
