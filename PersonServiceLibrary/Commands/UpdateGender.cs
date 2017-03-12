using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary.Commands
{
    public class UpdateGender : Command
    {
        public string Gender { get; set; }
    }
}
