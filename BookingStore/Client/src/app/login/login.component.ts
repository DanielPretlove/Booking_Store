import { Component, Directive, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { iif } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
  
export class LoginComponent implements OnInit {

  username: string = '';
  password: string = '';
  constructor(private router: Router, private http: HttpClient) { 

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
    this.http.get('https://localhost:5000/Accounts').subscribe(Response => {
      if (Response) {
        console.log("HELLO")
      }
      console.log(Response);
    });

  }

}
