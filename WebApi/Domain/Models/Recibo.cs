using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Recibo
    {
        public int Id { get; set; }

        public string Logo { get; set; }
        [Required]
        public int TipoMoneda { get; set; }
        [Required]
        public double Monto { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Titulo { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Direccion { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Nombres { get; set; }
        [Required]
        public int TipoDocumento { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NumeroDocumento { get; set; } 
    }
}
