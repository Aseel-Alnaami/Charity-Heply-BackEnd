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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IDbContext _dbContext;

        public CategoriesRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCategory(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("category_name", category.Categoryname, DbType.String, ParameterDirection.Input);
            parameters.Add("profit", category.Profit, DbType.Decimal, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Categories_Package.CreateCategory",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public void DeleteCategory(int ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "Categories_Package.DeleteCategory",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public List<Category> GetAllCategories()
        {
            IEnumerable<Category> result = _dbContext.Connection.Query<Category>(
                   "Categories_Package.GetAllCategories",
                   commandType: CommandType.StoredProcedure
               );
            return result.ToList();
        }

        public void UpdateCategory(Category category)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", category.Categoryid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("category_name", category.Categoryname, DbType.String, ParameterDirection.Input);
            parameters.Add("profit2", category.Profit, DbType.Int16, ParameterDirection.Input);



            var result = _dbContext.Connection.Execute("Categories_Package.UpdateCategory", parameters, commandType: CommandType.StoredProcedure);

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
