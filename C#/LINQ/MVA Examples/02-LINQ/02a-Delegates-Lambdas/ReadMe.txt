Delegates and Lambdas ReadMe

This demo covers delegates and how to achieve loose coupling with delegates.
We also take a look at how to define a delegate within the body of a method
using anonymous methods and lambda expressions.

Part A: Delegates Intro

1. Define a delegate that accepts two integers and returns an integer

2. Define a static Add method that matches the delegate definition

3. Write code in Main that initializes and invokes the delegate

Part B: Loose Coupling with Delegates

Set Loose-Coupling as the Startup project for the solution.

1. Define a delegate that accepts a string and returns bool

2. Create a TestForLength method that matches the delegate
   - Return true if the length is greater than 3

3. Write a static Where method that accepts a string array and the delegate type
   - Method should return a string array
   - Foreach over the items and invoke delegate
   - Include item in the results if delegate returns true

4. Write code in Main to invoke the Where method
   - Create a string array with items
   - Pass the array and the TestForLength method

5. Replace the custom delegate with built-in generic Func delegate
   - Use Func<string, bool>

Part C: Anonymous Methods

Continue where you left off in the Part B of the Loose-Coupling project.

1. Refactor the standalone TestForLength method as an anonymous method
   - Define a local int max variable in Main and assign a value of 3
   - Create an anonymous method in main with the same body as TestForLength,
     but access the local max variable for the value
   - Pass anonymous method to the Where method

Part D: Lambda Expressions

Continue where you left off in the Part C of the Loose-Coupling project.

1. Refactor the anonymous method in Main as a lambda expression

