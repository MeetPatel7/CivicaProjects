var numbers = [301, 302, 303, 304, 305];

/*
var even = numbers.filter(function (x) {
    return x % 2 === 0;
});
*/

var even = numbers.filter((x) => x % 2 === 0);
console.log(even); // [ 302, 304 ]