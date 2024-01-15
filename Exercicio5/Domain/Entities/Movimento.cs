

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public Guid idmovimento { get; set; }
        public string idcontacorrente { get; set; }
        public string datamovimento { get; set; }
        public char tipomovimento { get; set; }
        public double valor { get; set; }
    }

    public class Idempotencia
    {
        public string chave_idempotencia { get; set; }       
        public string requisicao { get; set; }
        public string resultado { get; set; }        
    }

}
