using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD.Modelos;

public class Postagem : INotifyPropertyChanged
{
    private int _curtidas;
    public bool _foiCurtido;


    public int Id { get; set; }

    public string Conteudo { get; set; } = string.Empty;

    public int Curtidas
    {
        get => _curtidas;
        set
        {
            _curtidas = value;
            NotificarPropiedadeAlterada();
        }
    }

    public DateTime Postadoem { get; set; }

    public Usuario Usuario { get; set; } = null!;

    public bool FoiCurtido
    {
        get => _foiCurtido;
        set
        {
            if (_foiCurtido == value) return;
            _foiCurtido = value;
            NotificarPropiedadeAlterada();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotificarPropiedadeAlterada([CallerMemberName] string nomepropriedade = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomepropriedade));
    }
}