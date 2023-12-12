Imports Model

Public Class EmpresaDados
    Public Shared Function Empresas() As List(Of EmpresaModel)
        Dim table = DataAccess.SQL("select * from empresa")
        Dim listEmpresas As New List(Of EmpresaModel)

        For index = 0 To table.Count - 1
            Dim value = table.Table.Rows(index).Item(0)
            Dim name = table.Table.Rows(index).Item(1)
            listEmpresas.Add(New EmpresaModel With {
                                    .Id = table.Table.Rows(index).Item(0),
                                    .RazaoSocial = table.Table.Rows(index).Item(1),
                                    .CNPJ = table.Table.Rows(index).Item(2)
                               })
        Next

        Return listEmpresas
    End Function

    Public Shared Sub CadastroEmpresa(empresa As EmpresaModel)
        Dim sql As String = $"
                              	INSERT INTO empresa (
                              		nome
                              		,cnpj
                              		)
                              	VALUES (
                              		'{empresa.RazaoSocial}'
                              		,'{empresa.CNPJ}'                            		
                              		)
                              "

        DataAccess.ExecuteReader(sql)

    End Sub

    Public Shared Sub AtualizaEmpresa(empresa As EmpresaModel)
        Dim sql As String = $"update empresa
                              		set nome = '{empresa.RazaoSocial}'
                              		,cnpj = '{empresa.CNPJ}'
                              		where id = {empresa.Id}"

        DataAccess.ExecuteReader(sql)

    End Sub

    Public Shared Sub RemoverEmpresa(empresa As EmpresaModel)
        Dim sql As String = $"delete from Associado_Empresa where id_empresa = {empresa.Id}; delete from empresa where id = {empresa.Id} "

        DataAccess.ExecuteReader(sql)

    End Sub
End Class
