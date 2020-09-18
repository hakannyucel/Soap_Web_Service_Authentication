using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TumSaatler : System.Web.UI.Page
{
    WatchRef.ServiceSoapClient client = new WatchRef.ServiceSoapClient();
    WatchRef.AuthControl auth = new WatchRef.AuthControl();

    protected void Page_Load(object sender, EventArgs e)
    {
        var saatler = client.Saatler(auth);
        foreach (var saat in saatler)
        {
            listSaatler.Items.Add(saat.Model);
        }
    }
}