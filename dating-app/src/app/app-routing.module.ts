import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MembersComponent } from './members/members.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'members',
    component: MembersComponent,
  },
  {
    path: 'member-detail',
    component: MemberDetailComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
