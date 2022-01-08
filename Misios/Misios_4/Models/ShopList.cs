using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misios_4.Models
{
    public class ShopList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}