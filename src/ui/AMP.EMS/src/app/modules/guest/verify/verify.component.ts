import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GuestService } from '@modules/event';
import { Observable, of, tap } from 'rxjs';

@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrl: './verify.component.scss'
})
export class VerifyComponent implements OnInit {
  result$: Observable<any> = new Observable<any>();

  name: string = '';

  constructor(private guestService: GuestService, private router: Router) {

  }

  ngOnInit(): void {
    this.result$ = of<any>({});
  }

  verify = () => {
    this.result$ = this.guestService.verify(this.name)
      .pipe(
        tap(result => {
          this.router.navigate(['invitation', result.code]);
        })
      )
  }
}
