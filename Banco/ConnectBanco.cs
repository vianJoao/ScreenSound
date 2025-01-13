using System;
using Npgsql; // Importando o namespace correto para PostgreSQL

public class ConnectBanco
{
    // String de conexão com o banco de dados PostgreSQL
    private readonly string _connectionString;

    // Construtor da classe, permite injetar uma string de conexão personalizada
    public ConnectBanco(string connectionString = null)
    {
        _connectionString = connectionString ??
                            "Host=db.rgogpdgqapophdiwodqg.supabase.co;Database=postgres;Username=postgres;Password=Lilian030124@@;SSL Mode=Require;Trust Server Certificate=true";
    }

    // Método para se conectar ao banco de dados e verificar a versão
    public void Connect()
    {
        try
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            Console.WriteLine("Conectado ao banco de dados!");

            // Executa uma consulta SQL simples para verificar a versão do banco de dados
            using var cmd = new NpgsqlCommand("SELECT version()", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Versão do PostgreSQL: {reader.GetString(0)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");
        }
    }

    // Método genérico para executar comandos SQL que não retornam resultados (e.g., INSERT, UPDATE, DELETE)
    public void ExecuteCommand(string sql)
    {
        try
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine($"Comando executado com sucesso! Linhas afetadas: {rowsAffected}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar comando SQL: {ex.Message}");
        }
    }

    // Método genérico para executar comandos SQL que retornam resultados (e.g., SELECT)
    public void ExecuteQuery(string sql)
    {
        try
        {
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}\t");
                }
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar consulta SQL: {ex.Message}");
        }
    }

    // Método para obter a string de conexão (caso seja necessário para outros usos)
    public string GetConnectionString()
    {
        return _connectionString;
    }
}
