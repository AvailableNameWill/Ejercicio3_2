using Ejercicio3_2.Models;
using Ejercicio3_2.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace Ejercicio3_2.ViewModel
{
    public class VMAddStud : Alumnos
    {
        public ICommand addStud { get; private set; }
        public ICommand clean { get; private set; } 
        public Command takePhoto { get; set; }

        public VMAddStud(){
            addStud = new Command(async () =>{
                if (!string.IsNullOrEmpty(Nombres) && !string.IsNullOrEmpty(Apellidos)
                 && !string.IsNullOrEmpty(Sexo) && !string.IsNullOrEmpty(Direccion))
                {
                    Alumnos alumno = new Alumnos()
                    {
                        Nombres = Nombres,
                        Apellidos = Apellidos,
                        Sexo = Sexo,
                        Direccion = Direccion,
                        Foto = Foto,
                    };

                    int i = await App.instance.addStudent(alumno);

                    Nombres = string.Empty;
                    Apellidos = string.Empty;
                    Sexo = string.Empty;
                    Direccion = string.Empty;
                    Foto = string.Empty;
                    FSource = null;
                }
                else Debug.WriteLine("no");
            });

            clean = new Command(() => {
                Nombres = string.Empty;
                Apellidos = string.Empty;
                Sexo = string.Empty;
                Direccion = string.Empty;
                Foto = string.Empty;
                FSource = null;
            });

            takePhoto = new Command(TakePhoto);
        }

        private async void TakePhoto(){
            var perm = await Permissions.CheckStatusAsync<Permissions.Photos>();
            if (perm == PermissionStatus.Granted)
            {
                var camera = new StoreCameraMediaOptions
                {
                    DefaultCamera = CameraDevice.Rear,
                    SaveToAlbum = true,
                    Directory = "Tarea32",
                    Name = null,
                    CompressionQuality = 100
                };

                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(camera);

                if (photo != null)
                {
                    FSource = ImageSource.FromStream(() => { return photo.GetStream(); });
                    Foto = photo.AlbumPath;
                }
            }
            else await Permissions.RequestAsync<Permissions.Camera>();
        }
    }
}
