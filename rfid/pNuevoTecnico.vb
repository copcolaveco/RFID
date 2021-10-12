Public Class pNuevoTecnico
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dNuevoTecnico = CType(o, dNuevoTecnico)
        Dim sql As String = "INSERT INTO nuevo_tecnico (id, nombre, direccion, telefono, celular, email, enviado) VALUES (" & obj.ID & ",'" & obj.NOMBRE & "', '" & obj.DIRECCION & "','" & obj.TELEFONO & "','" & obj.CELULAR & "','" & obj.EMAIL & "'," & obj.ENVIADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dNuevoTecnico = CType(o, dNuevoTecnico)
        Dim sql As String = "UPDATE nuevo_tecnico SET nombre ='" & obj.NOMBRE & "', direccion ='" & obj.DIRECCION & "', telefono ='" & obj.TELEFONO & "', celular ='" & obj.CELULAR & "', email ='" & obj.EMAIL & "', enviado =" & obj.ENVIADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarenviado(ByVal o As Object) As Boolean
        Dim obj As dNuevoTecnico = CType(o, dNuevoTecnico)
        Dim sql As String = "UPDATE nuevo_tecnico SET enviado = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dNuevoTecnico = CType(o, dNuevoTecnico)
        Dim sql As String = "DELETE FROM nuevo_tecnico WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNuevoTecnico
        Dim obj As dNuevoTecnico = CType(o, dNuevoTecnico)
        Dim t As New dNuevoTecnico
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), enviado FROM nuevo_tecnico WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                t.ID = CType(unaFila.Item(0), Long)
                t.NOMBRE = CType(unaFila.Item(1), String)
                t.DIRECCION = CType(unaFila.Item(2), String)
                t.TELEFONO = CType(unaFila.Item(3), String)
                t.CELULAR = CType(unaFila.Item(4), String)
                t.EMAIL = CType(unaFila.Item(5), String)
                t.ENVIADO = CType(unaFila.Item(6), Integer)

                Return t
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dNuevoTecnico
        Dim obj As dNuevoTecnico = CType(o, dNuevoTecnico)
        Dim t As New dNuevoTecnico
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), enviado FROM nuevo_tecnico ORDER By id DESC LIMIT 1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                 t.ID = CType(unaFila.Item(0), Long)
                t.NOMBRE = CType(unaFila.Item(1), String)
                t.DIRECCION = CType(unaFila.Item(2), String)
                t.TELEFONO = CType(unaFila.Item(3), String)
                t.CELULAR = CType(unaFila.Item(4), String)
                t.EMAIL = CType(unaFila.Item(5), String)
                t.ENVIADO = CType(unaFila.Item(6), Integer)

                Return t
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), enviado FROM nuevo_tecnico order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim t As New dNuevoTecnico
                    t.ID = CType(unaFila.Item(0), Long)
                    t.NOMBRE = CType(unaFila.Item(1), String)
                    t.DIRECCION = CType(unaFila.Item(2), String)
                    t.TELEFONO = CType(unaFila.Item(3), String)
                    t.CELULAR = CType(unaFila.Item(4), String)
                    t.EMAIL = CType(unaFila.Item(5), String)
                    t.ENVIADO = CType(unaFila.Item(6), Integer)
                    Lista.Add(t)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), enviado FROM nuevo_tecnico WHERE enviado = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim t As New dNuevoTecnico
                    t.ID = CType(unaFila.Item(0), Long)
                    t.NOMBRE = CType(unaFila.Item(1), String)
                    t.DIRECCION = CType(unaFila.Item(2), String)
                    t.TELEFONO = CType(unaFila.Item(3), String)
                    t.CELULAR = CType(unaFila.Item(4), String)
                    t.EMAIL = CType(unaFila.Item(5), String)
                    t.ENVIADO = CType(unaFila.Item(6), Integer)
                    Lista.Add(t)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(direccion,''), ifnull(telefono,''), ifnull(celular,''), ifnull(email,''), enviado FROM nuevo_tecnico WHERE nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim t As New dNuevoTecnico()
                    t.ID = CType(unaFila.Item(0), Long)
                    t.NOMBRE = CType(unaFila.Item(1), String)
                    t.DIRECCION = CType(unaFila.Item(2), String)
                    t.TELEFONO = CType(unaFila.Item(3), String)
                    t.CELULAR = CType(unaFila.Item(4), String)
                    t.EMAIL = CType(unaFila.Item(5), String)
                    t.ENVIADO = CType(unaFila.Item(6), Integer)
                    listaResultado.Add(t)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
End Class
