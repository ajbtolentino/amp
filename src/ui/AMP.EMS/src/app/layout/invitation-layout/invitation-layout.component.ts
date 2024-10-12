import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-invitation-layout',
  templateUrl: './invitation-layout.component.html',
  styleUrl: './invitation-layout.component.scss',
  imports: [RouterOutlet, RouterModule]

})
export class InvitationLayoutComponent {

}
