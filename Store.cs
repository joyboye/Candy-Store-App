using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_Store_App2.Data
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

    }
}
