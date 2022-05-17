import { Component, Directive, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
  
export class LoginComponent implements OnInit {

  username: string = '';
  password: string = '';
  constructor(private router: Router) { 

  }
  
  public LoginClick = (): void => {
    if (this.username === "Daniel" && this.password === "Gintama22") {
      this.router.navigateByUrl("/register")
      console.log("AAAAAAAAAAAAAAA")
    } else {
      console.log("WHAT THE FUCK");
    }
  }

  ngOnInit(): void {
  }

}
