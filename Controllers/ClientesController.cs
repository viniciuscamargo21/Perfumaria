using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaPerfume.Models;
using Microsoft.AspNetCore.Mvc;
using LojaPerfume.Repository;
using Microsoft.EntityFrameworkCore;
using Perfumaria.DTO;

namespace Perfumaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context =  context;
        }

        [HttpGet]
        public async Task<ActionResult<List<clientes>>> GetClientes()
        {
            var ListaClientes = await _context.Clientes.ToListAsync();

            return Ok(ListaClientes);
        }

        [HttpPost]
        public async Task<ActionResult<clientes>> CriarCliente(clientes Cli)
        {
            var isEmailExistente = await _context.Clientes.AnyAsync(u => u.EmailCliente == Cli.EmailCliente);
            if(isEmailExistente)
            {
                return BadRequest("Email ja cadastrado!");
            }

            await _context.Clientes.AddAsync(Cli);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<clientes>> EditarCliente(int id, ClienteEditar clienteEditar )
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);
            if(clienteExistente == null)
                
            {
               return NotFound($"Usuario com id = {id} não encontrado!"); 
            }

            clienteExistente.NomeCliente = clienteEditar.NomeCliente;
            clienteExistente.EmailCliente = clienteEditar.EmailCliente;
            clienteExistente.SenhaCliente = clienteEditar.SenhaCliente;

            _context.Clientes.Update(clienteExistente);
            await _context.SaveChangesAsync();

            return Ok(clienteExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if(cliente == null)
            {
                return NotFound($"Usuario com o id = {id} não encontrado!");
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Usuario deletado com sucesso!");
        }


    }
}