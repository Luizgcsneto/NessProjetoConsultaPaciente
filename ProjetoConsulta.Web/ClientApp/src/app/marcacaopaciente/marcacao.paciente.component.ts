import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MarcacaoPaciente } from '../../model/marcacao_paciente';

@Component({
  selector: 'app-marcacaopaciente',
  templateUrl: './marcacao.paciente.component.html',
  styleUrls: ['./marcacao.paciente.component.css']


})
export class MarcacaoPacienteComponent implements OnInit {

  MarcacaoPaciente marcacao1 = new MarcacaoPaciente("3bd65c4f-fae8-4a81-971c-c8a2eab4fae4", new Date(), true, new Date().getTime(), null, "3bd65c4f-fae8-4a81-971c-c8a2eab4fae4");
  MarcacaoPaciente marcacao2 = new MarcacaoPaciente("3bd65c4f-fae8-4a81-971c-c8a2eab4fae4", new Date(), true, new Date().getTime(), null, "3bd65c4f-fae8-4a81-971c-c8a2eab4fae4");
  MarcacaoPaciente marcacao3 = new MarcacaoPaciente("3bd65c4f-fae8-4a81-971c-c8a2eab4fae4", new Date(), true, new Date().getTime(), null, "3bd65c4f-fae8-4a81-971c-c8a2eab4fae4");

  /*
  Marcacao marcacao2 = new Marcacao();
  
  Marcacao marcacao3 = new Marcacao();

  Marcacao marcacao4 = new Marcacao();
  */
  marcacoes: MarcacaoPaciente[] = [this.marcacao1, this.marcacao2, this.marcacao3];


  constructor(private router: Router, private activatedRouter: ActivatedRoute) { }


  ngOnInit(): void {



  }
  desmarcarMarcacao(marcacao: MarcacaoPaciente): void {
    this.router.navigate(['/app-hospital'], { queryParams: { id: 1 } });
  }

}
