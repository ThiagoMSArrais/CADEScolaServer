using Dapper;
using Eleva.CADEscola.Domain.Escolas;
using Eleva.CADEscola.Domain.Escolas.Interfaces;
using Eleva.CADEscola.Domain.Turmas;
using Eleva.CADEscola.Infra.Data.Connection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Eleva.CADEscola.Infra.Data.Repository
{
    public class EscolaRepository : ConnectionDB, IEscolaRepository
    {
        public EscolaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task AdicionarEscola(Escola escola)
        {
            using (IDbConnection con = Connection)
            {

                string sqlCadastrarEscola = @"INSERT INTO ESCOLAS
                                            (
                                                ESCOLAID,
                                                NOME,
                                                EMAIL,
                                                TELEFONE
                                            )
                                            VALUES
                                            (
                                                @ESCOLAID,
                                                @NOME,
                                                @EMAIL,
                                                @TELEFONE
                                            )";

                


                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosEscola = new DynamicParameters();
                    parametrosEscola.Add("ESCOLAID", escola.EscolaId, DbType.Guid, ParameterDirection.Input);
                    parametrosEscola.Add("NOME", escola.Nome, DbType.String, ParameterDirection.Input);
                    parametrosEscola.Add("EMAIL", escola.Email, DbType.String, ParameterDirection.Input);
                    parametrosEscola.Add("TELEFONE", escola.Telefone, DbType.String, ParameterDirection.Input);

                    await con.ExecuteAsync(sqlCadastrarEscola, param: parametrosEscola);

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
            }
        }

        public async Task<IEnumerable<Escola>> ObterEscolas()
        {
            using (IDbConnection con = Connection)
            {

                var escolaDictionary = new Dictionary<Guid, Escola>();

                string sqlObterEscolas = @"SELECT 
                                                    ESCO.ESCOLAID AS EscolaId,
                                                    ESCO.NOME AS Nome,
                                                    ESCO.EMAIL AS Email,
                                                    ESCO.TELEFONE AS Telefone,
                                                    TURM.TURMAID AS TurmaId,
                                                    TURM.NOME AS Nome,
                                                    TURM.SALA AS Sala,
                                                    TURM.DATAINICIO AS DataInicio,
                                                    TURM.DATAFIM AS DataFim,
                                                    TURM.LIMITETURMA AS LimiteTurma
                                            FROM
                                                    ESCOLAS ESCO
                                                    LEFT JOIN TURMAS TURM
                                                    ON ESCO.ESCOLAID = TURM.ESCOLAID
                                            ORDER BY ESCO.NOME";

                IEnumerable<Escola> escolas = default(IEnumerable<Escola>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();


                    escolas = await con.QueryAsync<Escola, Turma, Escola>(sqlObterEscolas,
                                         map: (escola, turma) =>
                                         {
                                             Escola escolaEntry;

                                             if (!escolaDictionary.TryGetValue(escola.EscolaId, out escolaEntry))
                                             {
                                                 escolaEntry = escola;
                                                 escolaEntry.Turmas = new List<Turma>();
                                                 escolaDictionary.Add(escolaEntry.EscolaId, escolaEntry);
                                             }

                                             escolaEntry.Turmas.Add(turma);
                                             return escolaEntry;

                                         }, splitOn: "TurmaId");
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

                return escolas.Distinct().ToList();
            }
        }
    }
}
