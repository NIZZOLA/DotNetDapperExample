using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNetDapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new RepositoryDapper();

            /*  CONSULTANDO UMA ENTIDADE SIMPLES  */
            var userList = repo.GetFuncionarioAll();
            Console.WriteLine("Consulta 1");
            foreach (var item in userList)
            {
                Console.WriteLine(item.Nome);
            }


            /*   CONSULTANDO UMA ENTIDADE SIMPLES + UM RELACIONAMENTO 1 X 1   */
            Console.WriteLine("Consulta 2");
            var userCargo = repo.GetFuncionarioAllCargo();
            foreach (var item in userCargo)
            {
                Console.WriteLine(item.Nome + " - " + item.Cargo.NomeDoCargo);
            }


            /* CONSULTANDO UMA ENTIDADE SIMPLES + ALGUNS RELACIONAMENTOS 1 X 1   E AUTO RELAÇÃO */
            Console.WriteLine("Consulta 3");
            var userCompleto = repo.GetFuncionarioAllRelated();
            foreach (var item in userCompleto)
            {
                Console.WriteLine(item.Nome + " - Cargo: " + item.Cargo.NomeDoCargo + " - Time: " + item.Time.Nome + " Superior: " + item.SuperiorImediato?.Nome);
            }

            /*  CONSULTANDO UMA ENTIDADE COM RELAÇÃO DE 1 PARA MUITOS   */
            Console.WriteLine("Consulta 4");
            var equipes = repo.GetEquipeAll();
            foreach (var equipe in equipes)
            {
                Console.WriteLine("\n Equipe:" + equipe.Nome);
                Console.WriteLine("------------------------------------------");
                foreach (var integrante in equipe.Integrantes)
                {
                    Console.WriteLine("\n " + integrante.Nome);
                }
            }

            // executa múltiplas consultas de entidades
            repo.GetMultiple();
            
            // execução de funções
            Console.WriteLine( "A equipe possui:" + repo.ContaMembrosDaEquipe(1) );

        }
    }
}
