import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Marcacao } from '../../model/marcacao';
import { HospitalServico } from '../servicos/paciente/hospital.servico';
import { Hospital } from '../../model/hospital';
import { PacienteServico } from '../servicos/paciente/paciente.servico';

@Component({
  selector: 'app-marcacao',
  templateUrl: './marcacao.component.html',
  styleUrls: ['./marcacao.component.css']
})
export class MarcacaoComponent implements OnInit {


  marcacoes: Marcacao[];
  hospital: Hospital;

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private servicoHospital: HospitalServico, private pacienteServico: PacienteServico) { }


  ngOnInit(): void {

    this.activatedRouter.queryParams.subscribe(parametros => {
      if (parametros['id']) {
        this.servicoHospital.ListarMarcacoesHospital(parametros['id'])
          .subscribe(
            data => {
              this.hospital = data;
              this.marcacoes = this.hospital.marcacoes;
            },
            err => {

              console.error(err.error);
            }
          );

      }
    });

  }
  realizarMarcacao(marcacao: Marcacao): void {

    marcacao.pacienteID = this.pacienteServico.pacienteLogado.id;

    this.servicoHospital.RealizarMarcacao(marcacao)
      .subscribe(
        data => {

          this.router.navigate(['/app-marcacaopaciente'], { queryParams: { inclusao: true } });


        },
        err => {

          console.error(err.error);
        }
      );


  }

}
