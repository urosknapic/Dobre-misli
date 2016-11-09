using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dobre_misli
{
  public partial class Default : System.Web.UI.Page
  {
    List<Label> history = new List<Label>();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Application["history"] == null)
        Application["history"] = history;
      
      if (!IsPostBack)
      {
        RefreshMessages();
      }
    }

    protected void dodajMisel_Click(object sender, EventArgs e)
    {
      history = (List<Label>)Application["history"];
      TextBox tb = (TextBox)FindControl("misel");
      Label newLabel = new Label();
      newLabel.Text = tb.Text;
      history.Add(newLabel);
      Application["history"] = history;
      RefreshMessages();
    }

    private void RefreshMessages()
    {
      if(Application["history"] != null)
        history = (List<Label>)Application["history"];
      for (int i = 0; i < history.Count; i++)
      {
        misli.Controls.Add(history[i]);
        misli.Controls.Add(new LiteralControl("<br />"));
      }
    }
  }

}