using System.Windows;
using System.Windows.Controls;
using CRUD.Modelos;
using MySql.Data.MySqlClient;

namespace CRUD;

public partial class NovaPostagem : Window
{
    private Usuario usuario;
    private readonly Usuario _usuario;

    public NovaPostagem(Usuario usuario)
    {
        _usuario = usuario;
        InitializeComponent();
    }

    private void TbConteudo_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        lblCaracteresMax.Content = $"{TbConteudo.Text.Length}/140";
    }

    private void BtnPostar_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TbConteudo.Text))
        {
            MessageBox.Show(" esvreva algo!");
            TbConteudo.Focus();
            return;
        }

        using var conexao = new MySqlConnection(App.StringConexao);

        const string query = "INSERT INTO postagens (conteudo, usuario_id)VALUES (@conteudo, @usuario_id)";

        using var commad = new MySqlCommand(query, conexao);
        commad.Parameters.AddWithValue("@conteudo", TbConteudo.Text);
        commad.Parameters.AddWithValue("@usuario_id", _usuario.Id);
        try
        {
            conexao.Open();
            var linhasAfetadas = commad.ExecuteNonQuery();
            if (linhasAfetadas < 1) throw new Exception("erro ao postar conteudo!");
            MessageBox.Show("Conteudo adicionado com sucesso!");
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
        finally
        {
            conexao.Close();
            Close();
        }
    }
}