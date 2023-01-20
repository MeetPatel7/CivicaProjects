export class EmployeeData {
    id:number = 0;
    firstName:string = '';
    lastName:string = '';
    age:number = 0;
    dateOfBirth !:  Date ;
    email : string = '';
    joinedDate !: Date;
    isActive !:boolean;
    departmentId : number = 0;
    EMId: number | undefined;
}
