using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaPerfume.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfumaria.DTO;
using Perfumaria.Models;

namespace Perfumaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Pedidos>> GetPedido()
        {
            var ListaPedido = await _context.pedidos.ToListAsync();
            return Ok(ListaPedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedidos>> CriarPedidos( PedidosBase post)
        {
            Pedidos publi = new Pedidos();

            publi.PedidosId = post.PedidosId;
            publi.ValorTotal = post.ValorTotal;
            publi.StatusPedidos = post.StatusPedidos;

            await _context.pedidos.AddAsync(publi);
            await _context.SaveChangesAsync();

            return Ok(publi);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarPedido(int id)
        {
           var pedidoD = await _context.pedidos.FindAsync(id);
           if(pedidoD == null)
            {
                return NotFound($"pedido numero {id} não encontrado!");
            }

            _context.pedidos.Remove(pedidoD);
            await _context.SaveChangesAsync();

            return Ok($"Pedido numero {id} deletado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pedidos>> EditarPedidos(int id, PedidosBase pedidoEditar)
        {
            var pedidoExiste = await _context.pedidos.FindAsync(id);
            if(pedidoExiste == null)
            {
                return NotFound($"Pedido numero = {id} não existe!");
            }

            pedidoExiste.PedidosId = pedidoEditar.PedidosId;
            pedidoExiste.ValorTotal = pedidoEditar.ValorTotal;
            pedidoExiste.StatusPedidos = pedidoEditar.StatusPedidos;

            _context.pedidos.Update(pedidoExiste);
            await _context.SaveChangesAsync();

            return Ok(pedidoExiste);
        }
       
    }
}