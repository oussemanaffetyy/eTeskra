using eTeskra.Data.Base;
using eTeskra.Models;
using Microsoft.EntityFrameworkCore;

namespace eTeskra.Data.Services
{
    public class ActorsService :EntityBaseRespository<Actor>, IActorsService
    {
       
        public ActorsService(AppDbContext context): base(context) { }
      
    }
}
