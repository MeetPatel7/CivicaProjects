/*

let have block scoping

*/

var x = 2;

if (x == 2) {
    let address = "Mumbai";
}

console.log(address); // ReferenceError: address is not defined