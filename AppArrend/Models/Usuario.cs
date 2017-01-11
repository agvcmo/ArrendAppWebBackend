﻿using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Primer Apellido")]
        public string Apellido { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Nombre De Usuario")]
        public string NombreUsuario { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string Correo { get; set; }
        [Display(Name = "Edad")]
        public int Edad { get; set; }
        [Display(Name = "Genero")]
        public EnumGenero Genero { get; set; }        
    }
}