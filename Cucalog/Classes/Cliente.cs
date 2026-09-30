using System;

namespace Cucalog.Classes
{
    public class Cliente : Pessoa
    {
        // Propriedade específica do cliente
        public string Endereco { get; set; }

        // Construtor
        public Cliente(
            string nome,
            string cpf,
            string telefone,
            string email,
            string endereco)
            : base(nome, cpf, telefone, email)
        {
            this.Endereco = endereco;
        }

        // Sobrescrevendo o método da classe Pessoa
        public override void ExibirTipo()
        {
            Console.WriteLine("Cliente cadastrado.");
        }

        // Exibe os dados do cliente
        public override void ExibirDados()
        {
            base.ExibirDados();
            Console.WriteLine($"Endereço: {Endereco}");
        }
    }
}