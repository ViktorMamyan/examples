Imports System.Security.Cryptography
Imports System.Text

Friend Function getMD5Hash(ByVal input As String) As String
	Dim md5Hasher As MD5 = MD5.Create()
	Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))
	Dim sBuilder As New StringBuilder()
	Dim i As Integer
	For i = 0 To data.Length - 1
		sBuilder.Append(data(i).ToString("x2"))
	Next i
	Return sBuilder.ToString()
End Function