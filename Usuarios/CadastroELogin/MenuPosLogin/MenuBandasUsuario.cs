using ScreenSound.Bandas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.API;
using ScreenSound.API.Mail.ApiMailFunction;

// Classe para adicionar banda e informações quando se está logado como usuário.
public class MenuBandasUsuario
    {
    public static void MeuUsuCad()
        {

        EmailSender emailSender = new EmailSender();
        FuncAddBanda funcAddBanda = new FuncAddBanda();
        Funcoes funcoes = new Funcoes();
        
        funcoes.ExibirLogo();
        Console.WriteLine(@"1 - Adicionar banda:
2 - Listar bandas: 
3 - Avaliar banda:
4 - Avaliar música:
5 - Exibir média: 
0 - Sair do menu: ");

            string opcao = Console.ReadLine();
            if (int.TryParse(opcao, out int opcaoNumerica))
            {
                switch (opcaoNumerica)
                {
                    case 1:
                        Console.Clear();
                        funcoes.ExibirLogo();
                        var (nomeBanda, musicas) = funcAddBanda.AddBandainfos();
                    if (!string.IsNullOrEmpty(nomeBanda) && musicas != null && musicas.Count > 0)
                    {
                        emailSender.RegistraAdicoes("Joao.viana","viana.joaovi@outlook.com.br",nomeBanda, musicas); // Passa os valores para o método
                    }

                    break;
                    case 2:
                        Console.WriteLine("Aqui teremos uma função para listar todas as bandas");
                        break;
                    case 3:
                        Console.WriteLine("Sera refatorado para um próximo menu");
                        break;
                    case 4:
                        Console.WriteLine("Também será refatorado para um próximo menu");
                        break;
                    case 0:
                        Console.Clear();
                        funcoes.ExibirLogo();
                        // orx MenuUsuarios.ExibirMenuInicial();
                        break;
                    
                }

            }
            else
            {
                Console.WriteLine("Funcionalidade ainda não implementada.");
            }
        }
    }

