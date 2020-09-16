using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        WatchRef.ServiceSoapClient client = new WatchRef.ServiceSoapClient();
        WatchRef.AuthControl auth = new WatchRef.AuthControl();

        string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8basdcvb9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var header = new JwtHeader(credentials);

        var payload = new JwtPayload
           {
               { "Username", txtUsername.Text },
               { "Password", txtPassword.Text },
           };

        var secToken = new JwtSecurityToken(header, payload);
        var handler = new JwtSecurityTokenHandler();

        auth.Token = handler.WriteToken(secToken);

        client.saatler(auth);
    }
}