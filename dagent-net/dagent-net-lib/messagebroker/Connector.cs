using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.messagebroker
{
    public class Connector
    {
        public Connector()
        {
        }
        public Connector(String [] Connectorspec, int start)
        {
            this.Constructor(Connectorspec, start);
        }
        public Connector(String Connector)
        {
            String[] connspec = Connector.Split('!');
            this.Constructor(connspec, 0);

        }
        public void Constructor(String[] Connectorspec, int index)
        {
            this.Match = Connectorspec[index];
            this.Expression = Connectorspec[index + 1];
            this.ApplicationProtocol = Connectorspec[index + 2];
            this.NetworkProtocol = Connectorspec[index + 3];
            this.NetworkAddress = Connectorspec[index + 4];
            this.TransportProtocol = Connectorspec[index + 5];
            this.TransportPort = Connectorspec[index + 6];
        }
        public String Match;
        public String Expression;
        public String ApplicationProtocol;
        public String NetworkProtocol;
        public String NetworkAddress;
        public String TransportProtocol;
        public String TransportPort;
        public override String ToString()
        {
            return this.Match + "!" + this.Expression + "!" + this.ApplicationProtocol + "!" + this.NetworkProtocol + "!" + this.NetworkAddress + "!" + this.TransportProtocol + "!" + this.TransportPort;
        }
    }
}
