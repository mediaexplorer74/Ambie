using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbientSounds.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AmbientSounds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = DependencyService.Resolve<CatalogueListViewModel>();
            //BindingContext = DependencyService.Resolve<PlayerViewModel>();
        }
    }
}
