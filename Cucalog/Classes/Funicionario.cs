using System;

namespace Cucalog.Classes
{
    public class Funcionario : Pessoa
    {
        // Propriedade específica do funcionário
        public string Cargo { get; set; }

        // Construtor
        public Funcionario(
            string nome,
            string cpf,
            string telefone,
            string email,
            string cargo)
            : base(nome, cpf, telefone, email)
        {
            this.Cargo = cargo;
        }

        // Sobrescrevendo o método da classe Pessoa
        public override void ExibirTipo()
        {
            Console.WriteLine("Funcionário cadastrado.");
        }

        // Exibe os dados do funcionário
        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine($"Cargo: {Cargo}");
        }
    }
}