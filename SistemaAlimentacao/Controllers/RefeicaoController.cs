using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAlimentacao.Models;
using SistemaAlimentacao.Repositorios.Interfaces;

namespace SistemaAlimentacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefeicaoController : ControllerBase
    {
        private readonly IRefeicaoRepositorio _refeicaoRepositorio;

        public RefeicaoController(IRefeicaoRepositorio refeicaoRepositorio)
        {
            _refeicaoRepositorio = refeicaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<RefeicaoModel>>> ListarTodas()
        {
            List<RefeicaoModel> refeicao = await _refeicaoRepositorio.BuscarTodasRefeicoes();
            return Ok(refeicao);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<RefeicaoModel>>> BuscarPorId(int id)
        {
            RefeicaoModel refeicao = await _refeicaoRepositorio.BuscarPorId(id);
            return Ok(refeicao);
        }

        [HttpPost]
        public async Task<ActionResult<RefeicaoModel>> Cadastrar([FromBody] RefeicaoModel refeicaoModel)
        {
            RefeicaoModel refeicao = await _refeicaoRepositorio.Adicionar(refeicaoModel);
            return Ok(refeicao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RefeicaoModel>> Atualizar([FromBody] RefeicaoModel refeicaoModel, int id)
        {
            refeicaoModel.Id = id;
            RefeicaoModel refeicao = await _refeicaoRepositorio.Atualizar(refeicaoModel, id);
            return Ok(refeicao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RefeicaoModel>> Apagar(int id)
        {
            bool apagado = await _refeicaoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
