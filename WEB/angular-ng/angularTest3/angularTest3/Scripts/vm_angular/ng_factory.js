var myApp;
(function () {
    myApp = angular.module("myApp", []);

    myApp.controller("personController", function (descargasFactory, personFactorySVC, personFactorySVC_POST) {
        var vm = this;
        vm.PersonaTodos = [];
        vm.Persona = [];
        vm.PersonaJson ='' ;
        vm.PersonId = '123213';
       vm.nombre = descargasFactory.nombre;
        vm.descargas = descargasFactory.getDescargas();

        //Hace llamadas a los servicios
        vm.funciones = {
            guardarNombre: function () {
                descargasFactory.nombre = vm.nombre;
            },
            agregarDescarga: function () {
                descargasFactory.nuevaDescarga(vm.nombreNuevaDescarga);
                vm.mensaje = "Descarga agregada";
            },
            borrarMensaje: function () {
                vm.mensaje = "";
            }
        }

     
        //Hace llamadas a los servicios
        vm.svc = {
            todos: function () {
                var promiseresult = personFactorySVC.getAll();
                promiseresult.then(function(data){
                    vm.PersonaTodos = JSON.stringify(data);
                });
                
            },
            porId: function (id) {
              
                var promiseresult = personFactorySVC.getById(id);
                promiseresult.then(function (data) {
                    vm.PersonaJson = JSON.stringify(data);
                    vm.Persona = data;
                });
            }
        }
        vm.MsgCreacionPersona = "Nada creado todavia";

        vm.svc_post = {
            todos: function () {
                var promiseresult = personFactorySVC_POST.retriveAll();
                promiseresult.then(function (data) {
                    vm.PersonaTodos = JSON.stringify(data);
                });

            },
            porId: function (id) {

                var promiseresult = personFactorySVC_POST.retriveById(id);
                promiseresult.then(function (data) {
                    vm.PersonaJson = JSON.stringify(data);
                    vm.Persona = data;
                });
            },

            //Utilizamos la interfaz del servicio personFactorySVC_POST.create  Como pasar parametros 
            //Obtenemos la promise (nos ayuda a ejecutar funciones e forma asincrona)
            create: function (person) {

                var promiseresult = personFactorySVC_POST.create(person);

                promiseresult.then(function (result) {
                    vm.MsgCreacionPersona = JSON.stringify(result.data);
                }).then(function (err) {
                    vm.MsgCreacionPersona = JSON.stringify(err);
                }
                    );
            }
        }
    });


    myApp.factory("descargasFactory", function () {
        var descargasRealizadas = ["Manual de Javascript", "Manual de jQuery", "Manual de AngularJS"];

        var interfaz = {
            nombre: "Manolo",
            getDescargas: function () {
                return descargasRealizadas;
            },
            nuevaDescarga: function (descarga) {
                descargasRealizadas.push(descarga);
            }
        }
        return interfaz;
    })


    myApp.factory("personFactorySVC", function ($http, $q) {

        var interfaz = {
            getById: function (id) {
                return getById(id);
            },
            getAll: function () {
                return getAll();
            }
        }




         function getAll() {
            var defered = $q.defer();
            var promise = defered.promise;

            $http.get(httpHost + '/api/person/GetAll')
                .success(function (data) {
                 
                    defered.resolve(data);
                })
                .error(function (err) {
                    defered.reject(err)
                });

            return promise;
         }

         function getById(id) {
             var defered = $q.defer();
             var promise = defered.promise;

             $http.get(httpHost + '/api/person/getById/'+id)
                 .success(function (data) {
                     defered.resolve(data);
                 })
                 .error(function (err) {
                     defered.reject(err)
                 });

             return promise;
         }


         return interfaz;
    })


    myApp.factory("personFactorySVC_POST", function ($http, $q) {

        var interfaz = {
            retriveById: function (id) {
                return retriveById(id);
            },
            retriveAll: function () {
                return retriveAll();
            },
            create: function (person) {
                return create_1(person);
            }
        }




        function retriveAll() {
            var defered = $q.defer();
            var promise = defered.promise;

            $http.get(httpHost + '/api/person/retriveAll')
                .success(function (data) {

                    defered.resolve(data);
                })
                .error(function (err) {
                    defered.reject(err)
                });

            return promise;
        }

        function retriveById(id) {
            var defered = $q.defer();
            var promise = defered.promise;

            var param = {
                id: id
            };
            
            $http({
                url: httpHost + '/api/person/retriveById/?id=' + id,
                method: 'POST'

            }
            ).success(function (data) {
                 defered.resolve(data);
             })
             .error(function (err) {
                 defered.reject(err)
             });

            

            return promise;
        }

        function create_1(person) {

            var car = {
                ID: 2121,
                Trademark: "Mercedes-Benz",
                Model: "SPORTS"
            };
            var param = {
                Person: person,
                Car: car
            };
            var defered = $q.defer();
            var promise = defered.promise;
            //$http.post(httpHost + '/api/person/create/', param)
            //    .success(function (data) { defered.resolve(data); })
            //    .error(function (err) {
            //        defered.reject(err)
            //    });
            $http.post(httpHost + '/api/person/create/', param).then(
                successCallback,
                errorCallback);



                
            return promise;
        }

        ///No usa promise
        function create_2(person) {
            var car = {
                ID: 2121,
                Trademark: "Mercedes-Benz",
                Model: "SPORTS"
            };
            var param = { Person: person, Car: car };
            var res = $http.post(httpHost + '/api/person/create/', param);
            return res;
        }




        function successCallback(response){
             defered.resolve(response);
        }

        function errorCallback(err){
            defered.reject(err)
        }
        return interfaz;
    })

   
})();
