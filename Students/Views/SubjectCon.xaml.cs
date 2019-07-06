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
    /// Interaction logic for SubjectCon.xaml
    /// </summary>
    public partial class SubjectCon : UserControl
    {
        private BackgroundWorker Worker = new BackgroundWorker();
        private DataContext Context;
        private Subject Subject;
        private ObservableCollection<Subject> Subjects;
        private int EditID;
        public SubjectCon()
        {
            InitializeComponent();
            Worker.DoWork += WOrkerDO;
            Worker.RunWorkerCompleted += WorkerrunCom;
            Load();
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
            Subjects = TObservableCollection(Context.Subjects.Where(i => i.isDeleted == false));
        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            DgvSubject.ItemsSource = Subjects;
        }

        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

      

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            object id = ((Button) sender).CommandParameter;
            EditID = (int) id;
            var q = Context.Subjects.SingleOrDefault(i => i.Id == EditID && i.isDeleted == false);
            TxtName.Text = q.Name;
            ComSubject.Text = q.Type;
            ComStudyYear.Text = q.StudyYear;
            BtnEditAdd.IsChecked = true;

        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            object ID = ((Button)sender).CommandParameter;

            EditID = (int)ID;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var q = Context.Subjects.Single(i => i.Id == EditID && i.isDeleted == false);
                q.isDeleted = true;
                Context.SaveChanges();
                Load();
            }
        }

        private void BtnEditAdd_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (BtnEditAdd.IsChecked == true)
            {
                var q = Context.Subjects.SingleOrDefault(i => i.Name == TxtName.Text && i.Type == ComSubject.Text);
                if (q == null)
                {
                    Subject = new Subject
                    {
                        Name = TxtName.Text,
                        Type = ComSubject.Text,
                        StudyYear = ComStudyYear.Text
                    };
                    Context.Subjects.Add(Subject);

                    BtnEditAdd.IsChecked = false;
                }
                else
                {
                    MessageBox.Show(" عذراً ! هناك نفس المقرر موجود مسبقاً  ", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                var q = Context.Subjects.SingleOrDefault(i => i.Name == TxtName.Text && i.Type == ComSubject.Text && i.Id != EditID);
                if (q == null)
                {
                    var query = Context.Subjects.Single(i => i.Id == EditID && i.isDeleted == false);
                    query.Name = TxtName.Text;
                    query.Type = ComSubject.Text;
                    query.StudyYear = ComStudyYear.Text;
                    BtnEditAdd.IsChecked = false;
                }
                else
                {
                    MessageBox.Show(" عذراً ! هناك نفس المقرر موجود مسبقاً  ", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }

            TxtName.Text = "";
            ComSubject.Text = "";
            Context.SaveChanges();
            Load();
        }
    }
}
