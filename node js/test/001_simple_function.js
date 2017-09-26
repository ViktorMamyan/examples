// using js function
function User(Name)
{
    this.name = Name;
    
    // creating method
    this.js_sub = () => 
    {
        console.log('Hello ' + this.name);
    };
}

// creating new instance
var U = new User('John');

// calling method
U.js_sub();

//executing:> node 001_simple_function