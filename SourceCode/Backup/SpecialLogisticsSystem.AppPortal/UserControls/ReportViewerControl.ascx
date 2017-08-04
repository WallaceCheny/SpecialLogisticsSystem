<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportViewerControl.ascx.cs" Inherits="SpecialLogisticsSystem.AppPortal.UserControls.ReportViewerControl" %>
<table cellpadding="0" cellspacing="0" border="0" style="margin:auto;"
    width="850px">
    <tr>
        <td style="padding-left: 150px; padding-right: 20px;text-align:center;">
            <dx:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewerID="ReportViewer1"
                EnableViewState="False">
                <Items>
                    <dx:ReportToolbarButton ItemKind='Search' ToolTip='Display the search window' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='PrintReport' ToolTip='Print the report' />
                    <dx:ReportToolbarButton ItemKind='PrintPage' ToolTip='Print the current page' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' ToolTip='First Page' />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' ToolTip='Previous Page' />
                    <dx:ReportToolbarLabel Text='Page' />
                    <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px' />
                    <dx:ReportToolbarLabel Text="of" />
                    <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                    <dx:ReportToolbarButton ItemKind='NextPage' ToolTip='Next Page' />
                    <dx:ReportToolbarButton ItemKind='LastPage' ToolTip='Last Page' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='SaveToDisk' ToolTip='Export a report and save it to the disk' />
                    <dx:ReportToolbarButton ItemKind='SaveToWindow' ToolTip='Export a report and show it in a new window' />
                    <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                        <Elements>
                            <dx:ListElement Text='Pdf' Value='pdf' />
                            <dx:ListElement Text='Xls' Value='xls' />
                            <dx:ListElement Text='Xlsx' Value='xlsx' />
                            <dx:ListElement Text='Rtf' Value='rtf' />
                            <dx:ListElement Text='Mht' Value='mht' />
                            <dx:ListElement Text='Html' Value='html' />
                            <dx:ListElement Text='Text' Value='txt' />
                            <dx:ListElement Text='Image' Value='png' />
                            <dx:ListElement Text='Csv' Value='csv' />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
            </dx:ReportToolbar>
        </td>
    </tr>
    <tr>
        <td style="height: 8px" />
    </tr>
    <tr>
        <td valign="top">
            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                <tr>
                    <td class="PageBorder_tlc" style="width: 10px; height: 10px;">
                        <div style="width: 10px; height: 10px; font-size: 1px" />
                    </td>
                    <td class="PageBorder_t" />
                    <td class="PageBorder_trc" style="width: 10px; height: 10px;">
                        <div style="width: 10px; height: 10px; font-size: 1px" />
                    </td>
                </tr>
                <tr>
                    <td class="PageBorder_l" />
                    <td style="background-color: white;" valign="top">
                        <dx:ReportViewer ID="ReportViewer1" Style="width: 100%; height: 100%; text-align: left"
                            runat="server" ClientInstanceName="ReportViewer1" EnableViewState="False">
                        </dx:ReportViewer>
                    </td>
                    <td class="PageBorder_r" />
                </tr>
                <tr>
                    <td class="PageBorder_blc" style="width: 10px; height: 10px;" />
                    <td class="PageBorder_b" />
                    <td class="PageBorder_brc" style="width: 10px; height: 10px;" />
                </tr>
            </table>
        </td>
    </tr>
</table>