﻿namespace ScreenSound.Funcoes
    
{
    public  class MenuBandas
    {
   

        public static void ExibirOpcoesBandas()
        {

            Funcoes funcoes = new Funcoes();
            funcoes.ExibirLogo();
            Console.WriteLine(@"１ － Ａｄｉｃｉｏｎａｒ ｂａｎｄａ： 
２ － Ｌｉｓｔａｒ ｂａｎｄａｓ： 
３ － Ａｖａｌｉａｒ ｂａｎｄａ： 
４ － Ｅｘｉｂｉｒ ｍｅｄｉａ： 
０ － Ｓａｉｒ ｄｏ ｍｅｎｕ：");

            string opcao = Console.ReadLine();
            if (int.TryParse(opcao,out int opcaoNumerica)) 
            {
                switch (opcaoNumerica)
                {
                    case 1:Console.Clear();
                        funcoes.ExibirLogo();
                        Console.WriteLine("Informe o nome da banda: ");

                        string nomeBanda = Console.ReadLine();
                        Console.WriteLine("Você adicionou: "+nomeBanda);
                        break;
                    case 2: Console.WriteLine("Aqui teremos uma função para listar todas as bandas");
                        break;
                    case 3: Console.WriteLine("Sera refatorado para um próximo menu");
                       break;
                    case 4: Console.WriteLine("Também será refatorado para um próximo menu");
                       break;
                    case 0:
                       Console.Clear();
                        funcoes.ExibirLogo();
                        MenuUsuarios.ExibirMenuInicial();
                        break;

                }
                
            }
            else
            {
                Console.WriteLine("Funcionalidade ainda não implementada.");
            }
        }
    }
}
