Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class SystemMenu

    Public Shared Sub DisableCloseButton(ByVal form As Form)
        SystemMenu.EnableMenuItem(SystemMenu.GetSystemMenu(form.Handle, 0), &HF060, 1)
    End Sub

    Public Shared Sub EnableCloseButton(ByVal form As Form)
        SystemMenu.EnableMenuItem(SystemMenu.GetSystemMenu(form.Handle, 0), &HF060, 0)
    End Sub

    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function EnableMenuItem(ByVal menu As IntPtr, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True, ExactSpelling:=True)> _
    Private Shared Function GetSystemMenu(ByVal WindowHandle As IntPtr, ByVal bReset As Integer) As IntPtr
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DisableCloseButton(Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EnableCloseButton(Me)
    End Sub

End Class