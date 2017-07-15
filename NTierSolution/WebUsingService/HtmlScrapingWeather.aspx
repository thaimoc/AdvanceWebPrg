<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HtmlScrapingWeather.aspx.cs" Inherits="WebUsingService.HtmlScrapingWeather" %>
<%@ OutputCache Duration="200" VaryByParam="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>Hiện tại:
                <p><asp:Label runat="server" ID="lblCurrentTime"></asp:Label></p>
            </th>
            <th>Hôm nay:
                <p><asp:Label runat="server" ID="lblCurrentDate"></asp:Label></p>
            </th>
            <th>Ngày mai:
                <p><asp:Label runat="server" ID="lblTomorrowDate"></asp:Label></p>
            </th>
            <th>Ngày kia:
                <p><asp:Label runat="server" ID="lblAfterTomorrow"></asp:Label></p>
            </th>            
        </tr>
        <asp:Repeater runat="server" ID="repData">
            <ItemTemplate>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <div class="tinh-tp">
                                        <a title='<%#Eval("Name")%>' href="#">
                                            <h3><strong><%#Eval("Name")%></strong></h3>
                                        </a>
                                        (Hôm nay, cập nhật lúc ...)
                                    </div>
                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                        <tr>
										    <td width="100" class="thoitiet-cell">
                                                <img width="90" height="86" alt="" src='<%# ShowWeather(Container.DataItem, "Image") %>'>
                                            </td>
										    <td>
                                                <%# ShowWeather(Container.DataItem, "Condition") %>
                                            </td>
									    </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div class="tt-sub-pic"><img width="64" height="60" alt="" 
                            src='<%# GetWeatherInfo(Container.DataItem, 0, "Image") %>'>
                        </div>
                        <div class="tt-sub-text">
                            <span class="nhietdo-small"><%# GetWeatherInfo(Container.DataItem, 0, "Temp") %><br>
                            <span class="tt-sub-small"><%# GetWeatherInfo(Container.DataItem, 0, "Condition")%></span>
                        </div>
                    </td>
                    <td>
                        <div class="tt-sub-pic"><img width="64" height="60" alt="" 
                            src='<%# GetWeatherInfo(Container.DataItem, 1, "Image") %>'>
                        </div>
                        <div class="tt-sub-text">
                            <span class="nhietdo-small"><%# GetWeatherInfo(Container.DataItem, 1, "Temp") %><br>
                            <span class="tt-sub-small"><%# GetWeatherInfo(Container.DataItem, 1, "Condition")%></span>
                        </div>
                    </td>
                    <td>
                        <div class="tt-sub-pic"><img width="64" height="60" alt="" 
                            src='<%# GetWeatherInfo(Container.DataItem, 2, "Image") %>'>
                        </div>
                        <div class="tt-sub-text">
                            <span class="nhietdo-small"><%# GetWeatherInfo(Container.DataItem, 2, "Temp") %><br>
                            <span class="tt-sub-small"><%# GetWeatherInfo(Container.DataItem, 2, "Condition")%></span>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
