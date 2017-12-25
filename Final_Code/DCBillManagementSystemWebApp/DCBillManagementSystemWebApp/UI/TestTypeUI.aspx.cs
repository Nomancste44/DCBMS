using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class TestTypeUI : System.Web.UI.Page
    {
        readonly TypeManager _aTypeManager = new TypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            typeGridView.DataSource = _aTypeManager.GetAll();
            typeGridView.DataBind();
        }

        protected void typeSaveButton_Click(object sender, EventArgs e)
        {
           messageLabel.Text= typeTextBox.Text!=String.Empty?_aTypeManager.SaveTestType(typeTextBox.Text):"Please Insert the Type Name";
            Page_Load(sender,e);
        }
    }
}