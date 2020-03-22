import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Marcacao } from '../../model/marcacao';

@Component({
  selector: 'app-marcacao',
  templateUrl: './marcacao.component.html',
  styleUrls: ['./marcacao.component.css']


})
export class MarcacaoComponent implements OnInit {

  Marcacao marcacao1 = new Marcacao("0e257627-596d-4fc5-b922-921858be628e");

  Marcacao marcacao2 = new Marcacao("0e257655-596d-4fc5-b922-921858be628e",
                                      "Hospital da Restauração",
                                      false,
                                      "endereco hospital 2",
                                          "hospital2@gmail.com",
                                          "contato hospital 2");
  

  Marcacao marcacao3 = new Marcacao("0e2576288-596d-4fc5-b922-921858be628e",
                                              "UPA da Pe-15",
                                                    false,
                                          "endereco hospital 3",
                                              "hospital3@gmail.com",
                                            "contato hospital 3");

  Marcacao marcacao4 = new Marcacao("0e2579999-596d-4fc5-b922-921858be628e",
                                              "Hospital das clínicas",
    false,
    "endereco hospital 4",
    "hospital4@gmail.com",
  "contato hospital 4");



  marcacoes: Marcacao[] = [this.marcacao1, this.marcacao2, this.marcacao3, this.marcacao4];
  

  constructor(private router: Router, private activatedRouter: ActivatedRoute) { }


  ngOnInit(): void {  

   

  }
 

}
