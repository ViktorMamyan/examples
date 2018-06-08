Public Class Form1

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Button1.Tag = New DragInfo(Form.MousePosition, Button1.Location)
    End Sub

    Private Sub Button1_MouseMove(sender As Object, e As MouseEventArgs) Handles Button1.MouseMove
        If Button1.Tag IsNot Nothing Then
            Dim info As DragInfo = CType(Button1.Tag, DragInfo)
            Dim newLoc As Point = info.NewLocation(Form.MousePosition)
            If Me.ClientRectangle.Contains(New Rectangle(newLoc, Button1.Size)) Then Button1.Location = newLoc
        End If
    End Sub

    Private Sub Button1_MouseUp(sender As Object, e As MouseEventArgs) Handles Button1.MouseUp
        Button1.Tag = Nothing
    End Sub

End Class

Public Class DragInfo
    Public Property InitialMouseCoords As Point
    Public Property InitialLocation As Point

    Public Sub New(ByVal MouseCoords As Point, ByVal Location As Point)
        InitialMouseCoords = MouseCoords
        InitialLocation = Location
    End Sub

    Public Function NewLocation(ByVal MouseCoords As Point) As Point
        Dim loc As New Point(InitialLocation.X + (MouseCoords.X - InitialMouseCoords.X), InitialLocation.Y + (MouseCoords.Y - InitialMouseCoords.Y))
        Return loc
    End Function
End Class