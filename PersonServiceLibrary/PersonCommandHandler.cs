using System;
using MessagingLibrary;
using PersonServiceLibrary.Commands;
using PersonServiceLibrary.Events;

namespace PersonServiceLibrary
{
    public class PersonCommandHandler : CommandHandler
    {
        public PersonCommandHandler(IRepository repo) : base(repo)
        {
        }

        public override void OnCommand(Command command)
        {
            Event @event;

            if (command is Archive)
            {
                var archive = command as Archive;
                @event = new Archived
                {
                    EntityId = archive.EntityId
                };
            }
            else if (command is Create)
            {
                var create = command as Create;
                @event = new Created
                {
                    EntityId = Guid.NewGuid(),
                    DOB = create.DOB,
                    FirstName = create.FirstName,
                    Gender = create.Gender,
                    LastName = create.LastName,
                    MiddleName = create.MiddleName,
                    Prefix = create.Prefix,
                    Suffix = create.Suffix
                };
            }
            else if (command is ChangeName)
            {
                var changeName = command as ChangeName;
                @event = new NameChanged
                {
                    EntityId = changeName.EntityId,
                    FirstName = changeName.FirstName,
                    LastName = changeName.LastName,
                    MiddleName = changeName.MiddleName,
                    Prefix = changeName.Prefix,
                    Suffix = changeName.Suffix
                };
            }
            else if (command is UpdateDOB)
            {
                var updateDOB = command as UpdateDOB;
                @event = new DOBChanged
                {
                    EntityId = updateDOB.EntityId,
                    DOB = updateDOB.DOB,
                };
            }
            else if (command is UpdateGender)
            {
                var updateGender = command as UpdateGender;
                @event = new GenderUpdated
                {
                    EntityId = updateGender.EntityId,
                    Gender = updateGender.Gender
                };
            }
            else
            {
                throw new NotImplementedException($"The type '{command.GetType().FullName}' does not have a handler");
            }

            this.Write(@event);
        }
    }
}
