using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Player
{
    internal class WebPlayerProfile : PlayerProfile
    {
        public string Password { get; set; }
        public string AvatarPicture { get; set; }
        public string SocilaVK { get; set; }

        public WebPlayerProfile(string name) : base(name)
        {
        }
    }
    
}
