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
            var ListaClientes = await _context.clientes.ToListAsync();

            return Ok(ListaClientes);
        }

        [HttpPost]
        public async Task<ActionResult<clientes>> CriarCliente(ClienteEditar Cli)
        {
            var isEmailExistente = await _context.clientes.AnyAsync(u => u.EmailCliente == Cli.EmailCliente);
            if(isEmailExistente)
            {
                return BadRequest("Email ja cadastrado!");
            }

            clientes clientenovo = new clientes();

            clientenovo.NomeCliente = Cli.NomeCliente;
            clientenovo.TelefoneCliente = Cli.TelefoneCliente;
            clientenovo.EmailCliente = Cli.EmailCliente;
            clientenovo.SenhaCliente = Cli.SenhaCliente;
            clientenovo.CepCliente = Cli.CepCliente;
            clientenovo.Logradouro = Cli.Logradouro;
            clientenovo.Numero = Cli.Numero;
            clientenovo.Complemento = Cli.Complemento;
            clientenovo.Bairro = Cli.Bairro;
            clientenovo.Cidade = Cli.Cidade;
            clientenovo.Estado = Cli.Estado;

            await _context.clientes.AddAsync(clientenovo);
            await _context.SaveChangesAsync();

            return Ok(clientenovo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<clientes>> EditarCliente(int id, ClienteEditar clienteEditar )
        {
            var clienteExistente = await _context.clientes.FindAsync(id);
            if(clienteExistente == null)
                
            {
               return NotFound($"Usuario com id = {id} não encontrado!"); 
            }

            clienteExistente.NomeCliente = clienteEditar.NomeCliente;
            clienteExistente.TelefoneCliente = clienteEditar.TelefoneCliente;
            clienteExistente.EmailCliente = clienteEditar.EmailCliente;
            clienteExistente.SenhaCliente = clienteEditar.SenhaCliente;
            clienteExistente.CepCliente = clienteEditar.CepCliente;
            clienteExistente.Logradouro = clienteEditar.Logradouro;
            clienteExistente.Numero = clienteEditar.Numero;
            clienteExistente.Complemento = clienteEditar.Complemento;
            clienteExistente.Cidade = clienteEditar.Cidade;
            clienteExistente.Estado = clienteEditar.Estado;

            _context.clientes.Update(clienteExistente);
            await _context.SaveChangesAsync();

            return Ok(clienteExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCliente(int id)
        {
            var cliente = await _context.clientes.FindAsync(id);
            if(cliente == null)
            {
                return NotFound($"Usuario com o id = {id} não encontrado!");
            }

            string nomeCliente = cliente.NomeCliente;

            _context.clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok($"Usuario {nomeCliente} deletado com sucesso!");
        }


    }
}