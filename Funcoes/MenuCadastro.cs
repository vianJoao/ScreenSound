using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Funcoes
{
    public class MenuCadastro
    {
        string usuario;
        string nomeCompleto;
        string cpf;
        string senha;
        string email;
        
        public void CadastrarUsuario()
        {
            Funcoes funcoes = new Funcoes();
           
            Console.Clear();
            funcoes.ExibirLogo();
            Console.WriteLine("Digite seu nome completo: ");
            nomeCompleto = Console.ReadLine();
            Console.WriteLine("Digite seu nome de usuário: ");
            usuario = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            email = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            senha = Console.ReadLine();
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
            Console.WriteLine($"Senha hasheada: {senhaHash}");
            
           // Console.Clear();

            //funcoes.ExibirLogo();
            //Console.WriteLine($"Usuário {nomeCompleto} cadastrado com sucesso!");
        }
    }
}
