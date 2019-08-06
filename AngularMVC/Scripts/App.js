(function () {
    var myApp = angular.module("myApp", ["ngTable"]);

    myApp.controller("MainCtrl", function ($scope, $http, NgTableParams) {
        var data = [];
        $scope.getTable = function () {
            $http({
                method: 'GET',
                url: '/Home/GetProducts'
            }).then(function successCallback(response) {
                data = response.data;
                $scope.myTable = new NgTableParams({}, { dataset: data });
            }, function errorCallback(response) {
                console.log(response);
            });
        }
        $scope.getTable();
        $scope.submitForm = function () {

            // check to make sure the form is completely valid
            if ($scope.name != undefined && $scope.number != undefined) {
                $http({
                    method: 'POST',
                    url: '/Home/Create',
                    data: {
                        Name: $scope.name,
                        NumberOfDays: $scope.number
                    }
                }).then(function successCallback(response) {
                    console.log(response);
                    $scope.getTable();
                    $scope.myTable.reload();
                }, function errorCallback(response) {
                    console.log(response);
                });
            }

        };
    });

})();