using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightsExample
{
    class MainModel
    {
        private User _user;

        public event Action<RightsEnum> UserChanged;

        public void LoginAsAdmin()
        {
            _user= new User(RightsEnum.Read | RightsEnum.Write);
            UserChanged?.Invoke(_user.Rights);
        }

        public void LoginAsUser()
        {
            _user = new User(RightsEnum.Read);
            UserChanged?.Invoke(_user.Rights);
        }
    }
}
