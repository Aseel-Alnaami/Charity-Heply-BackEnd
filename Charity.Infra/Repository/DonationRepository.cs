using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Infra.Repository
{
    public class DonationRepository : IDonationRepository
    {
        private readonly IDbContext _dbContext;

        public DonationRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Donation> GetAllDonations()
        {
            IEnumerable<Donation> result = _dbContext.Connection.Query<Donation>
                ("Donations_Package.GetAllDonations", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // استرجاع تبرع حسب الـ ID
        public Donation GetDonationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Donation> result = _dbContext.Connection.Query<Donation>
                ("Donations_Package.GetDonationById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        // إنشاء تبرع جديد
        public void CreateDonation(Donation donation)
        {
            var p = new DynamicParameters();
            p.Add("amount2", donation.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("userId2", donation.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("charityId2", donation.Charityid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Donations_Package.CreateDonation", p, commandType: CommandType.StoredProcedure);
        }

        // تحديث تبرع موجود
        public void UpdateDonation(Donation donation)
        {
            var p = new DynamicParameters();
            p.Add("id", donation.Donationid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("amount2", donation.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("userId2", donation.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("charityId2", donation.Charityid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Donations_Package.UpdateDonation", p, commandType: CommandType.StoredProcedure);
        }

        // حذف تبرع
        public void DeleteDonation(int donationId)
        {
            var p = new DynamicParameters();
            p.Add("id", donationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Donations_Package.DeleteDonation", p, commandType: CommandType.StoredProcedure);
        }

   

    
        public List<DonationWithUserDto> GetAllDonationsWithUsers()
        {
            IEnumerable<DonationWithUserDto> result = _dbContext.Connection.Query<DonationWithUserDto>
                ("Donations_Package.GetAllDonationsWithUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        List<UserDonationsDto> IDonationRepository.GetAllUserDonationsByUserId(int Id)
        {
            var p = new DynamicParameters();
            p.Add("id", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<UserDonationsDto>(
                "Donations_Package.GetUserDonationsByUserId",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

    }
}



