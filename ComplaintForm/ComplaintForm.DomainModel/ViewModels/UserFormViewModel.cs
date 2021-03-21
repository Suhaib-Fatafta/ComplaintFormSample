using System;
using System.Collections.Generic;

namespace ComplaintForm.DomainModel.ViewModels
{
    public class UserFormViewModel
    {
        public string UserName { get; set; }
        public string ComplaintTitle { get; set; }
        public string ComplaintDetails { get; set; }
        public string IsRecurring { get; set; }
        public DateTime LogDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public string FormId { get; set; }
        public string StatusTitle { get; set; }
        public List<string> Complaints { get; set; }
    }
}
