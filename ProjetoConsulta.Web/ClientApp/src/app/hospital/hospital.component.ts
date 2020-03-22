import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Hospital } from '../../model/hospital';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.css']


})
export class HospitalComponent implements OnInit {

  Hospital hospital1 = new Hospital("0e257627-596d-4fc5-b922-921858be628e",
                                    "Getulio Vargas",
                                         false,
                                    "rua hospital 1",
                                    "hospital1@hotamil.com",
                                    "contato hospital 1");

  Hospital hospital2 = new Hospital("0e257655-596d-4fc5-b922-921858be628e",
                                      "Hospital da Restauração",
                                      false,
                                      "endereco hospital 2",
                                          "hospital2@gmail.com",
                                          "contato hospital 2");
  

  Hospital hospital3 = new Hospital("0e2576288-596d-4fc5-b922-921858be628e",
                                              "UPA da Pe-15",
                                                    false,
                                          "endereco hospital 3",
                                              "hospital3@gmail.com",
                                            "contato hospital 3");

  Hospital hospital4 = new Hospital("0e2579999-596d-4fc5-b922-921858be628e",
                                              "Hospital das clínicas",
    false,
    "endereco hospital 4",
    "hospital4@gmail.com",
  "contato hospital 4");



  hospitais: Hospital[] = [this.hospital1, this.hospital2, this.hospital3, this.hospital4];
  

  constructor(private router: Router, private activatedRouter: ActivatedRoute) { }


  ngOnInit(): void {  

   /* function marcacaoHospitais(id:number) {
      this.router.navigate(['/app-marcacoes']);
    }
    */
  }
 

}
