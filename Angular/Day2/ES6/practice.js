let number = [301, 302, 303, 304, 305, 306];

//Array distructure

const [one, two, ...three] = number;//spread operator
console.log(one);
console.log(two);
console.log(three);

//==============merge======================

let n1 = [10, 20, 30, 40, 50];
let n2 = [60, 70, 80, 90];

const n = [...n1, ...n2];
console.log(n);

//=======================================================

let family={
    father:"a",
    mother:"b",
    brother:"c",
    sister:"d"
}

let userfamily={
    father:"Jagdishbhai",
    mother:"Vilasben"
}

let finalfamily