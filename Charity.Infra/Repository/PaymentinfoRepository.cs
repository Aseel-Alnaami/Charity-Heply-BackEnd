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
    public class PaymentinfoRepository : IPaymentinfoRepository
    {
        private readonly IDbContext dbContext;

        public PaymentinfoRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Paymentinfo> GetAllPayments()
        {
            IEnumerable<Paymentinfo> result = dbContext.Connection.Query<Paymentinfo>(
                "PaymentInfo_Package.GetAllPayments", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreatePayment(Paymentinfo payment)
        {
            var p = new DynamicParameters();

            p.Add("Card_Number", payment.Cardnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CVV_Number", payment.Cvvnumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Balance", payment.Balance, dbType: DbType.Int16, direction: ParameterDirection.Input);
            p.Add("Created_Date", payment.Createddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("PaymentInfo_Package.CreatePayment", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePayment(int cardId)
        {
            var p = new DynamicParameters();
            p.Add("Card_ID", cardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("PaymentInfo_Package.DeletePayment", p, commandType: CommandType.StoredProcedure);
        }

        public Paymentinfo GetPaymentById(int cardId)
        {
            var p = new DynamicParameters();
            p.Add("Card_ID", cardId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Paymentinfo> result = dbContext.Connection.Query<Paymentinfo>(
                "PaymentInfo_Package.GetPaymentById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public bool MakePayment(string cardNumber, string cvvNumber, decimal amount)
        {
            var p = new DynamicParameters();
            p.Add("Card_Number", cardNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CVV_Number", cvvNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Amount", amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            try
            {
                dbContext.Connection.Execute("PaymentInfo_Package.MakePayment", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                // لو في خطأ مثل insufficient balance or invalid card, نرجع false
                return false;
            }
        }

    }
}