<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NatureFresh.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css/Register.css" rel="stylesheet" />
    
    <div class="MainContainerDiv">
        <div  id ="RegDivId"> 
            
        <asp:Label ID="RegisterLabel" runat="server" Text="Register" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <table class="auto-style1">  
                <tr>  
                    <td>Name :</td>  
                    <td>  
                        <asp:TextBox ID="RegNameTextBox" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  

                <tr>  
                    <td>Username</td>  
                     <td> <asp:TextBox ID="RegUsernameTextBox" runat="server"></asp:TextBox></td>  
                </tr>  
                
                <tr>  
                    <td>Password</td>  
                     <td> <asp:TextBox ID="RegPasswordTextBox" runat="server"></asp:TextBox></td>  
                </tr>  
                <tr>  
                    <td>Confirm Password</td>  
                    <td>  
                        <asp:TextBox ID="RegPassword2TextBox" runat="server" TextMode="Password"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Gender</td>  
                    <td>  
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">  
                            <asp:ListItem>Male</asp:ListItem>  
                            <asp:ListItem>Female</asp:ListItem>  
                        </asp:RadioButtonList>  
                    </td>  
               </tr>  

                <tr>  
                    <td>Address</td>  
                    <td>  
                        <asp:TextBox ID="RegAddressTextBox" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  

                <tr>  
                    <td>ZipCode</td>  
                    <td>  
                        <asp:TextBox ID="RegZipTextBox" runat="server"></asp:TextBox>  
                    </td>

                <tr>  
                    <td>Email</td>  
                    <td>  
                        <asp:TextBox ID="RegEmailTextBox" runat="server"></asp:TextBox>  
                    </td>  
                </tr>  
                <tr>  
                    <td>Mobile</td>  
                    <td>  
                        <asp:TextBox ID="RegMobileTextBox" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr>  
                    <td>  
                        <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />  
                    </td>  
                </tr>  
            </table>  
        </div> 

        <div id ="LoginDivId">  
        <asp:Label ID="LoginLabel" runat="server" Text="Login" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <table class="auto-style1">  

                <tr>  
                    <td>Username</td>  
                     <td> <asp:TextBox ID="LoginUsernameTextBox" runat="server"></asp:TextBox></td>  
                </tr>  

                <tr>  
                    <td>Password</td>  
                     <td> <asp:TextBox ID="LoginPasswordTextBox" runat="server"></asp:TextBox></td>  
                </tr>  
                <tr>  
                    <td>  
                        <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />  
                        
                    </td>  
                </tr>  
            </table>  
            <asp:Label ID="IdLabel" runat="server" Text="---"></asp:Label>
        </div>
        </div>

</asp:Content>
