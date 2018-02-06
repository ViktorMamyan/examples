Module Module1

   Sub Main()
   
      Dim words = {"once", "upon", "a", "time", "there", "was", "a", "jungle"}

      Dim query = From word In words 
                  Take 3 

      Dim sb As New System.Text.StringBuilder()
	  
      For Each str As String In query
         sb.AppendLine(str)
         Console.WriteLine(str)
      Next 
	  
      Console.ReadLine()
	  
   End Sub
   
End Module