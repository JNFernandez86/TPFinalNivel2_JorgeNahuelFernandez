﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica
{
    public class Articulos
    {
        public int Id_articulos { get; set; }
        public string Codigo { get; set; }
        public string Name { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Marca { get; set; }
        public int Categoria { get; set; }
        public string UrlImagen { get; set; }
        public decimal Precio { get; set; }

    }
}
