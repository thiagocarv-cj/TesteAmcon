using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Questao5.Infrastructure.Services.Controllers
{
    
    [ApiController]
    public class QuestoesController : ControllerBase
    {
        private readonly IDatabaseBootstrap _databaseBootstrap;
        public QuestoesController(IDatabaseBootstrap databaseBootstrap)
        {
            _databaseBootstrap = databaseBootstrap;
        }
        
        // GET api/<QuestoesController>/5
        [HttpGet("{id}")]
        public Conta Get(string id)
        {
            return _databaseBootstrap.buscaDadosPorID(id);
        }

        [HttpGet]
        [Route("buscarTodos")]
        public IEnumerable<Conta> BuscarTodos()
        {
            return _databaseBootstrap.buscaDados();
        }

        [HttpGet]
        [Route("buscaPorConta/{conta}")]
        public Conta BuscarPorConta(int conta)
        {
            return _databaseBootstrap.buscaDadosPorConta(conta);
        }

        [HttpPost]
        [Route("insereMovimento")]
        public Movimento InsereMovimento([FromBody] Movimento conta)
        {
            return _databaseBootstrap.InsereMovimento(conta);
        }

        [HttpGet]
        [Route("buscaSaldo/{numerodaConta}")]
        public double BuscaSaldo(int numerodaConta)
        {
            return _databaseBootstrap.BuscaSaldo(numerodaConta);
        }

    }
}
