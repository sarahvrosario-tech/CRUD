using System.Windows;
using CRUD.Modelos;
using MySql.Data.MySqlClient;

namespace CRUD;

public partial class MeuPerfil : Window
{
    private Usuario UsuarioAtual;
    public MeuPerfil(Usuario usuario)
    {
        InitializeComponent();
        UsuarioAtual = usuario;
        TxtNome.Text = UsuarioAtual.Nome;
        TxtEmail.Text = UsuarioAtual.Email;
        TxtUsername.Text = UsuarioAtual.Username;
    }

    private void BtnSalvar_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtNome.Text))
        {
            MessageBox.Show("O campo NOME não pode estar vazio.");
            TxtNome.Focus();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(TxtEmail.Text))
        {
            MessageBox.Show("O campo EMAIL não pode estar vazio.");
            TxtEmail.Focus();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(TxtUsername.Text))
        {
            MessageBox.Show("O campo USERNAME não pode estar vazio.");
            TxtUsername.Focus();
            return;
        }

        using var conexao = new MySqlConnection(App.StringConexao);
        const string query = "";

    }
}