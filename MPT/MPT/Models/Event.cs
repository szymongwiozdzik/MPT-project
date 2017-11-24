using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPT.Models
{
    public class Event
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }
        public string Type { get; set; }
        public virtual User User { get; set; }

    }
}