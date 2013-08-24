using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace dagent_net_lib
{
    public class Dispatcher
    {
        private Queue<AgentOperation> InputQueue = new Queue<AgentOperation>();
        public Boolean Enqueue(AgentOperation operation)
        {
            lock (this.InputQueue)
            {
                this.InputQueue.Enqueue(operation);
                return true;
            }
            return false;
        }
        private AgentOperation Dequeue()
        {
            lock (this.InputQueue)
            {
                return this.InputQueue.Dequeue();
            }
        }
    }
}
