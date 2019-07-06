using Students.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
        private Introductive Introductive;
        private ObservableCollection<Introductive> Introductives;
        private ObservableCollection<Subject> Subjects;
        private ObservableCollection<IntroductiveFullName> IntroductiveFullNames;
        private int EditId;
        public IntroductiveCon()
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
            Introductives = TObservableCollection(Context.Introductives.Where(i => !i.isDeleted).Include(nameof(Student)).Where(i=>i.StudentId == i.Student.Id).Include(nameof(Subject)).Where(i=> i.SubjectId == i.Subject.Id));
            Subjects = TObservableCollection(Context.Subjects.Where(i => !i.isDeleted));
            IntroductiveFullNames = TObservableCollection(Context.Introductives.Where(i => !i.isDeleted).Include(nameof(Subject)).Where(b => b.SubjectId == b.Subject.Id).Select(a =>
                new IntroductiveFullName
                {
                    Id = a.Id,
                    IntDate = a.IntDate,
                    FullName = a.Student.FirstName + " " + a.Student.LastName,
                    Avg = a.Avg,
                    SubjectName = a.Subject.Name
                }));
        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            ComSubject.ItemsSource = Subjects;
            DgvIntro.ItemsSource = IntroductiveFullNames;

        }
        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
         

        }

        private void BtnEditAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(TxtNum.Text);
            var StuQuery = Context.Students.SingleOrDefault(i => i.StuNumber == num && !i.isDeleted);
            if (BtnEditAdd.IsChecked == true)
            {
                try
                {
                    Introductive = new Introductive
                    {
                        StudentId = StuQuery.Id,
                        SubjectId = Convert.ToInt32(ComSubject.SelectedValue),
                        IntDate = Convert.ToDateTime(DpInt.Text),
                        Avg = Convert.ToInt32(TxtAverage.Text)
                    };
                    Context.Introductives.Add(Introductive);
                }
                catch
                {
                    MessageBox.Show(" عذراً ! هناك خطأ في الرقم الجامعي ", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    BtnEditAdd.IsChecked = false;
                    return;

                }

            }
            else
            {
                try
                {
                    var queryIntro = Context.Introductives.SingleOrDefault(i => i.Id == EditId && !i.isDeleted);
                    queryIntro.Avg = Convert.ToInt32(TxtAverage.Text);
                    queryIntro.StudentId = StuQuery.Id;
                    queryIntro.IntDate = Convert.ToDateTime(DpInt.Text);
                    queryIntro.SubjectId = Convert.ToInt32(ComSubject.SelectedValue);
                }
                catch
                {
                    MessageBox.Show(" عذراً ! هناك خطأ في الرقم الجامعي ", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    BtnEditAdd.IsChecked = true;
                    return;
                }

            }


               TxtNum.Text = "";
               DpInt.Text = "";
               ComSubject.Text = "";
               TxtAverage.Text = "";
               BtnEditAdd.IsChecked = false;
               Context.SaveChanges();
               Load();
            }

            catch
            {

            }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            object id = ((Button) sender).CommandParameter;
            EditId = (int) id;
            var DelQuery = Context.Introductives.SingleOrDefault(i => i.Id == EditId && !i.isDeleted);
            MessageBoxResult result = MessageBox.Show("هل أنت متأكد من إجراء هذه العملية ؟", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                DelQuery.isDeleted = true;
            }

            Context.SaveChanges();
            Load();
        }

        private void ComSubject_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            object id = ((Button)sender).CommandParameter;
            EditId = (int)id;
            var queryShow = Context.Introductives.SingleOrDefault(i => i.Id == EditId && !i.isDeleted);
            TxtNum.Text = queryShow.Student.StuNumber.ToString();
            ComSubject.Text = queryShow.Subject.Name;
            DpInt.Text = queryShow.IntDate.ToString();
            TxtAverage.Text = queryShow.Avg.ToString();
            BtnEditAdd.IsChecked = true;
        }
    }
}
