﻿using ScreenSound.Bandas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MenuBandasUsuario
    {
        public static void MeuUsuCad()
        {
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
                        funcAddBanda.AddBandainfos();

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

