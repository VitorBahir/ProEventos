using System.Collections.Generic;
namespace ProEventos.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Curriculum { get; set; }
        public string ImagemURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<SpeakerEvent> SpeakersEvents { get; set; }
    }
}