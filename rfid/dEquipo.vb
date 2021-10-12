Public Class dEquipo
#Region "Atributos"
    Private m_id As Integer
    Private m_equipo As String
    Private m_correo As String
    
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
        End Set
    End Property
    Public Property CORREO() As String
        Get
            Return m_correo
        End Get
        Set(ByVal value As String)
            m_correo = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_equipo = ""
        m_correo = ""
        
    End Sub
    Public Sub New(ByVal id As Integer, ByVal equipo As String, ByVal correo As String)
        m_id = id
        m_equipo = equipo
        m_correo = correo
        
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pEquipo
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pEquipo
        Return p.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim p As New pEquipo
        Return p.eliminar(Me)
    End Function
    Public Function eliminartodo() As Boolean
        Dim p As New pEquipo
        Return p.eliminartodo(Me)
    End Function
    Public Function buscar() As dEquipo
        Dim p As New pEquipo
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pEquipo
        Return p.listar()
    End Function
End Class
