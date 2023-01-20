/*

Class 
Object 
Static method - without creating an object for the class we can call method
Constructor method
Call method from object

*/

class Person {
    constructor(name, surname, age) { // constructor method inside class, whenever we create an object for class, constructor automatically executes
        this.name = name; // property
        this.surname = surname;
        this.age = age;
    }

    getFullname() { // normal method
        return this.name + " " + this.surname;
    }

    static older(person1, person2) { // static method
        return person1.age >= person2.age ? person1 : person2 // ternary operator
    }
}

var harsh = new Person("Harsh", "Panchal", 24); // creating object, constructor autocall
var anas = new Person("Anas", "Pathan", 23);

console.log(harsh.getFullname()); // calling normal method
console.log(anas.getFullname());

console.log(Person.older(harsh, anas)); // calling static method

