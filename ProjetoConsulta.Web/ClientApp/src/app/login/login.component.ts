import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Paciente } from '../../model/paciente';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']


})
export class LoginComponent implements OnInit {

  public email = "luizgonzaga15@gmail.com";
  public senha = "12345";
  public enderecoImagem = "https://about-which.s3.amazonaws.com/about-us/media/images/955x637_ct/338_best_buy_458303_00136cc4507103353e2910674352bef4.jpg";
  public titulo = "Imagem padrão do site";
  public enderecoImagemBaixada = "../../../assets/buylogo.jpg";
  public usuario;
  public usuarioAutenticado = false;
  public usuarios;
  public returnUrl;
  public mensagemErro;
  public ativarSpinner = false;

  constructor(private router: Router, private activatedRouter: ActivatedRoute) { }


  ngOnInit(): void {
    this.usuario = new Paciente();
    this.usuarios = ["", "", "", ""];

  }
  entrar(): void {
    this.ativarSpinner = true;
    //this.usuarioServico.verificarUsuario(this.usuario)
    //  .subscribe(
    //    data => {
    //      this.ativarSpinner = false;
    //      this.usuarioServico.usuario = data;
    //      this.usuario = data;
    //      console.log("Realizou login:" + JSON.stringify(data));

    //      if (this.returnUrl != null) {
    //        console.log("returnUrl:" + this.getReturnUrl());
    //        this.router.navigate([this.getReturnUrl()]);
    //      }
    //      else {
    //        this.router.navigate(["/pesquisar-produto"]);
    //      }
    //    },
    //    err => {
    //      this.ativarSpinner = false;
    //      this.mensagemErro = err.error;
    //      console.error(err.error);
    //    }
    //  );

    //if (this.usuario.email == "saulobatistapereira@gmail.com" &&
    //  this.usuario.senha == "12345") {
    //  this.usuarioAutenticado = true;
    //  sessionStorage.setItem("usuario-autenticado", "1");
    //  this.router.navigate([this.returnUrl]);

    //} else {
    //  this.usuarioAutenticado = false;
    //}
    //alert("Email:" + this.usuario.email + " Senha:" + this.usuario.senha);
    this.router.navigate(['/questions']);
  }

  public getReturnUrl() {
    return this.activatedRouter.snapshot.queryParams['returnUrl'];
  }

  on_keypress() {


  }

}
