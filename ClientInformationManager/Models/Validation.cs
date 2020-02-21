using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientInformationManager.Models
{
    public class Validation
    {
    }

    [MetadataType(typeof(Address_Validation))]
    public partial class Address
    {

    }
    

    public class Address_Validation
    {
        [Display(Name = "Description")]
        [Required]
        public string description;
        [Display(Name = "Street Address")]
        [Required]
        public string street_address;
        [Display(Name = "City")]
        [Required]
        public string city;
        [Display(Name = "Province or State")]
        [Required]
        public string province_state;
        [Display(Name = "Zip/Postal")]
        [Required]
        public string zip_postal_code;
    }    [MetadataType(typeof(Contact_Validation))]
    public partial class ContactInformation
    {

    }


    public class Contact_Validation
    {
        [Required]
        public string type_of_info { get; set; }
        [Required]
        public string info  { get; set; }
}


    [MetadataType(typeof(Person_Validation))]
    public partial class PersonInformation
    {

    }


    public class Person_Validation
    {
        [Display(Name = "First name")]
        [Required]
        public string first_name;
        [Display(Name = "Last name")]
        [Required]
        public string last_name;

    }


    [MetadataType(typeof(Picture_Validation))]
    public partial class Picture
    {

    }


    public class Picture_Validation
    {
        [Display(Name = "Caption")]
        [Required]
        public string caption;
        [Display(Name = "Path")]
        [Required]
        public string path_of_picture;
        [Display(Name = "Time")]
        [Required]
        public string time_info;
        [Display(Name = "Location")]
        [Required]
        public string location_info;
    }
}