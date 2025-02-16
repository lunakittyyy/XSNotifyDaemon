using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaXS.Types
{
    /// <summary>
    /// Object containing parameters pertaining to the notification. This data is serialized into JSON and included in the API object.
    /// </summary>
    public class XSONotificationObject
    {
        public int type = 1;
        public int index = 0;
        public float timeout = 0.5f;
        public float height = 175;
        public float opacity = 1;
        public float volume = 0.7f;
        public string audioPath = "default";
        public string title = "";
        public string content = "";
        public bool useBase64Icon = false;
        public string icon = "";
        public string sourceApp = "";
    }
}
