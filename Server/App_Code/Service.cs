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

    [SoapHeader("Auth")]
    [WebMethod]
    public List<V_Saatler> saatler()
    {
        ErsaEntities db = new ErsaEntities();
        if (Context.Cache["Token"] != null && Context.Cache["Token"].ToString() == Auth.Token)
        {
            return db.V_Saatler.ToList();
        }
        else
        {
            if (!Auth.IsValid())
                throw new SoapException("Authentication Error", SoapException.ClientFaultCode);
            Context.Cache.Insert("Token", Auth.Token, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
            return db.V_Saatler.ToList();
        }
    }
}
