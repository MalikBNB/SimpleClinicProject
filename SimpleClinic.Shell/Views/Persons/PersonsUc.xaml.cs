using SimpleClinic.Data.Layers.EntitesInfos;
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleClinic.Shell.Views.Persons
{
    /// <summary>
    /// Interaction logic for PersonsUc.xaml
    /// </summary>
    public partial class PersonsUc : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<PersonInfo> _personInfos;      

        public ObservableCollection<PersonInfo> PersonInfos 
        { 
            get => _personInfos;
            set
            {
                _personInfos = value;
                OnPropertyChanged();
            } 
        }

        public PersonsUc()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void GetData()
        {
            //var items = await PersonBLL.GetPesronInfos();
            //PersonInfos = new ObservableCollection<PersonInfo>(items);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
            OnPropertyChanged(nameof(PersonInfos));
        }        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }       
    }
}
