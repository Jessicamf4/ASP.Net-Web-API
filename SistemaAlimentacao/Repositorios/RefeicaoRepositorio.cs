using Microsoft.EntityFrameworkCore;
using SistemaAlimentacao.Data;
using SistemaAlimentacao.Models;
using SistemaAlimentacao.Repositorios;
using SistemaAlimentacao.Repositorios.Interfaces;

namespace SistemaAlimentacao.Repositorios
{
    public class RefeicaoRepositorio : IRefeicaoRepositorio
    {
        private readonly SistemaRefeicaoDBContext _dbContext;

        public RefeicaoRepositorio(SistemaRefeicaoDBContext sistemaRefeicaoDBContext)
        {
            _dbContext = sistemaRefeicaoDBContext;
        }

        public async Task<RefeicaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Refeicao
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<RefeicaoModel>> BuscarTodasRefeicoes()
        {
            return await _dbContext.Refeicao
                .Include(x => x.Usuario)
                .ToListAsync();
        }
        public async Task<RefeicaoModel> Adicionar(RefeicaoModel refeicao)
        {
            await _dbContext.Refeicao.AddAsync(refeicao);
            await _dbContext.SaveChangesAsync();

            return refeicao;
        }

        public async Task<bool> Apagar(int id)
        {
            RefeicaoModel refeicaoPorId = await BuscarPorId(id);

            if (refeicaoPorId == null)
            {
                throw new Exception($"Refeição para o Id {id}: não encontrado");
            }
            _dbContext.Refeicao.Remove(refeicaoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<RefeicaoModel> Atualizar(RefeicaoModel refeicao, int id)
        {
            RefeicaoModel refeicaoPorId = await BuscarPorId(id);

            if (refeicaoPorId == null)
            {
                throw new Exception($"Refeição para o Id {id}: não encontrado");
            }
            refeicaoPorId.TipoRefeicao = refeicao.TipoRefeicao;
            refeicaoPorId.Descricao = refeicao.Descricao;
            refeicaoPorId.Calorias= refeicao.Calorias;
            refeicaoPorId.UsuarioId = refeicao.UsuarioId;

            _dbContext.Refeicao.Update(refeicaoPorId);
            await _dbContext.SaveChangesAsync();
            return refeicaoPorId;
        }


    }
}
