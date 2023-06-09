import { AccountService } from '@app/services/account.service';
import { Component } from '@angular/core';
import { User } from './models/identity/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    public accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.setCurretUser();
  }

  setCurretUser(): void {
    let user: User | null;

    if (localStorage.getItem('user'))
      user = JSON.parse(localStorage.getItem('user') ?? '{}');
    else
      user = null;

    if (user)
      this.accountService.setCurrentUser(user);
  }
}
