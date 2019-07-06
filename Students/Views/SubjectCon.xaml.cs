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
        private ObservableCollection<SubjectStudyYear> SubjectStudyYears;
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
            Subjects = TObservableCollection(Context.Subjects.Where(i => !i.isDeleted));
            SubjectStudyYears = TObservableCollection(Context.Subjects.Where(i=> !i.isDeleted).Select(a => new SubjectStudyYear
            {
                Id = a.Id,
               Type  = a.Type,
               StudyYearNum = a.StudyYear,
                Name = a.Name
            }).ToList());
        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            DgvSubject.ItemsSource = SubjectStudyYears;
        }

        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

      

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            string studyYear;
            object id = ((Button) sender).CommandParameter;
            EditID = (int) id;
            var q = Context.Subjects.SingleOrDefault(i => i.Id == EditID && i.isDeleted == false);

            TxtName.Text = q.Name;
            ComSubject.Text = q.Type;
            if (q.StudyYear == 1)
                studyYear= "الأولى";
            else if (q.StudyYear == 2) studyYear= "الثانية";
            else if (q.StudyYear == 3) studyYear= "الثالثة";
            else if (q.StudyYear == 4) studyYear= "الرابعة";
            else if (q.StudyYear == 5)
            {
                studyYear= "الخامسة";
            }
            else
            {
                studyYear= "السادسة";
            }
            ComStudyYear.Text = studyYear;
            BtnEditAdd.IsChecked = true;

        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            object ID = ((Button)sender).CommandParameter;

            EditID = (int)ID;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var q = Context.Subjects.Single(i => i.Id == EditID && !i.isDeleted);
                q.isDeleted = true;
                Context.SaveChanges();
                Load();
            }
        }

        public int StudyYear(string value)
        {
            if (value == "الاولى")
                return  1;
            else if (value == "الثانية") return  2;
            else if (value == "الثالثة") return  3;
            else if (value == "الرابعة") return 4;
            else if (value == "الخامسة")
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }
        private void BtnEditAdd_OnClick(object sender, RoutedEventArgs e)
        {
            int value = StudyYear(ComStudyYear.Text);
            if (BtnEditAdd.IsChecked == true)
            {
                var q = Context.Subjects.SingleOrDefault(i => i.Name == TxtName.Text && i.Type == ComSubject.Text);
                if (q == null)
                {
                    Subject = new Subject
                    {
                        Name = TxtName.Text,
                        Type = ComSubject.Text,
                        StudyYear =value
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
                    query.StudyYear =value;
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
            ComStudyYear.Text = "";
            Context.SaveChanges();
            Load();
        }
    }
}
