using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumaria.DTO
{
    public class PedidosBase
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public string StatusPedidos { get; set; }
    }
}