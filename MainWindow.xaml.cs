using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace CRUD;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public string connectionString = "Server=localhost;Uid=root;Pwd=root;DataBase=orkut;";

    public MainWindow()
    {
        InitializeComponent();
    }


    private void btnCadastrar_OnClick(object sender, RoutedEventArgs e)

    {
        if (string.IsNullOrWhiteSpace(txtNome.Text) ||
            string.IsNullOrWhiteSpace(txtUsername.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtSenha.Password))
        {
            MessageBox.Show("Todos os campos são obrigatórios.", "Erro!");
            return;
        }

        using (var conexao = new MySqlConnection(connectionString))
        {
            var query = "INSERT INTO usuarios(nome, username, email, senha) VALUE( @nome, @username, @email, @senha)";

            using (var command = new MySqlCommand(query, conexao))
            {
                command.Parameters.AddWithValue("@nome", txtNome.Text);
                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@email", txtEmail.Text);
                command.Parameters.AddWithValue("@senha", txtSenha.Password);

                try
                {
                    conexao.Open();
                    var linhasAfetadas = command.ExecuteNonQuery();
                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Cadastro realizado!");
                    }
                }
                catch (Exception exception)
                {
                    if (exception is MySqlException erroSql)
                    {
                        if (erroSql.Number == 1062)
                        {
                            MessageBox.Show("O email ou username já foram utilizados");
                            return;
                        }
                    }

                        Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}