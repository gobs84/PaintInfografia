import { Injectable,} from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private _router:Router) {}
  log_status:boolean = true
  canActivate(): boolean {
    if (this.log_status) {
      return true
    }
    else {
      this._router.navigate(['/log-in'])
      return false
    }
  }

}
