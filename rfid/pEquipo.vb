Public Class pEquipo
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dEquipo = CType(o, dEquipo)
        Dim sql As String = "INSERT INTO equipo_correo (id, equipo, correo) VALUES (" & obj.ID & ", '" & obj.EQUIPO & "','" & obj.CORREO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dEquipo = CType(o, dEquipo)
        Dim sql As String = "UPDATE equipo_correo SET equipo = '" & obj.EQUIPO & "', correo = '" & obj.CORREO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dEquipo = CType(o, dEquipo)
        Dim sql As String = "DELETE FROM equipo_correo WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminartodo(ByVal o As Object) As Boolean
        Dim obj As dEquipo = CType(o, dEquipo)
        Dim sql As String = "DELETE FROM equipo_correo"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEquipo
        Dim obj As dEquipo = CType(o, dEquipo)
        Dim l As New dEquipo
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, equipo, correo FROM equipo_correo WHERE equipo = '" & obj.EQUIPO & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.EQUIPO = CType(unaFila.Item(1), String)
                l.CORREO = CType(unaFila.Item(2), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, equipo, correo FROM equipo_correo"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dEquipo
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.EQUIPO = CType(unaFila.Item(1), String)
                    l.CORREO = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
