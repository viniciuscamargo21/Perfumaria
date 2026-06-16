using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.Models
{
    public class Pedidos
    {
        [Key]
        [Column("pedidos_id")]
        public int PedidosId {get; set;}

         [Column("cliente_id")]
         public int ClienteId {get; set;}

          [Column("valor_total")]
          public decimal ValorTotal {get; set;}

            [Column("status")]
          public enum StatusPedido {
        PENDENTE,
        PAGO,
        ENVIADO,
        ENTREGUE,
        CANCELADO
}

            [Column("data_criacao")]
            public Datetime DataCriacao {get; set;}


    
    }
}