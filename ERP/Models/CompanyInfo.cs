//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanyInfo
    {
        public CompanyInfo()
        {
            this.PersonInfoes = new HashSet<PersonInfo>();
        }
    
        public int CID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Tags { get; set; }
        public string Remarks { get; set; }
        public string CreateDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Year { get; set; }
        public string Employee { get; set; }
    
        public virtual ICollection<PersonInfo> PersonInfoes { get; set; }
    }
}