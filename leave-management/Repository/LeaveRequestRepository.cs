﻿using leave_management.Contracts;
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
        public async Task<bool> Create(LeaveRequest entity)
        {
           await _db.LeaveRequest.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequest.Remove(entity);
            return await Save();
        }
        public async Task<bool> isExists(int id)
        {
            var exists = await _db.LeaveRequest.AnyAsync(q => q.Id == id); //lampda 
            return exists;
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
           return await _db.LeaveRequest.Include(q => q.RequestingEmployee).Include(q =>q.ApprovedBy).Include(q => q.LeaveType).ToListAsync();
        }

        public async Task<LeaveRequest> FindById(int id)
        {
           return await _db.LeaveRequest.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequest.Update(entity);
            return  await Save();
        }

        public async Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeid)
        {
            var leaveRequests = await FindAll();
            return leaveRequests.Where(q => q.RequestingEmployeeId == employeeid).ToList();
            
        }
    }
}
