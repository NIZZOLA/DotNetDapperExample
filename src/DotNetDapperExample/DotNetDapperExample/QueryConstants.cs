using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapperExample
{
    public static class QueryConstants
    {
		public static string GetFuncionario = "select * from FUNCIONARIO";

		public static string GetFuncionarioCargo = @"SELECT fun.id FUN_ID,
															fun.*, 
															cg.id  CG_ID,
															CG.*
		
														FROM funcionario fun
														INNER JOIN cargo   cg			ON cg.id = fun.cargoid";

		public static string GetFuncionarioRelated = @"SELECT fun.id FUN_ID,
															fun.*, 
															cg.id  CG_ID,
															CG.*,
															TM.ID  TM_ID,
															TM.*,
															SUP.ID SUP_ID,
															SUP.*

														FROM funcionario fun
														INNER JOIN cargo   cg			ON cg.id = fun.cargoid
														INNER JOIN equipe  tm			ON tm.id = fun.timeid 
														INNER JOIN funcionario sup		ON sup.id = fun.superiorimediatoid ";

		public static string GetEquipe = @"SELECT EQ.ID EQ_ID,
													EQ.*,
													FUN.ID FUN_ID,
													FUN.*
													FROM EQUIPE EQ 
													INNER JOIN FUNCIONARIO FUN ON FUN.TIMEID = EQ.ID ";

		public static string GetMultiple = @"select * from cargo
											 select * from equipe
											 select * from funcionario";

		public static string SomaIntegrantesDaEquipe = @"select dbo.F_ContaEquipe(@equipeId)";

    }
}
