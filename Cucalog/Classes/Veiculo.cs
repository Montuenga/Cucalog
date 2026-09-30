using System;

namespace Cucalog.Classes
{
    public class Veiculo
    {
        // Propriedades
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public double Capacidade { get; set; }

        // Construtor
        public Veiculo(
            string placa,
            string modelo,
            string marca,
            int ano,
            double capacidade)
        {
            this.Placa = placa;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Ano = ano;
            this.Capacidade = capacidade;
        }

        // Método para exibir os dados
        public void ExibirDados()
        {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Ano: {Ano}");
            Console.WriteLine($"Capacidade: {Capacidade} kg");
        }
    }
}