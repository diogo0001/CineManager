using CineManager.Models;
using System.Threading.Tasks;

namespace CineManager.Data
{
    public interface IRepository
    {
        // General
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Movies
        Task<Movies[]> GetAllMoviesAsync(bool includeSession = true);
        Task<Movies> GetMovieAsyncBySessionId(int sessionId);
        Task<Movies> GetMovieAsyncById(int MovieId, bool includeSession = true);

        //Rooms
        Task<Rooms[]> GetAllRoomsAsync(bool includeSessions = true);

        //Sessions
        Task<Sessions[]> GetAllSessionsAsync(bool includeRoom = true, bool includeMovie = true);
        Task<Sessions> GetSessionAsyncById(int sessionId, bool includeRoom = true, bool includeMovie = true);

        //Users
        Task<Users[]> GetAllUsersAsync();
    }
}
