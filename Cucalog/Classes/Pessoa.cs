using System;

namespace Cucalog.Classes
{
    public class Pessoa
    {
        // Propriedades
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Construtor
        public Pessoa(string nome, string cpf, string telefone, string email)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.Telefone = telefone;
            this.Email = email;
        }

        // Método virtual para permitir polimorfismo
        public virtual void ExibirTipo()
        {
            Console.WriteLine("Pessoa cadastrada.");
        }

        // Método para exibir os dados
        public virtual void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {CPF}");
            Console.WriteLine($"Telefone: {Telefone}");
            Console.WriteLine($"E-mail: {Email}");
        }
    }
}