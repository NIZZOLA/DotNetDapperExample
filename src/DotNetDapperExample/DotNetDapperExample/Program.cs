using Microsoft.Extensions.DependencyInjection;
using System;

namespace DotNetDapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new RepositoryDapper();
/*
            
            var userList = repo.GetAll();

            foreach (var item in userList)
            {
                Console.WriteLine(item.Nome);
            }

            var userCargo = repo.GetAllCargo();
            foreach (var item in userCargo)
            {
                Console.WriteLine(item.Nome + " - " + item.Cargo.NomeDoCargo);
            }

            var userCompleto = repo.GetFuncionarioAllRelated();
            foreach (var item in userCompleto)
            {
                Console.WriteLine(item.Nome + " - " + item.Cargo.NomeDoCargo);
            }
*/

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


            Console.WriteLine("Hello World!");
        }
    }
}
