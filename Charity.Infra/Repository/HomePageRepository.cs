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

namespace Charity.Infra.Repository
{
    public class HomePageRepository : IHomePageRepository
    {
        private readonly IDbContext _dbContext;

        public HomePageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<HomePage> GetAllhomePage()
        {
            IEnumerable<HomePage> result = _dbContext.Connection.Query<HomePage>(
                 "homePage_PACKAGE.GetAllhomePage",
                 commandType: CommandType.StoredProcedure
             );
            return result.ToList();
        }

        public void UpdatehomePage(HomePage homePage)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PhomeId", homePage.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Ptitle1", homePage.Title1, DbType.String, ParameterDirection.Input);
            parameters.Add("Ptitle2", homePage.Title2, DbType.String, ParameterDirection.Input);
            parameters.Add("PheroImg", homePage.Heroimg, DbType.String, ParameterDirection.Input); ;

            _dbContext.Connection.Execute(
                "homePage_PACKAGE.UpdatehomePage",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
