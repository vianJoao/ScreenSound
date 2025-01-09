using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Funcoes;
    public class Funcoes
{
    string mensagemDeBoasVindas = "Boas Vindas ao ScreenSound";
    public void ExibirLogo() // Função de exibição de logo
    
    {
        Console.WriteLine(@" 
███████████████████████████████████████████████████████████████████████
█─▄▄▄▄█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─▄▄─█▄─▀█▄─▄█─▄▄▄▄█─▄▄─█▄─██─▄█▄─▀█▄─▄█▄─▄▄▀█
█▄▄▄▄─█─███▀██─▄─▄██─▄█▀██─▄█▀██─█▄▀─██▄▄▄▄─█─██─██─██─███─█▄▀─███─██─█
▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▀▀▄▄▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▀▀");
    }

    public void ExibirMensagemBoasVindas() //Função
    {
        //Colocar o '@' antes das aspas para Verbatim Literal e poder colocar a string da forma que quer que apareça.
        ExibirLogo();
        Console.WriteLine("");
        Console.WriteLine(mensagemDeBoasVindas);
    }

}
