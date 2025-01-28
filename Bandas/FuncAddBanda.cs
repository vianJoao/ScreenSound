using ScreenSound.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Bandas
{
    public class FuncAddBanda
    {
        public void AddBandainfos()
        {
            var connectionString = @"Data Source=C:\Users\joao.viana\source\repos\ScreenSoundAtt\Banco\DbeaverSQLLITE\BancoSQLLITE; Version=3;";

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
                    return;
                }

                Console.WriteLine("Quantas dessas faixas você deseja adicionar?");
                if (!int.TryParse(Console.ReadLine(), out int faixasAdd) || faixasAdd <= 0)
                {
                    Console.WriteLine("Número inválido. Operação cancelada.");
                    return;
                }

                if (faixasAdd > faixasAlbum)
                {
                    Console.WriteLine("Você não pode adicionar mais faixas do que o álbum possui.");
                    return;
                }

                List<string> musicas = new List<string>();

                for (int i = 1; i <= faixasAdd; i++)
                {
                    Console.WriteLine($"Música {i}: ");
                    string nomeMusica = Console.ReadLine();
                    musicas.Add(nomeMusica);
                    Console.WriteLine("Duracao: ");
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

                            int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL
                        
                        }
                       
                        // Adiciona as músicas
                        foreach (var musica in musicas)  foreach (var duracao in musicas) { 
                        
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

                        Console.WriteLine("Banda e músicas salvas no banco de dados com sucesso!" );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar no banco de dados: {ex.Message}");
                }

                // Exibe o menu inicial novamente
                menuUsuarios.ExibirMenuInicial();
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
                menuUsuarios.ExibirMenuInicial();
            }
        }
    }
}
