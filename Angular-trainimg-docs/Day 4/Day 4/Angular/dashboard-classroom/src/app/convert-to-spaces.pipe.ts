import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'convertToSpaces'
})
export class ConvertToSpacesPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    // console.log(value);
    return value.replace("-", " ");
  }

}
