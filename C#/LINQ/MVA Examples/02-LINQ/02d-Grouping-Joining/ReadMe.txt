Grouping and Joining ReadMe

Here we look at grouping and joining operations. We will also examine the let keyword and
chaining from clauses to get all child objects.

The SampleData project contains a LinkBooks static class with properties of arrays for 
Books, Authors, Subjects and Publishers.

Part A: More LINQ Syntax

1. Write a query to get books
   - Use 'let' to calculate sales tax at 8.25%
   - Use 'let' to calculate total including tax
   - Place inline variable in both where and select clauses

2. Write a query that gets all the authors from all the books
   - Chain multiple from clauses to execute a Select Many operation

Part B: Grouping

1. Write a query that groups books by price
   - Iterate over the groups, printing the key
   - Within the first foreach, iterate each group
     > Print each book title

2. Use 'into' keyword to declare group variable
   - Sort by the group key
   - Add select to project the groups

Part C: Joins

1. Join Authors with Data.Names on FirstName

2. Create Group Join between Authors and Data.AuthorHobbies
   - Use 'into' to create a variable representing groups of hobbies
   - Project anonymous type with Name and Hobbies
   - Iterate over authors and their hobbies

3. Create 'Outer Join' between Authors and Data.AuthorHobbies
  - Add a 'from' clause on group join variable (hobbies)
  - Call DefaultIfEmpty on group join variable
  - Project anonymous type with Name and Hobby
  - Use ternary operator to test if h is null
