export class Hospital {

  id: number;
  nomeHospital: string;
  endereco: string;
  email: string;
  contato: string;

  constructor(_id: number, _nomeHospital: string, _endereco: string, _email: string, _contato: string) {
    this.id = _id;
    this.nomeHospital = _nomeHospital;
    this.endereco = _endereco;
    this.email = _email;
    this.contato = _contato;


  }
}
