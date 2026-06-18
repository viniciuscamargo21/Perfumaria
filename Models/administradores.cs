using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.Models
{
    public class administradores
    {
        [Key]
        [Column("admin_id")]
        public int IdAdm { get; set; }

        [Column("nome")]
        public string NomeAdm { get; set; }

        [Column("email")]
        public string EmailAdm { get; set; }

        [Column("senha")]
        public string SenhaAdm { get; set; }

        [Column("data_cadastro")]
        public DateTime DataAdm { get; set; }
    }
}