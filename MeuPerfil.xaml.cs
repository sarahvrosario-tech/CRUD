using System.Windows;
using CRUD.Modelos;
using MySql.Data.MySqlClient;
using Mysqlx.Expect;

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

        var senhaFoiAterada = !string.IsNullOrWhiteSpace(TxtSenha.Password);

        UsuarioAtual.Username = TxtUsername.Text;
        UsuarioAtual.Nome = TxtNome.Text;
        UsuarioAtual.Email = TxtEmail.Text;
        if (!senhaFoiAterada) UsuarioAtual.Senha = TxtSenha.Password;


        using var conexao = new MySqlConnection(App.StringConexao);
        var query = " UPDATE usuarios SET username = @username, nome= @nome, email= @email ";

        if (senhaFoiAterada) query += ",senha = @senha";
        query += " WHERE id = @id";

        using var command = new MySqlCommand(query, conexao);

        command.Parameters.AddWithValue("@username", UsuarioAtual.Username);
        command.Parameters.AddWithValue("@nome", UsuarioAtual.Nome);
        command.Parameters.AddWithValue("@email", UsuarioAtual.Email);
        command.Parameters.AddWithValue("@id", UsuarioAtual.Id);
        
        if  (senhaFoiAterada) command.Parameters.AddWithValue("@senha", UsuarioAtual.Senha);
            
            
            
            
        try
        {
            conexao.Open();
            var linhasAfetadas = command.ExecuteNonQuery();

            if (linhasAfetadas > 0) MessageBox.Show("Cadastro atualizado com sucesso!");
            else MessageBox.Show("Erro ao atualizar o cadastro!");
        }
        catch (Exception exception)
        {
            MessageBox.Show($"Erro de DB.");
        }
    }
}