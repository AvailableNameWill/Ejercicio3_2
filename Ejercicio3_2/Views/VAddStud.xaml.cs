using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VAddStud : ContentPage
    {
        private string photoP;
        public VAddStud()
        {
            InitializeComponent();
        }

        private async void btnStudList_Clicked(object sender, EventArgs e){
            await Navigation.PushAsync(new Views.VListStud());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e){
            
        }
    }
}