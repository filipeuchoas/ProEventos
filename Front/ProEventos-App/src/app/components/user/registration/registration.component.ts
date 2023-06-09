import { ValidatorField } from './../../../Helpers/ValidatorField';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { AccountService } from '@app/services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '@app/models/identity/User';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  user = {} as User;
  form!: FormGroup;

  get f(): any { return this.form.controls; }

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private toaster: ToastrService
  ) { }

  ngOnInit() {
    this.validation();
  }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'confirmePassword')
    };

    this.form = this.fb.group({
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['',
        [Validators.required, Validators.email]
      ],
      userName: ['', Validators.required],
      password: ['',
        [Validators.required, Validators.minLength(4)]
      ],
      confirmePassword: ['', Validators.required]
    }, formOptions);
    console.log('1', this.form);
    console.log('2', formOptions);

  }

  register(): void {
    this.user = { ...this.form.value };
    this.accountService.register(this.user).subscribe(
      () => this.router.navigateByUrl('/dashboard'),
      (error: any ) => this.toaster.error(error.error)
    );
  }

}
