using System;

namespace Aplicacion_de_Hugo.Models
{
    [Serializable]
    public class tarjeta_credito : SuperClass
    {
        public string Id { get; set; }
        public double codigo { get; set; }


    }
}