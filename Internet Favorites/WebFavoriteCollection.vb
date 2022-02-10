Public Class WebFavoriteCollection
    Inherits CollectionBase

    Public Sub Add(ByVal Favorite As WebFavorite)
        List.Add(Favorite)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index >= 0 And index < Count Then
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property Item(ByVal index As Integer) As WebFavorite
        Get
            Return CType(List.Item(index), WebFavorite)
        End Get
    End Property
End Class
