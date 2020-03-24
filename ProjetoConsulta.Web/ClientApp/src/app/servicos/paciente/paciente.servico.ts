import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs'
import { Paciente } from '../../../model/Paciente';

@Injectable({
  providedIn: 'root'
})
export class PacienteServico implements OnInit {
  ngOnInit(): void {

  }

  private baseURL: string;
  private _paciente: Paciente;
  public pacienteLogado: Paciente;

  get Paciente(): Paciente {
    let paciente_json = sessionStorage.getItem("paciente-autenticado");
    if (paciente_json != null) {
      this._paciente = JSON.parse(paciente_json);
      return this._paciente;
    }
  }

  set paciente(paciente: Paciente) {
    sessionStorage.setItem("paciente-autenticado", JSON.stringify(paciente));

    this._paciente = paciente;
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  public verificarPaciente(paciente: Paciente): Observable<Paciente> {

    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<Paciente>(this.baseURL + "api/paciente/verificarPaciente", JSON.stringify(paciente), { headers });
  }

  public buscarPaciente(id: string): Observable<Paciente> {

    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.get<Paciente>(this.baseURL + "api/paciente/BuscarPaciente" + id, { headers });
  }



  public pacienteAutenticado(): boolean {

    return this._paciente != null && (this._paciente.email != "" && this._paciente.password != "");
  }

  public paciente_Administrador(): boolean {
    return this.pacienteAutenticado() && this._paciente.ehAdministrador;
  }

  public limparSessao(): void {
    sessionStorage.setItem("paciente-autenticado", "");
    this._paciente = null;
  }

  public cadastrarPaciente(paciente: Paciente): Observable<Paciente> {
    const headers = new HttpHeaders().set('content-type', 'application/json');

    var body = {
      email: paciente.email,
      senha: paciente.password,
      nome: paciente.nome,
      sobreNome: paciente.sobreNome
    }
    return this.http.post<Paciente>(this.baseURL + "api/paciente/cadastrarPaciente", body, { headers });
  }
}
