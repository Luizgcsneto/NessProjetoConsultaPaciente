export class Hospital {

  id: number;
  nomeHospital: string;
  ehAdministrador: boolean;
  endereco: string;
  email: string;
  contato: string;

  constructor(_id: number, _nomeHospital: string, _ehAdministrador: boolean, _endereco: string, _email: string, _contato: string) {
    this.id = _id;
    this.nomeHospital = _nomeHospital;
    this.ehAdministrador = _ehAdministrador;
    this.endereco = _endereco;
    this.email = _email;
    this.contato = _contato;


  }
}
