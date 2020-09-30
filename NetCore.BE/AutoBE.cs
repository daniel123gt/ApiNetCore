using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.BE
{
    public class AutoBE
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public MarcaBE Marca { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
