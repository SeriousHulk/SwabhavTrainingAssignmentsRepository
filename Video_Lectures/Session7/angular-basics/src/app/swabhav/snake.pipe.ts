import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'snake'
})
export class SnakePipe implements PipeTransform {

  transform(inputMessage: string, casing: string = ""): string {
    console.log(inputMessage);
    if (casing == "U")
    inputMessage = inputMessage.toUpperCase()
    else if (casing == "L")
    inputMessage = inputMessage.toLowerCase()
    inputMessage.split(' ').join('_');
    return inputMessage;
  }

}
