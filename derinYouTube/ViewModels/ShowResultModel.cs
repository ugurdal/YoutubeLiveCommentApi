using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.ViewModels
{
    public class ShowResultModel : EventArgs
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public List<CompetitionResultModel> Results { get; set; }
        public List<WinnerOfDayModel> CurrentWinners { get; set; }
        public DateTime Date { get; set; }

        public ShowResultModel()
        {
            this.Results = new List<CompetitionResultModel>();
            this.CurrentWinners = new List<WinnerOfDayModel>();
        }
    }
}
