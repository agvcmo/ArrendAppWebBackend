using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models 
{
    public class Arrendatario : Usuario
    {
        [Display(Name = "Tipo De Usuario")]
        public EnumRolUsuario Tipo { get; set; }
        public virtual ObservableCollection<Archivo> Archivo { get; set; }                    
    }
}