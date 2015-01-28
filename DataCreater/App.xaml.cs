using Parse;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DataCreater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
    //        this.Suspending += OnSuspending;

            ParseClient.Initialize("30h40Y0id8Sg4UySnrhJZZgbe33jUXtAK7Th3EuW", "gXDba6TNKKcZNUQgCmEpEtneJfSerz9Fh7GurmbR");
        }
    }
}
