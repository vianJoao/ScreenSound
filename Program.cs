using ScreenSound.Funcoes;
//using ScreenSound.ConnectBanco;  // Importando o namespace correto para ConnectBanco

class Program
{
    static void Main(string[] args)
    {
        // Exibindo o menu e mensagem inicial
        MenuUsuarios menuUsuarios = new MenuUsuarios();
        Funcoes funcoes = new Funcoes();
        funcoes.ExibirMensagemBoasVindas();
        menuUsuarios.ExibirMenuInicial();

        // Conexão com o banco de dados PostgreSQL
        try
        {
            ConnectBanco connectBanco = new ConnectBanco();
            connectBanco.Connect(); // Chama o método Connect para testar a conexão com o banco
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
        }
    }
}
