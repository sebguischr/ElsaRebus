using Elsa.Activities.Console;
using Elsa.Activities.Rebus;
using Elsa.Builders;


namespace ElsaRebus
{
    public class ConsumerWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .StartWith<RebusMessageReceived>(messageReceived => messageReceived.Set(x => x.MessageType, typeof(MyMessage)))
                .WriteLine(context =>
                {
                    
                    var mymessage = context.GetInput<MyMessage>();
                    
                    return mymessage.Text;
                });
        }
    }
}
