import { AccountService } from '../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { AuthUser } from '../_models/app-user';
import { Router } from '@angular/router';

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
    private router: Router,
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

  handleRedirect(link:string) {
    this.router.navigate([link]);
  }
}