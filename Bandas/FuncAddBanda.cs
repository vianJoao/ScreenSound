using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Bandas
{
    public class FuncAddBanda
    {
        public void AddBandainfos()
        {

            Console.WriteLine("Deseja Adicionar a banda e informacoes?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            string resposta = Console.ReadLine();
            if (resposta == "1")
            {
                Console.WriteLine("Informe o nome da banda: ");
                string nomeBanda = Console.ReadLine();
                Console.WriteLine("Você adicionou: " + nomeBanda);
                Console.WriteLine("Informe um album da banda: ");
                string albumBanda = Console.ReadLine();
                Console.WriteLine("Quantas faixas tem o álbum " + albumBanda + "?");
                int faixasAlbum = int.Parse(Console.ReadLine());
                Console.WriteLine("Quantas dessas faixas você deseja adicionar?");

                int faixasAdd = int.Parse(Console.ReadLine());
                if (faixasAdd > faixasAlbum)
                {
                    Console.WriteLine("Você não pode adicionar mais faixas do que o álbum possui.");
                }
                else if (faixasAdd <= faixasAlbum)
                {
                    Console.WriteLine("Digite o nome das músicas: ");
                    foreach (int i in Enumerable.Range(1, faixasAdd))
                    {
                        Console.WriteLine("Música " + i + ": ");
                        string nomeMusica = Console.ReadLine();
                        Console.WriteLine("Você adicionou a música " + nomeMusica);

                    }
                    Console.Clear();
                    Console.WriteLine("Banda e músicas adicionadas com sucesso!");

                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine("Obrigado por usar o ScreenSound");
            }
        }
    }
}
