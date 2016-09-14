using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.View;

namespace Yatzee.Controller
{
    class UserController
    {
        public void CreateUser()
        {
            User Userview = new User();

            Userview.Register();
        }



    }
}
