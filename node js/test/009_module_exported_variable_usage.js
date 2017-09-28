var obj = require('./008_module_exports_variable_middle_file_to_be_included'); // seting module into variable

// using exported variables

console.log('value from variable ' + obj.x_val);

obj.func_1(); // calling method