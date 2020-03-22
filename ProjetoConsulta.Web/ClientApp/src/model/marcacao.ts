import { Data } from "@angular/router";

export class Marcacao {

  id: number;
  dataMarcacao: Data;

  constructor(_id: number, _dataMarcacao) {
    this.id = _id;
    this.dataMarcacao = _dataMarcacao;
 


  }

}
