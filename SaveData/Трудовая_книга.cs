//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaveData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Трудовая_книга
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Трудовая_книга()
        {
            this.Сотрудники = new HashSet<Сотрудники>();
        }
    
        public int Код_трудовой_книги { get; set; }
        public int Табельный_номер { get; set; }
        public int Код_отдела { get; set; }
        public int Код_должности { get; set; }
        public string Примечание { get; set; }
        public System.DateTime Дата_начала { get; set; }
        public System.DateTime Дата_окончания { get; set; }
    
        public virtual Должности Должности { get; set; }
        public virtual Отделы Отделы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
