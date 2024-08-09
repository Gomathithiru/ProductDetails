<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductMaster.aspx.cs" Inherits="ProductMangement.ProductMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table>
                <tr>
                    <td>ProductName  
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    </td>
                    <td>Size</td>
                    <td>
                        <asp:DropDownList ID="ddlSize" runat="server">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="S" Value="S"></asp:ListItem>
                            <asp:ListItem Text="M" Value="M"></asp:ListItem>
                            <asp:ListItem Text="L" Value="L"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    </td>

                    <td>Catagory</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Standard" Value="Standard"></asp:ListItem>
                            <asp:ListItem Text="Premium" Value="Premium"></asp:ListItem>
                            <asp:ListItem Text="Economy" Value="Economy"></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                    <td>Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    </td>
                    <td>

                        <asp:Calendar ID="dtMFG" runat="server"  OnSelectionChanged="dtMFG_SelectionChanged" ></asp:Calendar>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        

                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>

                    </td>
                    <td>


                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"></asp:Button>

                    </td>
                </tr>
            </table>
          
                    <asp:GridView ID="grdProduct" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="ProductID" DataField="ProductID" />
                            <asp:BoundField HeaderText="ProductName" DataField="ProductName" />
                            <asp:BoundField HeaderText="Size" DataField="Size" />
                            <asp:BoundField HeaderText="Price" DataField="Price" />
                            <asp:BoundField HeaderText="MfgDate" DataField="MfgDate" />
                            <asp:BoundField HeaderText="Category" DataField="Category" />

                        </Columns>
                    </asp:GridView>
               
        </div>
    </form>
</body>
</html>
