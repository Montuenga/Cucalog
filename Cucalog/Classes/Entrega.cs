using System;
using Cucalog.Interfaces;

namespace Cucalog.Classes
{
    public class Entrega : IEntrega
    {
        public int Codigo { get; set; }
        public Encomenda Encomenda { get; set; }
        public Veiculo Veiculo { get; set; }
        public Funcionario FuncionarioResponsavel { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Status { get; set; }

        public Entrega(
            int codigo,
            Encomenda encomenda,
            Veiculo veiculo,
            Funcionario funcionarioResponsavel,
            DateTime dataEntrega,
            string status)
        {
            this.Codigo = codigo;
            this.Encomenda = encomenda;
            this.Veiculo = veiculo;
            this.FuncionarioResponsavel = funcionarioResponsavel;
            this.DataEntrega = dataEntrega;
            this.Status = status;
        }

        public void AlterarStatus(string novoStatus)
        {
            this.Status = novoStatus;
        }

        public void RealizarEntrega()
        {
            this.Status = "Entregue";
            Console.WriteLine("Entrega realizada com sucesso!");
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Código da entrega: {Codigo}");
            Console.WriteLine($"Encomenda: {Encomenda.Codigo}");
            Console.WriteLine($"Veículo: {Veiculo.Placa}");
            Console.WriteLine($"Funcionário: {FuncionarioResponsavel.Nome}");
            Console.WriteLine($"Data: {DataEntrega:dd/MM/yyyy}");
            Console.WriteLine($"Status: {Status}");
        }
    }
}