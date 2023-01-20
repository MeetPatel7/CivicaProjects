/*
Inheritance 
    Whenever a Child aquires the properties and method of parent class then it is called inheritance.
    We use extends keyword for inheritance

*/
class Person { // parent class
    constructor(name, surname, age) {
        this.name = name; // property
        this.surname = surname;
        this.age = age;
    }

    getFullName() { // normal method
        return this.name + " " + this.surname;
    }

    static older(person1, person2) { // static method
        return person1.age >= person2.age ? person1 : person2 // ternary operator
    }
}

class PersonWithMiddleName extends Person {  // child class inherit Person
    constructor(name, middleName, surname, age) {
        super(name, surname, age); // take this from parent
        this.middleName = middleName;
    }

    getFullName() {
        return this.name + " " + this.middleName + " " + this.surname;
    }
}

const rashmi = new PersonWithMiddleName("Rashmi", "MiddleName", "Sharma", 22);
console.log(rashmi.getFullName());

