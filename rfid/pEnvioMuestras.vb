Public Class pEnvioMuestras
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dEnvioMuestras = CType(o, dEnvioMuestras)
        Dim sql As String = "INSERT INTO enviosflorida (id, fecha, productor, tipoinforme, subinforme, observaciones, nmuestras, temperatura, cajas, muestra, tecnico, razonsocial, rut, direccion, marca ) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.PRODUCTOR & ", " & obj.TIPOINFORME & ", " & obj.SUBINFORME & ", '" & obj.OBSERVACIONES & "', " & obj.NMUESTRAS & ", '" & obj.TEMPERATURA & "',  '" & obj.CAJAS & "', " & obj.MUESTRA & ", " & obj.TECNICO & ", '" & obj.RAZONSOCIAL & "', '" & obj.RUT & "', '" & obj.DIRECCION & "', " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dEnvioMuestras = CType(o, dEnvioMuestras)
        Dim sql As String = "UPDATE enviosflorida SET fecha = '" & obj.FECHA & "', productor = " & obj.PRODUCTOR & ", tipoinforme = " & obj.TIPOINFORME & ", subinforme = " & obj.SUBINFORME & ", observaciones = '" & obj.OBSERVACIONES & "', nmuestras = " & obj.NMUESTRAS & ", temperatura = '" & obj.TEMPERATURA & "', cajas = '" & obj.CAJAS & "', muestra = " & obj.MUESTRA & ", tecnico = " & obj.TECNICO & ", razonsocial = '" & obj.RAZONSOCIAL & "', rut = '" & obj.RUT & "', direccion = '" & obj.DIRECCION & "', marca = " & obj.MARCA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object) As Boolean
        Dim obj As dEnvioMuestras = CType(o, dEnvioMuestras)
        Dim sql As String = "UPDATE enviosflorida SET marca = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dEnvioMuestras = CType(o, dEnvioMuestras)
        Dim sql As String = "DELETE FROM enviosflorida WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEnvioMuestras
        Dim obj As dEnvioMuestras = CType(o, dEnvioMuestras)
        Dim m As New dEnvioMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, productor, tipoinforme, subinforme, ifnull(observaciones,''), nmuestras, ifnull(temperatura,''),ifnull(cajas,''), muestra, tecnico, ifnull(razonsocial,''), ifnull(rut,''), ifnull(direccion,''), marca FROM enviosflorida WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FECHA = CType(unaFila.Item(1), String)
                m.PRODUCTOR = CType(unaFila.Item(2), Long)
                m.TIPOINFORME = CType(unaFila.Item(3), Integer)
                m.SUBINFORME = CType(unaFila.Item(4), Integer)
                m.OBSERVACIONES = CType(unaFila.Item(5), String)
                m.NMUESTRAS = CType(unaFila.Item(6), Integer)
                m.TEMPERATURA = CType(unaFila.Item(7), String)
                m.CAJAS = CType(unaFila.Item(8), String)
                m.MUESTRA = CType(unaFila.Item(9), Integer)
                m.TECNICO = CType(unaFila.Item(10), Long)
                m.RAZONSOCIAL = CType(unaFila.Item(11), String)
                m.RUT = CType(unaFila.Item(12), String)
                m.DIRECCION = CType(unaFila.Item(13), String)
                m.MARCA = CType(unaFila.Item(14), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dEnvioMuestras
        Dim obj As dEnvioMuestras = CType(o, dEnvioMuestras)
        Dim m As New dEnvioMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, productor, tipoinforme, subinforme, ifnull(observaciones,''), nmuestras, ifnull(temperatura,''),ifnull(cajas,''), muestra, tecnico, ifnull(razonsocial,''), ifnull(rut,''), ifnull(direccion,''), marca FROM enviosflorida ORDER By id DESC LIMIT 1 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Long)
                m.FECHA = CType(unaFila.Item(1), String)
                m.PRODUCTOR = CType(unaFila.Item(2), Long)
                m.TIPOINFORME = CType(unaFila.Item(3), Integer)
                m.SUBINFORME = CType(unaFila.Item(4), Integer)
                m.OBSERVACIONES = CType(unaFila.Item(5), String)
                m.NMUESTRAS = CType(unaFila.Item(6), Integer)
                m.TEMPERATURA = CType(unaFila.Item(7), String)
                m.CAJAS = CType(unaFila.Item(8), String)
                m.MUESTRA = CType(unaFila.Item(9), Integer)
                m.TECNICO = CType(unaFila.Item(10), Long)
                m.RAZONSOCIAL = CType(unaFila.Item(11), String)
                m.RUT = CType(unaFila.Item(12), String)
                m.DIRECCION = CType(unaFila.Item(13), String)
                m.MARCA = CType(unaFila.Item(14), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, productor, tipoinforme, subinforme, ifnull(observaciones,''), nmuestras, ifnull(temperatura,''),ifnull(cajas,''), muestra, tecnico, ifnull(razonsocial,''), ifnull(rut,''), ifnull(direccion,''), marca FROM enviosflorida WHERE marca = 0 ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dEnvioMuestras
                    m.ID = CType(unaFila.Item(0), Long)
                    m.FECHA = CType(unaFila.Item(1), String)
                    m.PRODUCTOR = CType(unaFila.Item(2), Long)
                    m.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    m.SUBINFORME = CType(unaFila.Item(4), Integer)
                    m.OBSERVACIONES = CType(unaFila.Item(5), String)
                    m.NMUESTRAS = CType(unaFila.Item(6), Integer)
                    m.TEMPERATURA = CType(unaFila.Item(7), String)
                    m.CAJAS = CType(unaFila.Item(8), String)
                    m.MUESTRA = CType(unaFila.Item(9), Integer)
                    m.TECNICO = CType(unaFila.Item(10), Long)
                    m.RAZONSOCIAL = CType(unaFila.Item(11), String)
                    m.RUT = CType(unaFila.Item(12), String)
                    m.DIRECCION = CType(unaFila.Item(13), String)
                    m.MARCA = CType(unaFila.Item(14), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim sql As String = "SELECT id, fecha, productor, tipoinforme, subinforme, ifnull(observaciones,''), nmuestras, ifnull(temperatura,''),ifnull(cajas,''), muestra, tecnico, ifnull(razonsocial,''), ifnull(rut,''), ifnull(direccion,''), marca FROM enviosflorida WHERE marca = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dEnvioMuestras
                    m.ID = CType(unaFila.Item(0), Long)
                    m.FECHA = CType(unaFila.Item(1), String)
                    m.PRODUCTOR = CType(unaFila.Item(2), Long)
                    m.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    m.SUBINFORME = CType(unaFila.Item(4), Integer)
                    m.OBSERVACIONES = CType(unaFila.Item(5), String)
                    m.NMUESTRAS = CType(unaFila.Item(6), Integer)
                    m.TEMPERATURA = CType(unaFila.Item(7), String)
                    m.CAJAS = CType(unaFila.Item(8), String)
                    m.MUESTRA = CType(unaFila.Item(9), Integer)
                    m.TECNICO = CType(unaFila.Item(10), Long)
                    m.RAZONSOCIAL = CType(unaFila.Item(11), String)
                    m.RUT = CType(unaFila.Item(12), String)
                    m.DIRECCION = CType(unaFila.Item(13), String)
                    m.MARCA = CType(unaFila.Item(14), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
End Class
