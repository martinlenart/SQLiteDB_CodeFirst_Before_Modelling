﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SeidoDemoModels
{
     
    public class Customer
    {
        #region Uncomment to create the Data model
        /*
        [Key]
        [Column("CustomerID")]
        public Guid CustomerID { get; set; }

        [Column(TypeName = "nvarchar (200)")]
        public string Comment { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
        */
        #endregion

        #region Uncomment to seed and query the Database
        /*
        public Customer ()
        {
            CustomerID = Guid.NewGuid();
            Comment = $"{CustomerID} specific comment";
        }
        */
        #endregion
    }
    
}
