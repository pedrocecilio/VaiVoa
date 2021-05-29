using CreditCardApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Data
{
    public class CreditContex : DbContext

    {
        public CreditContex(DbContextOptions<CreditContex> opcoes) : base(opcoes) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public string GerarNovoNumero()
        {
            Random num = new Random();
            string RandomResult = "";
            for (int i = 0; i < 16; i++)
            {
                RandomResult += num.Next(9).ToString();
            }
            return RandomResult;
        }
    }
    
    
}
