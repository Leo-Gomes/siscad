<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Associado.aspx.vb" Inherits="WebApplication1.Associado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #b4b4b4; font-size: xx-large" color="white" align="center">
        CADASTRO DE ASSOCIADOS
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="Id associado" ID="lblidassociado"></asp:Label>
            </div>
            <div class="col-md-10">
                <input id="txtid" class="col-md-12" type="text" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="nome" ID="lblnome"></asp:Label>
            </div>
            <div class="col-md-10">
                <input id="txtnome" class="col-md-12" type="text" runat="server" />
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="cpf" ID="lblcpf"></asp:Label>
            </div>
            <div class="col-md-4">
                <input id="txtcpf" type="number" class="col-md-12" maxlength="11" runat="server" formenctype="multipart/form-data" placeholder="xxx.xxx.xxx-xx" />
            </div>
            <div class="col-md-2">
                <asp:Label runat="server" Text="data nascimento" ID="ctl03"></asp:Label>
            </div>
            <div class="col-md-4">
                <input id="txtdatanas" class="col-md-12" type="date" runat="server" />
            </div>
        </div>
        <div class="row">
            <asp:CheckBoxList ID="listEmpresa" runat="server"></asp:CheckBoxList>
        </div>
        <div class="row">
            <asp:Button runat="server"  Text="Cadastrar" ID="btncadastrar" class="btn btn-success col-md-12"></asp:Button>
        </div>

        <div class="row">
            <hr />
            <asp:GridView runat="server" HeaderStyle-BackColor="#68bafd" ID="GridView1" EmptyDataText="No records." AutoGenerateColumns="false" 
                OnRowDataBound="OnRowDataBound" OnRowCancelingEdit="OnRowCancelingEdit"
                OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" DataKeyNames="Id" class="col-md-12">
                <Columns>
                    <asp:TemplateField HeaderText="Nome" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Nome") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CPF" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblCPF" runat="server" Text='<%# Eval("CPF") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCPF" runat="server" Text='<%# Eval("CPF") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data de Nascimento" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label ID="lblDataNascimento" runat="server" Text='<%# Eval("DataNascimento") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDataNascimento" runat="server" Text='<%# Eval("DataNascimento") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
