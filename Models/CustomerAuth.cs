using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_First.Models
{
    public class CustomerAuth
    {
        public int CustomerAuthID {  get; set; }  
        public int CustomerID { get; set; } 
        public string Password { get; set; }    

        public Customer Customer { get; set; }
    }
}
