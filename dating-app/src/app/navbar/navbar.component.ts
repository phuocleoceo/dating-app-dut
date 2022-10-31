import { AccountService } from '../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { AuthUser } from '../_models/app-user';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  // authUser: AuthUser = new AuthUser();
  authUser: AuthUser = { username: 'phuocleoceo', password: 'phuocars10' };

  constructor(
    public accountService: AccountService,
  ) { }

  ngOnInit(): void {

  }

  login(): void {
    this.accountService.login(this.authUser)
      .subscribe(response => {
        console.log(response);
      });
  }

  logout(): void {
    this.accountService.logout();
  }
}