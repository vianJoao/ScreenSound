using ScreenSound.API.Mail.ApiMailFunction;
using ScreenSound.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound.API;

namespace ScreenSound.Bandas
{
    public class FuncAddBanda
    {
        public (string, List<string>) AddBandainfos() // Mudado para retornar uma tupla
        {
            var connectionString = @"Data Source=C:\Users\joao.viana\source\repos\ScreenSoundAtt\Banco\DbeaverSQLLITE\BancoSQLLITE; Version=3;";

            EmailSender emailSender = new EmailSender();
            MenuUsuarios menuUsuarios = new MenuUsuarios();

            Console.WriteLine("Deseja adicionar uma banda e suas informações?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            string resposta = Console.ReadLine();

            if (resposta == "1")
            {
                Console.WriteLine("Informe o nome da banda: ");
                string nomeBanda = Console.ReadLine();

                Console.WriteLine("Qual o gênero da banda?");
                string generoBanda = Console.ReadLine();

                Console.WriteLine("Informe um álbum da banda: ");
                string albumBanda = Console.ReadLine();

                Console.WriteLine($"Quantas faixas tem o álbum {albumBanda}?");
                if (!int.TryParse(Console.ReadLine(), out int faixasAlbum) || faixasAlbum <= 0)
                {
                    Console.WriteLine("Número de faixas inválido. Operação cancelada.");
                    return ("", new List<string>());
                }

                Console.WriteLine("Quantas dessas faixas você deseja adicionar?");
                if (!int.TryParse(Console.ReadLine(), out int faixasAdd) || faixasAdd <= 0)
                {
                    Console.WriteLine("Número inválido. Operação cancelada.");
                    return ("", new List<string>());
                }

                if (faixasAdd > faixasAlbum)
                {
                    Console.WriteLine("Você não pode adicionar mais faixas do que o álbum possui.");
                    return ("", new List<string>());
                }

                List<string> musicas = new List<string>();

                for (int i = 1; i <= faixasAdd; i++)
                {
                    Console.WriteLine($"Música {i}: ");
                    string nomeMusica = Console.ReadLine();
                    musicas.Add(nomeMusica);
                    Console.WriteLine("Duração: ");
                    string duracao = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("Banda e músicas adicionadas com sucesso!");

                try
                {
                    using (var connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        // Adiciona a banda
                        string queryBanda = "INSERT INTO Bandas (Nome, Genero) VALUES (@NomeBanda, @GeneroBanda)";
                        using (var command = new SQLiteCommand(queryBanda, connection))
                        {
                            command.Parameters.AddWithValue("@NomeBanda", nomeBanda);
                            command.Parameters.AddWithValue("@GeneroBanda", generoBanda);
                            command.ExecuteNonQuery();
                        }

                        // Adiciona as músicas
                        foreach (var musica in musicas)
                        {
                            // Aqui você deve pedir a duração de cada música.
                            Console.WriteLine($"Duração da música {musica}: ");
                            string duracao = Console.ReadLine();

                            string queryMusica = "INSERT INTO Musicas (Nome, Album, Banda, duracao) VALUES (@NomeMusica, @Album, @Banda, @Duracao)";
                            using (var command = new SQLiteCommand(queryMusica, connection))
                            {
                                command.Parameters.AddWithValue("@NomeMusica", musica);
                                command.Parameters.AddWithValue("@AlbumBanda", albumBanda);
                                command.Parameters.AddWithValue("@NomeBanda", nomeBanda);
                                command.Parameters.AddWithValue("@duracao", duracao);
                                command.ExecuteNonQuery();
                            }
                        }

                        Console.WriteLine("Banda e músicas salvas no banco de dados com sucesso!");

                        // Retorna uma tupla com nomeBanda e musicas
                        return (nomeBanda, musicas);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar no banco de dados: {ex.Message}");
                }

                // Exibe o menu inicial novamente
                menuUsuarios.ExibirMenuInicial();
                return ("", new List<string>());
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
                menuUsuarios.ExibirMenuInicial();
                return ("", new List<string>());
            }
        }
    }
}
