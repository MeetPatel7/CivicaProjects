function DelayedGreeter(name) { // constructor function
    this.name = name;
}
// Object.prototype.name = value 
DelayedGreeter.prototype.greet = function () {
    setTimeout(function cb() {
        console.log('hello ' + this.name);
    }, 5000); // after 5 seconds, 1000 milliseconds is 1 second
}

let greeter = new DelayedGreeter("World");
console.log(greeter.greet());