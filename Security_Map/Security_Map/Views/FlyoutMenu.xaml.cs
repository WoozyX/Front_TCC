﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenu : Shell
    {
        public FlyoutMenu()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("UsuarioUsername"))
                lblLogin.Text = "Login" + Application.Current.Properties["UsuarioUsername"].ToString();
        }
    }
}