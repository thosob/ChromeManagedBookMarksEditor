﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChromeManagedBookmarksEditor.CustomControls
{
    /// <summary>
    /// Interaction logic for BannerBacking.xaml
    /// </summary>
    public partial class BannerBacking : UserControl
    {
        public BannerBacking()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsVisibleBannerProperty =
            DependencyProperty.Register("IsVisibleBanner", typeof(bool), typeof(BannerBacking), new PropertyMetadata(false));

        public bool IsVisibleBanner
        {
            get { return (bool)GetValue(IsVisibleBannerProperty); }
            set { SetValue(IsVisibleBannerProperty, value); }
        }
    }
}
