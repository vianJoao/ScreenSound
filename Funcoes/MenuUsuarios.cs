namespace ScreenSound.Funcoes
{
    public static class MenuUsuarios
    {
        public static void ExibirMenuInicial()
        {
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
                    case 2:
                        CadastrarUsuario();
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

        private static void CadastrarUsuario()
        {
            string usuario;
            string nomeCompleto;
            string senha;
            string email;

            Console.WriteLine("Digite seu nome completo: ");
            nomeCompleto = Console.ReadLine();
            Console.WriteLine("Digite seu nome de usuário: ");
            usuario = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            email = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            senha = Console.ReadLine();

            Console.WriteLine($"Usuário {nomeCompleto} cadastrado com sucesso!");
        }
    }
}
