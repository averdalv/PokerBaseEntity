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
    
    public partial class Tournament
    {
        public Tournament()
        {
            this.TournamentPlayers = new HashSet<TournamentPlayer>();
        }
    
        public int TournamentId { get; set; }
        public int Payment { get; set; }
        public bool IsOnline { get; set; }
        public System.DateTime Date { get; set; }
        public int CityId { get; set; }
        public int OrganizationId { get; set; }
        public string TournamentName { get; set; }
        public string WinRatio { get; set; }
    
        public virtual City City { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<TournamentPlayer> TournamentPlayers { get; set; }
    }
}