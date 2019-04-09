import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { StudentListComponent } from './students/student-list/student-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { StudentDetailComponent } from './students/student-detail/student-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { StudentDetailResolver } from './_resolvers/student-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';
import { StudentListResolver } from './_resolvers/student-list.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { StudentEditComponent } from './students/student-edit/student-edit.component';
import { StudentEditResolver } from './_resolvers/student-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ListsResolver } from './_resolvers/lists.resolver';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'members', component: MemberListComponent,
                resolve: {users: MemberListResolver}},
            {path: 'members/:id', component: MemberDetailComponent,
                resolve: {user: MemberDetailResolver}},
            {path: 'member/edit', component: MemberEditComponent,
                resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            {path: 'students', component: StudentListComponent,
                resolve: {students: StudentListResolver}},
            {path: 'students/:id', component: StudentDetailComponent,
                resolve: {student: StudentDetailResolver}},
            {path: 'student/edit', component: StudentEditComponent,
                resolve: {student: StudentEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            {path: 'messages', component: MessagesComponent, resolve: {messages: MessagesResolver}},
            {path: 'lists', component: ListsComponent, resolve: {users: ListsResolver}},
            {path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin', 'Moderator']}},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
