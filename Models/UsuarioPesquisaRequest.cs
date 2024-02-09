namespace Api.FCXLabs.AvaliacaoUsuario.Models
{
    public class UsuarioPesquisaRequest
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Status { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public int? FaixaEtariaMinima { get; set; }
        public int? FaixaEtariaMaxima { get; set; }

    }
}
