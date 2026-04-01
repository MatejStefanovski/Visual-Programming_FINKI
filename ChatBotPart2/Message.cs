using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotPart2
{
    public class Message
    {
        public Message(string sender, string poraka)
        {
            Sender = sender;
            Poraka = poraka;
        }

        public string Sender { get; set; }
        public string Poraka { get; set; }

        public override string ToString()
        {
            string s = Sender + ": " + Poraka;
            return s;
        }
    }
}
