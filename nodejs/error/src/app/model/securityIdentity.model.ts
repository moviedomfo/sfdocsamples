


export class SecurityUser {
    public UserName: string;
    public Password: string;
    public UserId?: string;
    public Email: string;

    public AppName: string;
    public CreatedDate: Date;
    public IsApproved: boolean;
    public IsLockedOut: boolean;
    //public LastActivityDate?: Date;
    public ModifiedDate?: Date;
    public ModifiedByUserId?: number;

    public ConfirmPassword :string;

    public Roles: string[];



  
    public PersonId: string;
    
    public GetRolList(): SecurityRole[] {

        var roles: SecurityRole[];

        return roles;
    }

    
}

export class SecurityRole {

    SecurityRole() {
        this.IsChecked = false;
    }
    public Id: string;
    public Name: string;
    public Description: string;

    public IsChecked: boolean = false;

}
export class SecurityRulesCategory {

    
    public CategoryId: string;
    public Name: string;
    public ParentCategoryId: string;

    public SecurityRulesInCategory: SecurityRulesInCategory[];
}
export class SecurityRulesInCategory{
    public CategoryId: string;
    public RuleId: string;
    public SecurityRule: SecurityRule;
    public SecurityRulesCategory : SecurityRulesCategory;
}

export class SecurityRule{
    public Id: string;
    public Name: string;
    public Description: string;
}
export class UserSession {
    public UserId: string;
    public UserName: string;
    public Email: string;
    public Password: string;
    public ConfirmPassword: string;
  }
  



export class AuthenticateResponse {

    userId: number;
    access_token: string;
    refresh_token: string;

}

export class logingChange{
    public returnUrl:string;
    public isLogued:boolean;
}

export class CurrentLogin {
    public oAuth: AuthenticateResponse;
    public currentUser: SecurityUser;

}