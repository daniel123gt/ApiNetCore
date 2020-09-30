using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.BE.Transporte.Reponse
{
    public class AutoResponse
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int IdMarca { get; set; }
        public string MarcaDesc { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
