using amartech.Data;
using amartech.Models.Admin;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace amartech.Repositories
{
    public class ContactUsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactUsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InsertContactUsAsync(ContactUs contact)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", contact.Name),
                new SqlParameter("@Mobile", contact.Mobile),
                new SqlParameter("@Subject", contact.Subject),
                new SqlParameter("@Message", contact.Message),
                new SqlParameter("@CreatedBy", contact.CreatedBy),
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC usp_InsertContactUs @Name, @Mobile, @Subject, @Message, @CreatedBy", parameters);
        }
    }
}
