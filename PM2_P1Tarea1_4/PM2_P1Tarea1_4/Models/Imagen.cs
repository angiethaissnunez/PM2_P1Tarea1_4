using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2_P1Tarea1_4.Models
{
    public class Imagen
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public Byte[] foto { get; set; }


        public string IdText
        {
            get { return $"Id: {id}"; }
        }

        public string DescText
        {
            get { return $"Descripcion: {descripcion}"; }
        }

        public string NombreText
        {
            get { return $"Nombre: {nombre}"; }
        }


    }
}
