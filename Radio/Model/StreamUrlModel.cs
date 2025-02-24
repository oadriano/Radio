using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio.Model
{
    internal class StreamUrlModel
    {
        internal List<string> StreamUrls = new List<string>();
        public StreamUrlModel()
        {
            StreamUrls.Add("https://icecast.radiobremen.de/rb/bremenvier/live/mp3/128/stream.mp3");         // Bremen Vier
            StreamUrls.Add("https://ffn-de-hz-fal-stream06-cluster01.radiohost.de/energybremen_mp3-192");   // Energy Bremen
            StreamUrls.Add("https://icecast.radiobremen.de/rb/bremennext/live/mp3/128/stream.mp3");         // Bremen Next
            StreamUrls.Add("https://icecast.radiobremen.de/rb/bremeneins/live/mp3/128/stream.mp3");         // Bremen Eins
            StreamUrls.Add("https://radio21.streamabc.net/radio21-bremen-mp3-192-7011720");                 // Radio 21
        }
    }
}
