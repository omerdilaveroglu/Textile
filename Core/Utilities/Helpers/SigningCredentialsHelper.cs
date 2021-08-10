using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Helpers
{
    public class SigningCredentialsHelper
    {
        //JWT servislerinin oluşturulması için 
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            //Asp Net' e anahtar olarak bu security key'i kullan şifreleme olarakda güvenlik algoritmalarından HmacSha512Signature'ı kullan.
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
