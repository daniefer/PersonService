using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingLibrary
{
    public interface ICommandHandler
    {
        void OnCommand(Command command);
    }
}
