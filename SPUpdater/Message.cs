using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPUpdater
{
    class Message
    {
        public enum MessageType
        {
            Error,
            Information
        }

        public string title { get; set; }
        public string message { get; set; }
        public MessageType messageType { get; set; }
        
    }
}
