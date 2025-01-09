namespace ScreenSound.Funcoes
{
    public  class MenuBandas
    {
   

        public static void ExibirOpcoesBandas()
        {

            Funcoes funcoes = new Funcoes();
            funcoes.ExibirMensagemBoasVindas();
            Console.WriteLine(@"１ － Ａｄｉｃｉｏｎａｒ ｂａｎｄａ： 
２ － Ｌｉｓｔａｒ ｂａｎｄａｓ： 
３ － Ａｖａｌｉａｒ ｂａｎｄａ： 
４ － Ｅｘｉｂｉｒ ｍｅｄｉａ： 
０ － Ｓａｉｒ ｄｏ ｍｅｎｕ：");

            string opcao = Console.ReadLine();
            if (opcao == "0")
            {
                Console.Clear();
               
                funcoes.ExibirMensagemBoasVindas();
                MenuUsuarios.ExibirMenuInicial();
            }
            else
            {
                Console.WriteLine("Funcionalidade ainda não implementada.");
            }
        }
    }
}
