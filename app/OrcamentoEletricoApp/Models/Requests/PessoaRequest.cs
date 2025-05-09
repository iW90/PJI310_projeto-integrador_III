namespace OrcamentoEletricoApp.Models.Requests
{
    public class PessoaRequest
    {
        public required string NomeCompleto { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
    }

}
