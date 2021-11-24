using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineManager.Models;
using Microsoft.EntityFrameworkCore;


namespace CineManager.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;
        }

        // General
        public void Add<T>(T entity) where T : class
        {
             _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        // Movie
        public async Task<Movies[]> GetAllMoviesAsync(bool includeSessions = true)
        {
            IQueryable<Movies> query = _context.Movies;

            if (includeSessions)
            {
                query = query.Include(Movie => Movie.Sessions);
            }

            query = query.AsNoTracking().OrderBy(Movie => Movie.MovieId);

            return await query.ToArrayAsync();
        }

        // Movie
        public async Task<Movies> GetMovieAsyncBySessionId(int sessionId)
        {
            IQueryable<Sessions> query = _context.Sessions;
            query = query.AsNoTracking()                       
                         .Where(Session => Session.SessionId == sessionId);   

            IQueryable<Movies> movie = query.Select(Session => Session.Movie);

            return await movie.FirstOrDefaultAsync();
        }

        // Movie
        public async Task<Movies> GetMovieAsyncById(int MovieId, bool includeSessions = true)
        {
            IQueryable<Movies> query = _context.Movies;
            query = query.AsNoTracking()
                        .Where(Movie => Movie.MovieId == MovieId);

            if (includeSessions)
            {
                query = query.Include(Movie => Movie.Sessions);
            }
            return await query.FirstOrDefaultAsync();
        }

        // Room
        public async Task<Rooms[]> GetAllRoomsAsync(bool includeSessions = true)
        {
            IQueryable<Rooms> query = _context.Rooms;

            if (includeSessions)
            {
                query = query.Include(Room => Room.Sessions);
            }

            query = query.AsNoTracking().OrderBy(Room => Room.RoomId);

            return await query.ToArrayAsync();
        }


        //Session
        public async Task<Sessions[]> GetAllSessionsAsync(bool includeRoom = true, bool includeMovie = true)
        {
            DateTime dateNow = DateTime.Now;
            IQueryable<Sessions> query = _context.Sessions.Where(Session => Session.IniTime >= dateNow);

            if (includeRoom)
            {
                query = query.Include(session => session.Room);
            }
            if (includeMovie)
            {
                query = query.Include(session => session.Movie);
            }

            query = query.AsNoTracking()
                        .OrderBy(session => session.SessionId);

            return await query.ToArrayAsync();
        }

        public async Task<Sessions> GetSessionAsyncById(int sessionId, bool includeRoom = true, bool includeMovie = true)
        {
            IQueryable<Sessions> query = _context.Sessions;
            query = query.AsNoTracking()
                        .Where(Session => Session.SessionId == sessionId);

            if (includeRoom)
            {
                query = query.Include(Session => Session.Room);
            }
            if (includeMovie)
            {
                query = query.Include(Session => Session.Movie);
            }

            return await query.FirstOrDefaultAsync();
        }

        // User
        public async Task<Users[]> GetAllUsersAsync(){
            IQueryable<Users> query = _context.Users;

            query = query.AsNoTracking().OrderBy(User => User.UserId);

            return await query.ToArrayAsync();
        }

    }
}
