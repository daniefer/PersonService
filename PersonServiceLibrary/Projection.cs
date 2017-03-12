using System;
using MessagingLibrary;
using PersonServiceLibrary.Events;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary
{
    public class Projection
    {
        private readonly PersonEntity _entity;
        public Projection(PersonEntity entity)
        {
            this._entity = entity;
        }

        public void Project(Event @event)
        {
            if (@event is Archived)
            {
                var archive = @event as Archived;
                this._entity.Archived = true;
            }
            else if (@event is Created)
            {
                var create = @event as Created;
                this._entity.EntityId = Guid.NewGuid();
                this._entity.DOB = create.DOB;
                this._entity.FirstName = create.FirstName;
                this._entity.Gender = create.Gender;
                this._entity.LastName = create.LastName;
                this._entity.MiddleName = create.MiddleName;
                this._entity.Prefix = create.Prefix;
                this._entity.Suffix = create.Suffix;
                this._entity.Archived = false;
            }
            else if (@event is NameChanged)
            {
                var changeName = @event as NameChanged;
                this._entity.EntityId = changeName.EntityId;
                this._entity.FirstName = changeName.FirstName;
                this._entity.LastName = changeName.LastName;
                this._entity.MiddleName = changeName.MiddleName;
                this._entity.Prefix = changeName.Prefix;
                this._entity.Suffix = changeName.Suffix;
            }
            else if (@event is DOBChanged)
            {
                var updateDOB = @event as DOBChanged;
                this._entity.EntityId = updateDOB.EntityId;
                this._entity.DOB = updateDOB.DOB;
            }
            else if (@event is GenderUpdated)
            {
                var updateGender = @event as GenderUpdated;
                this._entity.EntityId = updateGender.EntityId;
                this._entity.Gender = updateGender.Gender;
            }
            else
            {
                throw new NotImplementedException($"The type '{@event.GetType().FullName}' does not have a handler");
            }
        }
    }
}
