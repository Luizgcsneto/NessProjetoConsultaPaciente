import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Hospital } from '../../model/hospital';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.css']


})
export class HospitalComponent implements OnInit {

  Hospital hospital1 = new Hospital(1,
                                    "Getulio Vargas",
                                    "Av. General San Martin, S/N, Cordeiro, Recife - PE",
                                    "hgvsec@saude.pe.gov.br",
                                    "Diretor: Bartolomeu Nascimento");

  Hospital hospital2 = new Hospital(2,
                                      "Hospital da Restauração",
                                      "Av. Gov. Agamenon Magalhães, s/n - Derby, Recife - PE, 52171-011",
                                      "direcaohr@gmail.com",
                                      "Diretor Miguel Arcanjo");
 
  Hospital hospital3 = new Hospital(3,
                                    "Hospital Agamenon Magalhães",
                                    "Estrada do Arraial, 2.723, Casa Amarela, Recife - PE",
                                    "diger.ham@saude.pe.gov.br",
                                    "Diretor: Cláudia Miranda");

  Hospital hospital4 = new Hospital(4,
                                    "Hospital Barão de Lucena",
                                    "Avenida Caxangá, 3.860, Iputinga, Recife - PE",
                                    "",
                                    "Diretor: Ângela Santos");

  Hospital hospital5 = new Hospital(5,
                                      "Hospital Geral de Areias",
                                      "Avenida Recife, 810 - Estância, Recife - PE",
                                      "hga@saude.pe.gov.br",
                                      "Diretor:Frinéa Vaz");

  Hospital hospital6 = new Hospital(6,
                                      "Hospital Jaboatão Prazeres",
                                      "Rua Recife, S/N, Cajueiro Seco, Jaboatão dos Guararapes - PE",
                                      "seshpjp@yahoo.com.br",
                                      "Diretor: Alfredo Pereira");


  Hospital hospital7 = new Hospital(7,
                                      "Hospital Otávio de Freitas",
                                      "Rua Aprígio Guimarães, S/N - Tejipió, Recife - PE",
                                      "diretoriahof@gmail.com",
                                       "Diretor: Antônio Almeida");

  Hospital hospital8 = new Hospital(8,
                                      "Hospital São Lucas",
                                       "Bosque Flamboyant, BR-363, S/N, Floresta Nova, Fernando de Noronha - PE",
                                      "hslucas@noronha.pe.gov.br",
                                      "Diretor: Natália Câmpelo");



  hospitais: Hospital[] = [this.hospital1, this.hospital2, this.hospital3, this.hospital4, this.hospital5, this.hospital6, this.hospital7, this.hospital8];
  

  constructor(private router: Router, private activatedRouter: ActivatedRoute) { }


  ngOnInit(): void {  
   
  }

  realizarAgendamento(): void {
    this.router.navigate(['/app-marcacao'], { queryParams: { id: 1 } });
  }

}
