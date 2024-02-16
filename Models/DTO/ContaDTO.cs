namespace BlazeToDo;

public record ContaLogadaDTO()
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Contacto { get; set; }
}

public class AdicionarEditarContaDTO
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Contacto { get; set; }
    public string Password { get; set; }
}
