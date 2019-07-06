using Students.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
    /// Interaction logic for RegesterCon.xaml
    /// </summary>
    public partial class RegesterCon : UserControl
    {
        private BackgroundWorker Worker = new BackgroundWorker();
        private DataContext Context;
        private Registering Registering;
        private ObservableCollection<Registering> Registerings;
        private int EditID;
       
        public RegesterCon()
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
            Registerings =TObservableCollection(Context.Registerings.Where(i=> i.isDeleted == false).Include(nameof(Student)).Where(i=> i.Student.Id == i.StudentId));
        }
        private void WorkerrunCom(object sender, RunWorkerCompletedEventArgs e)
        {
            dh.IsOpen = false;
            DgvReg.ItemsSource = Registerings;
            
        }

         
        private void Dh_OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }
      
        private void BtnEditAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int type = 0;
                int num = Convert.ToInt32(TxtNum.Text);
                var q = Context.Students.SingleOrDefault(i => i.StuNumber == num && !i.isDeleted);
                if (ComType.Text == "تسجيل كمستجد")
                    type = 0;
                else if (ComType.Text == "إيقاف التسجيل")
                    type = 1;
                else
                {
                    type = 2;
                }

               
                if (BtnEditAdd.IsChecked == true)
                {
                    try
                    {
                        Registering = new Registering
                        {
                            RegDate = Convert.ToDateTime(DpReg.Text),
                            StudentId = q.Id,
                            RegType = type

                        };
                        Context.Registerings.Add(Registering);
                    }
                    catch 
                    {
                        MessageBox.Show(" عذراً ! هناك خطأ في الرقم الجامعي ", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        BtnEditAdd.IsChecked = false;
                        return;
                       
                    }
                    

                }
                else
                {
                    try
                    {
                        var queryUpdate = Context.Registerings.SingleOrDefault(i => !i.isDeleted && i.Id == EditID);
                        queryUpdate.StudentId = q.Id;
                        queryUpdate.RegDate = Convert.ToDateTime(DpReg.Text);
                        queryUpdate.RegType = type;
                    }
                    catch
                    {
                        MessageBox.Show(" عذراً ! هناك خطأ في الرقم الجامعي ", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        BtnEditAdd.IsChecked = true;
                        return;
                    }
                   
                }

                TxtNum.Text = "";
                DpReg.Text = "";
                ComType.Text = "";
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
            int EditID = (int) id;
            MessageBoxResult result = MessageBox.Show("هل أنت متأكد من إجراء هذه العملية ؟", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                var q = Context.Registerings.SingleOrDefault(i => i.Id == EditID);
                q.isDeleted = true;
            }

            Context.SaveChanges();
            Load();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {

            object id = ((Button)sender).CommandParameter;
            EditID = (int)id;
            var q = Context.Registerings.SingleOrDefault(i => i.Id == EditID && !i.isDeleted);
            TxtNum.Text = q.Student.StuNumber.ToString();
            DpReg.Text = q.RegDate.ToString();
            BtnEditAdd.IsChecked = true;
        }

    }
}
