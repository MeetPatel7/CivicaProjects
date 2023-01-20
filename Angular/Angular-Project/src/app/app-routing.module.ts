import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DocsManagementComponent } from './docs-management/docs-management.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { GroupChatComponent } from './group-chat/group-chat.component';
import { LoginSuccessfulComponent } from './login-successful/login-successful.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { RegisterSuccessfulComponent } from './register-successful/register-successful.component';
import { RegisterComponent } from './register/register.component';
import { UsersManagementComponent } from './users-management/users-management.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  {
    path: 'welcome', component: WelcomeComponent
  },
  {
    path: '', redirectTo: 'welcome', pathMatch: 'full'
  },
  {
    path: 'groupchat', component: GroupChatComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'register', component: RegisterComponent
  },
  {
    path: 'users-management', component: UsersManagementComponent
  },
  {
    path: 'docs-management', component: DocsManagementComponent
  },
  {
    path: 'login-successful', component: LoginSuccessfulComponent
  },
  // {
  //   path: 'login-successful/:id', component: LoginSuccessfulComponent
  // },
  {
    path: 'register-successful', component: RegisterSuccessfulComponent
  },
  {
    path: 'edit-user', component: EditUserComponent
  },
  {
    path: 'logout', component: LogoutComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
