// using exports to transfer variable values

var x = 10;

function ShowVar()
{
    console.log('value from method ' + x);
}

exports.x_val = x;
exports.func_1 = ShowVar;