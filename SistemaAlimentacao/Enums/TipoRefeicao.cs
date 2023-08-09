using System.ComponentModel;

namespace SistemaAlimentacao.Enums
{
    public enum TipoRefeicao
    {
        [Description("Café da manhã")]
        CafeManha = 1,
        [Description("Lanche")]
        Lanche = 2,
        [Description("Almoço")]
        Almoco = 3,
        [Description("Jantar")]
        Jantar = 4
    }
}
