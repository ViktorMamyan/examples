Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

	Friend Function Encrypt(clearText As String, EncryptionKey As String, Salt As String) As String

		Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)

		Using encryptor As Aes = Aes.Create()

			Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, System.Text.Encoding.UTF8.GetBytes(Salt))

			encryptor.Key = pdb.GetBytes(32)
			encryptor.IV = pdb.GetBytes(16)

			Using ms As New MemoryStream()

				Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
					cs.Write(clearBytes, 0, clearBytes.Length)
					cs.Close()
				End Using

				clearText = Convert.ToBase64String(ms.ToArray())

			End Using

		End Using

		Return clearText

	End Function

	Friend Function Decrypt(cipherText As String, EncryptionKey As String, Salt As String) As String

		Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)

		Using encryptor As Aes = Aes.Create()

			Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, System.Text.Encoding.UTF8.GetBytes(Salt))

			encryptor.Key = pdb.GetBytes(32)
			encryptor.IV = pdb.GetBytes(16)

			Using ms As New MemoryStream()

				Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
					cs.Write(cipherBytes, 0, cipherBytes.Length)
					cs.Close()
				End Using

				cipherText = Encoding.Unicode.GetString(ms.ToArray())

			End Using

		End Using

		Return cipherText

	End Function