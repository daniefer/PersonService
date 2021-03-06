﻿using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary
{
    public class PersonEntity : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public bool Archived { get; set; }
    }
}
