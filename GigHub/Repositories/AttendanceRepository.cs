using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Attendance GetAttendance(Gig gig, string attendee)
        {
            return _context.Attendances
                    .SingleOrDefault(a => a.GigId == gig.Id && a.Attendee.Id == attendee);
        }

        public IEnumerable<Attendance> GetFutureAttendences(string userId)
        {
            return _context.Attendances
                            .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                            .ToList();
        }
    }
}