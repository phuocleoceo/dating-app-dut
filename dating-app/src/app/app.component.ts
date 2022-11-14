import { AccountService } from './_services/account.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  name = 'phuocleoceo';

  constructor(
    public accountService: AccountService,
  ) { }

  ngOnInit(): void {
    this.accountService.reLogin();
  }
}
