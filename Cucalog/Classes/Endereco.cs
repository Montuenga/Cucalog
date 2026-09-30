using System;

namespace Cucalog.Classes
{
    public class Endereco
    {
        // Propriedades
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }

        // Construtor
        public Endereco(
            string rua,
            string numero,
            string bairro,
            string cidade,
            string cep)
        {
            this.Rua = rua;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.CEP = cep;
        }

        // Método para exibir o endereço
        public void ExibirEndereco()
        {
            Console.WriteLine($"Rua: {Rua}");
            Console.WriteLine($"Número: {Numero}");
            Console.WriteLine($"Bairro: {Bairro}");
            Console.WriteLine($"Cidade: {Cidade}");
            Console.WriteLine($"CEP: {CEP}");
        }

        // Retorna o endereço completo em texto
        public override string ToString()
        {
            return $"{Rua}, {Numero} - {Bairro} - {Cidade} - CEP: {CEP}";
        }
    }
}