import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'preco',
  standalone: false
})
export class PrecoPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
