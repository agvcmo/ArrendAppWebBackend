﻿using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre Del Contrato")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Fin")]
        public DateTime FechaFin { get; set; }
        [Display(Name = "Estado Contrato")]
        public EnumEstadoContrato Estado { get; set; }        
        public virtual ObservableCollection<Archivo> Archivos { get; set; }
    }
}