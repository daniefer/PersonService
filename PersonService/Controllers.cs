using PersonServiceLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingLibrary;
using Microsoft.AspNetCore.Mvc;

namespace PersonService
{
    public class CreateController : BaseController<Create>
    {
        public CreateController(ICommandHandler handler) : base(handler) { }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public override IActionResult Get()
        {
            return base.Get();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public override IActionResult Post([FromBody] Create command)
        {
            return base.Post(command);
        }
    }
    public class ArchiveController : BaseController<Archive>
    {
        public ArchiveController(ICommandHandler handler) : base(handler) { }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public override IActionResult Get()
        {
            return base.Get();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public override IActionResult Post([FromBody] Archive command)
        {
            return base.Post(command);
        }
    }
    public class ChangeNameController : BaseController<ChangeName>
    {
        public ChangeNameController(ICommandHandler handler) : base(handler) { }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public override IActionResult Get()
        {
            return base.Get();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public override IActionResult Post([FromBody] ChangeName command)
        {
            return base.Post(command);
        }
    }
    public class UpdateDOBController : BaseController<UpdateDOB>
    {
        public UpdateDOBController(ICommandHandler handler) : base(handler) { }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public override IActionResult Get()
        {
            return base.Get();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public override IActionResult Post([FromBody] UpdateDOB command)
        {
            return base.Post(command);
        }
    }
    public class UpdateGenderController : BaseController<UpdateGender>
    {
        public UpdateGenderController(ICommandHandler handler) : base(handler) { }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public override IActionResult Get()
        {
            return base.Get();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public override IActionResult Post([FromBody] UpdateGender command)
        {
            return base.Post(command);
        }
    }
}
