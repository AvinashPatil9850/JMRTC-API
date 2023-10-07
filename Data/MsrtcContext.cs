using Microsoft.EntityFrameworkCore;
using msrtc_api.Entities;

namespace msrtc_api.Data
{
    public class MsrtcContext: DbContext
    {
        public MsrtcContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet
        public virtual DbSet<BussessModel> Bussess { get; set; }
        public virtual DbSet<BusStopsModel> BusStopsModel { get; set; }
        public virtual DbSet<WeekDays> WeekDays { get; set; }
        public virtual DbSet<DestinationModal> DestinationModal { get; set; }
        public virtual DbSet<DestinationArr> DestinationArr { get; set; }
        public virtual DbSet<StopsListModel> StopsListModel { get; set; }
        public virtual DbSet<StopDetail> StopDetail { get; set; }

    }
}
