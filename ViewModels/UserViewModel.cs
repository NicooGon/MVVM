using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.IdentityModel.Abstractions;
using MVVM.BD;
using MVVM.Commands;
using MVVM.Models;

namespace MVVM.ViewModels
{
    internal class UserViewModel : ViewModelBase
    {
        private readonly Bd bd;
        private ObservableCollection<UserModel> _users;
        private UserModel _user;
        private UserModel _selectedUser;

        public UserViewModel()
        {
            bd = new Bd();
            _user = new UserModel();
            _users = bd.Get();
        }

        public UserModel User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                    if (_selectedUser != null)
                    {
                        User = new UserModel
                        {
                            Id = _selectedUser.Id,
                            Nombre = _selectedUser.Nombre,
                            Apellidos = _selectedUser.Apellidos,
                            Email = _selectedUser.Email,
                            Password = _selectedUser.Password
                        };
                    }
                }
            }
        }


        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(AddExecute, AddCanExecute);
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(EditExecute);
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(DeleteExecute);
            }
        }

        private void AddExecute(Object user)
        {
            bd.Add(User);
            Users = bd.Get();
        }

        private bool AddCanExecute(Object user)
        {
            return true;
        }

        private void EditExecute(Object user)
        {
            bd.Edit(User);
            Users = bd.Get();
        }

        private void DeleteExecute(Object user)
        {
            if (SelectedUser == null)
                return;

            bd.Delete(SelectedUser);
            Users = bd.Get(); // para no dejar datos anteriores cargados en el formulario
            User = new UserModel();
        }
    }
}
