using ScreenSound.Funcoes;

class Program
{
    static void Main(string[] args)
    {
        // Chama a mensagem de boas-vindas e o menu inicial
        Funcoes funcoes = new Funcoes();
        funcoes.ExibirMensagemBoasVindas();
        MenuUsuarios.ExibirMenuInicial();
    }
}
