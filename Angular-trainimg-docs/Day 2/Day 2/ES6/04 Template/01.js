const name = "Kaavya"; // string
const interests = ["Dancing", "Singing", "Reading"]; // Array
const birth = { // Object
    year: 2000,
    place: 'Chandigarh'
};
/*
    Join - convert array in to string
    Split - convert string in to array
*/
// ES5 
const text = name + " is an Indian developer, interested in many topics such as " + interests.join(", ") + ". She is born in " + birth.year + " in " + birth.place + ".";
console.log(text);

// ES6 
const text2 = `${name} is an Indian developer, interested in many topics such as ${interests.join(", ")}. She is born in ${birth.year} in ${birth.place}.`;

console.log(text2);

Car 
    color = red
    
    move    
        console.log("My car is moving ...");



