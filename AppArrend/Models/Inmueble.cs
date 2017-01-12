using AppArrend.Enumeracion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppArrend.Models
{
    public class Inmueble
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Tipo de Inmueble")]
        public EnumTipoInmueble Tipo { get; set; }
        [Display(Name = "Numero de Baños comunes")]
        public int BañosComunes { get; set; }
        [Display(Name = "Area")]
        public double Area { get; set; }
        [Display(Name = "Estrato")]
        public int Estrato { get; set; }
        [Display(Name = "Precio")]
        public float Precio { get; set; }
        [Display(Name = "Patio")]
        public bool Patio { get; set; }
        [Display(Name = "Parqueadero")]
        public bool Parqueadero { get; set; }
        [Display(Name = "Lavadero")]
        public int Lavadero { get; set; }
        [Display(Name = "Comedor")]
        public bool Comedor { get; set; }
        [Display(Name = "Sala Comedor")]
        public bool SalaComedor { get; set; }
        [Display(Name = "Sala")]
        public bool Sala { get; set; }        
        public virtual ObservableCollection<Usuario> Usuario { get; set; }
        [Display(Name = "Contrato inmueble")]
        public int ContratoInmuebleID { get; set; }
        public virtual Contrato ContratoInmueble { get; set; }        
        public virtual ObservableCollection<Archivo> Archivo { get; set; }        
        public virtual ObservableCollection<Habitacion> Habitaciones { get; set; }
    }
}