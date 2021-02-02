using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequest.Add(entity);
            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequest.Remove(entity);
            return Save();
        }
        public bool isExists(int id)
        {
            var exists = _db.LeaveRequest.Any(q => q.Id == id); //lampda 
            return exists;
        }

        public ICollection<LeaveRequest> FindAll()
        {
           return _db.LeaveRequest.Include(q => q.RequestingEmployee).Include(q =>q.ApprovedBy).Include(q => q.LeaveType).ToList();
        }

        public LeaveRequest FindById(int id)
        {
           return _db.LeaveRequest.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).FirstOrDefault(q => q.Id == id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequest.Update(entity);
            return Save();
        }

        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string employeeid)
        {
            var leaveRequests = _db.LeaveRequest.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).Where(q => q.RequestingEmployeeId == employeeid).ToList();
            return leaveRequests;
        }
    }
}
