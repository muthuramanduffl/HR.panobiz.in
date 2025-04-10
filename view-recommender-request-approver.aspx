<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="view-recommender-request-approver.aspx.cs" Inherits="admin_request_approver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="page-inner">
            <div class="page-header">
                <div class="d-flex">
                    <h4 class="page-title text-uppercase align-self-center">View Recommender Request Approver</h4>
                    <ul class="breadcrumbs py-0">
                        <li class="nav-home">
                            <a href="dashboard.aspx">
                                <i class="flaticon-home"></i>
                            </a>
                        </li>
                    </ul>
                </div>

                <div class="ml-12">

                    <%--                <input type="button" onclick="window.location.href='addholidays.aspx'" value="Add" class="btn btn-success py-1 px-2 ml-auto">--%>
                </div>
            </div>
            <h1 class="d-flex m-0">
                <a href="Add-recommender-request-approver.aspx" class="btn btn-default py-1 btn-sm mb-3 ml-auto" style="/* float: right; */"><i class="icon-list" style="position: relative; top: 2px; left: -5px;"></i>Add Recommender Request Approver</a>
            </h1>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex">
                                <asp:Label ID="lblTotal" runat="server" Text="" class="Total-count"></asp:Label>
                            </div>
                            <div class="table-responsive">
                                <div class="col-lg-12 row f-12 sort_by_select pt-2">
                                </div>
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <label>Client</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" AutoPostBack="true" ID="ddlcompany" runat="server" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged1" EnableViewState="true">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="" runat="server" ErrorMessage="Select client" Display="Dynamic"
                                                        ControlToValidate="ddlcompany" ValidationGroup="val"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <label>Requester</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlrequester_SelectedIndexChanged" ID="ddlrequester" runat="server">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="" runat="server" ErrorMessage="Select requester" Display="Dynamic"
                                                        ControlToValidate="ddlrequester" ValidationGroup="val"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlrequester" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <label>Emp ID</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlemp_SelectedIndexChanged" ID="ddlemp" runat="server">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="error">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator112" InitialValue="" runat="server" ErrorMessage="Select Emp ID" Display="Dynamic"
                                                        ControlToValidate="ddlemp" ValidationGroup="val"></asp:RequiredFieldValidator>
                                                </span>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlrequester" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlemp" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-2 col-md-6 mb-4">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <label>Moduler</label>
                                                <asp:DropDownList CssClass="form-control h-80px" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlModuler_SelectedIndexChanged" ID="ddlModuler" runat="server">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                    <asp:ListItem Value="Man Power">Man Power</asp:ListItem>
                                                    <asp:ListItem Value="Job Officer">Job Officer</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlrequester" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlemp" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlModuler" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-lg-1 col-md-6">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <div class="mt-4">
                                                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary btn-sm py-1 btn-h" Text="Clear" OnClick="btnClear_Click" />
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlrequester" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlemp" EventName="SelectedIndexChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="ddlModuler" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="">
                                            <div class="">
                                                <div class="tab-content mt-2 mb-3" id="pills-tabContent">
                                                    <div>
                                                        <asp:Label ID="lblmsg" runat="server" CssClass="text-dark" Text=""></asp:Label>
                                                    </div>
                                                    <div class="tab-pane fade show active" id="pills-table-2" role="tabpanel" aria-labelledby="pills-table-2-tab">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Repeater ID="rprjobfunction" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="OnItemDataBound" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="basic-datatables4" class="display table-striped table-hover table-head-bg-info table">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th>ID</th>
                                                                                    <th>Client ID</th>
                                                                                    <th>Requester</th>
                                                                                    <th>Moduler</th>
                                                                                    <th>EMPID</th>
                                                                                    <th>MPAStatus</th>
                                                                                    <th>Action</th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <asp:HiddenField ID="HiddenField1" Value='<%# Eval("ID") %>' runat="server" />

                                                                            <th style="color: black !important">
                                                                                <asp:Label ID="lblRowNumber" runat="server" />
                                                                            </th>

                                                                            <td><%# GetName(Eval("ClientID").ToString()) %></td>
                                                                            <td><%# GetEmpRoleName(Eval("Requester").ToString()) %></td>
                                                                            <td><%# Eval("Moduler") %></td>
                                                                            <td><%#  GetEmpID(Eval("EMPID").ToString()) %></td>
                                                                            <td><%# Eval("MPAStatus") %></td>
                                                                            <td>
                                                                                <input class="btn btn-sm btn-outline-secondary" onclick="window.location.href='Add-recommender-request-approver.aspx?ID=<%# Eval("ID") %>'" type="button" value="Edit" <%#(System.Convert.ToString(DataBinder.Eval(Container.DataItem, "ID"))) %> />
                                                                                <asp:LinkButton
                                                                                    ID="LinkButton2"
                                                                                    runat="server"
                                                                                    CssClass="dlt-img btn btn-sm btn-outline-secondary"
                                                                                    Text="Delete"
                                                                                    CommandName="Delete"
                                                                                    CommandArgument='<%# Eval("ID") %>'
                                                                                    OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </tbody>
					</table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlcompany" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="ddlrequester" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="ddlemp" EventName="SelectedIndexChanged" />
                                                                <asp:AsyncPostBackTrigger ControlID="ddlModuler" EventName="SelectedIndexChanged" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

