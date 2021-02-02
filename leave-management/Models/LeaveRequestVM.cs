
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveRequestVM
    {
        public int Id { get; set; }

        public EmployeeVM RequestingEmployee { get; set; }
        [Display(Name ="Employee Name")]
        public string RequestingEmployeeId { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        [Display(Name ="Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
        public bool Cancelled { get; set; }


        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }
        public EmployeeVM ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }

    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Totoal Requsets")]

        public int TotoalRequsets { get; set; }
        [Display(Name = "Approved Requsets")]
        public int ApprovedRequsets { get; set; }
        [Display(Name = "Pending Requsets")]
        public int PendingRequsets { get; set; }
        [Display(Name = "Rejected Requsets")]
        public int RejectedRequsets { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }

    public class CreateLeaveRequestVM
    {
        [Display(Name ="Start Date")]
        [Required]
        public string startDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public string endDate { get; set; }

        public string RequestComments { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; } // get all the leaves Types from the DB. (SelectListItem to show a drop dowen list)
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
    }

    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
