class Car {

    constructor(color) {
        this.color = color;
    }

    move() {
        console.log(`Speed 200 kph and color is ${this.color}`);
    }
}

var car = new Car('Blue');
car.move();

//===Q-2===========

const name = "Meet";
const intrest = ["Sports", "Traveling"];
const birth = {
    year: 2000,
    place: "Vadodara"
}

const detail = `${name} is an Indian developer, interested in many topics such as ${intrest.join(", ")}. gender is born in ${birth.year} in ${birth.place}.`;
console.log(detail);