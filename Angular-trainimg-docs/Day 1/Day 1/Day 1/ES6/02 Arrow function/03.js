var numbers = [301, 302, 303, 304, 305];

/*
var even = numbers.filter(function (x) {
    return x % 2 === 0;
});
*/

var even = numbers.filter((x) => {
    if (x % 2 === 0) {
        console.log(x + " is even");
        return true;
    }
});

console.log(even);

/*
302 is even
304 is even
*/
