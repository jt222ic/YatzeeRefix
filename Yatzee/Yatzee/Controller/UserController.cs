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

               
            //User.Options input = Userview.GetOptions();

            //if(input == User.Options.Play)
            //{
               //Userview.Register();
              // Userview.MainMenu();
            //}
            //else
            //{
               Userview.Register();
            //}
        }



    }
}
