using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaXS.Types
{
    /// <summary>
    /// API object that is serialized into JSON. This is the final object that gets sent to XSOverlay via WebSockets.
    /// </summary>
    internal class XSOApiObject
    {
        public string sender = null;
        public string target = null;
        public string command = null;
        public string jsonData = null;
        public string rawData = null;
    }
}
