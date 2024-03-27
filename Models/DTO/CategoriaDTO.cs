namespace BlazeToDo;


public class ListaAlteraCategorias
{
    public int Id { get; set; }
    public string Categoria { get; set; }
    public int NumeroTarefas { get; set; }
}

public class CriaCategoriaDTO
{
    public string Categoria { get; set; }
}