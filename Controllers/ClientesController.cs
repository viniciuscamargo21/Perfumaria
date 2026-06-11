using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaPerfume.Models;
using Microsoft.AspNetCore.Mvc;
using LojaPerfume.Repository;
using Microsoft.EntityFrameworkCore;

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
    }
}