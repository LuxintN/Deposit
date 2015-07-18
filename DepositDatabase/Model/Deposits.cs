//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DepositDatabase.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deposits
    {
        public int Id { get; set; }
        public string UserOwnerId { get; set; }
        public byte TermId { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal Balance { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<System.DateTime> LastInterestPaymentDate { get; set; }
        public byte StateId { get; set; }
        public byte WayOfAccumulationId { get; set; }
        public string CardForAccumulationId { get; set; }
        public string Name { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Cards Cards { get; set; }
        public virtual DepositStates DepositStates { get; set; }
        public virtual DepositTerms DepositTerms { get; set; }
        public virtual DepositWaysOfAccumulation DepositWaysOfAccumulation { get; set; }
    }
}