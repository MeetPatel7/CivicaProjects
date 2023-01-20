import { Pipe, PipeTransform } from '@angular/core';
import { Iproduct } from './iproduct';
@Pipe({
  name: 'productFilter'
})
export class ProductFilterPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    let filterBy = args[0].toLocaleLowerCase();
    return value.filter((product: Iproduct) => product.productName.toLocaleLowerCase().includes(filterBy))
  }

}
