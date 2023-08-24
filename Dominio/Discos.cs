using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Discos
    {
        public int Id { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Fecha de Lanzamiento")]
        public string FechaLanzamiento { get; set; }

        [DisplayName("Cantidad de Canciones")]
        public int CantidadCanciones{ get; set; }
        public string UrlImagen { get; set; }
        public Estilo Estilo { get; set; }

        [DisplayName("Tipo de Edición")]
        public TiposEdicion TipoEdicion { get; set; }

    }
}
