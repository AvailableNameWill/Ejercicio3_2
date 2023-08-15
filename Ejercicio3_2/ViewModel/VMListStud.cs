using Ejercicio3_2.Models;
using Ejercicio3_2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ejercicio3_2.ViewModel
{
    public class VMListStud : Alumnos
    {
        private ObservableCollection<Alumnos> studList;

        //public ICommand delStud { get; private set; }
        public ObservableCollection<Alumnos> StudList {
            get {
                if (studList == null){
                    fillStudList();
                }
                return studList;
            }
            
            set => studList = value; }

        public VMListStud()
        {
            /*delStud = new Command(async () => {
                Alumnos alumno = new Alumnos()
                {
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    Sexo = Sexo,
                    Direccion = Direccion,
                    Foto = Foto,
                    Id = Id
                };

                await App.instance.delStudent(alumno);
            });*/
        }

        public async void delStud(Alumnos alumno)
        {
            await App.instance.delStudent(alumno);
        }

        public async void fillStudList(){
            studList = new ObservableCollection<Alumnos>(); 
            try
            {
                if(studList != null) { studList.Clear(); }
                
                var list = await App.instance.getAllAlumnos();
                foreach (var alumnos in list)
                {
                    Debug.WriteLine("nombre" + alumnos.Nombres);
                    studList.Add(alumnos);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.ToString()); }
        }
    }
}
