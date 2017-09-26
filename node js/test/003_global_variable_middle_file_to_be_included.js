// using global variables

var x = 10;

function ShowVar()
{
    console.log('value from method ' + x);
}

global.x_val = x;
global.func_1 = ShowVar;