Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Public Class Form1
    Private idproductor As Long
    Private nombreprod As String
    Private idequipo As String
    Private fecha As Date = Now
    Private fec As String

    Private archivo As String = ""
    Private correo As String = ""
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Timer1.Enabled = True
    End Sub
#End Region

    Private Sub caravanasrfid()
        fecha = Now
        'fec = Format(fecha, "yyyy-MM-dd HH_mm_ss")
        fec = Format(fecha, "yyyy-MM-dd")
        Dim extension As String
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("C:\correo")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("C:\correo")
        If Not (_ficheros.Length > 0) Then
        Else
            For Each file As FileInfo In folder.GetFiles("*.txt")
                nombrearchivo = file.Name
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                Dim objReader2 As New StreamReader("C:\correo\" & file.Name)
                Dim sLine As String = ""
                Dim arraytext() As String
                Dim id As Long = 0
                Dim equipo As String = ""
                Dim equipotext As String = ""
                Dim productor As Long = 0
                Dim ficha As Long = 0
                Dim frasco As String = ""
                Dim caravana As String = ""
                Dim litros As Double = 0
                Dim litros2 As Double = 0
                Dim marca As Integer = 0

                If extension = "txt" Or extension = "TXT" Then

                    Dim c As New dCaravanasRfid

                    Do
                        sLine = objReader2.ReadLine()
                        If Not sLine Is Nothing Then
                            If sLine <> "" Then
                                arraytext = Split(sLine, ":")
                                equipotext = Trim(arraytext(8))
                                equipotext = equipotext.Remove(equipotext.Length - 1)
                                equipo = equipotext
                                productor = Trim(arraytext(3))
                                frasco = Trim(arraytext(4))
                                caravana = Trim(arraytext(5))
                                litros = Trim(arraytext(6))
                                litros2 = Trim(arraytext(7))

                                c.EQUIPO = equipo
                                c.FECHA = fec
                                c.PRODUCTOR = productor
                                c.FICHA = ficha
                                c.FRASCO = frasco
                                c.CARAVANA = caravana
                                c.LITROS = litros
                                c.LITROS2 = litros2
                                c.MARCA = 0
                                If c.PRODUCTOR <> -1 Then
                                    c.guardar()
                                End If
                            End If
                        End If
                    Loop Until sLine Is Nothing
                    objReader2.Close()
                End If


        idproductor = productor
        idequipo = equipo



        '*** MOVER ARCHIVO ***********************************************************************
                Dim sArchivoOrigen As String = "c:\correo\" & nombrearchivo
                Dim sRutaDestino As String = "c:\correo\procesados\" & nombrearchivo
                Try
                    ' Mover el fichero.si existe lo sobreescribe  
                    My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                    sRutaDestino, _
                                                    True)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try


        '*** GENERA EXCEL
        generar_excel()
        '****************

            Next
        End If
    End Sub
    
    Private Sub generar_excel()

       
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 20
        x1hoja.Cells(1, 3).columnwidth = 10

        Dim filaexcel As Integer = 1
        Dim columnaexcel As Integer = 1
        Dim p As New dCliente
        Dim nombreproductor As String = ""
        p.ID = idproductor
        p = p.buscar
        If Not p Is Nothing Then
            nombreproductor = p.NOMBRE
            nombreprod = p.NOMBRE
        End If
        x1hoja.Cells(filaexcel, columnaexcel).formula = "LISTADO DE CARAVANAS" & " - " & nombreproductor & " - " & Now
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        'x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        filaexcel = filaexcel + 2
        x1hoja.Cells(filaexcel, columnaexcel).formula = "FRASCO"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "CARAVANA"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "LITROS"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        columnaexcel = columnaexcel + 1
        x1hoja.Cells(filaexcel, columnaexcel).formula = "LITROS 2"
        x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = True
        x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
        x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
        filaexcel = filaexcel + 1
        columnaexcel = 1

        Dim c As New dCaravanasRfid
        Dim lista As New ArrayList

        lista = c.listar(idequipo, idproductor)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    x1hoja.Cells(filaexcel, columnaexcel).formula = c.FRASCO
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = "'" & c.CARAVANA
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = c.LITROS
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    columnaexcel = columnaexcel + 1
                    x1hoja.Cells(filaexcel, columnaexcel).formula = c.LITROS2
                    x1hoja.Cells(filaexcel, columnaexcel).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Bold = False
                    x1hoja.Cells(filaexcel, columnaexcel).Font.Size = 10
                    x1hoja.Cells(filaexcel, columnaexcel).BORDERS.color = RGB(255, 0, 0)
                    filaexcel = filaexcel + 1
                    columnaexcel = 1
                    c.marcarexcel()
                Next
            End If
        End If


        'GUARDA EL ARCHIVO DE EXCEL
        fec = Format(fecha, "yyyy-MM-dd HH_mm_ss")
        x1hoja.PageSetup.CenterFooter = "Página &P"
        x1hoja.SaveAs("c:\correo\excel\" & idproductor & "_" & fec & ".xls")
        archivo = "c:\correo\excel\" & idproductor & "_" & fec & ".xls"
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

        '*** MATAR PROCESOS DE EXCEL********************************************
        Dim proceso2 As System.Diagnostics.Process()
        proceso2 = System.Diagnostics.Process.GetProcessesByName("EXCEL.EXE *32")

        For Each opro As System.Diagnostics.Process In proceso2
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()

        Next
        '***********************************************************************

        enviarmail()
    End Sub
    Private Sub enviarmail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim c As New dEquipo
        c.EQUIPO = idequipo
        c.EQUIPO = idequipo
        c = c.buscar
        If Not c Is Nothing Then
            email = c.CORREO
        End If


        If email <> "" Then
            'colaveco19912016COLAVECO
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "CLV19912021Colaveco30")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            _Message.[To].Add(email)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Caravanas - " & nombreprod & "_" & fec
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos listado de caravanas."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = "\\SRVCOLAVECO\D\NET\INFORMES PARA SUBIR\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _File As String = ""
            _File = archivo 'archivo que se quiere adjuntar ‘



            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException
                'MessageBox.Show(ex.ToString)
            End Try
        End If
        email = ""
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'procesar_florida()
        'caravanasrfid()
        'moverarchivos
        procesar_txt()
        For i = 1 To 100
            ProgressBar1.Value = i
        Next
    End Sub

    Private Sub procesar_florida()
        fecha = Now
        fec = Format(fecha, "yyyy-MM-dd")
        Dim extension As String = ""
        Dim tipo As String = ""
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("C:\correo")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("C:\correo")

        If Not (_ficheros.Length > 0) Then
        Else
            For Each file As FileInfo In folder.GetFiles("*.txt")
                nombrearchivo = file.Name
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                tipo = Microsoft.VisualBasic.Left(file.Name, 3)
                Dim objReader As New StreamReader("C:\correo\" & file.Name)
                Dim sLine As String = ""
                Dim arraytext() As String
                Dim arrText As New ArrayList()
                If extension = "txt" Or extension = "TXT" Then

                    If tipo = "pro" Then ' *** PRODUCTORES ******************************************************************************************
                        Dim idpro As Long = 0
                        Dim pedidopro As Long = 0
                        Dim enviopro As Long = 0
                        Dim tipousuariopro As Integer = 0
                        Dim nombrepro As String = ""
                        Dim razonsocialpro As String = ""
                        Dim rutpro As String = ""
                        Dim direccionpro As String = ""
                        Dim idlocalidadpro As Integer = 0
                        Dim iddepartamentopro As Integer = 0
                        Dim dicosepro As String = ""
                        Dim telefonopro As String = ""
                        Dim celularpro As String = ""
                        Dim emailpro As String = ""
                        Dim tecnicopro As Long = 0
                        Dim direccionenviopro As String = ""
                        Dim idagenciapro As Integer = 0
                        Dim cnombrepro As String = ""
                        Dim ccelularpro As String = ""
                        Dim ctelefonopro As String = ""
                        Dim cemailpro As String = ""

                        Dim p As New dNuevoProductor
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then
                                    arraytext = Split(sLine, ":")

                                    idpro = Trim(arraytext(0))
                                    pedidopro = Trim(arraytext(1))
                                    enviopro = Trim(arraytext(2))
                                    tipousuariopro = Trim(arraytext(3))
                                    nombrepro = Trim(arraytext(4))
                                    razonsocialpro = Trim(arraytext(5))
                                    rutpro = Trim(arraytext(6))
                                    direccionpro = Trim(arraytext(7))
                                    idlocalidadpro = Trim(arraytext(8))
                                    iddepartamentopro = Trim(arraytext(9))
                                    dicosepro = Trim(arraytext(10))
                                    telefonopro = Trim(arraytext(11))
                                    celularpro = Trim(arraytext(12))
                                    emailpro = Trim(arraytext(13))
                                    tecnicopro = Trim(arraytext(14))
                                    direccionenviopro = Trim(arraytext(15))
                                    idagenciapro = Trim(arraytext(16))
                                    cnombrepro = Trim(arraytext(17))
                                    ccelularpro = Trim(arraytext(18))
                                    ctelefonopro = Trim(arraytext(19))
                                    cemailpro = Trim(arraytext(20))

                                    p.ID = idpro
                                    p.PEDIDO = pedidopro
                                    p.ENVIO = enviopro
                                    p.TIPOUSUARIO = tipousuariopro
                                    p.NOMBRE = nombrepro
                                    p.RAZON_SOCIAL = razonsocialpro
                                    p.RUT = rutpro
                                    p.DIRECCION = direccionpro
                                    p.IDLOCALIDAD = idlocalidadpro
                                    p.IDDEPARTAMENTO = iddepartamentopro
                                    p.DICOSE = dicosepro
                                    p.TELEFONO = telefonopro
                                    p.CELULAR = celularpro
                                    p.EMAIL = emailpro
                                    p.TECNICO = tecnicopro
                                    p.DIRECCIONENVIO = direccionenviopro
                                    p.IDAGENCIA = idagenciapro
                                    p.CNOMBRE = cnombrepro
                                    p.CCELULAR = ccelularpro
                                    p.CTELEFONO = ctelefonopro
                                    p.CEMAIL = cemailpro
                                    p.guardar()
                                End If
                            End If
                        Loop Until sLine Is Nothing
                        objReader.Close()

                    ElseIf tipo = "tec" Then ' *** TECNICOS ******************************************************************************************

                    ElseIf tipo = "ped" Then ' *** PEDIDOS ******************************************************************************************
                        Dim idped As Long = 0
                        Dim fechaped As String = ""
                        Dim idproductorped As Long = 0
                        Dim direccionped As String = ""
                        Dim idagenciaped As Integer = 0
                        Dim celularped As String = ""
                        Dim telefonoped As String = ""
                        Dim emailped As String = ""
                        Dim cconservanteped As Integer = 0
                        Dim sconservanteped As Integer = 0
                        Dim aguaped As Integer = 0
                        Dim sangreped As Integer = 0
                        Dim caja1 As String = ""
                        Dim caja2 As String = ""
                        Dim caja3 As String = ""
                        Dim caja4 As String = ""
                        Dim caja5 As String = ""
                        Dim caja6 As String = ""
                        Dim observacionesped As String = ""
                        Dim estadoped As String = ""

                        Dim p As New dPedidos
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then
                                    arraytext = Split(sLine, ":")
                                    'equipotext = Trim(arraytext(7))
                                    'equipotext = equipotext.Remove(equipotext.Length - 1)
                                    'equipo = equipotext
                                    idped = Trim(arraytext(0))
                                    fechaped = Trim(arraytext(1))
                                    idproductorped = Trim(arraytext(2))
                                    direccionped = Trim(arraytext(3))
                                    idagenciaped = Trim(arraytext(4))
                                    celularped = Trim(arraytext(5))
                                    telefonoped = Trim(arraytext(6))
                                    emailped = Trim(arraytext(7))
                                    cconservanteped = Trim(arraytext(8))
                                    sconservanteped = Trim(arraytext(9))
                                    aguaped = Trim(arraytext(10))
                                    sangreped = Trim(arraytext(11))
                                    caja1 = Trim(arraytext(12))
                                    caja2 = Trim(arraytext(13))
                                    caja3 = Trim(arraytext(14))
                                    caja4 = Trim(arraytext(15))
                                    caja5 = Trim(arraytext(16))
                                    caja6 = Trim(arraytext(17))
                                    observacionesped = Trim(arraytext(12))
                                    estadoped = Trim(arraytext(13))
                                    p.ID = idped
                                    p.FECHA = fec
                                    p.IDPRODUCTOR = idproductorped
                                    p.DIRECCION = direccionped
                                    p.IDAGENCIA = idagenciaped
                                    p.CELULAR = celularped
                                    p.TELEFONO = telefonoped
                                    p.EMAIL = emailped
                                    p.CCONSERVANTE = cconservanteped
                                    p.SCONSERVANTE = sconservanteped
                                    p.AGUA = aguaped
                                    p.SANGRE = sangreped
                                    p.CAJA1 = caja1
                                    p.CAJA2 = caja2
                                    p.CAJA3 = caja3
                                    p.CAJA4 = caja4
                                    p.CAJA5 = caja5
                                    p.CAJA6 = caja6
                                    p.OBSERVACIONES = observacionesped
                                    p.ESTADO = estadoped
                                    p.guardar()
                                    'arrText.Add(sLine)
                                End If
                            End If
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    ElseIf tipo = "env" Then ' *** ENVIOS ******************************************************************************************

                        Dim idenv As Long = 0
                        Dim fechaenv As String = ""
                        Dim idproductorenv As Long = 0
                        Dim tipoinformenv As Integer = 0
                        Dim subtipoinformeenv As Integer = 0
                        Dim observacionesenv As String = ""
                        Dim nmuestrasenv As Integer = 0
                        Dim temperaturaenv As String = ""
                        Dim cajasenv As String = ""
                        Dim muestraenv As Integer = 0
                        Dim tecnicoenv As Long = 0
                        Dim razonsocialenv As String = ""
                        Dim rutenv As String = ""
                        Dim direccionenv As String = ""

                        Dim env As New dEnvioMuestras
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then
                                    arraytext = Split(sLine, ":")
                                    idenv = Trim(arraytext(0))
                                    fechaenv = Trim(arraytext(1))
                                    idproductorenv = Trim(arraytext(2))
                                    tipoinformenv = Trim(arraytext(3))
                                    subtipoinformeenv = Trim(arraytext(4))
                                    observacionesenv = Trim(arraytext(5))
                                    nmuestrasenv = Trim(arraytext(6))
                                    temperaturaenv = Trim(arraytext(7))
                                    cajasenv = Trim(arraytext(8))
                                    muestraenv = Trim(arraytext(9))
                                    tecnicoenv = Trim(arraytext(10))
                                    razonsocialenv = Trim(arraytext(11))
                                    rutenv = Trim(arraytext(12))
                                    direccionenv = Trim(arraytext(13))

                                    env.ID = idenv
                                    env.FECHA = fec
                                    env.PRODUCTOR = idproductorenv
                                    env.TIPOINFORME = tipoinformenv
                                    env.SUBINFORME = subtipoinformeenv
                                    env.OBSERVACIONES = observacionesenv
                                    env.NMUESTRAS = nmuestrasenv
                                    env.TEMPERATURA = temperaturaenv
                                    env.CAJAS = cajasenv
                                    env.MUESTRA = muestraenv
                                    env.TECNICO = tecnicoenv
                                    env.RAZONSOCIAL = razonsocialenv
                                    env.RUT = rutenv
                                    env.DIRECCION = direccionenv
                                    env.guardar()

                                End If
                            End If
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    End If
                End If

                '*** MOVER ARCHIVO ***********************************************************************
                Dim sArchivoOrigen As String = "c:\correo\" & nombrearchivo
                Dim sRutaDestino As String = ""
                If tipo = "pro" Then
                    sRutaDestino = "c:\correo\productores\" & nombrearchivo
                ElseIf tipo = "tec" Then
                    sRutaDestino = "c:\correo\tecnicos\" & nombrearchivo
                ElseIf tipo = "env" Then
                    sRutaDestino = "c:\correo\envios\" & nombrearchivo
                ElseIf tipo = "ped" Then
                    sRutaDestino = "c:\correo\pedidos\" & nombrearchivo
                End If
                If sRutaDestino <> "" Then
                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                        sRutaDestino, _
                                                        True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'procesar_florida()
        'caravanasrfid()
        procesar_txt()
    End Sub
    Private Sub procesar_txt()
        fecha = Now
        fec = Format(fecha, "yyyy-MM-dd")
        Dim extension As String = ""
        Dim tipo As String = ""
        Dim nombrearchivo As String = ""
        Dim linea As Integer
        Dim folder As New DirectoryInfo("C:\correo")
        Dim _ficheros() As String
        _ficheros = Directory.GetFiles("C:\correo")

        If Not (_ficheros.Length > 0) Then
        Else
            For Each file As FileInfo In folder.GetFiles("*.txt")
                nombrearchivo = file.Name
                linea = 1
                extension = Microsoft.VisualBasic.Right(file.Name, 3)
                tipo = Microsoft.VisualBasic.Left(file.Name, 3)
                Dim objReader As New StreamReader("C:\correo\" & file.Name)
                Dim sLine As String = ""
                Dim arraytext() As String
                Dim arrText As New ArrayList()
                If extension = "txt" Or extension = "TXT" Then

                    If tipo = "pro" Then ' *** PRODUCTORES ******************************************************************************************
                        'Dim idpro As Long = 0
                        Dim pedidopro As Long = 0
                        Dim enviopro As Long = 0
                        Dim tipousuariopro As Integer = 0
                        Dim nombrepro As String = ""
                        Dim razonsocialpro As String = ""
                        Dim rutpro As String = ""
                        Dim direccionpro As String = ""
                        Dim idlocalidadpro As Integer = 0
                        Dim iddepartamentopro As Integer = 0
                        Dim dicosepro As String = ""
                        Dim telefonopro As String = ""
                        Dim celularpro As String = ""
                        Dim emailpro As String = ""
                        Dim tecnicopro As Long = 0
                        Dim direccionenviopro As String = ""
                        Dim idagenciapro As Integer = 0
                        Dim cnombrepro As String = ""
                        Dim ccelularpro As String = ""
                        Dim ctelefonopro As String = ""
                        Dim cemailpro As String = ""

                        'Dim p As New dNuevoProductor
                        Dim p As New dNuevoCliente
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then
                                    arraytext = Split(sLine, ":")

                                    'idpro = Trim(arraytext(0))
                                    pedidopro = Trim(arraytext(1))
                                    enviopro = Trim(arraytext(2))
                                    tipousuariopro = Trim(arraytext(3))
                                    nombrepro = Trim(arraytext(4))
                                    razonsocialpro = Trim(arraytext(5))
                                    rutpro = Trim(arraytext(6))
                                    direccionpro = Trim(arraytext(7))
                                    idlocalidadpro = Trim(arraytext(8))
                                    iddepartamentopro = Trim(arraytext(9))
                                    dicosepro = Trim(arraytext(10))
                                    telefonopro = Trim(arraytext(11))
                                    celularpro = Trim(arraytext(12))
                                    emailpro = Trim(arraytext(13))
                                    tecnicopro = Trim(arraytext(14))
                                    direccionenviopro = Trim(arraytext(15))
                                    idagenciapro = Trim(arraytext(16))
                                    cnombrepro = Trim(arraytext(17))
                                    ccelularpro = Trim(arraytext(18))
                                    ctelefonopro = Trim(arraytext(19))
                                    cemailpro = Trim(arraytext(20))

                                    'p.ID = idpro
                                    p.PEDIDO = pedidopro
                                    p.ENVIO = enviopro
                                    p.TIPOUSUARIO = tipousuariopro
                                    p.NOMBRE = nombrepro
                                    p.RAZON_SOCIAL = razonsocialpro
                                    p.RUT = rutpro
                                    p.DIRECCION = direccionpro
                                    p.IDLOCALIDAD = idlocalidadpro
                                    p.IDDEPARTAMENTO = iddepartamentopro
                                    p.DICOSE = dicosepro
                                    p.TELEFONO = telefonopro
                                    p.CELULAR = celularpro
                                    p.EMAIL = emailpro
                                    p.TECNICO = tecnicopro
                                    p.DIRECCIONENVIO = direccionenviopro
                                    p.IDAGENCIA = idagenciapro
                                    p.CNOMBRE = cnombrepro
                                    p.CCELULAR = ccelularpro
                                    p.CTELEFONO = ctelefonopro
                                    p.CEMAIL = cemailpro
                                    p.guardar()
                                End If
                            End If
                        Loop Until sLine Is Nothing
                        objReader.Close()

                    ElseIf tipo = "tec" Then ' *** TECNICOS ******************************************************************************************

                    ElseIf tipo = "ped" Then ' *** PEDIDOS ******************************************************************************************
                        'Dim idped As Long = 0
                        Dim fechaped As String = ""
                        Dim idproductorped As Long = 0
                        Dim direccionped As String = ""
                        Dim idagenciaped As Integer = 0
                        Dim celularped As String = ""
                        Dim telefonoped As String = ""
                        Dim emailped As String = ""
                        Dim cconservanteped As Integer = 0
                        Dim sconservanteped As Integer = 0
                        Dim aguaped As Integer = 0
                        Dim sangreped As Integer = 0
                        Dim caja1 As String = ""
                        Dim caja2 As String = ""
                        Dim caja3 As String = ""
                        Dim caja4 As String = ""
                        Dim caja5 As String = ""
                        Dim caja6 As String = ""
                        Dim observacionesped As String = ""
                        Dim estadoped As String = ""

                        Dim p As New dPedidos
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then
                                    arraytext = Split(sLine, ":")
                                    'equipotext = Trim(arraytext(7))
                                    'equipotext = equipotext.Remove(equipotext.Length - 1)
                                    'equipo = equipotext
                                    'idped = Trim(arraytext(0))
                                    fechaped = Trim(arraytext(1))
                                    idproductorped = Trim(arraytext(2))
                                    direccionped = Trim(arraytext(3))
                                    idagenciaped = Trim(arraytext(4))
                                    celularped = Trim(arraytext(5))
                                    telefonoped = Trim(arraytext(6))
                                    emailped = Trim(arraytext(7))
                                    cconservanteped = Trim(arraytext(8))
                                    sconservanteped = Trim(arraytext(9))
                                    aguaped = Trim(arraytext(10))
                                    sangreped = Trim(arraytext(11))
                                    caja1 = Trim(arraytext(12))
                                    caja2 = Trim(arraytext(13))
                                    caja3 = Trim(arraytext(14))
                                    caja4 = Trim(arraytext(15))
                                    caja5 = Trim(arraytext(16))
                                    caja6 = Trim(arraytext(17))
                                    observacionesped = Trim(arraytext(12))
                                    estadoped = Trim(arraytext(13))
                                    ' p.ID = idped
                                    p.FECHA = fec
                                    p.IDPRODUCTOR = idproductorped
                                    p.DIRECCION = direccionped
                                    p.IDAGENCIA = idagenciaped
                                    p.CELULAR = celularped
                                    p.TELEFONO = telefonoped
                                    p.EMAIL = emailped
                                    p.CCONSERVANTE = cconservanteped
                                    p.SCONSERVANTE = sconservanteped
                                    p.AGUA = aguaped
                                    p.SANGRE = sangreped
                                    p.CAJA1 = caja1
                                    p.CAJA2 = caja2
                                    p.CAJA3 = caja3
                                    p.CAJA4 = caja4
                                    p.CAJA5 = caja5
                                    p.CAJA6 = caja6
                                    p.OBSERVACIONES = observacionesped
                                    p.ESTADO = estadoped
                                    p.guardar()
                                    'arrText.Add(sLine)
                                End If
                            End If
                        Loop Until sLine Is Nothing
                        objReader.Close()
                    ElseIf tipo = "env" Then ' *** ENVIOS ******************************************************************************************

                        'Dim idenv As Long = 0
                        Dim fechaenv As String = ""
                        Dim idproductorenv As Long = 0
                        Dim tipoinformenv As Integer = 0
                        Dim subtipoinformeenv As Integer = 0
                        Dim observacionesenv As String = ""
                        Dim nmuestrasenv As Integer = 0
                        Dim temperaturaenv As String = ""
                        Dim cajasenv As String = ""
                        Dim muestraenv As Integer = 0
                        Dim tecnicoenv As Long = 0
                        Dim razonsocialenv As String = ""
                        Dim rutenv As String = ""
                        Dim direccionenv As String = ""

                        Dim env As New dEnvioMuestras
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then
                                    arraytext = Split(sLine, ":")
                                    'idenv = Trim(arraytext(0))
                                    fechaenv = Trim(arraytext(1))
                                    idproductorenv = Trim(arraytext(2))
                                    tipoinformenv = Trim(arraytext(3))
                                    subtipoinformeenv = Trim(arraytext(4))
                                    observacionesenv = Trim(arraytext(5))
                                    nmuestrasenv = Trim(arraytext(6))
                                    temperaturaenv = Trim(arraytext(7))
                                    cajasenv = Trim(arraytext(8))
                                    muestraenv = Trim(arraytext(9))
                                    tecnicoenv = Trim(arraytext(10))
                                    razonsocialenv = Trim(arraytext(11))
                                    rutenv = Trim(arraytext(12))
                                    direccionenv = Trim(arraytext(13))

                                    'env.ID = idenv
                                    env.FECHA = fec
                                    env.PRODUCTOR = idproductorenv
                                    env.TIPOINFORME = tipoinformenv
                                    env.SUBINFORME = subtipoinformeenv
                                    env.OBSERVACIONES = observacionesenv
                                    env.NMUESTRAS = nmuestrasenv
                                    env.TEMPERATURA = temperaturaenv
                                    env.CAJAS = cajasenv
                                    env.MUESTRA = muestraenv
                                    env.TECNICO = tecnicoenv
                                    env.RAZONSOCIAL = razonsocialenv
                                    env.RUT = rutenv
                                    env.DIRECCION = direccionenv
                                    env.guardar()

                                End If
                            End If
                        Loop Until sLine Is Nothing
                        objReader.Close()

                    ElseIf tipo = "mue" Then ' *** MUESTRAS ******************************************************************************************

                        '*************************************************
                        fecha = Now
                        'fec = Format(fecha, "yyyy-MM-dd HH_mm_ss")
                        fec = Format(fecha, "yyyy-MM-dd")


                        Dim id As Long = 0
                        Dim equipo As String = ""
                        Dim equipotext As String = ""
                        Dim productor As Long = 0
                        Dim ficha As Long = 0
                        Dim frasco As String = ""
                        Dim caravana As String = ""
                        Dim litros As Double = 0
                        Dim litros2 As Double = 0
                        Dim marca As Integer = 0


                        Dim c As New dCaravanasRfid
                        Dim flag As Integer = 0
                        Do
                            sLine = objReader.ReadLine()
                            If Not sLine Is Nothing Then
                                If sLine <> "" Then

                                    arraytext = Split(sLine, ":")
                                    equipotext = Trim(arraytext(8))
                                    equipotext = equipotext.Remove(equipotext.Length - 1)
                                    equipo = equipotext
                                    If flag = 0 Then
                                        productor = Trim(arraytext(3))
                                        idproductor = productor
                                    End If
                                    flag = 1
                                    frasco = Trim(arraytext(4))
                                    caravana = Trim(arraytext(5))
                                    litros = Trim(arraytext(6))
                                    litros2 = Trim(arraytext(7))

                                    c.EQUIPO = equipo
                                    c.FECHA = fec
                                    c.PRODUCTOR = productor
                                    c.FICHA = ficha
                                    c.FRASCO = frasco
                                    c.CARAVANA = caravana
                                    c.LITROS = litros
                                    c.LITROS2 = litros2
                                    c.MARCA = 0
                                    If caravana <> "" Then
                                        c.guardar()
                                    End If
                                End If
                            End If
                        Loop Until sLine Is Nothing
                        'idproductor = productor
                        idequipo = equipo
                        flag = 0
                        objReader.Close()
                    End If
                End If



                '*** GENERA EXCEL
                generar_excel()
                '****************



                '*** MOVER ARCHIVO ***********************************************************************
                Dim sArchivoOrigen As String = "c:\correo\" & nombrearchivo
                Dim sRutaDestino As String = ""
                If tipo = "pro" Then
                    sRutaDestino = "c:\correo\productores\" & nombrearchivo
                ElseIf tipo = "tec" Then
                    sRutaDestino = "c:\correo\tecnicos\" & nombrearchivo
                ElseIf tipo = "env" Then
                    sRutaDestino = "c:\correo\envios\" & nombrearchivo
                ElseIf tipo = "ped" Then
                    sRutaDestino = "c:\correo\pedidos\" & nombrearchivo
                ElseIf tipo = "mue" Then
                    sRutaDestino = "c:\correo\procesados\" & nombrearchivo
                End If
                If sRutaDestino <> "" Then
                    Try
                        ' Mover el fichero.si existe lo sobreescribe  
                        My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                        sRutaDestino, _
                                                        True)
                        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                        ' errores  
                    Catch ex As Exception
                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                    End Try
                End If
            Next
        End If
    End Sub
End Class
