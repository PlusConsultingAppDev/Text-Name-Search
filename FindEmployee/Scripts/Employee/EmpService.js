app.service("EmpService", function ($http) {

    //Get Employess Data from the API
    this.getEmployees = function () {
        var url = 'api/EmpData';
        return $http.get(url).then(function (response) {
            return response.data;
        });
    }
    
});