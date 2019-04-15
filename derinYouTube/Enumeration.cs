using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube
{
    public class Enumeration
    {
        public enum SucscriberStatus
        {
            [Description("Hayır")]
            No = 0,
            
            [Description("Evet")]
            Yes = 1,

            [Description("Sorgulama Yapılamıyor")]
            NotAllowed = 2
        }
    }
}
