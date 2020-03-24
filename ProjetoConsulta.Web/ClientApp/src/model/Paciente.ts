import { Marcacao } from "./marcacao";

export class Paciente {

  id: string;
  email: string;
  password: string;
  nome: string;
  sobreNome: string;
  ehAdministrador: boolean;
  marcacoes: Marcacao[];
}
