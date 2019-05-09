using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string dbName = "Tournaments";
        // TODO: Wire up the CreatePrize for sql database
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var p = new Dapper.DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");
            }
            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var p = new Dapper.DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spPersons_Insert", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");
            }
            return model;
        }

        public List<PersonModel> GetPerson_ALL()
        {
            List<PersonModel> models;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                models = connection.Query<PersonModel>("dbo.spPersons_GetAll").ToList();
            }
            return models;
        }

        public TeamModel CreateTeam(TeamModel teamModel)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(dbName)))
            {
                var p = new Dapper.DynamicParameters();
                p.Add("@TeamName", teamModel.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);
                teamModel.Id = p.Get<int>("@id");

                foreach (PersonModel member in teamModel.TeamMembers)
                {
                    var m = new Dapper.DynamicParameters();
                    m.Add("@TeamId", teamModel.Id);
                    m.Add("@PersonId", member.Id);
                    connection.Execute("dbo.spTeamMembers_Insert", m, commandType: CommandType.StoredProcedure);
                    //member.Id = m.Get<int>("@id");
                }
            }
            return teamModel;
        }
    }
}
