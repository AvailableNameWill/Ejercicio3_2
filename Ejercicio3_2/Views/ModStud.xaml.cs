using Ejercicio3_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3_2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModStud : ContentPage
	{
		private Alumnos alumno;

		public ModStud (Alumnos _alumno)
		{
			InitializeComponent ();
			alumno = _alumno;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			fillFields ();
        }

        private void fillFields()
		{
            var stream = new MemoryStream(alumno.Foto);
            imgE.Source = ImageSource.FromStream(() => stream);
            lblName.Text = alumno.Nombres;
			lblSname.Text = alumno.Apellidos;
			lblSex.Text = alumno.Sexo;
			lblDir.Text = alumno.Direccion;
			lblId.Text = Convert.ToString(alumno.Id);
		}

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }
    }
}