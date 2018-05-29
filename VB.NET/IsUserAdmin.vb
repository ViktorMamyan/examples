Imports System.Security.Principal

Friend Function IsUserAdmin() As Boolean
	Dim identity = WindowsIdentity.GetCurrent()
	Dim principal = New WindowsPrincipal(identity)

	Return principal.IsInRole(WindowsBuiltInRole.Administrator)
End Function

Friend Function IsUserAdmin2() As Boolean
	If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
		Return True
	Else
		Return False
	End If
End Function