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
    public class FAQPageRepository : IFAQPageRepository
    {
        private readonly IDbContext _dbContext;

        public FAQPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FAQPage> GetAllFAQPage()
        {
            IEnumerable<FAQPage> result = _dbContext.Connection.Query<FAQPage>(
                 "FAQPage_PACKAGE.GetAllFAQPage",
                 commandType: CommandType.StoredProcedure
             );
            return result.ToList();
        }

        public void UpdateFAQPage(FAQPage fAQPage)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PFAQId", fAQPage.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PQuestion", fAQPage.Question, DbType.String, ParameterDirection.Input);
            parameters.Add("PAnswer", fAQPage.Answer, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "FAQPage_PACKAGE.UpdateFAQPage",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
