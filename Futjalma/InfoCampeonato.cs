//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Futjalma
{
    using System;
    using System.Collections.Generic;
    
    public partial class InfoCampeonato
    {
        public int ID { get; set; }
        public int CampeonatoID { get; set; }
        public int ClubeID { get; set; }
        public int Qnt_Gols { get; set; }
        public int Qnt_Vitorias { get; set; }
        public int Qnt_Empates { get; set; }
        public int Qnt_Derrotas { get; set; }
        public int Qnt_Pontos { get; set; }
    
        public virtual Campeonato Campeonato { get; set; }
        public virtual Clube Clube { get; set; }
    }
}
