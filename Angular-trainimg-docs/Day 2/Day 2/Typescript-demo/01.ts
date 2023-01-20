let address: string = "Mumbai";
let x: number = 2;

let numbers: number[] = [301, 302, 303, 304, 305, 311, 312, 313, 314, 315];

let cities: string[] = ["Rose", "Dahlia", "Magnolia", "Tulip", "Daisy"];

let mixedCity: (string | number)[] = [301, 302, 303, 304, 305, "Mumbai"];

interface IUsers {
    id: number;
    fullname: string;
    email: string;
    password: string
}

let users: IUsers = {
    id: 1,
    fullname: 'Anne Hunter',
    email: 'anne.hunter@gmail.com',
    password: 'anne123'
}

