using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace msrtc_api.Entities
{
    public class BustListModel
    {
        [Key]
        public int BusListID { get; set; }
        public BussessModel BussessModel { get; set; }
        [ForeignKey("BussessModel")]
        public int BusID { get; set; }
      //  public string Time { get; set; }
        public string Type { get; set; }
        public List<BusStopsModel> Stops { get; set; }

    }
}
