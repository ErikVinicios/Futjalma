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
    
    public partial class Contratacao
    {
        public int ID { get; set; }
        public int ClubeID { get; set; }
        public int JogadorID { get; set; }
        public int Camisa { get; set; }
        public System.DateTime Fechamento { get; set; }
    
        public virtual Clube Clube { get; set; }
        public virtual Jogador Jogador { get; set; }
    }
}
