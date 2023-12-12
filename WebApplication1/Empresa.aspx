<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Empresa.aspx.vb" Inherits="WebApplication1.Empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div style="background-color: #b4b4b4; font-size: xx-large" color="white" align="center">
     CADASTRO DE EMPRESAS
 </div>
 <br />
 <div class="container">
     <div class="row">
         <div class="col-md-2">
             <asp:Label runat="server" Text="Id empresa" ID="lblidempresa"></asp:Label>
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
             <input id="txtnome" class="col-md-12" type="text" required runat="server" />
         </div>
     </div>

     <div class="row">
         <div class="col-md-2">
             <asp:Label runat="server" Text="cnpj" ID="lblcnpj"></asp:Label>
         </div>

         <div class="col-md-4">
             <input id="txtcnpj" type="number" class="col-md-12" maxlength="11" required runat="server" formenctype="multipart/form-data" />
         </div>
        
     </div>
     <div class="row">
         <asp:CheckBoxList ID="listEmpresa" runat="server"></asp:CheckBoxList>
     </div>
     <div class="row">
         <asp:Button runat="server" Text="Cadastrar" ID="btncadastrar" class="btn btn-success col-md-12"></asp:Button>
     </div>

     <div class="row">
         <hr />
         <asp:GridView runat="server" HeaderStyle-BackColor="#68bafd" ID="GridView1" EmptyDataText="No records." AutoGenerateColumns="false" 
             OnRowDataBound="OnRowDataBound" OnRowCancelingEdit="OnRowCancelingEdit"
             OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" DataKeyNames="Id" class="col-md-12">
             <Columns>
                 <asp:TemplateField HeaderText="Nome" ItemStyle-Width="150">
                     <ItemTemplate>
                         <asp:Label ID="lblName" runat="server" Text='<%# Eval("RazaoSocial") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("RazaoSocial") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="CNPJ" ItemStyle-Width="150">
                     <ItemTemplate>
                         <asp:Label ID="lblCNPJ" runat="server" Text='<%# Eval("CNPJ") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtCNPJ" runat="server" Text='<%# Eval("CNPJ") %>'></asp:TextBox>
                     </EditItemTemplate>
                 </asp:TemplateField>
            
                 <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />
             </Columns>
         </asp:GridView>
     </div>
 </div>
</asp:Content>
