using eTeskra.Data.Base;
using eTeskra.Models;

namespace eTeskra.Data.Services
{
    public class ProducersService : EntityBaseRespository<Producer>, IProducersService
    {
       
        public ProducersService(AppDbContext context) : base(context) { }

    }
}
