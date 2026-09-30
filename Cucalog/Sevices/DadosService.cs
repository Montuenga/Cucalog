using System;
using System.IO;

namespace Cucalog.Services
{
    public class DadosService
    {
        private readonly string caminhoArquivo = "dados.txt";

        public void Salvar(string dados)
        {
            try
            {
                File.WriteAllText(caminhoArquivo, dados);

                Console.WriteLine("Dados salvos com sucesso!");
                Console.WriteLine("Arquivo: " + caminhoArquivo);
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao salvar os dados.");
                Console.WriteLine("Detalhes: " + erro.Message);
            }
        }

        public string Carregar()
        {
            try
            {
                if (!File.Exists(caminhoArquivo))
                {
                    Console.WriteLine("Arquivo de dados não encontrado.");
                    return "";
                }

                return File.ReadAllText(caminhoArquivo);
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao carregar os dados.");
                Console.WriteLine("Detalhes: " + erro.Message);

                return "";
            }
        }
    }
}