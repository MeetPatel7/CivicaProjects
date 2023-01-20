// Object destructuring

const students = {
    firstName: "John",
    lastName: "Rhey",
    country: "Australia"
};

const { firstName } = students;

console.log(firstName);

var family = {
    father: "a",
    mother: "b",
    sister: "c",
    brother: "d"
};

// father: ram, mother: sita, sister c brother d

var updateFamily = {
    brother: "Ramesh"
}

var finalFamily = {
    ...family,
    ...updateFamily
};

console.log("finalFamily", finalFamily);

