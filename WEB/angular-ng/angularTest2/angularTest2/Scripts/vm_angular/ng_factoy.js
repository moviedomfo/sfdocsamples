var myApp;
(function () {
    myApp = angular.module("myApp", []);



})();
myApp.controller("appCtrl", function (descargasFactory) {
    var vm = this;
    
    vm.nombre = descargasFactory.nombre;
    vm.descargas = descargasFactory.getDescargas();
    vm.funciones = {
        guardarNombre: function(){
            descargasFactory.nombre = vm.nombre;
        },
        agregarDescarga: function(){
            descargasFactory.nuevaDescarga(vm.nombreNuevaDescarga);
            vm.mensaje = "Descarga agregada";
        },
        borrarMensaje: function(){
            vm.mensaje = "";
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

