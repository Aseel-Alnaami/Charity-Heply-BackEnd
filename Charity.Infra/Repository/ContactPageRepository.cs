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
    public class ContactPageRepository : IContactPageRepository
    {
        private readonly IDbContext _dbContext;

        public ContactPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ContactPage> GetAllcontactPage()
        {
            IEnumerable<ContactPage> result = _dbContext.Connection.Query<ContactPage>(
                 "contactPage_PACKAGE.GetAllcontactPage",
                 commandType: CommandType.StoredProcedure
             );
            return result.ToList();
        }

        public void UpdatecontactPage(ContactPage contactPage)
        {
            var parameters = new DynamicParameters();
            parameters.Add("PcontactId", contactPage.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Ptitle1", contactPage.Title1, DbType.String, ParameterDirection.Input);
            parameters.Add("Ptitle2", contactPage.Title2, DbType.String, ParameterDirection.Input);
            parameters.Add("Plocation", contactPage.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("PphoneNumber", contactPage.Phonenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Pemail", contactPage.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("PheroImg", contactPage.Heroimg, DbType.String, ParameterDirection.Input);;

            _dbContext.Connection.Execute(
                "contactPage_PACKAGE.UpdatecontactPage",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
