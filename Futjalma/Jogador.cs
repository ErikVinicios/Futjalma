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
    
    public partial class Jogador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogador()
        {
            this.Contratacao = new HashSet<Contratacao>();
        }
    
        public int ID { get; set; }
        public byte[] Foto { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataNascimento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contratacao> Contratacao { get; set; }
    }
}
