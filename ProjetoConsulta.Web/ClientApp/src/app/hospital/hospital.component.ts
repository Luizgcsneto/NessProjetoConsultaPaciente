import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Hospital } from '../../model/hospital';
import { HospitalServico } from '../servicos/paciente/hospital.servico';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.css']


})
export class HospitalComponent implements OnInit {




  hospitais: Hospital[];


  constructor(private router: Router, private activatedRouter: ActivatedRoute, private hospitalServico: HospitalServico) { }


  ngOnInit(): void {
    this.carregarHospitais();
  }

  realizarAgendamento(id: string): void {
    this.router.navigate(['/app-marcacao'], { queryParams: { id } });
  }

  public carregarHospitais() {


    this.hospitalServico.ListarHospitais()
      .subscribe(
        data => {
          this.hospitais = data;
        },
        err => {

          console.error(err.error);
        }
      );

  }

}
