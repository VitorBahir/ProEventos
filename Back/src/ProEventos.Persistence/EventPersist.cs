using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Persistence
{
    public class EventPersist : IEventPersist
    {
        private readonly ProEventosContext _context;
        public EventPersist(ProEventosContext context)
        {
            this._context = context;
           // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;  
        }
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);

            if (includeSpeakers) {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);

            if (includeSpeakers) {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);

            if (includeSpeakers) {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
            .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
    }
}