using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Models
{
    public class Cartao
    {

        public int Id { get; set; }
        public string NumeroDoCartao { get; set; }
        public int ClienteId { get; set; }
    }
}
