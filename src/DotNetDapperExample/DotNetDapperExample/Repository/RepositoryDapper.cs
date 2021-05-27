using Dapper;
using EmpregadosDomain.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapperExample
{
    public class RepositoryDapper
    {
        private string strConn = "Server=localhost,1433;Database=DapperExample;User Id=sa;Password=Orch3str4#;Application Name=DapperExample;Trusted_Connection=false;MultipleActiveResultSets=true";


        public ICollection<FuncionarioModel> GetFuncionarioAll()
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var funList = db.Query<FuncionarioModel>(QueryConstants.GetFuncionario).ToList();
                return funList;
            }
        }

        public ICollection<FuncionarioModel> GetFuncionarioAllCargo()
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var funList = db.Query<FuncionarioModel, CargoModel, FuncionarioModel>(QueryConstants.GetFuncionarioCargo,
                    (funcio, cargo) =>
                    {
                        funcio.Cargo = cargo;
                        return funcio;
                    }, splitOn: "FUN_ID,CG_ID").ToList();

                return funList;
            }
        }

        public ICollection<FuncionarioModel> GetFuncionarioAllRelated()
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                var funList = db.Query<FuncionarioModel, CargoModel, EquipeModel, FuncionarioModel, FuncionarioModel>(QueryConstants.GetFuncionarioRelated,
                    (funcio, cargo, time, superior) =>
                    {
                        funcio.Cargo = cargo;
                        funcio.Time = time;
                        funcio.SuperiorImediato = superior;
                        return funcio;
                    }, splitOn: "FUN_ID,CG_ID,TM_ID,SUP_ID").ToList();

                return funList;
            }
        }

        public ICollection<EquipeModel> GetEquipeAll()
        {
            Dictionary<int, EquipeModel> listEquipes = new Dictionary<int, EquipeModel>();

            using (IDbConnection db = new SqlConnection(strConn))
            {
                var funList = db.Query<EquipeModel, FuncionarioModel, EquipeModel>(QueryConstants.GetEquipe,
                    (equipe, funcionario) =>
                    {
                        if( listEquipes.TryGetValue(equipe.Id, out EquipeModel equipeItem))
                        {
                            equipeItem.Integrantes.Add(funcionario);
                        }
                        else
                        {
                            equipe.Integrantes = new List<FuncionarioModel>();
                            if( funcionario != null)
                                equipe.Integrantes.Add(funcionario);

                            listEquipes.Add(equipe.Id,equipe);
                        }
                        return equipe;

                    }, splitOn: "EQ_ID,FUN_ID");

                return listEquipes.Values;
            }
        }

        public void GetMultiple()
        {
            using (IDbConnection db = new SqlConnection(strConn))
            {
                using (var multi = db.QueryMultiple(QueryConstants.GetMultiple ))
                {
                    var listFun = multi.Read<FuncionarioModel>().ToList();
                    var listCargo = multi.Read<CargoModel>().ToList();
                    var equipe = multi.Read<EquipeModel>().ToList();
                }
                
            }
        }

        public int ContaMembrosDaEquipe(int equipeId)
        {
            using(IDbConnection db = new SqlConnection(strConn))
            {
                var result = db.QuerySingle<int>(QueryConstants.SomaIntegrantesDaEquipe, new { @equipeId = equipeId });
                return result;
            }
        }

    }
}
