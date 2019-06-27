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

namespace Students.Views
{
    /// <summary>
    /// Interaction logic for IntroductiveCon.xaml
    /// </summary>
    public partial class IntroductiveCon : UserControl
    {
        private BackgroundWorker Worker = new BackgroundWorker();
        private DataContext Context;
        private Student Student;
        public IntroductiveCon()
        {
            InitializeComponent();
        }
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

        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            
        }
        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonShow_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
