@echo off
:: REalizando deploy 

ECHO:
Echo  ********************************************************************
ECHO  ******* creando rsa ******************************************
Echo  ********************************************************************
ECHO:

@SET release=e:\projects\sfdocsamples\aspnet-core\jwt_RSA\AuthServer\pelsoft.auth\openssl\
c:
cd c:\Users\moviedo\Dropbox\Pelsoft-Tools\openssl-1.1\x64\bin\
dir


openssl genrsa -out e:\projects\sfdocsamples\aspnet-core\jwt_RSA\AuthServer\pelsoft.auth\openssl\pelsoft.private 3072

openssl rsa -in e:\projects\sfdocsamples\aspnet-core\jwt_RSA\AuthServer\pelsoft.auth\openssl\pelsoft.private -RSAPublicKey_out



pause