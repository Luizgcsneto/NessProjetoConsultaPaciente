import { Data } from "@angular/router";
import { Timestamp } from "rxjs";

export class Marcacao {

  id: string;
  dataMarcacao: Data;
  disponivel: boolean;
  horario: Data;
  pacienteID: string;
  hospitalID: string;

  constructor(_id: string, _dataMarcacao: Data, _disponivel: boolean, _horario: Data, _pacienteID: string, _hospitalID: string) {
    this.id = _id;
    this.dataMarcacao = _dataMarcacao;
    this.disponivel = _disponivel;
    this.horario = _horario;
    this.pacienteID = _pacienteID;
    this.hospitalID = _hospitalID;
 
  }

}
