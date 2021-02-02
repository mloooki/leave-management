﻿using leave_management.Contracts;
using leave_management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }
        public bool isExists(int id)
        {
            var exists = _db.LeaveAllocations.Any(q => q.Id == id); //lampda 
            return exists;
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations= _db.LeaveAllocations.Include(q => q.LeaveType).Include(q => q.Employee).ToList();
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            return _db.LeaveAllocations.Include(q => q.LeaveType).Include(q => q.Employee).FirstOrDefault(q => q.Id == id);
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }

        public bool CheckAlloaction(int leavetypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == employeeid && q.LeaveTypeId == leavetypeid && q.Period == period).Any();
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string id)
        {
            var period = DateTime.Now.Year;

            return FindAll().Where(q => q.EmployeeId == id && q.Period == period).ToList();
        }

        public LeaveAllocation GetLeaveAllocationsByEmployeeAndType(string id, int levetypeid)
        {
            var period = DateTime.Now.Year;

            return FindAll().FirstOrDefault(q => q.EmployeeId == id && q.Period == period && q.LeaveTypeId == levetypeid); // we use FirstOrDefault to get one value only.
        }
    }
}
