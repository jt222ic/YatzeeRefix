﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Controller;
using Yatzee.Model;

namespace Yatzee
{
    class Program
    {
        
        static void Main(string[] args)
        {
            UserController startgame = new UserController();
            startgame.CreateUser();

           
        }
    }
}