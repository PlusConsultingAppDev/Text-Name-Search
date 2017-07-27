
app.controller("EmpCtrl", function ($scope, $filter, EmpService) {
    //Get Data from the service
    $scope.empList = EmpService.getEmployees().then(function (data) {
        $scope.empList = data;
    }, function (error) {
        console.log('Error Occurred')
    });;

    //Set the name and number of occurences
    $scope.getEmp = function (empList, input) {
        $scope.empData = $filter('findEmployee')(empList, input);

        if ($scope.empData.length != 0) {
            $scope.name = $scope.empData[0].name;
            $scope.empNo = $scope.empData.length;
        } else {
            $scope.name = '';
            $scope.empNo = 0;
        }
    };


});

app.filter('findEmployee', function () {

    return function (list, input) {
        var output = [];

        if (input) {
            angular.forEach(list, function (emp) {
                var params = input.split(" ");

                var empNameParams = emp.name.split(" ");
                var found = 0;

                //Check the filter conditions for first,Middle and LastNames
                if (emp.name.toLowerCase().indexOf(params[0].toLowerCase()) != -1) {
                    found = 1;

                    if (found && params[1] != undefined) {
                        if ((params[2] == undefined && empNameParams[2].toLowerCase() == params[1].toLowerCase())
                            || (empNameParams[1].charAt(0).toLowerCase() == params[1].charAt(0).toLowerCase() || empNameParams[1].toLowerCase() == params[1].toLowerCase())) {
                            found = 1;
                        } else {
                            found = 0;
                        };
                    }

                    if (found && params[2] != undefined) {
                        if (emp.name.toLowerCase().indexOf(params[2].toLowerCase())) {
                            found = 1;
                        } else {
                            found = 0;
                        };
                    }

                }

                if (found)
                    output.push(emp);

            });
        } else {
            output = list;
        }

        return output;

    };
});