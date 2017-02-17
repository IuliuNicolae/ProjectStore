using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class AdRedirection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String adName = Request.QueryString["ad"];
        String redirect = Request.QueryString["target"];
        if (adName == null | redirect == null)
            redirect = "AdRedirection.aspx";

        XmlDocument doc = new XmlDocument();

        doc.Load(Server.MapPath("AdResponses.xml"));
        System.Xml.XmlNode root = doc.DocumentElement;
        System.Xml.XmlNode adNode =
            root.SelectSingleNode(
            @"descendant::ad[@adname='" + adName + "']");
        if (adNode != null)
        {
            int ctr =
                int.Parse(adNode.Attributes["hitCount"].Value);
            ctr += 1;
            System.Xml.XmlNode newAdNode = adNode.CloneNode(false);
            newAdNode.Attributes["hitCount"].Value = ctr.ToString();
            root.ReplaceChild(newAdNode, adNode);
            doc.Save(Server.MapPath("AdResponses.xml"));
        }
        Response.Redirect(redirect);
    }
}


