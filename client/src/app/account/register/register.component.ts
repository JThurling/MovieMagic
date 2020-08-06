import { Component, OnInit } from '@angular/core';
import {NgForm} from "@angular/forms";
import {AccountService} from "../../shared/account.service";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private accountService: AccountService, private toast: ToastrService, private router: Router) { }

  ngOnInit(): void {
  }

  onRegister(register: NgForm) {
    console.log(register.value);
    this.accountService.onRegister(register.value).subscribe(res => {
      this.toast.success("Thank you for registering");
      this.router.navigate(['/']);
      console.log(res);
    }, error => {
      this.toast.error("Error");
      console.log(error);
    })
  }
}
