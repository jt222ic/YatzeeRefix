﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Controller;
using Yatzee.Model;
using Yatzee.View;

namespace Yatzee
{
    class Program
    {
        internal MenuController MenuController
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        static void Main(string[] args)
        {
            
            MenuController startYatzee = new MenuController();
            startYatzee.Register();
           
        }
    }
}
