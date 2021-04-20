using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab03.Models
{
    public class Author
    {
        [Key]
        public string au_id { get; set; }

        public string au_lname { get; set; }

        public string au_fname { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }

        public bool contract { get; set; }

    }
    public class DbPubsContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
    }

}