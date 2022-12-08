using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aplicacion_de_Hugo.Models
{
    [Serializable]
    public class Persona : SuperClass
    {
        public string nombre { get; set; }
        public string edad { get; set; }

        public ObservableCollection<compras> lista_compras { get; set; } = new ObservableCollection<compras>();
        public ObservableCollection<direccion> lista_direccion { get; set; } = new ObservableCollection<direccion>();
        public ObservableCollection<tarjeta_credito> lista_tarjeta_credito { get; set; } = new ObservableCollection<tarjeta_credito>();

    }
}
