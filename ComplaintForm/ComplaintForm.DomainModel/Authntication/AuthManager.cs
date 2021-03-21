using ComplaintForm.DomainModel.Interfaces;
using ComplaintForm.DomainModel.Services;
using ComplaintForm.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ComplaintForm.DomainModel.Authntication
{
    public class AuthManager
    {
        private const string SECRET_KEY = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCedkiJxCdBl/eUkJ5sT4A0AdvRrb6hZRvGLW45ljVva1Tf/WbdL03fxoJoPCOIMUbwxWF9AJUjc7T7kMe3F4r6KiKubHedlaSuAntK+ploLjOa420ZJan9M3BKdNz73SxZIJk1UoC4+503yss/W2MmkVBv9B5ra5rbWuwdxIDaLQIDAQAB";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateAuthToken(string userName, string password)
        {

            IComplaintFormService _complaintFormService = new ComplaintFormService();
            User userAccount = _complaintFormService.Login(userName, password);

            if (userAccount != null)
            {

                var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(credentials);
                DateTime expiry = DateTime.UtcNow.AddMinutes(60);
                int ts = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;
                var payload = new JwtPayload {
                {"sub",userAccount.FullName },
                {"name","test" },
                {"email","test@gmail.com"},
                {"id",userAccount.Id },
                {"exp",ts },
                {"iss","http://localhost:54073" },
                {"aud","http://localhost:54073" },
                {"role",userAccount.Role },
            };

                var secToken = new JwtSecurityToken(header, payload);
                var handler = new JwtSecurityTokenHandler();
                var tokenString = handler.WriteToken(secToken);
                return tokenString;
            }

            return "";
        }
    }
}
