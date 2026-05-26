using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaPerfume.Models
{
    public class clientes
    {   
        [Key]
        [Column("id")]
        public int IdUsuario { get; set;}
    }
}