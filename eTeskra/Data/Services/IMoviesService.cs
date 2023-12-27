using eTeskra.Data.Base;
using eTeskra.Data.ViewModels;
using eTeskra.Models;

namespace eTeskra.Data.Services
{
    public interface IMoviesService:IEntityBaseRespository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);

    }
}
