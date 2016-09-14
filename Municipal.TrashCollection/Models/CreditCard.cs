﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Municipal.TrashCollection.Models
{
    public class CreditCard
    {
        [Key]
        public int ID { get; set; }

        public string CardHolderName { get; set; }
        public int CardNumber { get; set; }
    }
}