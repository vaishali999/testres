<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-right: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Search restaurant 
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" >
                            <asp:ListItem Value="111">shimla</asp:ListItem>
                            <asp:ListItem Value="122">chandigarh</asp:ListItem>
                            <asp:ListItem Value="123">delhi</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                </tr>
            
            
               
            </table>

        </div>
        
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="auto-style1" GridLines="Both" Height="207px"  Width="340px" DataSourceID="SqlDataSource1">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <ItemStyle ForeColor="#000066" />
                <ItemTemplate>
                    <asp:ImageButton ID ="img1" ImageUrl="~/add to cart.jpg" CommandArgument='<%# Eval("rescod") %>' CommandName="abc1" runat="server" />
                    <br />
 
                    <b> res name:  </b><asp:HyperLink ID="hk" Text='<%# Eval("resnam") %>' runat="server" NavigateUrl='<%# Eval("resnam") %>'></asp:HyperLink> 
                    <b>
                    <br />
                    res phone:  </b><%# Eval("resphn") %><br />
                    
                   

                </ItemTemplate>
                <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
