using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharityEntity = Charity.Core.Data.Charity;

namespace Charity.Infra.Repository
{
    public class CharitiesRepository : ICharitiesRepository

    {
        private readonly IDbContext _dbContext;

        public CharitiesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateCharity(CharityEntity charity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PCharityName", charity.Charityname, DbType.String, ParameterDirection.Input);
            parameters.Add("PDescription", charity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("PCharityImg", charity.Charityimg, DbType.String, ParameterDirection.Input);
            parameters.Add("Pgoals", charity.Goals, DbType.String, ParameterDirection.Input);
            parameters.Add("Plocation", charity.Location, DbType.String, ParameterDirection.Input);
            //parameters.Add("Pstatus", charity.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("Ptarget", charity.Target, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PUserID", charity.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PCategoryID", charity.Categoryid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Plongitude", charity.Longitude, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Platitude", charity.Latitude, DbType.Decimal, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Charities_Package.CreateCharity",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }


        public void DeleteCharity(int ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Charities_Package.DeleteCharity",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }



        public List<CharityEntity> GetAllCharities()
        {
            var charities = _dbContext.Connection.Query<CharityEntity, Category, Userinfo, CharityEntity>(
                "Charities_Package.GetAllCharities",
                (charity, category, user) =>
                {
                    charity.Category = category;
                    charity.User = user;
                    return charity;
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Categoryid,Userid"
            ).ToList();

            return charities;
        }


        public void UpdateCharity(CharityEntity charity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", charity.Charityid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PCharityName", charity.Charityname, DbType.String, ParameterDirection.Input);
            parameters.Add("PDescription", charity.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("PCharityImg", charity.Charityimg, DbType.String, ParameterDirection.Input);
            parameters.Add("Pgoals", charity.Goals, DbType.String, ParameterDirection.Input);
            parameters.Add("Plocation", charity.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("Pstatus", charity.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("Ptarget", charity.Target, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PUserID", charity.Userid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PCategoryID", charity.Categoryid, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Plongitude", charity.Longitude, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Platitude", charity.Latitude, DbType.Decimal, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Charities_Package.UpdateCharity",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }




        public void UpdateCharityStatusToPaid(int charityId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PCharityID", charityId, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Charities_Package.UpdateCharityStatusToPaid",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public void AddDonationToCharity(int charityId, decimal donationAmount)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PCharityID", charityId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PDonationAmount", donationAmount, DbType.Decimal, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Charities_Package.AddDonationToCharity",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
        public void GetCharitiesCounts(out int charityCount, out int totalProfit)
        {
            var p = new DynamicParameters();
            p.Add("charity_count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("total_profit", dbType: DbType.Int32, direction: ParameterDirection.Output);



            _dbContext.Connection.Execute(
                "Charities_Package.GetCharitiesCounts",
                p,
                commandType: CommandType.StoredProcedure
            );

            charityCount = p.Get<int>("charity_count");
            totalProfit = p.Get<int>("total_profit");
        }
    }
}
