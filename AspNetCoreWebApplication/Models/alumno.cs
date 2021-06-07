using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreWebApplication.Models
{
    [Table("newtable")]
    public class alumno
    {
        [Key]
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String facultad { get; set; }
        public String temp { get; set; }
    }
}