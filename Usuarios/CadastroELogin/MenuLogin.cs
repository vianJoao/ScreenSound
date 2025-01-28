using System;
using System.Data.SQLite; // Biblioteca para conexão com SQLite

//Tela de login e validação.
namespace ScreenSound.Usuarios.CadastroELogin
{
    public class MenuLogin
    {
        string usuario;
        string senha;

        public void TelaLogin()
        {
            MenuBandasUsuario menuBandasUsuario = new MenuBandasUsuario();
            // Caminho do banco de dados SQLite
            var connectionString = @"Data Source=C:\Users\joao.viana\source\repos\ScreenSoundAtt\Banco\DbeaverSQLLITE\BancoSQLLITE; Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    Console.WriteLine("Usuário: ");
                    usuario = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Usuário: " + usuario);

                    Console.WriteLine("Senha: ");
                    senha = Console.ReadLine();

                    // Comando SQL para buscar o usuário
                    string query = "SELECT Senha FROM Usuarios WHERE Usuario = @Usuario";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Adiciona o parâmetro do comando
                        command.Parameters.AddWithValue("@Usuario", usuario);

                        // Executa o comando e lê o resultado
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Verifica se o usuário existe
                            {
                                // Obtém o hash da senha armazenado no banco
                                string senhaHash = reader["Senha"].ToString();

                                // Verifica a senha usando BCrypt
                                if (BCrypt.Net.BCrypt.Verify(senha, senhaHash))
                                {
                                    Console.WriteLine("Bem-vindo, " + usuario + "!");
                                    Console.Clear();
                                    MenuBandasUsuario.MeuUsuCad();


                                }
                                else
                                {
                                    Console.WriteLine("Senha incorreta.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Usuário não encontrado.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao acessar o banco de dados: {ex.Message}");
                }
            }
        }
    }
}
