using Dapper;
using Eleva.CADEscola.Domain.Escolas;
using Eleva.CADEscola.Domain.Turmas;
using Eleva.CADEscola.Domain.Turmas.Interfaces;
using Eleva.CADEscola.Infra.Data.Connection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Infra.Data.Repository
{
    public class TurmaRepository : ConnectionDB, ITurmaRepository
    {
        public TurmaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task AdicionarTurma(Turma turma)
        {
            using (IDbConnection con = Connection)
            {
                string sqlCadastrarTurma = @"INSERT INTO TURMAS
                                            (
                                                TURMAID,
                                                NOME,
                                                SALA,
                                                DATAINICIO,
                                                DATAFIM,
                                                LIMITETURMA,
                                                ESCOLAID
                                            )
                                            VALUES
                                            (
                                                @TURMAID,
                                                @NOME,
                                                @SALA,
                                                @DATAINICIO,
                                                @DATAFIM,
                                                @LIMITETURMA,
                                                @ESCOLAID
                                            )";

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosTurma = new DynamicParameters();
                    parametrosTurma.Add("TURMAID", turma.TurmaId, DbType.Guid, ParameterDirection.Input);
                    parametrosTurma.Add("NOME", turma.Nome, DbType.String, ParameterDirection.Input);
                    parametrosTurma.Add("SALA", turma.Sala, DbType.String, ParameterDirection.Input);
                    parametrosTurma.Add("DATAINICIO", turma.DataInicio, DbType.DateTime, ParameterDirection.Input);
                    parametrosTurma.Add("DATAFIM", turma.DataFim, DbType.DateTime, ParameterDirection.Input);
                    parametrosTurma.Add("LIMITETURMA", turma.LimiteTurma, DbType.Int32, ParameterDirection.Input);
                    parametrosTurma.Add("ESCOLAID", turma.EscolaId, DbType.Guid, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlCadastrarTurma, param: parametrosTurma);
                }
                catch (System.Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        public async Task<IEnumerable<Turma>> ObterTurmas()
        {
            using (IDbConnection con = Connection)
            {

                string sqlObterTurmas = @"SELECT
                                                TURM.TURMAID AS TurmaId,
                                                TURM.NOME AS Nome,
                                                TURM.SALA AS Sala,
                                                TURM.DATAINICIO AS DataInicio,
                                                TURM.DATAFIM AS DataFim,
                                                TURM.LIMITETURMA AS LimiteTurma,
                                                TURM.ESCOLAID AS EscolaId,
                                                ESCO.EMAIL AS Email,
                                                ESCO.NOME AS Nome                                              
                                        FROM
                                                TURMAS TURM
                                                INNER JOIN ESCOLAS ESCO
                                                ON ESCO.ESCOLAID = TURM.ESCOLAID
                                        ORDER BY ESCO.NOME, TURM.NOME";

                IEnumerable<Turma> turmas = default(IEnumerable<Turma>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    turmas = await con.QueryAsync<Turma, Escola, Turma>(sqlObterTurmas,
                                            map: (turma, escola) =>
                                            {
                                                turma.NomeEscola = escola.Nome;
                                                return turma;

                                            }, splitOn: "Email");
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return turmas;
            }
        }
    }
}
