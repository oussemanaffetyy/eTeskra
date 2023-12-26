using eTeskra.Data.Base;
using eTeskra.Models;

namespace eTeskra.Data.Services
{
    public class CinemasService : EntityBaseRespository<Cinema>, ICinemasService
    {

        public CinemasService(AppDbContext context) : base(context) { }
    }
}
