Module Module1

   Sub Main()
  
      Dim classGrades = New System.Collections.Generic.List(Of Integer) From {63, 68, 71, 75, 68, 92, 75}

      Dim distinctQuery = From grade In classGrades 
                          Select grade Distinct

      Dim sb As New System.Text.StringBuilder("The distinct grades are: ")
	  
      For Each number As Integer In distinctQuery
         sb.Append(number & " ")
      Next

      MsgBox(sb.ToString())
	  
   End Sub
   
End Module