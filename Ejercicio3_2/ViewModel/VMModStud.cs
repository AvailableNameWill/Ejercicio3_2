using Ejercicio3_2.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ejercicio3_2.ViewModel
{
    public class VMModStud : Alumnos
    {
        public ICommand modStud { get; private set; }
        public Command takePhoto { get; set; }

        public VMModStud() {
            modStud = new Command(async () => {
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
                        Id = Id
                    };

                    int i = await App.instance.UpdtStudent(alumno);

                    Nombres = string.Empty;
                    Apellidos = string.Empty;
                    Sexo = string.Empty;
                    Direccion = string.Empty;
                    Foto = null;
                    FSource = null;
                    Debug.WriteLine(i);
                }
                else Debug.WriteLine("no");
            });

            takePhoto = new Command(TakePhoto);
        }

        private async void TakePhoto()
        {
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
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Stream stream = photo.GetStream();
                        stream.CopyTo(ms);
                        byte[] data = ms.ToArray();
                        Foto = data;
                    }
                }
            }
            else await Permissions.RequestAsync<Permissions.Camera>();
        }
    }
}
