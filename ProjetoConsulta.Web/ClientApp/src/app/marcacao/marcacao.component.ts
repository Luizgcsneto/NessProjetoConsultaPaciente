import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Marcacao } from '../../model/marcacao';

@Component({
  selector: 'app-marcacao',
  templateUrl: './marcacao.component.html',
  styleUrls: ['./marcacao.component.css']


})
export class MarcacaoComponent implements OnInit {

  Marcacao marcacao1 = new Marcacao("3bd65c4f-fae8-4a81-971c-c8a2eab4fae4", new Date(), true, new Date().getTime(), null, "3bd65c4f-fae8-4a81-971c-c8a2eab4fae4");
  Marcacao marcacao2 = new Marcacao("3bd65c4f-fae8-4a81-971c-c8a2eab4fae4", new Date(), true, new Date().getTime(), null, "3bd65c4f-fae8-4a81-971c-c8a2eab4fae4");
  Marcacao marcacao3 = new Marcacao("3bd65c4f-fae8-4a81-971c-c8a2eab4fae4", new Date(), true, new Date().getTime(), null, "3bd65c4f-fae8-4a81-971c-c8a2eab4fae4");

  /*
  Marcacao marcacao2 = new Marcacao();
  
  Marcacao marcacao3 = new Marcacao();

  Marcacao marcacao4 = new Marcacao();
  */
  marcacoes: Marcacao[] = [this.marcacao1, this.marcacao2, this.marcacao3];


  constructor(private router: Router, private activatedRouter: ActivatedRoute) { }


  ngOnInit(): void {



  }
  realizarMarcacao(marcacao: Marcacao): void {
    this.router.navigate(['/app-marcacaopaciente'], { queryParams: { id: 1 } });
  }

}
