
public class NotaDto
{
    public int Id { get; set; }
    public string NomeAluno { get; set; }
    public string NomeMateria { get; set; }
    public List<int> NotasAdicionais { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Conceito { get; set; }
}
