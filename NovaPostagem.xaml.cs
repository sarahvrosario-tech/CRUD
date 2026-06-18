using System.Windows;
using CRUD.Modelos;

namespace CRUD;

public partial class NovaPostagem : Window
{
    private Usuario usuario;
    private readonly Usuario _usuario;

    public NovaPostagem(Usuario usuario)
    {
        _usuario =  usuario;
        InitializeComponent();
    }
    
}