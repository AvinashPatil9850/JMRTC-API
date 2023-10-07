using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace msrtc_api.Entities
{
    public class StopsListModel
    {
        [Key]
        public int RouteID { get; set; }
        public string? BusDepo { get; set; }
        public string? Source { get; set; }
        public string? Destination { get; set; }
        public List<StopDetail>? StopsList { get; set; }
    }
    public class StopDetail
    {
        [Key]
        public int? StopID { get; set; }
        public StopsListModel StopsListModel { get; set; }
        [ForeignKey("StopsListModel")]
        public int RouteID { get; set; }
        public string StopName { get; set; }
    }
    public class DeleteStops
    {
        [Key]
        public int? StopID { get; set; }
    }

}
