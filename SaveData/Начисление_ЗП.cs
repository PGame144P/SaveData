//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace SaveData
{
    public partial class Начисление_ЗП
    {
        public int Код_начисления { get; set; }
        public int Код_сотрудника { get; set; }
        public System.DateTime Дата_начисления { get; set; }
        public int Кол_во_отработанных_дней { get; set; }
        public int Кол_во_рабочих_часов_в_день { get; set; }
        public int Всего_отработано_часов { get; set; }
        public int Сколько_должен_отработать { get; set; }
        public Nullable<int> Больничные_дни { get; set; }
        public Nullable<int> Отпускные_дни { get; set; }
        public Nullable<int> Командировочные_дни { get; set; }
        public Nullable<decimal> Премия { get; set; }
        public decimal Зарплата { get; set; }
    
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
