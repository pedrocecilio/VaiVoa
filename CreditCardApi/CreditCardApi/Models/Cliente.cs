using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Cartao> Cartoes { get; set; }
    }
}
