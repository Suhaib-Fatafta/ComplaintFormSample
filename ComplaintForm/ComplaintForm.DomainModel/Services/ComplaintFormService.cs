using ComplaintForm.DomainModel.Authntication;
using ComplaintForm.DomainModel.Interfaces;
using ComplaintForm.DomainModel.ViewModels;
using ComplaintForm.Entities;
using ComplaintForm.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ComplaintForm.DomainModel.Services
{
    public class ComplaintFormService : IComplaintFormService
    {
        string strcon = ConfigurationManager.ConnectionStrings["complaintform_connection"].ConnectionString;
        public void AddComplaintForm(UserFormViewModel userFormViewModel)
        {
            string formId = Guid.NewGuid().ToString().Replace("\"", "'");
            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("INSERT INTO COMPLAINTS.USER_FORMS (Id,USER_NAME,COMPLAINT_TITLE,IS_RECURRING,COMPLAINT_DETAILS,LOG_DATE,STATUS_ID,USER_ID) VALUES (@n1,@n2,@n3,@n4,@n5,@n6,@n7,@n8)", conn))
                {
                    command.Parameters.AddWithValue("n1", formId);
                    command.Parameters.AddWithValue("n2", userFormViewModel.UserName);
                    command.Parameters.AddWithValue("n3", userFormViewModel.ComplaintTitle);
                    command.Parameters.AddWithValue("n4", userFormViewModel.IsRecurring);
                    command.Parameters.AddWithValue("n5", userFormViewModel.ComplaintDetails);
                    command.Parameters.AddWithValue("n6", DateTime.Now);
                    command.Parameters.AddWithValue("n7", (int)ComplaintStatus.Pending);
                    command.Parameters.AddWithValue("n8", userFormViewModel.UserId);
                    command.ExecuteNonQuery();
                }
            }

            using (var conn = new SqlConnection(strcon))

            {
                conn.Open();
                foreach (var complaint in userFormViewModel.Complaints)
                {
                    using (var command = new SqlCommand("INSERT INTO COMPLAINTS.COMPLAINTS (COMPLAINT_TYPE,FORM_ID) VALUES (@n1,@n2)", conn))
                    {
                        command.Parameters.AddWithValue("n1", complaint);
                        command.Parameters.AddWithValue("n2", formId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public IEnumerable<UserFormViewModel> GetUserFormByUserId(int userId)
        {
            List<UserFormViewModel> userFormViewModels = new List<UserFormViewModel>();

            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("SELECT COMPLAINT_TITLE,STATUS_ID,LOG_DATE from COMPLAINTS.USER_FORMS where USER_ID=@n", conn))
                {
                    command.Parameters.AddWithValue("n", userId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UserFormViewModel userFormViewModel = new UserFormViewModel
                        {
                            ComplaintTitle = reader.GetString(0),
                            StatusTitle = ((ComplaintStatus)reader.GetInt32(1)).ToString(),
                            LogDate = reader.GetDateTime(2)
                        };
                        userFormViewModels.Add(userFormViewModel);
                    }
                }
            }
            return userFormViewModels;
        }

        public IEnumerable<UserFormViewModel> GetAllUserForm()
        {
            List<UserFormViewModel> userFormViewModels = new List<UserFormViewModel>();

            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("SELECT ID,COMPLAINT_TITLE,COMPLAINT_DETAILS,STATUS_ID,LOG_DATE from COMPLAINTS.USER_FORMS", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UserFormViewModel userFormViewModel = new UserFormViewModel
                        {
                            FormId = reader.GetString(0),
                            ComplaintTitle = reader.GetString(1),
                            ComplaintDetails = reader.GetString(2),
                            StatusId = reader.GetInt32(3),
                            LogDate = reader.GetDateTime(4)
                        };
                        userFormViewModels.Add(userFormViewModel);
                    }
                }
            }
            return userFormViewModels;
        }

        public void ChangeComplaintStatus(int statusId, string formId)
        {
            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("UPDATE COMPLAINTS.USER_FORMS set STATUS_ID=@n where Id=@n1", conn))
                {
                    command.Parameters.AddWithValue("n", statusId);
                    command.Parameters.AddWithValue("n1", formId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateUserAccount(string userName, string paswword, string role)
        {
            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("INSERT INTO [COMPLAINTS].[USER] (FULL_NAME,PASSWORD,ROLE) VALUES (@n1,@n2,@n3)", conn))
                {
                    command.Parameters.AddWithValue("n1", userName);
                    command.Parameters.AddWithValue("n2", paswword.MD5Hash());
                    command.Parameters.AddWithValue("n3", role);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User Login(string userName, string password)
        {
            User userAccount = new User();


            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("SELECT * from [COMPLAINTS].[USER] where FULL_NAME=@n1 and PASSWORD=@n2", conn))
                {
                    command.Parameters.AddWithValue("n1", userName);
                    command.Parameters.AddWithValue("n2", password.MD5Hash());
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userAccount.Id = reader.GetInt32(0);
                        userAccount.FullName = reader.GetString(1);
                        userAccount.Password = reader.GetString(2);
                        userAccount.Role= reader.GetString(3);
                    }
                }
                return userAccount;
            }
        }

       public int ValidUser(int userId, string role)
        {
            using (var conn = new SqlConnection(strcon))
            {
                conn.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) from [COMPLAINTS].[USER] where ID=@n1 and Role=@n2", conn))
                {
                    command.Parameters.AddWithValue("n1", userId);
                    command.Parameters.AddWithValue("n2", role);
                   return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}