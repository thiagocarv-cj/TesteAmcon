using System.Threading;

namespace Questao5.Domain.Entities
{
    public class Conta
    {        
        public string idcontacorrente { get; set; }
        public int numero { get; set; } 
        public string nome { get; set; }
        public bool ativo { get; set; }  
    }
}

