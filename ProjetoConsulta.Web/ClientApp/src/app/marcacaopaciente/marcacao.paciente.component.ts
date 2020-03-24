import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MarcacaoPaciente } from '../../model/marcacao_paciente';
import { PacienteServico } from '../servicos/paciente/paciente.servico';
import { Paciente } from '../../model/paciente';

@Component({
  selector: 'app-marcacaopaciente',
  templateUrl: './marcacao.paciente.component.html',
  styleUrls: ['./marcacao.paciente.component.css']


})
export class MarcacaoPacienteComponent implements OnInit {


  marcacoes: MarcacaoPaciente[];
  paciente: Paciente;
  inclusao: boolean = false;
  constructor(private router: Router, private activatedRouter: ActivatedRoute, private pacienteServico: PacienteServico) { }


  ngOnInit(): void {

    this.activatedRouter.queryParams.subscribe(parametros => {
      if (parametros['inclusao'] == "true") {
        this.inclusao = true;
      }

      this.pacienteServico.buscarPaciente(this.pacienteServico.pacienteLogado.id)
        .subscribe(
          data => {
            this.paciente = data;
            this.marcacoes = this.paciente.marcacoes;
          },
          err => {

            console.error(err.error);
          }
        );

    });

  }
  desmarcarMarcacao(marcacao: MarcacaoPaciente): void {
    this.router.navigate(['/app-hospital'], { queryParams: { id: 1 } });
  }

}
