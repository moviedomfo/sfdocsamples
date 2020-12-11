import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { authService } from '../service/auth.service';

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
    private authService: authService
  ) {
  }

  async ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/game';

    // this.form = this.fb.group({
    //   username: ['', Validators.email],
    //   password: ['', Validators.required]
    // });

    if (await this.authService.isAuth()) {
      await this.router.navigate([this.returnUrl]);
    }
  }

  async authenticate() {
    this.loginInvalid = false;

    // if (this.form.valid) {
      try {

        await this.authService.oauthToken$(this.userName, this.password);
      } catch (err) {
        this.loginInvalid = true;
      }
    // } else {
    //   this.formSubmitAttempt = true;
    // }
  }

}
