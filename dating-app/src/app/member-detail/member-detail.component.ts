import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from '../_models/member';
import { MemberService } from '../_services/member.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  @Input() member: Member | null = null;
  constructor(
    private route: ActivatedRoute,
    private memberService: MemberService,
  ) { }

  ngOnInit(): void {
    if (!this.member) {
      const username = this.route.snapshot.paramMap.get('id');
      if (username) {
        this.memberService.getMemberByUsername(username).subscribe(
          response => {
            this.member = response;
          },
          error => {
            console.log(error);
          }
        );
      }
    }
  }
}
