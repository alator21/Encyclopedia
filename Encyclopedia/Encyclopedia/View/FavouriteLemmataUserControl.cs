﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encyclopedia.View
{
    public partial class FavouriteLemmataUserControl : UserControl
    {
        private static FavouriteLemmataUserControl _instance;


        public static FavouriteLemmataUserControl Instance
        {
            get
            {

                if (_instance == null)
                    _instance = new FavouriteLemmataUserControl();
                return _instance;

            }
        }
        public FavouriteLemmataUserControl()
        {
            InitializeComponent();
        }

        
    }
}
