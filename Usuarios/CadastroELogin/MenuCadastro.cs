using System;
using System.Data.SQLite; // Biblioteca para conexão com SQLite
using ScreenSound.Usuarios;

namespace ScreenSound.Usuarios.CadastroELogin
{
    public class MenuCadastro
    {
        private string usuario;
        private string nomeCompleto;
        private string cpf;
        private string senha;
        private string email;

        public void CadastrarUsuario()
        {
            // String de conexão com o banco de dados SQLite
            var connectionString = @"Data Source=C:\Users\joao.viana\source\repos\ScreenSoundAtt\Banco\DbeaverSQLLITE\BancoSQLLITE; Version=3;";

            MenuUsuarios menuUsuarios = new MenuUsuarios();
            var funcoes = new Funcoes();

            Console.Clear();
            funcoes.ExibirLogo();

            // Coleta dos dados
            Console.WriteLine("Digite seu nome completo: ");
            nomeCompleto = Console.ReadLine();

            Console.WriteLine("Digite seu email: ");
            email = Console.ReadLine();

            Console.WriteLine("Digite seu nome de usuário: ");
            usuario = Console.ReadLine();

            Console.WriteLine("Digite seu CPF: ");
            cpf = Console.ReadLine();

            Console.WriteLine("Digite sua senha: ");
            senha = Console.ReadLine();

            // Hash da senha
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

            try
            {
                // Conectando ao banco de dados usando SQLite
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Usuarios (Usuario, Nome, Senha, CPF, Email) VALUES (@Usuario, @Nome, @Senha, @CPF, @Email)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Adicionando parâmetros para o comando SQL
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.Parameters.AddWithValue("@Nome", nomeCompleto);
                        command.Parameters.AddWithValue("@Senha", senhaHash);
                        command.Parameters.AddWithValue("@CPF", cpf);
                        command.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                        if (rowsAffected > 0)
                        {
                            Console.Clear();
                            funcoes.ExibirLogo();
                            Console.WriteLine($"Usuário {nomeCompleto} cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao cadastrar usuário. Tente novamente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            // Exibe o menu inicial novamente
            menuUsuarios.ExibirMenuInicial();
        }
    }
}
