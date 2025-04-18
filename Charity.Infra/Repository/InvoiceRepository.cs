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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDbContext dbContext;

        public InvoiceRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Invoice> GetAllInvoices()
        {
            IEnumerable<Invoice> result = dbContext.Connection.Query<Invoice>
                ("Invoices_Package.GetAllInvoices", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Invoice> result = dbContext.Connection.Query<Invoice>
                ("Invoices_Package.GetInvoiceById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateInvoice(Invoice invoice)
        {
            var p = new DynamicParameters();
            p.Add("userId2", invoice.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("charityId2", invoice.Charityid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("amount2", invoice.Amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("type2", invoice.Type, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Invoices_Package.CreateInvoice", p, commandType: CommandType.StoredProcedure);
        }


        public InvoiceDetailsDto GetInvoiceByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<InvoiceDetailsDto> result = dbContext.Connection.Query<InvoiceDetailsDto>
                ("Invoices_Package.GetInvoiceDetailsByUserID", p, commandType: CommandType.StoredProcedure);

            //return result.FirstOrDefault();
            return result.OrderByDescending(x => x.InvoiceDate).FirstOrDefault();

        }



        InvoiceDetailsDto IInvoiceRepository.GetInvoiceByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<InvoiceDetailsDto> result = dbContext.Connection.Query<InvoiceDetailsDto>
                ("Invoices_Package.GetInvoiceDetailsByUserID", p, commandType: CommandType.StoredProcedure);

            //return result.FirstOrDefault();
            return result.OrderByDescending(x => x.InvoiceDate).FirstOrDefault();
        }

        public InvoiceDetailsDto GetDonationInvoiceByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<InvoiceDetailsDto> result = dbContext.Connection.Query<InvoiceDetailsDto>
                ("Invoices_Package.GetInvoiceDetailsByUserIDD", p, commandType: CommandType.StoredProcedure);

            //return result.FirstOrDefault();
            return result.OrderByDescending(x => x.InvoiceDate).FirstOrDefault();
        }
    }
}



