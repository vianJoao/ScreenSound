using ScreenSound.Funcoes;

class Program
{
    static void Main(string[] args)
    {
        MenuUsuarios menuUsuarios = new MenuUsuarios();
        Funcoes funcoes = new Funcoes();
        funcoes.ExibirMensagemBoasVindas();
        menuUsuarios.ExibirMenuInicial();
    }
}
