Conversion and Aggregation ReadMe

To avoid re-executing, use a conversion operator to cache results in a collection, such as
an array, list or dictionary.  We'll look at other aggregation operators as well.

Part A: Conversion

1. Select a single customer
   - Use Single operator for customer from Oakland
     > Notice runtime exception
   - Use Single for customer from Los Angeles
     > Notice runtime exception
   - Use Single for customer from San Francisco
     > No error this time because there is just one

2. Repeat using SingleOrDefault
   - Still get error if more than one
   - But returns null if none

3. Convert query of customers to a List
   - Customers in Oakland
   - Set breakpoint in query
   - See when breakpoint is hit - or not

4. Convert query to a Dictionary
   - Use FirstName + " " + LastName as key

5. Convert grouping query to a Lookup
   - Use City as the key

Part B: Aggregation

1. Count number of customers from Oakland

2. Get customer with fewest orders
   - Use Min operator within where clause
   - Use Single on result

3. Get average number of orders for customers in Oakland

4. See if there are any customers with less than 5000 orders