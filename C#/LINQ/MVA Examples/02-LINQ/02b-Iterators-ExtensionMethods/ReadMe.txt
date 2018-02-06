Iterators and Extension Methods ReadMe

Here we demonstrate how to use the C# keywords, yield return, to create an iterator
for implementing IEnumerable<T>.  Then we create some extension methods and bring
them into scope. We use "var" with anonymous types and explore nullable value types.

Part A: Iterators

1. Run the Iterators program to see how it works.
   - Open CompanyOrig to see how IEnumerable was implemented

2. Implement GetEnumerator in CompanyNew using a C# iterator
   - Foreach over _workers, calling yield return for each worker

3. Add a GetEvens method to Main which returns IEnumberable<int> using an iterator
   - Write code in Main that initializes an int array and calls GetEvens

Part B: Extension Methods

1. Add a public static Where method to the Enumerable class returning IEnumerable<T>
   - Include parameters for IEnumerable<T> items and Func<T, bool> test
   - Use an iterator to only return items which pass the test

2. Write code in Main that initializes an array of ints
   - Call the Where method passing the ints and a lambda expression for even numbers

3. Convert Where to an extension method
   - Make Enumerable a static class
   - Place 'this' before the first parameter

4. Write code in Main to call Where as an extension method
   - Add a using directive for the MyLinq namespace

Part C: Anonymous Types

1. Add a Select extension method to the Enumberable class in the ExtensionMethods project
   - There should be two type arguments: T and TResult
   - Selector parameter is a Func<T, TResult>
   - Iterate over items, calling yield return with selector

2. Write code in Main that initializes an array of strings
   - Then calls Select to project a sequence of anonymous types
   - Selector creates an anonymous type with Name (string) and Age (string length)

Part D: Nullable Value Types

1. Explicitly init nullable date

2. Use C# shorthand and implicit conversion

3. Check type of NVT

4. Try boxing and unboxing

5. Try nullibility and comparison

6. Try 'as' operator

