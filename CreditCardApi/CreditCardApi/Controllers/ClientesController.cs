using CreditCardApi.Data;
using CreditCardApi.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly CreditContex _context;
        public ClientesController(CreditContex context)
        {
            _context = context;
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<Cliente>> ListarCliente(string email)
        {
            var cliente = await _context.Clientes
                .Include(x => x.Cartoes.OrderBy(z => z.Id))
                .FirstOrDefaultAsync(v => v.Email == email);

            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Cliente(Cliente cliente)
        {
            var c = await _context.Clientes.FirstOrDefaultAsync(b => b.Email == cliente.Email);
            if (c == null)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                c = await _context.Clientes.FirstOrDefaultAsync(b => b.Email == cliente.Email);
            }

            Random num = new Random();
            Cartao cartao = new Cartao();
            cartao.NumeroDoCartao = _context.GerarNovoNumero();
            cartao.ClienteId = c.Id;
            _context.Cartoes.Add(cartao);
            await _context.SaveChangesAsync();
            return CreatedAtAction("ListarCliente", new { email = c.Email }, c);

        }

    }
}
