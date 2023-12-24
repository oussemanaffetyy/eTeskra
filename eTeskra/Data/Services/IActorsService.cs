using eTeskra.Models;

namespace eTeskra.Data.Services
{
    public interface IActorsService
    {
        Task <IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        void Delete(int id);
        Actor Update(int id, Actor newActor);

    }
}
