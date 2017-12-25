using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCBillManagementSystemWebApp.BLL;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model;

namespace DCBillManagementSystemWebApp.UI
{
    public partial class TestNameUI : System.Web.UI.Page
    {
        readonly NameManager _aNameManager = new NameManager();
        readonly TypeManager _aTypeManager = new TypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                typeDropDownList.DataSource = _aTypeManager.GetAllTestType();
                typeDropDownList.DataTextField = "TestType";
                typeDropDownList.DataValueField = "Sl";
                typeDropDownList.DataBind();
            }
            nameGridView.DataSource = _aNameManager.GetAllName();
            nameGridView.DataBind();

        }

        protected void NameSaveButton_Click(object sender, EventArgs e)
        {

            if (nameTextBox.Text != String.Empty && feeTextBox.Text != String.Empty)
            {
                try
                {
                    var aTestNames = new TestNames
                    {
                        TestName = nameTextBox.Text,
                        Fee = Convert.ToDouble(feeTextBox.Text),
                        TestTypeId = Convert.ToInt32(typeDropDownList.SelectedValue)
                    };
                    nameMessageLabel.Text = (Convert.ToDouble(feeTextBox.Text) > 0)
                        ? _aNameManager.SaveTestName(aTestNames)
                        : "Please insert amount greater than zero";
                }
                catch
                {
                    nameMessageLabel.Text= "Please Insert information in the right format";
                }
            }
            else
            {
                nameMessageLabel.Text = "Please insert information properly";
            }
            Page_Load(sender, e);
        }
    }
}