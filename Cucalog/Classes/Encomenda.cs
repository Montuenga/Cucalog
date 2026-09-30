using System;

namespace Cucalog.Classes
{
    public class Encomenda
    {
        // Propriedades
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Peso { get; set; }
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public Cliente ClienteResponsavel { get; set; }

        // Construtor
        public Encomenda(
            int codigo,
            string descricao,
            double peso,
            Endereco origem,
            Endereco destino,
            Cliente clienteResponsavel)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.Peso = peso;
            this.Origem = origem;
            this.Destino = destino;
            this.ClienteResponsavel = clienteResponsavel;
        }

        // Método para exibir os dados
        public void ExibirDados()
        {
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Peso: {Peso} kg");
            Console.WriteLine($"Cliente: {ClienteResponsavel.Nome}");

            Console.WriteLine("\nEndereço de origem:");
            Origem.ExibirEndereco();

            Console.WriteLine("\nEndereço de destino:");
            Destino.ExibirEndereco();
        }
    }
}