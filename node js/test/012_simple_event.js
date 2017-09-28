var event = require('events');              // importing events module

var emmiter = new event.EventEmitter();

emmiter.on('create', function(){            // createing event ON CREATE
    console.log('event on create');
});

emmiter.emit('create');                     // executing event