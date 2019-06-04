using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Animals;
using Domain.Identity;

namespace Domain
{
    public class SoundTrack : BaseEntity
    {
        [Required]
        [MaxLength(80, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public string Name { get; set; }
        public string FileName { get; set; }
        public string Reader { get; set; }
        public string TrackLength { get; set; }
        [Required]
        public string Url { get; set; }
        public int TimesPlayed { get; set; }
        public DateTime UploadedDateTime { get; set; }
        public string FileType { get; set; }
        public Guid UploaderUserId { get; set; }
        public virtual AppUser UploaderUser { get; set; }
        public virtual IList<SoundTrackInAnimal> AnimalSoundtracks { get; set; }
    }
}