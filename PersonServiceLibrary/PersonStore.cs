using MessagingLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonServiceLibrary
{
    public class PersonStore
    {
        private readonly IRepository _repository;

        private readonly Dictionary<Guid, PersonEntity> _cache;

        public PersonStore(IRepository repo)
        {
            this._repository = repo;
            this._cache = new Dictionary<Guid, PersonEntity>();
        }

        public PersonEntity Get(Guid entityId)
        {
            PersonEntity entity;
            if (!this._cache.TryGetValue(entityId, out entity))
            {
                entity = new PersonEntity()
                {
                    EntityId = entityId
                };
            }
            var projection = new Projection(entity);
            IEnumerable<Event> newEvents = this._repository.GetLatestedEvents(entity);
            foreach (Event @event in newEvents)
            {
                projection.Project(@event);
            }
            return entity;
        }
    }
}
