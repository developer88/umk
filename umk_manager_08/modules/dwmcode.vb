Imports System.Runtime.InteropServices

Module DWM_Code
    <StructLayout(LayoutKind.Sequential)> _
Public Structure Margins
        Public Sub New(ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer)
            _left = left
            _right = right
            _top = top
            _bottom = bottom
        End Sub

        Public Sub New(ByVal allMargins As Integer)
            _left = allMargins
            _right = allMargins
            _top = allMargins
            _bottom = allMargins
        End Sub

        Private _left As Integer
        Private _right As Integer
        Private _top As Integer
        Private _bottom As Integer

        Public Property Left() As Integer
            Get
                Return _left
            End Get
            Set(ByVal value As Integer)
                _left = value
            End Set
        End Property
        Public Property Right() As Integer
            Get
                Return _right
            End Get
            Set(ByVal value As Integer)
                _right = value
            End Set
        End Property
        Public Property Top() As Integer
            Get
                Return _top
            End Get
            Set(ByVal value As Integer)
                _top = value
            End Set
        End Property
        Public Property Bottom() As Integer
            Get
                Return _bottom
            End Get
            Set(ByVal value As Integer)
                _bottom = value
            End Set
        End Property

        Public ReadOnly Property IsMarginless() As Boolean
            Get
                Return (_left < 0 AndAlso _right < 0 AndAlso _top < 0 AndAlso _bottom < 0)
            End Get
        End Property

        Public ReadOnly Property IsNull() As Boolean
            Get
                Return (_left = 0 AndAlso _right = 0 AndAlso _top = 0 AndAlso _bottom = 0)
            End Get
        End Property
    End Structure

    <DllImport("dwmapi.dll", PreserveSig:=False)> _
Public Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As Margins) As Integer
    End Function
End Module
