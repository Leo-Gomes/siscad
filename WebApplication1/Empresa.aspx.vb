Imports DAO
Imports Model

Public Class Empresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            CarregaDados()
        End If
    End Sub

    Private Sub btncadastrar_Click(sender As Object, e As EventArgs) Handles btncadastrar.Click
        Dim empresa As New EmpresaModel
        empresa.RazaoSocial = txtnome.Value
        empresa.CNPJ = txtcnpj.Value


        EmpresaDados.CadastroEmpresa(empresa)
        CarregaDados()
    End Sub

    Public Sub CarregaDados()

        GridView1.DataSource = EmpresaDados.Empresas()
        GridView1.DataBind()

        If Not IsPostBack Then
            Dim tableEmpresa = DataAccess.SQL("select * from empresa")
            For index = 0 To tableEmpresa.Count - 1
                Dim value = tableEmpresa.Table.Rows(index).Item(0)
                Dim name = tableEmpresa.Table.Rows(index).Item(1)
                listEmpresa.Items.Add(New ListItem(name, value))
            Next
        End If

    End Sub

    Protected Sub OnRowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        Me.CarregaDados()
    End Sub

    Protected Sub OnRowCancelingEdit(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.EditIndex = -1
        Me.CarregaDados()
    End Sub

    Protected Sub OnRowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)

        Dim empresa As New EmpresaModel With {
                .Id = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Values(0)),
                .RazaoSocial = TryCast(row.FindControl("txtName"), TextBox).Text,
                .CNPJ = TryCast(row.FindControl("txtCNPJ"), TextBox).Text
            }

        EmpresaDados.AtualizaEmpresa(empresa)

        GridView1.EditIndex = -1
        Me.CarregaDados()
    End Sub

    Protected Sub OnRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        Dim empresa As New EmpresaModel With {
                .Id = Convert.ToInt32(GridView1.DataKeys(e.RowIndex).Values(0))
            }

        EmpresaDados.RemoverEmpresa(empresa)

        GridView1.EditIndex = -1
        Me.CarregaDados()

    End Sub

    Protected Sub OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowIndex <> GridView1.EditIndex Then
            Dim linkButtom As LinkButton = TryCast(e.Row.Cells(2).Controls(2), LinkButton)
            linkButtom.Attributes("onclick") = "return confirm('Deseja realmente excluir o registro?');"
        End If
    End Sub

    Private Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing

    End Sub
End Class