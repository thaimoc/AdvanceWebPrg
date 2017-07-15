<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusUserOnline.ascx.cs" Inherits="WebFormApp.Controls.StatusUserOnline" %>
<div class="grid_3">
    <div class="grid_1 title alpha">
        Users is online:
    </div>
    <div class="grid_2 omega">
        <asp:Label runat="server" ID="lblUserIsOnline"></asp:Label>
    </div>
    <div class="clear"></div>
</div>
<div class="grid_3">
    <div class="grid_1 title alpha">
        Users accessed:
    </div>
    <div class="grid_2 omega">
        <asp:Label runat="server" ID="lblUserAccessed"></asp:Label>
    </div>
    <div class="clear"></div>
</div>