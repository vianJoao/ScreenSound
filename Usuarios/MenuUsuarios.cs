using ScreenSound.Bandas;
using ScreenSound.Usuarios.CadastroELogin;

namespace ScreenSound.Usuarios
{
    public class MenuUsuarios
    {

        MenuCadastro MenuCadastro = new MenuCadastro();
        public void ExibirMenuInicial()
        {
            MenuLogin menuLogin = new MenuLogin();
            Funcoes funcoes = new Funcoes();
            // funcoes.ExibirMensagemBoasVindas();

            Console.WriteLine(@"１ － Ｌｏｇｉｎ： 
２ － Ｃａｄａｓｔｒａｒ Ｕｓｕａｒｉｏ： 
３ － Ｅｓｑｕｅｃｉ ａ Ｓｅｎｈａ： 
０ － Ｍｅｎｕ ｄｅ ｂａｎｄａｓ ｓｅｍ Ｌｏｇｉｎ：");

            string opcao = Console.ReadLine();
            if (int.TryParse(opcao, out int opcaoNumerica))
            {
                switch (opcaoNumerica)
                {
                    case 0:
                        Console.Clear();
                        MenuBandas.ExibirOpcoesBandas();
                        break;
                    case 1:
                        Console.Clear();
                        menuLogin.TelaLogin();
                        break;
                    case 2:
                        Console.Clear();
                        MenuCadastro.CadastrarUsuario();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, digite uma opção válida.");
            }
        }
    }
}

