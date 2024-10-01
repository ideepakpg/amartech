using amartech.Data;
using amartech.Models.Admin;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace amartech.Repositories
{
    public class RequestPricingRepository
    {
        private readonly AmartechDbContext _context;

        public RequestPricingRepository(AmartechDbContext context)
        {
            _context = context;
        }

        public async Task InsertPricingRequestAsync(PricingRequest request)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", request.Name),
                new SqlParameter("@Email", request.Email),
                new SqlParameter("@Mobile", request.Mobile),
                new SqlParameter("@Service", request.Service),
                new SqlParameter("@SpecialNote", request.SpecialNote),
                new SqlParameter("@CreatedBy", request.CreatedBy),
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC usp_InsertPricingRequest @Name, @Email, @Mobile, @Service, @SpecialNote, @CreatedBy", parameters);
        }
    }
}
