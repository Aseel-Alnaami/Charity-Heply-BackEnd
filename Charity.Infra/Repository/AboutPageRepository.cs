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
    public class AboutPageRepository : IAboutPageRepository
    {
        private readonly IDbContext _dbContext;
        public AboutPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AboutPage GetAboutPage()
        {
            var result = _dbContext.Connection.Query<AboutPage>(
               "ABOUT_PACKAGE.GetAboutPage",
               commandType: CommandType.StoredProcedure
           ).FirstOrDefault();

            return result;
        }

            public void UpdateAboutPage(AboutPage aboutPage)
        {
            var p = new DynamicParameters();
            p.Add("PAboutID", aboutPage.AboutId, DbType.Int32, ParameterDirection.Input);
            p.Add("PHeroImg", aboutPage.HeroImg, DbType.String, ParameterDirection.Input);
            p.Add("PMissionImg", aboutPage.MissionImg, DbType.String, ParameterDirection.Input);
            p.Add("PTEXT1", aboutPage.Text1, DbType.String, ParameterDirection.Input);
            p.Add("PTEXT2", aboutPage.Text2, DbType.String, ParameterDirection.Input);
            p.Add("PTEXT3", aboutPage.Text3, DbType.String, ParameterDirection.Input);
            p.Add("PTEXT4", aboutPage.Text4, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ABOUT_PACKAGE.UpdateAboutPage",
                p,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}