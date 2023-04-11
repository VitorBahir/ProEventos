using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Persistence
{
    public class SpeakerPersist : ISpeakerPersist
    {
        private readonly ProEventosContext _context;
        public SpeakerPersist(ProEventosContext context)
        {
            this._context = context;
            
        }
        
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speaker
            .Include(s => s.SocialMedias);

            if (includeEvents) {
                query = query.Include(e => e.SpeakersEvents)
                .ThenInclude(se => se.Event);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speaker
            .Include(s => s.SocialMedias);

            if (includeEvents) {
                query = query.Include(s => s.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id)
            .Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speaker
            .Include(s => s.SocialMedias);

            if (includeEvents) {
                query = query.Include(s => s.SpeakersEvents)
                .ThenInclude(se => se.Speaker);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id)
            .Where(s => s.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }
    }
}