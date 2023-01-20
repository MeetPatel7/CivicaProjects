/*

Functional oriented or procedure orientend language 

OOP 
    class is a template
        contains properties and method

*/

function Person(name, surname, age) { // constructor function
    this.name = name;
    this.surname = surname;
    this.age = age;
}

// Object.prototype.name = value
Person.prototype.getFullname = function () {
    return this.name + " " + this.surname;
}

Person.older = function (person1, person2) {
    return person1.age >= person2.age ? person1 : person2 // ternary operator
}

var harsh = new Person("Harsh", "Panchal", 24);
var anas = new Person("Anas", "Pathan", 23);

console.log(harsh.getFullname()); // Harsh Panchal
console.log(anas.getFullname()); // anas pathan

console.log(Person.older(harsh, anas)); // Person { name: 'Anas', surname: 'Pathan', age: 23 }


