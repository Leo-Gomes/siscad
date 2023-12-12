Imports Model

Public Class AssociadoDados
    Public Shared Function Associados() As List(Of AssociadoModel)
        Dim table = DataAccess.SQL("select * from associados")
        Dim listAssociados As New List(Of AssociadoModel)

        For index = 0 To table.Count - 1
            Dim value = table.Table.Rows(index).Item(0)
            Dim name = table.Table.Rows(index).Item(1)
            listAssociados.Add(New AssociadoModel With {
                                    .Id = table.Table.Rows(index).Item(0),
                                    .Nome = table.Table.Rows(index).Item(1),
                                    .CPF = table.Table.Rows(index).Item(2),
                                    .DataNascimento = table.Table.Rows(index).Item(3)
                               })
        Next

        Return listAssociados
    End Function

    Public Shared Sub CadastroAssociado(associado As AssociadoModel)
        Dim sql As String = $"DECLARE @idAssociado INT
                              BEGIN
                              	INSERT INTO associados (
                              		nome
                              		,cpf
                              		,DataNascimento
                              		)
                              	VALUES (
                              		'{associado.Nome}'
                              		,'{associado.CPF}'
                              		,'{associado.DataNascimento}'
                              		)
                              
                              	SET @idAssociado = @@identity
                              END
                              "

        For Each item As EmpresaModel In associado.EmpresaLista
            sql += $"begin
                        insert into Associado_Empresa(Id_Associado,id_Empresa)values(@idAssociado,{item.Id})
                    end"
        Next

        DataAccess.ExecuteReader(sql)

    End Sub

    Public Shared Sub AtualizaAssociado(associado As AssociadoModel)
        Dim sql As String = $"update associados
                              		set nome = '{associado.Nome}'
                              		,cpf = '{associado.CPF}'
                              		,DataNascimento = '{associado.DataNascimento}'
                              		where id = {associado.Id}"

        DataAccess.ExecuteReader(sql)

    End Sub

    Public Shared Sub RemoverAssociado(associado As AssociadoModel)
        Dim sql As String = $"delete from Associado_Empresa where id_associado = {associado.Id}; delete from associados where id = {associado.Id} "

        DataAccess.ExecuteReader(sql)

    End Sub
End Class
