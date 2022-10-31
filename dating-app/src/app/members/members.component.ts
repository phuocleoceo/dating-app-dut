import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { MemberService } from '../_services/member.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  members: Member[] = [];

  constructor(
    private memberService: MemberService,
  ) { }

  ngOnInit(): void {
    this.getMembersTable();
  }

  getMembersTable() {
    this.memberService.getMembers().subscribe(
      response => {
        this.members = response;
      },
      error => {
        console.log(error);
      }
    );
  }
}
