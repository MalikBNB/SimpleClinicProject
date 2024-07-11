using SimpleClinic.Data.Layers;
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
using System.Data.Entity;
using SimpleClinic.Shell.Views.Ptient;
using SimpleClinic.Data.Bll.Entities;
using DevExpress.Xpf.Core;
using SimpleClinic.Data.Layers.Entities;

namespace SimpleClinic.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using (var db = new AppDbContext())
            //{
            //    var p = new Patient();
            //    p = PatientBLL.GetPatientById(1);
            //    DXMessageBox.Show(p.Person.FirstName);

            //}
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void biLogOut_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void AppointmentsAccordionItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void DactorsAccordionItem_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void PatientsAccordionItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LoadingDecorator.IsSplashScreenShown = true;

            var NewPanel = DockLayoutManager.DockController.AddDocumentPanel(DocumentGroup);
            NewPanel.FloatOnDoubleClick = NewPanel.AllowFloat = false;
            NewPanel.Caption = "Patients";
            NewPanel.Content = new PatientUc();

            DockLayoutManager.Activate(NewPanel);

            LoadingDecorator.IsSplashScreenShown = false;
        }
    }
}
