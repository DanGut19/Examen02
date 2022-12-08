using Aplicacion_de_Hugo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Aplicacion_de_Hugo.ViewModels
{
    public class PersonaViewModel : INotifyPropertyChanged
    {

        public PersonaViewModel()
        {

            CrearPersona = new Command(() =>
            {

                Persona p = new Persona()
                {

                    nombre = this.nombre,
                    edad = this.edad,


                };

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "persona.aut");

                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, p);
                archivo.Close();
            });

        }

        string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(nombre));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        string edad;

        public string Edad
        {
            get => edad;
            set
            {
                edad = value;
                var arg = new PropertyChangedEventArgs(nameof(edad));
                PropertyChanged?.Invoke(this, arg);

            }
        }

        public Command CrearPersona { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
