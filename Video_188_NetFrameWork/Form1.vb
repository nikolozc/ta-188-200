﻿Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lnkURL.Text = "Visit " & "Youtube"
        lnkURL.Links.Clear()
        lnkURL.Links.Add(6, 7, "http://www.youtube.com")
        LoadFavorites()
    End Sub

    Private Sub lstFavorites_Click(sender As Object, e As EventArgs) Handles lstFavorites.Click
        lnkURL.Text = "Visit " & lstFavorites.SelectedItems.Item(0).Text
        lnkURL.Links.Clear()
        lnkURL.Links.Add(6, lstFavorites.SelectedItems.Item(0).Text.Length, lstFavorites.SelectedItems.Item(0).SubItems(1).Text)
    End Sub

    Private Sub lnkURL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkURL.LinkClicked
        Process.Start(e.Link.LinkData)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadFavorites()
    End Sub

    Private Sub LoadFavorites()
        lstFavorites.Items.Clear()
        Dim objMenu As New ContextMenu
        Try
            Using objFavorites As New Favorites
                objFavorites.ScanFavorites()
                For Each objWebFavorite As WebFavorite In objFavorites.FavoritesCollection
                    Dim objListViewItem As New ListViewItem
                    Dim objItem As New WebFavoritesMenuItem(objWebFavorite)
                    objMenu.MenuItems.Add(objItem)
                    objListViewItem.Text = objWebFavorite.Name
                    objListViewItem.SubItems.Add(objWebFavorite.URL)
                    lstFavorites.Items.Add(objListViewItem)
                Next
            End Using
            objMenu.MenuItems.Add("-")
            objMenu.MenuItems.Add(New ExitMenuItem())
            icnFavorites.ContextMenu = objMenu
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub icnFavorites_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles icnFavorites.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub
End Class
