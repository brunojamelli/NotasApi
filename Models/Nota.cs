
public class Nota
{
    public int Id { get; set; }
    public string NomeAluno { get; set; }
    public string NomeMateria { get; set; }
    public List<int> NotasAdicionais { get; set; } = new List<int>(3); // Três notas
    public DateTime DataCriacao { get; set; }
    public string Conceito
    {
        get
        {
            if (NotasAdicionais == null || NotasAdicionais.Count != 3)
                return "N/A";

            double media = NotasAdicionais.Average();
            if (media >= 9.0) return "A";
            if (media >= 7.0) return "B";
            if (media >= 5.0) return "C";
            if (media >= 3.0) return "D";
            return "E";
        }
    }
}