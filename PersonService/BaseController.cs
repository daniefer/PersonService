using System;
using MessagingLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonService
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class BaseController<T> : Microsoft.AspNetCore.Mvc.Controller where T: Command
    {
        private readonly ICommandHandler handler;

        internal BaseController(ICommandHandler handler)
        {
            this.handler = handler;
        }
        
        //[Microsoft.AspNetCore.Mvc.HttpGet]
        public virtual Microsoft.AspNetCore.Mvc.IActionResult Get()
        {
            return this.Ok("test");
        }
        
        //[Microsoft.AspNetCore.Mvc.HttpPost]
        //public Microsoft.AspNetCore.Mvc.IActionResult Command([Microsoft.AspNetCore.Mvc.FromBody] Command command)
        //{
        //    if (command == null)
        //    {
        //        return this.BadRequest();
        //    }

        //    // process command
        //    this.handler.OnCommand(command);

        //    return this.Accepted();
        //}

        public virtual Microsoft.AspNetCore.Mvc.IActionResult Post([Microsoft.AspNetCore.Mvc.FromBody] T command)
        {
            if (command == null)
            {
                return this.BadRequest();
            }

            // process command
            this.handler.OnCommand(command as Command);

            return this.Accepted();
        }

    }
}
