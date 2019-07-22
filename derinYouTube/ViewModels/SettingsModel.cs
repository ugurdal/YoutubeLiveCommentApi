using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class SettingsModel
    {
        public short Id { get; set; }
        public string Value { get; set; }
        public bool IsNumeric
        {
            get { return Helper.IsNumeric(this.Value); }
        }
        public int NumericValue
        {
            get
            {
                if (!this.IsNumeric)
                    return -1;
                return Convert.ToInt32(this.Value);
            }
        }
    }
}
