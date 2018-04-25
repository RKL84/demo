using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.RemoteFlights.Core.Commands
{
    public interface ICommandBus
    {
        CommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;

        void ApplyChanges();
        CommandResult GetDelayedCommandResult();
    }
}
