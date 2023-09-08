﻿using LibraryAPI.Domain.Entities.BarrowEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.UserEntities
{
    public class User : BaseEntity
    {
        public User()
        {

            BarrowedBooks = new HashSet<BarrowedBook>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoPath { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool UserType { get; set; } // default olarak customer olarak kayıt olcak // false is customer
        public bool? Status { get; set; } // default 1
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<BarrowedBook> BarrowedBooks { get; set; }

        public ICollection<UserOperationClaim> OperationClaims { get; set; }
    }
}
