using System;
using System.Collections.Generic;
using System.Text;

namespace MessagingLibrary
{
    public abstract class CommandHandler : ICommandHandler
    {
        private readonly IRepository _repository;

        public CommandHandler(IRepository repo)
        {
            this._repository = repo;
        }

        public abstract void OnCommand(Command command);

        //public event EventHandler<EventEventArgs> EventDidOccur;

        //public class EventEventArgs : EventArgs
        //{
        //    public Event Event { get; }
        //    public EventEventArgs(Event @event)
        //    {
        //        this.Event = @event;
        //    }
        //}

        //protected void OnEventDidOccur(EventEventArgs args)
        //{
        //    var handler = EventDidOccur;
        //    if (handler != null)
        //    {
        //        var subscribers = handler.GetInvocationList();
        //        foreach (var item in subscribers)
        //        {
        //            // We know all Event listener will be of type EventHandler<EventEventArgs>
        //            // So we can safely call DynamicInvoke without worrying about type 
        //            // mismatch related errors.
        //            System.Threading.Tasks.Task.Run(() => item.DynamicInvoke(args));
        //        }
        //    }
        //}

        protected long GetCurrentSequenceNumber(Event @event)
        {
            return this._repository.ReadLastSequenceNumber(@event);
        }

        protected void Write(Event @event)
        {
            this._repository.Insert(@event);
        }

        //protected void Raise(Event @event)
        //{

        //}
    }
}
