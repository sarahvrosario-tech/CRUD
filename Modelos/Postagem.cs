using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CRUD.Modelos;

public class Postagem : INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Conteudo { get; set; }

    public int Curtidas { get; set; }
    public DateTime Postado_em { get; set; }

    public Usuario Usuario { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    public bool _foiCurtido;

    public bool FoiCurtido
    {
        get => _foiCurtido;
        set
        {
            if (_foiCurtido != value)
            {
                _foiCurtido = value;
                NotificarPropiedadeAlterada();
            }
        }
    }

    private void NotificarPropiedadeAlterada([CallerMemberName] string nomepropriedade = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomepropriedade));
    }
}