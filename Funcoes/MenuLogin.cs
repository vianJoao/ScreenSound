using System;
using BCrypt.Net;

namespace ScreenSound.Funcoes
{
    public class MenuLogin
    {
        string usuario ;
        string senha;

        //
        // hash de senha para um usuário específico
        private string usuarioRegistrado;
        private string senhaHash;

        public void TelaLogin()
        {
            Console.WriteLine("Usuário: ");
            usuario = Console.ReadLine();

            Console.WriteLine("Senha: ");
            senha = Console.ReadLine();

            // Verifica as credenciais
            if (usuario == usuarioRegistrado && BCrypt.Net.BCrypt.Verify(senha, senhaHash))
            {
                Console.WriteLine("Bem-vindo, " + usuario + "!");
            }
            else
            {
                Console.WriteLine("Usuário ou senha inválidos.");
            }
        }
    }
}
