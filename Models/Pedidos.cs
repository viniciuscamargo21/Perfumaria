using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.Models
{
    public class Pedidos
    {
        [Key]
        [Column("pedido_id")]
        public int PedidosId {get; set;}

         [Column("cliente_id")]
         public int ClienteId {get; set;}

          [Column("valor_total")]
          public decimal ValorTotal {get; set;}

          [Column("statusserv")]
          public string StatusPedidos { get; set;}
        
        [Column("data_criacao")]
         public DateTime DataCriacao {get; set;}
         


    
    }
}