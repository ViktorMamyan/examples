Imports Microsoft.Win32
Imports System.Management

Public Class IsVirtual

    Public Function DetectVMStep1() As Boolean
        Try
            Const virtualMachineKey As String = "SOFTWARE\Microsoft\Virtual Machine\Guest\Parameters"

            Dim oReg As RegistryKey = Registry.LocalMachine.OpenSubKey(virtualMachineKey)

            If oReg IsNot Nothing Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Function DetectVMStep2() As Boolean
        Try
            Using searcher = New System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem")

                Using items = searcher.[Get]()

                    For Each item In items
                        Dim manufacturer As String = item("Manufacturer").ToString().ToLower()
                        If (manufacturer = "microsoft corporation" AndAlso item("Model").ToString().ToUpperInvariant().Contains("VIRTUAL")) OrElse
                            manufacturer.Contains("vmware") OrElse
                            item("Model").ToString() = "VirtualBox" Then
                            Return True
                        End If
                    Next

                End Using

            End Using

            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function

End Class