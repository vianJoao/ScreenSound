using System;
using System.Data.SQLite;

public class ConnectBanco
{
    private readonly string _connectionString;

    // Construtor para inicializar a string de conexão
    public ConnectBanco()
    {
        _connectionString = @"Data Source=C:\Users\joao.viana\source\repos\ScreenSoundAtt\Banco\DbeaverSQLLITE\BancoSQLLITE; Version=3;";
    }

    // Método para abrir e fechar a conexão, verificando o funcionamento
    public void TestarConexao()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados aberta com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Conexão com o banco de dados fechada.");
            }
        }
    }

    // Método para executar um comando SQL e retornar os resultados
    public void ExecutarComando(string query)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            try
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Exemplo: exibe todos os dados das colunas
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar comando SQL: {ex.Message}");
            }
        }
    }
}
