using System.ComponentModel.DataAnnotations;

namespace lohran_mendes_DR4_AT_S2.Views.ViewNotes
{
    public class AnotacaoModel
    {
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Descricao { get; set; } = string.Empty;
    }

    public class ViewNotesModel
    {
        public AnotacaoModel Anotacao { get; set; } = new AnotacaoModel();
        public List<AnotacaoModel> Anotacoes { get; set; } = new List<AnotacaoModel>();
    }
}
