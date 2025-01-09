namespace ScreenSound.Funcoes
{
    public static class MenuBandas
    {
        public static void ExibirOpcoesBandas()
        {
            Console.WriteLine(@"１ － Ａｄｉｃｉｏｎａｒ ｂａｎｄａ： 
２ － Ｌｉｓｔａｒ ｂａｎｄａｓ： 
３ － Ａｖａｌｉａｒ ｂａｎｄａ： 
４ － Ｅｘｉｂｉｒ ｍｅｄｉａ： 
０ － Ｓａｉｒ ｄｏ ｍｅｎｕ：");

            string opcao = Console.ReadLine();
            if (opcao == "0")
            {
                Console.Clear();
                Funcoes funcoes = new Funcoes();
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
