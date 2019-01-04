using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Input;
using System.Xml;
using Microsoft.Win32;
using PlusConsulting.NameSearch.SearchCritera;

namespace PlusConsulting.NameSearch.WpfApp.ViewModels
{
    public class NamesViewModel : ViewModelBase
    {
        public const string NamesFileFilter = "Xml File(*.xml)|*.xml|All files (*.*)|*.*";

        private string _newFirstName;
        private string _newMiddleName;
        private string _newLastName;

        private ObservableCollection<Name> _names;
        
        private ICommand _saveCommand;
        private ICommand _loadCommand;
        private ICommand _removeCommand;
        private ICommand _addNameCommand;

        public NamesViewModel()
        {
            _names = new ObservableCollection<Name>();
            NewFirstName = "";
            NewMiddleName = "";
            NewLastName = "";
        }
        
        public ObservableCollection<Name> Names
        {
            get => _names;
            set
            {
                _names = value;
                OnPropertyChanged();
            }
        }
        
        public string NewFirstName
        {
            get => _newFirstName;
            set
            {
                if (_newFirstName == value)
                    return;
                _newFirstName = value;
                OnPropertyChanged();
            }
        }

        public string NewMiddleName
        {
            get => _newMiddleName;
            set
            {
                if (_newMiddleName == value)
                    return;
                _newMiddleName = value;
                OnPropertyChanged();
            }
        }

        public string NewLastName
        {
            get => _newLastName;
            set
            {
                if (_newLastName == value)
                    return;
                _newLastName = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(p => Names.Any(), p => Save()));
        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(p => true, p => Load()));
        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new RelayCommand(p => true, RemoveSelectedNames));
        public ICommand AddNameCommand => _addNameCommand ?? (_addNameCommand = new RelayCommand(p => !string.IsNullOrEmpty(NewFirstName.Trim()) && !string.IsNullOrEmpty(NewLastName.Trim()), p => AddName()));

        
        private void Save()
        {
            var dialog = new SaveFileDialog {DefaultExt = ".xml", Filter = NamesFileFilter};
            var result = dialog.ShowDialog();
            if(result.HasValue && result.Value)
                SaveToFile(dialog.FileName);
        }

        private void SaveToFile(string filename)
        {
            var serializer = new DataContractSerializer(typeof(List<Name>), new List<Type>{typeof(Name)});
            using (XmlWriter writer = new XmlTextWriter(filename, Encoding.Unicode))
            {
                serializer.WriteObject(writer, Names);
            }
        }

        private void Load()
        {
            var dialog = new OpenFileDialog { Multiselect = false, DefaultExt = ".xml", Filter = NamesFileFilter};
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
                LoadFromFile(dialog.FileName);
        }

        private void LoadFromFile(string filename)
        {
            List<Name> names;
            var serializer = new DataContractSerializer(typeof(List<Name>), new List<Type> { typeof(Name) });
            using (var reader = XmlReader.Create(filename))
            {
                names = serializer.ReadObject(reader) as List<Name>;
            }

            if (names != null && names.Any())
            {
                Names.Clear();
                foreach (var name in names)
                {
                    Names.Add(name);
                }
            }
        }

        private void AddName()
        {
            Names.Add(new Name(NewFirstName, NewMiddleName, NewLastName));
            NewFirstName = "";
            NewMiddleName = "";
            NewLastName = "";
        }

        private void RemoveSelectedNames(object selection)
        {
            var selectedRows = (IList) selection;
            var selectedNames = new List<Name>(selectedRows.Cast<Name>());
            
            foreach (var name in selectedNames)
            {
                if (Names.Contains(name))
                    Names.Remove(name);
            }
        }

        public void ClearAllNames()
        {
            Names.Clear();
            NewFirstName = "";
            NewMiddleName = "";
            NewLastName = "";
        }
    }
}
