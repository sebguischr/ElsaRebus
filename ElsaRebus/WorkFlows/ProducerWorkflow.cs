using Elsa.Activities.Console;
using Elsa.Activities.Rebus;
using Elsa.Activities.Temporal;
using Elsa.Builders;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaRebus
{
    public class ProducerWorkflow : IWorkflow
    {
        private readonly IClock _clock;
        private readonly Random _random;

        public ProducerWorkflow(IClock clock)
        {
            _clock = clock;
            _random = new Random();
        }

        public void Build(IWorkflowBuilder builder)
        {
            builder
                .Timer(Duration.FromSeconds(5))
                .WriteLine("Sending a hello message.")
                .Then<SendRebusMessage>(sendMessage => sendMessage.Set(x => x.Message, new MyMessage { Text = "hello" }));
        }

        
    }
}
