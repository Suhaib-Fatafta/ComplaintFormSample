using ComplaintForm.DomainModel.Authntication;
using ComplaintForm.DomainModel.Interfaces;
using ComplaintForm.DomainModel.Services;
using ComplaintForm.DomainModel.ViewModels;
using ComplaintForm.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace ComplaintForm.Controllers
{
    [RoutePrefix("api/ComplaintForm")]
    public class ComplaintFormController : ApiController
    {

        private readonly IComplaintFormService _complaintFormService = new ComplaintFormService();

        // POST: api/ComplaintForm
        public void AddComplaintForm([FromBody] UserFormViewModel userFormViewModel)
        {
            _complaintFormService.AddComplaintForm(userFormViewModel);
        }

        [HttpGet]
        [Route("GetUserFormByUserId")]
        public IEnumerable<UserFormViewModel> GetUserFormByUserId(int userId)
        {
            return _complaintFormService.GetUserFormByUserId(userId);
        }

        [HttpGet]
        [Route("GetAllUserForm")]
        public IEnumerable<UserFormViewModel> GetAllUserForm()
        {
            return _complaintFormService.GetAllUserForm();
        }

        [HttpPut]
        [Route("ChangeComplaintStatus")]
        public void ChangeComplaintStatus(int statusId, string formId)
        {
            _complaintFormService.ChangeComplaintStatus(statusId, formId);
        }

        [HttpPost]
        [Route("CreateUserAccount")]
        public void CreateUserAccount(string userName, string password, string role)
        {
            _complaintFormService.CreateUserAccount(userName, password, role);
        }

        [HttpGet]
        public string AuthToken(string userName, string password)
        {
            return AuthManager.GenerateAuthToken(userName, password);
        }

        [HttpGet]
        [Route("ValidUser")]
        public int ValidUser(int userId, string role)
        {
            return _complaintFormService.ValidUser(userId, role);
        }

    }
}
