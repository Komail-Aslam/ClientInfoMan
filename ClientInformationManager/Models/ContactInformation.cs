//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientInformationManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactInformation
    {
        public int contact_id { get; set; }
        public int person_id { get; set; }
        public string type_of_info { get; set; }
        public string info { get; set; }
    
        public virtual PersonInformation PersonInformation { get; set; }
    }
}