Public Class AssociadoModel
    Public Property Id As Integer
    Public Property Nome As String
    Public Property CPF As String
    Public Property DataNascimento As String
    Public Property EmpresaLista As List(Of EmpresaModel)
End Class
