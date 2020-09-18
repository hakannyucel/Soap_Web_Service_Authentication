using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for AuthControl
/// </summary>
public class AuthControl : SoapHeader
{
    public string Token { get; set; }

    ErsaEntities db = new ErsaEntities();

    public bool IsValid()
    {
        if (HttpContext.Current.Cache.Get("Token") != null)
            return true;
        else if(this.Token != null)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(this.Token);
            List<Tbl_Admin> admins = db.Tbl_Admin.ToList();
            foreach (var admin in admins)
            {
                if (token.Payload["Username"].ToString() == admin.Username && token.Payload["Password"].ToString() == admin.Password)
                {
                    HttpContext.Current.Cache.Insert("Token", this.Token, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero);
                    return true;
                }
            }
        }
        return false;
    }
}