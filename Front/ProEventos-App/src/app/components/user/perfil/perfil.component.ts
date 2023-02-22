import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/Helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.validation();
  }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group(
      {
        titulo: ['', Validators.required],
        primeiroNome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        ultimoNome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        email: ['', [Validators.required, Validators.email]],
        telefone: ['', Validators.required],
        descricao: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        funcao: ['', Validators.required],
        senha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50)]],
        confirmeSenha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50)]],
      },
      formOptions
    );
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.form.reset();
  }

}
