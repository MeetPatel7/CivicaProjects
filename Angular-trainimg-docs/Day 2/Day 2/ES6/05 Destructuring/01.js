let numbers = [301, 302, 303, 304, 306, 307, 308, 309, 310, 311, 312, 313, 314, 315];
/*
Array destructuring
Spread operator 
REST 
*/ 
const [first, second, ...restOfItems] = numbers;

console.log(first); // 301
console.log(second); // 302
console.log(restOfItems); // [ 303, 304, 305 ]
