import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';


@Component({
  selector: 'app-pepe',
  templateUrl: './pepe.component.html',
  styleUrls: ['./pepe.component.css']
})
export class PepeComponent implements OnInit {
  public loginInvalid: boolean;
  private returnUrl: string;
  public userName: string;
  public password: string;
  
  constructor(
  
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {
  }

  async ngOnInit() {
    //this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/game';

    
    // if (await this.authService.isAuth()) {
    //   await this.router.navigate([this.returnUrl]);
    // }
  }

  async authenticate() {

    // this.authService.retriveStock2$().subscribe(res=>{
    //     alert('todo ok');
    // });
    // return;
    this.loginInvalid = false;

    
      try {

        this.authService.oauthToken$(this.userName, this.password).subscribe(res=>{
               alert('todo ok');
           });
      } catch (err) {
        this.loginInvalid = true;
      }
   
  }

}
