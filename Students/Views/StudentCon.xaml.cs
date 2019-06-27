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
    /// Interaction logic for StudentCon.xaml
    /// </summary>
    public partial class StudentCon : UserControl
    {
        private BackgroundWorker Worker = new BackgroundWorker();
        private DataContext Context;
        private Student Student;
        private ObservableCollection<Student> Students;
        private int IdEdit;
        public StudentCon()
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
            Students = TObservableCollection(Context.Students.Where(i => i.isDeleted == false));
        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            DgvStu.ItemsSource = Students;
        }

        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

           
            int num = Convert.ToInt32(TxtNumber.Text);
                        string gend;
                        if (BtnEditAdd.IsChecked == true)
                        {
                            var qFind = Context.Students.SingleOrDefault(i => i.StuNumber == num);
                if (qFind == null)
                            {
                             if (BtnGender.IsChecked == true)
                                gend = "ذكر";
                            else
                            {
                                gend = "أنثى";
                            }

                            Student = new Student()
                            {
                                FirstName = TxTFirstName.Text,
                                LastName = TxtLastName.Text,
                                Phone = Convert.ToInt32(TxtPhone.Text),
                                BirthDate = Convert.ToDateTime(DpBirthday.Text),
                                Gender = gend,
                                StuNumber = Convert.ToInt32(TxtNumber.Text)
                            };
                            Context.Students.Add(Student);
                            Context.SaveChanges();
                            Load();
                          
                        }
                        else
                        {
                            
                            MessageBox.Show(" عذراً ! هناك طالب مسبق التسجيل بنفس رقم الجامعي  " , "", MessageBoxButton.OK,
                                MessageBoxImage.Error );
                        }

                            BtnEditAdd.IsChecked = false;
                        }
                        else
                        {

                            if (BtnGender.IsChecked == true)
                                gend = "ذكر";
                            else
                            {
                                gend = "أنثى";
                            }

                            var query = Context.Students.Single(i => i.Id == IdEdit && i.isDeleted == false);

                            query.FirstName = TxTFirstName.Text;
                            query.LastName = TxtLastName.Text;
                            query.Phone = Convert.ToInt32(TxtPhone.Text);
                            query.BirthDate = Convert.ToDateTime(DpBirthday.Text);
                            query.Gender = gend;
                            query.StuNumber = Convert.ToInt32(TxtNumber.Text);
                            BtnEditAdd.IsChecked = false;
                            Context.SaveChanges();
                            Load();
                        }
            TxtNumber.Text = " ";
            TxTFirstName.Text = " ";
            TxtLastName.Text = "";
            TxtPhone.Text = "";
            DpBirthday.Text = "";
            }
            catch
            {

            }
        }
    

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            object ID = ((Button)sender).CommandParameter;

            IdEdit = (int)ID;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var q = Context.Students.Single(i => i.Id == IdEdit && i.isDeleted==false);
                q.isDeleted = true;
                Context.SaveChanges();
                Load();
            }

        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            object ID = ((Button)sender).CommandParameter;

            IdEdit = (int)ID;

            var query = Context.Students.Single(i => i.isDeleted == false && i.Id == IdEdit);
            TxTFirstName.Text = query.FirstName;
            TxtLastName.Text = query.LastName;
            TxtNumber.Text = query.StuNumber.ToString();
            TxtPhone.Text = query.Phone.ToString();
            DpBirthday.Text = query.BirthDate.ToString();
            if (query.Gender == "ذكر") BtnGender.IsChecked = true;
            else
            {
                BtnGender.IsChecked = false;
            }

            BtnEditAdd.IsChecked = true;
        }
    }
}
