Module Module1

   Sub Main()

      Dim barley As New Pet With {.Name = "Barley", .Age = 4}
      Dim boots As New Pet With {.Name = "Boots", .Age = 1}
      Dim whiskers As New Pet With {.Name = "Whiskers", .Age = 6}
      Dim bluemoon As New Pet With {.Name = "Blue Moon", .Age = 9}
      Dim daisy As New Pet With {.Name = "Daisy", .Age = 3}

      Dim charlotte As New Person With {.Name = "Charlotte", .Pets = New Pet() {barley, boots}}
      Dim arlene As New Person With {.Name = "Arlene", .Pets = New Pet() {whiskers}}
      Dim rui As New Person With {.Name = "Rui", .Pets = New Pet() {bluemoon, daisy}}

      Dim people As New System.Collections.Generic.List(Of Person)(New Person() {charlotte, arlene, rui})

      Dim query = From pers In people
                  Where (Aggregate pt In pers.Pets Into Any(pt.Age > 7))
                  Select pers.Name

      For Each e In query
         Console.WriteLine("Name = {0}", e)
      Next

      Console.WriteLine(vbLf & "Press any key to continue.")
      Console.ReadKey()
	  
   End Sub

   Class Person
      Public Property Name As String
      Public Property Pets As Pet()
   End Class

   Class Pet
      Public Property Name As String
      Public Property Age As Integer
   End Class
   
End Module