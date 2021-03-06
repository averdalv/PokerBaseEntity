//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokerBaseEntity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Player
    {
        public Player()
        {
            this.TournamentPlayers = new HashSet<TournamentPlayer>();
        }
    
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public int CityId { get; set; }
        public System.DateTime DOB { get; set; }
        public string Image { get; set; }
    
        public virtual City City { get; set; }
        public virtual ICollection<TournamentPlayer> TournamentPlayers { get; set; }
    }
}
