Public Class Favorites
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

    Public FavoritesCollection As WebFavoriteCollection

    Public ReadOnly Property FavoritesFolder() As String
        Get
            Return Environment.GetFolderPath(Environment.SpecialFolder.Favorites)
        End Get
    End Property

    Public Sub ScanFavorites()
        ScanFavorites(FavoritesFolder)
    End Sub

    Public Sub ScanFavorites(ByVal FolderName As String)
        If FavoritesCollection Is Nothing Then
            FavoritesCollection = New WebFavoriteCollection
        End If
        For Each strFile As String In My.Computer.FileSystem.GetFiles(FolderName)
            If strFile.EndsWith(".url", True, Nothing) Then
                Try
                    Using objWebFavorite As New WebFavorite
                        objWebFavorite.Load(strFile)
                        FavoritesCollection.Add(objWebFavorite)
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub
End Class
