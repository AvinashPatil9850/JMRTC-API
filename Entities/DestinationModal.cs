using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace msrtc_api.Entities
{
    public class DestinationModal
    {
        [Key]
        public int DepoID { get; set; }
        public string BusDepo { get; set; }
        public List<DestinationArr> DestinationArr { get; set; }
    }
    public class DestinationArr
    {
        [Key]
        public int DestinationID { get; set; }
        public DestinationModal DestinationModal { get; set; }
        [ForeignKey("DestinationModal")]
        public int DepoID { get; set; }
        public string Destination { get; set; }

    }
    public class DeleteDestination
    {
        [Key]
        public int? DestinationID { get; set; }
    }
}
