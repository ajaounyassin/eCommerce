﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Profil Profil { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        public string Password { get; set; }
        public Sexe Sexe { get; set; } 
        public Address Address { get; set; }
        public ICollection<Article> ArticleSale { get; set; }

    }
}
