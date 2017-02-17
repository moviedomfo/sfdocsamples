


function ContextInformation() {

var that = {};
    //constructor()
    //{
        this.Culture = null;
        this.ProviderNameWithCultureInfo = null;
        this.HostName = '';
        this.HostIp = null;
        this.HostTime = null;
        this.ServerName = null,
        this.ServerTime = null;
        this.UserName = null;
        this.UserId = '';
        this.AppId = '';
        this.ProviderName = null;
  //  }
 return that;
}



class Setting {

    constructor( )
    {
        this.Culture = null;;

        this.HostName =  '';

    }
 
}

module.exports.Context = ContextInformation;
module.exports.Setting = Setting;