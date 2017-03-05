using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Data_Hackathon__2017
{
    public class Store
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Producer { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Hours { get; set; }

        public string Brands { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", City, Address, Producer, ContactName);
        }
    }
}
