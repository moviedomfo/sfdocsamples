Documentacio:
Signing JWT with RSA in .NET Core 3.x Made Easy

https://vmsdurano.com/-net-core-3-1-signing-jwt-with-rsa/#google_vignette


Uso de open SSl
https://www.scottbrady91.com/OpenSSL/Creating-RSA-Keys-using-OpenSSL


1) Ejecutar el comando openssl.cmd como administrador
El mismo generara dos claves en dos archivos una publica otra privada
2)Abrir pelsoft.private copiar el body de y notar que por cada fila hay un carry return
  debemos eliminaros y generar una sola linea de modo que esta clave pueda ser copiada en el .json
  NOTA: Tampoco incluya el encabezado y pie de página al almacenar las claves RSA.
3) abrir el archivo .\jwt_RSA\AuthServer\pelsoft.auth\appsettings.Development.json
y en la configuracion  RsaPrivateKey copiar la linea generado en el paso 2

4)  Hay que hacer lo mismo con en archivo pelsoft.public pero el contenido hubircarlo en RsaPublicKey


Nota: Usando el archivo openssl2.cmd se genera el archivo  pelsoft.private.pem y en consola se muiestra la public key
Esta hay q copiarla de la consola y funciona OK