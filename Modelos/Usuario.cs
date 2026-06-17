namespace CRUD.Modelos;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Username { get; set; } = string.Empty;
}