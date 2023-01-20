export class EmployeeData {
    id?:number = 0;
    firstName:string = '';
    lastName:string = '';
    dateOfBirth !:  Date ;
    age:number = 0;
    email : string = '';
    joinedDate ?: Date;
    isActive ?:boolean;
    departmentId : number = 0;
}
