using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace msrtc_api.Entities
{
    public class BussessModel
    {
        [Key]
        public int BusID { get; set; }
        public string BusTime { get; set; }
        public string BusDepo { get; set; } 
        public string BusType { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string BusRoute { get; set; }
        public string Via { get; set; }
        
        
        public List<WeekDays> WeekDays { get; set; }
        public List<BusStopsModel> Stops { get; set; }

    }
    public class WeekDays
    {
        [Key]
        public int? ID { get; set; }
        public BussessModel BussessModel { get; set; }
        [ForeignKey("BussessModel")]
        public int? BusID { get; set; }
        public string Day { get; set; }
        public string Abbr { get; set; }
    }
}
