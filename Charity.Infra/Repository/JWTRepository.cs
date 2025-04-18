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
    public class JWTRepository:IJWTRepository
    {
        private readonly IDbContext _dbContext;
        public JWTRepository(IDbContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public Userinfo Auth(Userinfo userinfo)
        {
            var p = new DynamicParameters();
            p.Add("username1", userinfo.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass1", userinfo.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Userinfo> result = _dbContext.Connection.Query<Userinfo>("Login_Package.User_Login",
           p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }

}

