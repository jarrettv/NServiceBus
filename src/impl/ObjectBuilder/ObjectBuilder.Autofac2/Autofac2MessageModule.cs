using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace NServiceBus.ObjectBuilder.Autofac2
{
    public class Autofac2MessageModule : IMessageModule
    {
        public void HandleBeginMessage()
        {
            Autofac2ObjectBuilder.MessageLifetimeScope = Autofac2ObjectBuilder.RootAutofacContainer.BeginLifetimeScope();
        }

        public void HandleEndMessage()
        {
            Dispose();
        }

        public void HandleError()
        {
            Dispose();
        }

        private void Dispose()
        {
            if (Autofac2ObjectBuilder.MessageLifetimeScope != null)
            {
                Autofac2ObjectBuilder.MessageLifetimeScope.Dispose();
                Autofac2ObjectBuilder.MessageLifetimeScope = null;
            }
        }
    }
}
