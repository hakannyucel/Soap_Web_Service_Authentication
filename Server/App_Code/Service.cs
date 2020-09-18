using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public AuthControl Auth;
    ErsaEntities db = new ErsaEntities();

    [SoapHeader("Auth")]
    [WebMethod]
    public void Login()
    {
        if (!Auth.IsValid())
            throw new SoapException("Authentication Error", SoapException.ClientFaultCode);
    }

    [SoapHeader("Auth")]
    [WebMethod]
    public List<V_Saatler> Saatler()
    {
        Login();
        return db.V_Saatler.ToList();
    }
}
