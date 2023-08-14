using SistemaAlimentacao.Enums;

namespace SistemaAlimentacao.Models
{
    public class RefeicaoModel
    {
        public int Id { get; set; }
        public TipoRefeicao TipoRefeicao { get; set; }

        public String? Descricao { get; set; }
        public int Calorias { get; set; }

        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
