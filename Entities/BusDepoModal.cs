using System.ComponentModel.DataAnnotations;

namespace msrtc_api.Entities
{
    public class BusDepoModal
    {
        [Key]
        public  int DepoID { get; set; }
        public string BusDepo { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
    }
}
