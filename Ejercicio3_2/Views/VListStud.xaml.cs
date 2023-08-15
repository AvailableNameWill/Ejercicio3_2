using Ejercicio3_2.Models;
using Ejercicio3_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VListStud : ContentPage
    {
        private VMListStud stud;
        private Alumnos alumno;

        public VListStud()
        {
            InitializeComponent();
            stud = new VMListStud();
            this.BindingContext = stud; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            stud.fillStudList();
        }

        private void listStud_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            alumno = (Alumnos)(e.CurrentSelection.FirstOrDefault() as Alumnos);
            Debug.WriteLine(alumno.Id);
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            if(alumno != null)
            {
                Navigation.PushAsync(new ModStud(alumno));
            }
        }

        private void btnDel_Clicked(object sender, EventArgs e)
        {
            if(alumno != null){
                stud.delStud(alumno);
                DisplayAlert("Alerta!!", "Eliminado exitosamente", "Ok");
            }
        }
    }
}