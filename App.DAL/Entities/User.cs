using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppDAL.Entities
{
    public class User {
        
        public int Id { get; set; }

        public String? Name { get; set; }

        public String? SurName { get; set; }

        public String? Phone { get; set; }

        public String? Email { get; set; }

        public String? CreateDate { get; set; }

    }
}

