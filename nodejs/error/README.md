
# descripcion

Permite manejo de errores del lado de clientes con un HttpInterseptor
Basicamente maneja el worwflow de llamar al front de Login si no existe el jwt y asi obtenerlo
Tambien genera un jwt a partir del Refresh Token hasta que este expire definitivamente y todo 
reinicie desde la pantalla de login

Cuando el RefreshToken Expira se llama a la pantalla de loging
Quien realiza la mayor parte de la logica es el **HttpInterceptorService**


**Backend** 
    celam-api (.net core)
        e:\projects\pelsoft-git\celam_projects\celam-api_2\
        https://github.com/moviedomfo/celam_api


**Front End scaffolding** 
* angular 10

  app
	common
	  errorDialor
	  errors
		global-error-handler
		error-handler.module

		HttpInterseptor
		LoadingDialogService : front end component, solo muestra un dialog
	 



# startup
	$ ng serve 
	Abrir (http://localhost:4200) para verlo en el navegador.

	$ ng build --prod


# info sobre login docs & videos

 -https://developer.okta.com/blog/2020/01/21/angular-material-login
