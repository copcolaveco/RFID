﻿Public Class pPedidos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim sql As String = "INSERT INTO pedidosflorida (id, fecha, productor, direccion, agencia, celular, telefono, email, cconservante, sconservante, agua, sangre, caja1, caja2, caja3, caja4, caja5, caja6, observaciones,  marca, estado) VALUES (" & obj.ID & ",'" & obj.FECHA & "', " & obj.IDPRODUCTOR & ",'" & obj.DIRECCION & "'," & obj.IDAGENCIA & ", '" & obj.CELULAR & "','" & obj.TELEFONO & "', '" & obj.EMAIL & "'," & obj.CCONSERVANTE & "," & obj.SCONSERVANTE & "," & obj.AGUA & "," & obj.SANGRE & ",  '" & obj.CAJA1 & "', '" & obj.CAJA2 & "', '" & obj.CAJA3 & "', '" & obj.CAJA4 & "', '" & obj.CAJA5 & "', '" & obj.CAJA6 & "','" & obj.OBSERVACIONES & "', " & obj.MARCA & ", '" & obj.ESTADO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim sql As String = "UPDATE pedidosflorida SET fecha ='" & obj.FECHA & "', productor = " & obj.IDPRODUCTOR & ", direccion = '" & obj.DIRECCION & "', agencia = " & obj.IDAGENCIA & ", celular = '" & obj.CELULAR & "', telefono = '" & obj.TELEFONO & "', email = '" & obj.EMAIL & "', cconservante = " & obj.CCONSERVANTE & ", sconservante = " & obj.SCONSERVANTE & ", agua = " & obj.AGUA & ", sangre = " & obj.SANGRE & ", caja1 = '" & obj.CAJA1 & "', caja2 = '" & obj.CAJA2 & "',  caja3 = '" & obj.CAJA3 & "', caja4 = '" & obj.CAJA4 & "', caja5 = '" & obj.CAJA5 & "', caja6 = '" & obj.CAJA6 & "', observaciones = '" & obj.OBSERVACIONES & "', marca = " & obj.MARCA & ", estado = '" & obj.ESTADO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim sql As String = "UPDATE pedidosflorida SET marca = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        'Dim sql As String = "DELETE FROM pedidos WHERE id = " & obj.ID
        Dim sql As String = "UPDATE pedidosflorida SET eliminado =1 WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPedidos
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim p As New dPedidos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, productor, ifnull(direccion,''), agencia, ifnull(celular,''), ifnull(telefono,''), ifnull(email,''), cconservante, sconservante, agua, sangre, ifnull(caja1,''), ifnull(caja2,''), ifnull(caja3,''), ifnull(caja4,''), ifnull(caja5,''), ifnull(caja6,''), ifnull(observaciones,''), marca, ifnull(estado,'') FROM pedidosflorida WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                p.DIRECCION = CType(unaFila.Item(3), String)
                p.IDAGENCIA = CType(unaFila.Item(4), Integer)
                p.CELULAR = CType(unaFila.Item(5), String)
                p.TELEFONO = CType(unaFila.Item(6), String)
                p.EMAIL = CType(unaFila.Item(7), String)
                p.CCONSERVANTE = CType(unaFila.Item(8), Integer)
                p.SCONSERVANTE = CType(unaFila.Item(9), Integer)
                p.AGUA = CType(unaFila.Item(10), Integer)
                p.SANGRE = CType(unaFila.Item(11), Integer)
                p.CAJA1 = CType(unaFila.Item(12), String)
                p.CAJA2 = CType(unaFila.Item(13), String)
                p.CAJA3 = CType(unaFila.Item(14), String)
                p.CAJA4 = CType(unaFila.Item(15), String)
                p.CAJA5 = CType(unaFila.Item(16), String)
                p.CAJA6 = CType(unaFila.Item(17), String)
                p.OBSERVACIONES = CType(unaFila.Item(18), String)
                p.MARCA = CType(unaFila.Item(19), Integer)
                p.ESTADO = CType(unaFila.Item(20), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dPedidos
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim p As New dPedidos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, productor, ifnull(direccion,''), agencia, ifnull(celular,''), ifnull(telefono,''), ifnull(email,''), cconservante, sconservante, agua, sangre, ifnull(caja1,''), ifnull(caja2,''), ifnull(caja3,''), ifnull(caja4,''), ifnull(caja5,''), ifnull(caja6,''), ifnull(observaciones,''), marca, ifnull(estado,'') FROM pedidosflorida ORDER By id DESC LIMIT 1 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                p.DIRECCION = CType(unaFila.Item(3), String)
                p.IDAGENCIA = CType(unaFila.Item(4), Integer)
                p.CELULAR = CType(unaFila.Item(5), String)
                p.TELEFONO = CType(unaFila.Item(6), String)
                p.EMAIL = CType(unaFila.Item(7), String)
                p.CCONSERVANTE = CType(unaFila.Item(8), Integer)
                p.SCONSERVANTE = CType(unaFila.Item(9), Integer)
                p.AGUA = CType(unaFila.Item(10), Integer)
                p.SANGRE = CType(unaFila.Item(11), Integer)
                p.CAJA1 = CType(unaFila.Item(12), String)
                p.CAJA2 = CType(unaFila.Item(13), String)
                p.CAJA3 = CType(unaFila.Item(14), String)
                p.CAJA4 = CType(unaFila.Item(15), String)
                p.CAJA5 = CType(unaFila.Item(16), String)
                p.CAJA6 = CType(unaFila.Item(17), String)
                p.OBSERVACIONES = CType(unaFila.Item(18), String)
                p.MARCA = CType(unaFila.Item(19), Integer)
                p.ESTADO = CType(unaFila.Item(20), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, productor, ifnull(direccion,''), agencia, ifnull(celular,''), ifnull(telefono,''), ifnull(email,''), cconservante, sconservante, agua, sangre, ifnull(caja1,''), ifnull(caja2,''), ifnull(caja3,''), ifnull(caja4,''), ifnull(caja5,''), ifnull(caja6,''), ifnull(observaciones,''), marca, ifnull(estado,'') FROM pedidosflorida WHERE marca = 0  order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    p.DIRECCION = CType(unaFila.Item(3), String)
                    p.IDAGENCIA = CType(unaFila.Item(4), Integer)
                    p.CELULAR = CType(unaFila.Item(5), String)
                    p.TELEFONO = CType(unaFila.Item(6), String)
                    p.EMAIL = CType(unaFila.Item(7), String)
                    p.CCONSERVANTE = CType(unaFila.Item(8), Integer)
                    p.SCONSERVANTE = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.CAJA1 = CType(unaFila.Item(12), String)
                    p.CAJA2 = CType(unaFila.Item(13), String)
                    p.CAJA3 = CType(unaFila.Item(14), String)
                    p.CAJA4 = CType(unaFila.Item(15), String)
                    p.CAJA5 = CType(unaFila.Item(16), String)
                    p.CAJA6 = CType(unaFila.Item(17), String)
                    p.OBSERVACIONES = CType(unaFila.Item(18), String)
                    p.MARCA = CType(unaFila.Item(19), Integer)
                    p.ESTADO = CType(unaFila.Item(20), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim sql As String = "SELECT id, fecha, productor, ifnull(direccion,''), agencia, ifnull(celular,''), ifnull(telefono,''), ifnull(email,''), cconservante, sconservante, agua, sangre, ifnull(caja1,''), ifnull(caja2,''), ifnull(caja3,''), ifnull(caja4,''), ifnull(caja5,''), ifnull(caja6,''), ifnull(observaciones,''), marca, ifnull(estado,'') FROM pedidosflorida WHERE marca = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    p.DIRECCION = CType(unaFila.Item(3), String)
                    p.IDAGENCIA = CType(unaFila.Item(4), Integer)
                    p.CELULAR = CType(unaFila.Item(5), String)
                    p.TELEFONO = CType(unaFila.Item(6), String)
                    p.EMAIL = CType(unaFila.Item(7), String)
                    p.CCONSERVANTE = CType(unaFila.Item(8), Integer)
                    p.SCONSERVANTE = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.CAJA1 = CType(unaFila.Item(12), String)
                    p.CAJA2 = CType(unaFila.Item(13), String)
                    p.CAJA3 = CType(unaFila.Item(14), String)
                    p.CAJA4 = CType(unaFila.Item(15), String)
                    p.CAJA5 = CType(unaFila.Item(16), String)
                    p.CAJA6 = CType(unaFila.Item(17), String)
                    p.OBSERVACIONES = CType(unaFila.Item(18), String)
                    p.MARCA = CType(unaFila.Item(19), Integer)
                    p.ESTADO = CType(unaFila.Item(20), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
End Class
