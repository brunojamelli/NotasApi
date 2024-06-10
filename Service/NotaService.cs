public interface INotaService
{
    IEnumerable<Nota> GetAll();
    Nota GetById(int id);
    Nota Create(Nota nota);
    void Update(int id, Nota nota);
    void Delete(int id);
}

public class NotaService : INotaService
{
    private readonly List<Nota> _notas = new();

    public IEnumerable<Nota> GetAll() => _notas;



    public Nota GetById(int id) => _notas.FirstOrDefault(n => n.Id == id);

    public Nota Create(Nota nota)
    {
        nota.Id = _notas.Count + 1;
        nota.DataCriacao = DateTime.Now;
        _notas.Add(nota);
        return nota;
    }

    public void Update(int id, Nota nota)
    {
        var existingNota = GetById(id);
        if (existingNota != null)
        {
            existingNota.NomeAluno = nota.NomeAluno;
            existingNota.NomeMateria = nota.NomeMateria;
            existingNota.NotasAdicionais = nota.NotasAdicionais;
        }
    }

    public void Delete(int id)
    {
        var nota = GetById(id);
        if (nota != null)
        {
            _notas.Remove(nota);
        }
    }
}
