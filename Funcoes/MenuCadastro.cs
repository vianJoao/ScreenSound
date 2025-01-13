using System;
using Npgsql;  // Importando o namespace do Npgsql para PostgreSQL
//using ScreenSound.ConnectBanco;
using ScreenSound.Funcoes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ScreenSound.Funcoes
{
    public class MenuCadastro
    {
        string usuario;
        string nomeCompleto;
        string cpf;
        string senha;
        string email;

        public void CadastrarUsuario()
        {
            // String de conexão com o banco de dados PostgreSQL
            ConnectBanco connectBanco = new ConnectBanco();
            var connectionString = connectBanco.GetConnectionString(); // Supondo que você tenha esse método para obter a string de conexão do banco
            MenuUsuarios menuUsuarios = new MenuUsuarios();
            Funcoes funcoes = new Funcoes();

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
                // Conectando ao banco de dados usando Npgsql
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO \"Usuario\" (Usuario, Nome, Senha, CPF, Email) VALUES (@usuario, @nome, @Senha, @CPF, @Email)";

                    using (var command = new NpgsqlCommand(query, connection))
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