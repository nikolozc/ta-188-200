Imports System.IO
Public Class WebFavorite
    Implements IDisposable

    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Name As String
    Public URL As String

    Public Sub Load(ByVal FileName As String)
        Dim strData As String
        Dim strLines() As String
        Dim strLine As String

        Dim objectFileInfo As New FileInfo(FileName)
        Name = objectFileInfo.Name.Substring(0, objectFileInfo.Name.Length - objectFileInfo.Extension.Length)

        Try
            strData = My.Computer.FileSystem.ReadAllText(FileName)
            strLines = strData.Split(New String() {ControlChars.CrLf}, StringSplitOptions.RemoveEmptyEntries)

            For Each strLine In strLines
                If strLine.StartsWith("URL=") Then
                    URL = strLine.Substring(4)
                    Exit For
                End If
            Next
        Catch ex As IOException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
