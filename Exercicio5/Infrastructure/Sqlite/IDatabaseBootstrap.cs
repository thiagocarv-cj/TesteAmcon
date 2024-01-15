using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite
{
    public interface IDatabaseBootstrap
    {
        void Setup();
        List<Conta> buscaDados();
        Conta buscaDadosPorID(string id);
        Conta buscaDadosPorConta(int id);
        Movimento InsereMovimento(Movimento movimento);
        double BuscaSaldo(int numerodaConta);
    }
}