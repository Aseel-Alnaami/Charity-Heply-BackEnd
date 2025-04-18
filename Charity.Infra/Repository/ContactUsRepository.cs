using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Infra.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbContext _dbContext;

        public ContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateContact(Contactu contact)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", contact.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("email", contact.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("message", contact.Message, DbType.String, ParameterDirection.Input);
            parameters.Add("status", contact.Status, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ContactUs_Package.CreateContact",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public void DeleteContact(int ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ID", ID, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute(
                "ContactUs_Package.DeleteContact",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public List<Contactu> GetAllContacts()
        {
            IEnumerable<Contactu> result = _dbContext.Connection.Query<Contactu>(
                 "ContactUs_Package.GetAllContacts",
                 commandType: CommandType.StoredProcedure
             );
            return result.ToList();
        }

        public List<Contactu> GetContactsByStatus(string status)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Contact_status", status, DbType.String, ParameterDirection.Input);

            IEnumerable<Contactu> result = _dbContext.Connection.Query<Contactu>(
                "ContactUs_Package.GetContactByStatus",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result.ToList();
        }

        public void ReplyToContact(int contactId, string replyMessage)
        {
            var contact = _dbContext.Connection.QueryFirstOrDefault<Contactu>(
                "SELECT * FROM ContactUs WHERE ContactId = :id", new { id = contactId });

            if (contact != null)
            {
                // Update status
                var parameters = new DynamicParameters();
                parameters.Add("id", contactId);
                parameters.Add("status", "Sent");
                _dbContext.Connection.Execute("UPDATE ContactUs SET Status = :status WHERE ContactId = :id", parameters);

                // Send email using App Password
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("companyhelpy@gmail.com", "krck bcwl thtj qspy"),  // استخدام كلمة مرور التطبيقات
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage("companyhelpy@gmail.com", contact.Email)
                {
                    Subject = "Reply to your inquiry",
                    Body = replyMessage,
                    IsBodyHtml = false,
                };

                smtpClient.Send(mailMessage);
            }
        }



    }
}
