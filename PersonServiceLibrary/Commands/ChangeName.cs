using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary.Commands
{
    public class ChangeName : Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
    }
}
