using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace msrtc_api.Entities
{
    public class BusStopsModel
    {
        [Key]
        public int? ID { get; set; }
        //public BussessModel BussessModel { get; set; }
        //[ForeignKey("BussessModel")]
        public int? BusID { get; set; }
        public string? Time { get; set; }
        public string? Stop { get; set; }
    }
}
