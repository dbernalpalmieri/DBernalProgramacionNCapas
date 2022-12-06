﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Estado
    {
        int idEstado;
        string nombre;
        ModelLayer.Pais pais;
        List<object> estados;

        [Required]
        [DisplayName("Estado")]
        public int IdEstado { get => idEstado; set => idEstado = value; }
        [DisplayName("Estado")]
        public string Nombre { get => nombre; set => nombre = value; }
        public Pais Pais { get => pais; set => pais = value; }
        public List<object> Estados { get => estados; set => estados = value; }
    }
}
