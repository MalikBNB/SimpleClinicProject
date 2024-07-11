using SimpleClinic.Data.Bll.Entities;
using SimpleClinic.Data.Layers.EntitesInfos;
using SimpleClinic.Data.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace SimpleClinic.Shell.Views.Ptient
{
    /// <summary>
    /// Interaction logic for PatientUc.xaml
    /// </summary>
    public partial class PatientUc : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<PatientInfo> _patientInfos;

        public ObservableCollection<PatientInfo> PatientInfos
        {
            get => _patientInfos; 
            set 
            { 
                _patientInfos = value; 
                OnPropertyChanged(); 
            }
        }

        public PatientUc()
        {
            InitializeComponent();

            DataContext = this;
        }


        private async void _LoadPatients()
        {
            var PatientsList = await PatientBLL.GetAllPatients();
            PatientInfos = new ObservableCollection<PatientInfo>(PatientsList);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _LoadPatients();
            OnPropertyChanged(nameof(PatientInfos));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void AddPerson_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void EditPerson_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void DeletePerson_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void RefreshPerson_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }

        private void ManageGridControl_ItemsSourceChanged(object sender, DevExpress.Xpf.Grid.ItemsSourceChangedEventArgs e)
        {

        }

        private void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {

        }

        private void TableView_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
