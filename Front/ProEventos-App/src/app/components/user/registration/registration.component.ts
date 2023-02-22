import { ValidatorField } from './../../../Helpers/ValidatorField';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

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
        primeiroNome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        ultimoNome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        email: ['', [Validators.required, Validators.email]],
        userName: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        senha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50)]],
        confirmeSenha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50)]],
        termoUso: ['', Validators.required],
      },
      formOptions
    );
  }

}
