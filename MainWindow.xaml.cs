using System.Windows;
using MySql.Data.MySqlClient;

namespace CRUD;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtUsuario.Text))
        {
            MessageBox.Show("Necessario preencher usuário!");
            TxtUsuario.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(TxtSenha.Password))
        {
            MessageBox.Show("Necessario preencher senha!");
            TxtSenha.Focus();
            return;
        }

        using (var conexao = new MySqlConnection(App.StringConexao))
        {
            var query = "SELECT * FROM usuarios WHERE username = @username AND senha = @senha";

            using (var command = new MySqlCommand(query, conexao))

            {
                command.Parameters.AddWithValue("@username", TxtUsuario.Text);
                command.Parameters.AddWithValue("@senha", TxtSenha.Password);
                
                try
                {
                    conexao.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Usuário e/ou senha incorretos!", "Erro!");
                            return;
                        }
                        while (reader.Read())
                        {
                            MessageBox.Show(reader.GetString(1));
                        }
                    }

                    command.ExecuteReader();
                    
                    
                }
                catch (Exception exeption)
                {
                    Console.WriteLine(exeption);
                    throw;
                }
            }
        }
    }
}