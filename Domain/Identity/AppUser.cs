using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string WorkPosition { get; set; }
        public string FirstLastName => FirstName + " " + LastName;

        public virtual IList<Media> Medias { get; set; }
        public virtual IList<SoundTrack> SoundTracks { get; set; }
    }
}