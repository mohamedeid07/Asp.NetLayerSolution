(function () {
    var myApp = angular.module("myApp", ["ngTable"]);

    myApp.controller("MainCtrl", function ($scope, $http, NgTableParams) {
        $scope.page = 1;
        $scope.count = 10;
        $scope.data = [];
        $scope.getTable = function () {
            $http({
                method: "GET",
                url: "/Home/GetProducts"
            }).then(
                function successCallback(response) {
                    $scope.data = response.data;
                    $scope.myTable = new NgTableParams({
                        page: $scope.page,
                        count: $scope.count,
                        filter: {
                            term : ''
                        }
                    }, { dataset: $scope.data });
                },
                function errorCallback(response) {
                    console.log(response);
                }
            );
        };
        $scope.getTable();
        $scope.createProduct = function () {
            $scope.page = $scope.myTable.page();
            $scope.count = $scope.myTable.count();
            if ($scope.myTable.data.length == $scope.myTable.count()) {
                $scope.page += 1;
            }
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
                        //$scope.myTable.reload();
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
            $scope.page = $scope.myTable.page();
            $scope.count = $scope.myTable.count();
            if ($scope.myTable.data.length == 1 && $scope.page != 1) {
                $scope.page -= 1;
            }
            $http({
                method: "GET",
                url: "/Home/Delete?id=" + id
            }).then(
                function successCallback(response) {
                    $scope.getTable();
                    $scope.myTable.reload();
                    
                    //$scope.search();
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
            $scope.page = $scope.myTable.page();
           
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
                        //$scope.search();
                    },
                    function errorCallback(response) {
                        console.log(response);
                    }
                );
                
            }
        };

        $scope.search = function () {
            
            var term = $scope.searchfield;
            $scope.myTable.filter({ $: term });
        }
        
        $scope.makePDF = function () {
            html2canvas(document.getElementById("myTable"), {
                onrendered: function(canvas){
                    var data = canvas.toDataURL();
                    var docDefinition = {
                        content: [{
                            image: data,
                            width: 500
                        }]
                    }
                    pdfMake.createPdf(docDefinition).download('test.pdf');
                }
            })
        }
        
    });
})();
