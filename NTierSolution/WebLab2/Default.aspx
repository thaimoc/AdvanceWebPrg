<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebLab2._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

    <%@ Register Assembly="ServerControls" Namespace="ServerControls" TagPrefix="CC" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-2.0.0.min.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <CC:WelcomeLabel runat="server" Text="Xin Chao" DefaultUserName="Hoai Khong" ID="wlbl"></CC:WelcomeLabel>
    
    <CC:EmailTextbox ID="EmailTextbox1" runat="server" 
        ErrorMessage="Not format email!" />
    
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>


        <br />
        <aspSample:EmailTextbox ID="EmailTextbox2" runat="server" />
        <aspSample:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="Images/1367839550_plus-24.png" Text="button"/>
        
        <aspSample:DatetimePicker ID="DatetimePicker1" runat="server"></aspSample:DatetimePicker>

        <br />
        
        <aspSample:StatusInfo ID="StatusInfo1" runat="server" />
        <div class="UpdatePanel">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <aspSample:TimemerInfo ID="TimemerInfo1" runat="server" DateImageUrl="Images/icon_mini_memberlist.gif" TimeImageUrl="Images/alarmclock.gif" />
        </ContentTemplate>              
        </asp:UpdatePanel>
        </div>
        <aspSample:XmlCustomControl ID="XmlCustomControl1" runat="server" XmlPath="D:/KimNguyen's Data/Advance Web Programming/dlu/Lab/NTierSolution/WebLab2/App_Data/XMLFile.xml" />
        <div>
            
            
            <div>
                <asp:Chart ID="Chart1" runat="server" Height="400px" Width="800px">
                    <Series>
                        <asp:Series Name="Testing" YValueType="Int32">

			                <Points>
				                <asp:DataPoint AxisLabel="Test 1" YValues="10" />
				                <asp:DataPoint AxisLabel="Test 2" YValues="20" />

				                <asp:DataPoint AxisLabel="Test 3" YValues="30" />
				                <asp:DataPoint AxisLabel="Test 4" YValues="40" />

			                </Points>
		                </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
           
</asp:Content>


