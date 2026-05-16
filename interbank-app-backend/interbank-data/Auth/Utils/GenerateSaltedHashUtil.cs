using interbank_domain.Auth.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Auth.Utils
{
    public class GenerateSaltedHashUtil
    {
        public static string GenerateSaltedHash(string passwordStr, string saltStr)
        {

            byte[] password = Encoding.ASCII.GetBytes(passwordStr);
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);


            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
                new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            byte[] hashedPwd = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(hashedPwd);
        }

        public static string GetJWT(UserAppProfile profile)
        {
            ClaimsIdentity claims = GenerateClaims(profile);
            int expireInMinuts = 30; //Debe venir de la configuracion
            DateTime expire = DateTime.UtcNow.AddMinutes(expireInMinuts);
            string KEY = "ctvybunim,ñlmknjhvgcvjg7h65j4k3llj5hj643klñ26hj54kl33&%$·$$/&%$·!)=)(/&%$/&%$";
            return GenerateToken(claims, expire, KEY);

        }

        public static ClaimsIdentity GenerateClaims(UserAppProfile profile)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
          
            //Id
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.NameIdentifier, profile.Id.ToString()));
            //Email
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Email, profile.Email.ToString())
                );
            //Name
            claimsIdentity.AddClaim(
                new Claim(ClaimTypes.Name, profile.Name.ToString())
                );
            //Agregar lo que quieras
            return claimsIdentity;
        }

        public static string GenerateToken(ClaimsIdentity claimsIdentity, DateTime expires, string secret)
        {
            var Key = Encoding.UTF8.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = expires,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(createdToken);
            return token;

        }
    }
}
