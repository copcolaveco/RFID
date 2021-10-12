Public Class dNuevoTecnico
#Region "Atributos"
    Private m_id As Long
    Private m_nombre As String
    Private m_direccion As String
    Private m_telefono As String
    Private m_celular As String
    Private m_email As String
    Private m_enviado As Integer
#End Region

#Region "Getters y Setters"
    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property
    Public Property CELULAR() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_direccion = ""
        m_telefono = ""
        m_celular = ""
        m_email = ""
        m_enviado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String, ByVal celular As String, ByVal email As String, ByVal enviado As Integer)
        m_id = id
        m_nombre = nombre
        m_direccion = direccion
        m_telefono = telefono
        m_celular = celular
        m_email = email
        m_enviado = enviado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim t As New pNuevoTecnico
        Return t.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim t As New pNuevoTecnico
        Return t.modificar(Me)
    End Function
    Public Function marcarenviado() As Boolean
        Dim t As New pNuevoTecnico
        Return t.marcarenviado(Me)
    End Function
    Public Function buscar() As dNuevoTecnico
        Dim t As New pNuevoTecnico
        Return t.buscar(Me)
    End Function
    Public Function buscarPorNombre(ByVal pnombre As String) As ArrayList
        Dim t As New pNuevoTecnico
        Return t.buscarPorNombre(pnombre)
    End Function
    Public Function buscarultimo() As dNuevoTecnico
        Dim t As New pNuevoTecnico
        Return t.buscarultimo(Me)
    End Function
#End Region


    Public Overrides Function ToString() As String
        Return m_nombre
    End Function
    Public Function listar() As ArrayList
        Dim t As New pNuevoTecnico
        Return t.listar
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim t As New pNuevoTecnico
        Return t.listarsinenviar
    End Function
End Class
