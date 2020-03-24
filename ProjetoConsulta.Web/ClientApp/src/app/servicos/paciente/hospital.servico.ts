import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs'
import { Hospital } from '../../../model/hospital';
import { Marcacao } from '../../../model/marcacao';

@Injectable({
  providedIn: 'root'
})
export class HospitalServico implements OnInit {

  private baseURL: string;


  ngOnInit(): void {

  }


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  public ListarHospitais(): Observable<Array<Hospital>> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.get<Array<Hospital>>(this.baseURL + "api/hospital/ListarHospitais");
  }

  public ListarMarcacoesHospital(id: string): Observable<Hospital> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.get<Hospital>(this.baseURL + "/api/Hospital/ListarMarcacoesHospital" + id, { headers: headers });
  }


  public RealizarMarcacao(marcacao: Marcacao): Observable<Marcacao> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<Marcacao>(this.baseURL + "/api/Paciente/RealizarAgendamento", JSON.stringify(marcacao), { headers: headers });
  }


}
