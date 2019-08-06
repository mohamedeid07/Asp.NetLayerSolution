(function () {
    var myApp = angular.module("myApp", ["ngTable"]);

    myApp.controller("MainCtrl", function ($scope, $http, NgTableParams) {
        var data = [];
        $scope.getTable = function () {
            $http({
                method: "GET",
                url: "/Home/GetProducts"
            }).then(
                function successCallback(response) {
                    data = response.data;
                    $scope.myTable = new NgTableParams({}, { dataset: data });
                },
                function errorCallback(response) {
                    console.log(response);
                }
            );
        };
        $scope.getTable();
        $scope.createProduct = function () {
            
            // check to make sure the form is completely valid
            if ($scope.createForm.name.$valid && $scope.createForm.number.$valid && $scope.createForm.number.$modelValue > 0) {
                
                $http({
                    method: "POST",
                    url: "/Home/Create",
                    data: {
                        Name: $scope.name,
                        NumberOfDays: $scope.number
                    }
                }).then(
                    function successCallback(response) {
                        $scope.getTable();
                        $scope.myTable.reload();
                        $scope.name = $scope.number = undefined;
                        $scope.createForm.name.$touched = $scope.createForm.number.$touched = false;
                    },
                    function errorCallback(response) {
                        console.log(response);
                    }
                );
            }
        };

        $scope.deleteProduct = function (id) {
            $http({
                method: "GET",
                url: "/Home/Delete?id=" + id
            }).then(
                function successCallback(response) {
                    $scope.getTable();
                    $scope.myTable.reload();
                },
                function errorCallback(response) {
                    console.log(response);
                }
            );
        };

        $scope.editProduct = function (id) {
            $http({
                method: "GET",
                url: "/Home/Edit?id=" + id
            }).then(
                function successCallback(response) {
                    $scope.productID = id;
                    $scope.editName = response.data.Name;
                    $scope.editNumber = response.data.NumberOfDays;
                },
                function errorCallback(response) {
                    console.log(response);
                }
            );
        };

        $scope.submitEdit = function (id) {
            
            console.log($scope.editForm.editNumber);
            console.log($scope.createForm.editNumber);
            // check to make sure the form is completely valid
            if ($scope.editForm.editName.$valid && $scope.editForm.editNumber.$valid && $scope.editForm.editNumber.$modelValue > 0) {
                $http({
                    method: "POST",
                    url: "/Home/Edit",
                    data: {
                        ID: $scope.productID,
                        Name: $scope.editName,
                        NumberOfDays: $scope.editNumber
                    }
                }).then(
                    function successCallback(response) {
                        $scope.getTable();
                        $scope.myTable.reload();
                        $scope.editName = $scope.editNumber = undefined;
                        $scope.editForm.editName.$touched = $scope.editForm.editNumber.$touched = false;
                    },
                    function errorCallback(response) {
                        console.log(response);
                    }
                );
            }
        };

        $scope.check = function () {
            console.log($scope.editFrom.editNumber.$touched);
            return false;
            //return ($scope.editFrom.editName.$invalid || $scope.editFrom.editNumber.$invalid || $scope.editForm.editNumber.$modelValue < 0) && ($scope.editFrom.editNumber.$touched || $scope.editFrom.editName.$touched);
        }
        
    });
})();

//(editFrom.editName.$invalid  || editFrom.editNumber.$invalid || editForm.editNumber.$modelValue < 0) && (editFrom.editNumber.$touched || editFrom.editName.$touched)