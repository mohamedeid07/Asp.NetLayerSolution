(function () {
    var myApp = angular.module("myApp", ["ngTable"]);

    myApp.controller("MainCtrl", function ($scope, $http, NgTableParams) {
        var data = [];
        $http({
            method: 'GET',
            url: '/Home/GetProducts'
        }).then(function successCallback(response) {
            data = response.data;
            $scope.myTable = new NgTableParams({}, { dataset: data });
        }, function errorCallback(response) {
            console.log(response);
        });
    });

})();