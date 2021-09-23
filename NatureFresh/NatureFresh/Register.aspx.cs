using System;
using System.Data.SqlClient;
using System.Data;

namespace NatureFresh
{
    
    public partial class Register : System.Web.UI.Page
    {
        string ConString = "Server=tcp:naturefresh.database.windows.net,1433;Initial Catalog = NatureFreshDb; Persist Security Info=False;User ID = shivam; Password={PASSWORD DALDO BHAI}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsernameHolder"] == null) { 
                LoginBtn.Visible = true;
            }
            else
            {
                LoginBtn.Visible = false;
            }
        }



        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand("AddCustomer"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", RegNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@mobile", RegMobileTextBox.Text);
                    cmd.Parameters.AddWithValue("@username", RegUsernameTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", RegPasswordTextBox.Text);
                    cmd.Connection = connection;
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand("AuthUser"))
                {
                    int UId=0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", LoginUsernameTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", LoginPasswordTextBox.Text);
                    cmd.Connection = connection;
                    connection.Open();
                    UId = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                    if(UId == -1)
                    {
                        IdLabel.Text="The Credentials does not match with each other";
                    }
                    else
                    {
                        Session["UsernameHolder"] = LoginUsernameTextBox.Text;
                        IdLabel.Text = ("The Id is: "+UId.ToString());
                        LoginBtn.Visible = false;
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }

        
    }
}