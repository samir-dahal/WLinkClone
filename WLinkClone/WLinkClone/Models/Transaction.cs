using System;
using System.Collections.Generic;
using System.Text;

namespace WLinkClone.Models
{
    public class Transaction
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
