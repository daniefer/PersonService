using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary.Commands
{
    public class UpdateDOB : Command
    {
        public DateTime DOB { get; set; }
    }
}
