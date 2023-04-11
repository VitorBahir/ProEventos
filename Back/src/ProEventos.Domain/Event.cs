using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public DateTime? EventDate { get; set; }
        public string Theme { get; set; }
        public int AmountPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batches {get; set;}
        public IEnumerable<SocialMedia> SocialMedias {get; set;}
        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }




    }
}