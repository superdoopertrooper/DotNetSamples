﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Korzh.EasyQuery;

namespace EqAspNetCoreDemo.Models
{

    [DisplayColumn("Name")]
    [EqEntity(DisplayName = "Client")]
    public class Customer
    {
        [Column("CustomerID")]
        public string Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        public string Street { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        [EqListValueEditor]
        public string Country { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

    }



}