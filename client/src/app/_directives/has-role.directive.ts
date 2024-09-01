import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { take } from 'rxjs/operators';
import { User } from '../_models/user';

@Directive({
  selector: '[appHasRole]' // *appHasRole='[]'
})
export class HasRoleDirective implements OnInit {
  @Input() appHasRole: string[];
  user: User;

  constructor(private viewConatinerRef: ViewContainerRef, 
              private templateRef: TemplateRef<any>, 
              private accountService: AccountService ) 
  {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    })        
  }

  ngOnInit(): void {
    if (!this.user?.roles || this.user == null) {
      this.viewConatinerRef.clear();
      return;
    }

    if (this.user?.roles.some(r => this.appHasRole.includes(r))) {
      this.viewConatinerRef.createEmbeddedView(this.templateRef);
    } else {
      this.viewConatinerRef.clear();
    }
  }

}
