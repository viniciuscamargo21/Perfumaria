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
        public int IdCliente { get; set; }

        [Column("nome")]
        public string NomeCliente { get; set; }

        [Column("cpf")]
        public string CpfCliente { get; set; }

        [Column("telefone_whatsapp")]
        public string TelefoneCliente {get; set; }

        [Column("email")]
        public string EmailCliente { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }


    }
}