import { Pipe, PipeTransform } from '@angular/core';
import { IUser } from './iuser';

@Pipe({
  name: 'filterUser'
})
export class FilterUserPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    let filterBy = args[0].toLocaleLowerCase();
    return value.filter((user: IUser) => user.fullname.toLocaleLowerCase().includes(filterBy))
  }

}
