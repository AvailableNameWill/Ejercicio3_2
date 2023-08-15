using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Ejercicio3_2.Models
{
    public class Alumnos : INotifyPropertyChanged 
    {
        private int id;
        private string nombres;
        private string apellidos;
        private string sexo;
        private string direccion;
        private byte[] foto;
        private ImageSource fSource;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propiedad){
            if (PropertyChanged != null){
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; 
            set {
                if(id != value){
                    id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        public string Nombres { get => nombres; 
            set{
                if (nombres != value){
                    nombres = value;
                    OnPropertyChanged("nombres");
                }
            }
        }
        public string Apellidos { get => apellidos;
            set{
                if (apellidos != value){
                    apellidos = value;
                    OnPropertyChanged("apellidos");
                }
            }
        }
        public string Sexo { get => sexo;
            set{
                if (sexo != value){
                    sexo = value;
                    OnPropertyChanged("sexo");
                }
            }
        }
        public string Direccion { get => direccion;
            set{
                if (direccion != value){
                    direccion = value;
                    OnPropertyChanged("direccion");
                }
            }
        }

        public byte[] Foto { get => foto;
            set{
                if (foto != value){
                    foto = value;
                    OnPropertyChanged("foto");
                }
            }
        }

        [Ignore]
        public ImageSource FSource
        {
            get => fSource;
            set
            {
                if (fSource != value)
                {
                    fSource = value;
                    OnPropertyChanged("");
                }
            }
        }
    }
}
