using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RightsExample
{
    class MainViewModel: INotifyPropertyChanged
    {
        private bool _userHasReadRight;
        private bool _userHasWriteRight;
        private MainModel _model;

        private RelayCommand _loginAsAdminCommand;
        private RelayCommand _loginAsUserCommand;

        public bool UserHasReadRight
        {
            get { return _userHasReadRight; }
            set
            {
                _userHasReadRight = value;
                OnPropertyChanged();
            }
        }

        public bool UserHasWriteRight
        {
            get { return _userHasWriteRight; }
            set
            {
                _userHasWriteRight = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoginAsAdminCommand
        {
            get {
                if (_loginAsAdminCommand == null)
                {
                    _loginAsAdminCommand = new RelayCommand(LoginAsAdmin);
                }
                return _loginAsAdminCommand;
            }
            set { _loginAsAdminCommand = value; }
        }

        public RelayCommand LoginAsUserCommand
        {
            get
            {
                if (_loginAsUserCommand == null)
                {
                    _loginAsUserCommand = new RelayCommand(LoginAsUser);
                }
                return _loginAsUserCommand;
            }
            set { _loginAsUserCommand = value; }
        }

        private void LoginAsUser(object obj)
        {
            _model.LoginAsUser();
        }

        private void LoginAsAdmin(object obj)
        {
            _model.LoginAsAdmin();
        }

        public MainViewModel()
        {
            _model = new MainModel();
            _model.UserChanged += OnUserChanged;
        }

        public void OnUserChanged(RightsEnum rights)
        {
            UserHasReadRight = rights.HasFlag(RightsEnum.Read);
            UserHasWriteRight = rights.HasFlag(RightsEnum.Write);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
