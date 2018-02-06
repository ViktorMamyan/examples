Module Module1

   Sub Main()
   
      Dim num As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9}

      Dim intDivByTwo = Aggregate n In num
                       Where n > 6
                       Into Count()
      Console.WriteLine("Count of Numbers: " & intDivByTwo)

      Dim intResult = Aggregate n In num
                     Where n > 6
                     Into Average()
							
      Console.WriteLine("Average of Numbers: " & intResult)

      intResult = Aggregate n In num
                 Where n > 6
                 Into LongCount()
					  
      Console.WriteLine("Long Count of Numbers: " & intResult)

      intResult = Aggregate n In num
                 Into Max()
					  
      Console.WriteLine("Max of Numbers: " & intResult)

      intResult = Aggregate n In num
                 Into Min()
					  
      Console.WriteLine("Min of Numbers: " & intResult)

      intResult = Aggregate n In num
                 Into Sum()
					  
      Console.WriteLine("Sum of Numbers: " & intResult)

      Console.ReadLine()

   End Sub
   
End Module