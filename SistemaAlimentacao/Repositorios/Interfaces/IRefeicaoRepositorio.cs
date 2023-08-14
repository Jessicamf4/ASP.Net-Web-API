using SistemaAlimentacao.Models;

namespace SistemaAlimentacao.Repositorios.Interfaces
{
    public interface IRefeicaoRepositorio
    {
        Task<List<RefeicaoModel>> BuscarTodasRefeicoes();
        Task<RefeicaoModel> BuscarPorId(int id);
        Task<RefeicaoModel> Adicionar(RefeicaoModel refeicao);
        Task<RefeicaoModel> Atualizar(RefeicaoModel refeicao, int id);
        Task<bool> Apagar(int id);
    }
}
