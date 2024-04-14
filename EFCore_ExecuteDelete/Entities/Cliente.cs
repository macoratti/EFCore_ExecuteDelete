namespace EFCore_ExecuteDelete.Entities;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public List<Animal> Animais { get; set; } = new();
}
