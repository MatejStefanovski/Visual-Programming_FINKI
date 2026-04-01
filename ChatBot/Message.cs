using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    public class Message
    {
        public Message(string sender, string text)
        {
            Sender = sender;
            Text = text;
        }

        public string Sender { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            string s = Sender + ": " + Text;
            return s;
        }
    }
}
