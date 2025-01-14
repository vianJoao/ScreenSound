using System;
using System.Data.SQLite; // Biblioteca para conexão com SQLite
using ScreenSound.Usuarios;

class Program
{
    static void Main(string[] args)
    {
        // String de conexão com o banco de dados SQLite
        var connectionString = @"Data Source=C:\Users\joao.viana\source\repos\ScreenSoundAtt\Banco\DbeaverSQLLITE\BancoSQLLITE; Version=3;";

        // Conexão com o banco de dados SQLite
        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                // Abre a conexão com o banco de dados
                connection.Open();
                //Console.WriteLine("Conexão com o banco de dados SQLite inicializada com sucesso!");

                // Exibindo o menu e mensagem inicial
                MenuUsuarios menuUsuarios = new MenuUsuarios();
                Funcoes funcoes = new Funcoes();

                funcoes.ExibirMensagemBoasVindas();
                menuUsuarios.ExibirMenuInicial();

                // O programa continuará rodando até ser encerrado manualmente.
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
            finally
            {
                // Fecha a conexão automaticamente ao sair do escopo do "using"
                Console.WriteLine("Conexão com o banco de dados SQLite encerrada.");
            }
        }
    }
}
