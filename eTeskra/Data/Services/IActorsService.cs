using eTeskra.Models;

namespace eTeskra.Data.Services
{
    public interface IActorsService
    {
        Task <IEnumerable<Actor>> GetAllAsync();
        Task <Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        void Delete(int id);
        Actor Update(int id, Actor newActor);

    }
}
