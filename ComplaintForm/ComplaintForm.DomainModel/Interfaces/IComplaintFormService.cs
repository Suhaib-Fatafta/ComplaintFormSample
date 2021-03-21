using ComplaintForm.DomainModel.ViewModels;
using ComplaintForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintForm.DomainModel.Interfaces
{
    public interface IComplaintFormService
    {
        void AddComplaintForm(UserFormViewModel userFormViewModel);
        void ChangeComplaintStatus(int statusId, string formId);
        IEnumerable<UserFormViewModel> GetUserFormByUserId(int userId);
        IEnumerable<UserFormViewModel> GetAllUserForm();
        void CreateUserAccount(string userName, string Paswword, string role);
        User Login(string userName, string password);
        int ValidUser(int userId,string role);
    }
}
