// using module.exports to transfer variable values

var x = 10;

function ShowVar()
{
    console.log('value from method ' + x);
}

module.exports = {
    x_val : x
    ,func_1 : ShowVar
};