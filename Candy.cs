using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_Store_App2.Data
{
    public class Candy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandyId { get; set; }
        public string CandyName { get; set; }
        public string CandyType { get; set; }
        

        
        public int MID { get; set; }
        [ForeignKey("MID")]
        public Manufacturer Manufactures { get; set; }

        
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Stores { get; set; }
    }
}
