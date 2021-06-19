
angular
    .module('ema', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/departments', {
                templateUrl: 'parts/department/show.html',
                controller: 'DepartmentsController'
            })
            .when('/departments/modify', {
                templateUrl: 'parts/department/modify.html',
                controller: 'DepartmentsModifyController'
            })
            .when('/employees', {
                templateUrl: 'parts/employee/show.html',
                controller: 'EmployeesController'
            })
            .when('/employees/modify', {
                templateUrl: 'parts/employee/modify.html',
                controller: 'EmployeesModifyController'
            })
    })
    .controller(
        'DepartmentsController',
        [
            '$scope',
            '$http', function ($scope, $http) {
                $scope.departments = [];

                $http.get('/api/department/getall').then(function (response) {
                    $scope.departments = response.data;
                });

                $scope.add_form = function () {
                    window.location = "#!/departments/modify?action=1";
                }

                $scope.edit_form = function ($event) {
                    let id = $($event.target).data('id');
                    window.location = "#!/departments/modify?action=2&id=" + id;
                }

                $scope.delete = function ($event) {
                    let id = $($event.target).data('id');
                    let url = '/api/department/delete/' + id;
                    $http({
                        method: 'GET',
                        url: url,
                    }).then(function (success) {
                        if (success.data) {
                            alert("Successfully deleted");
                            window.location = "#!/departments";

                            $http.get('/api/department/getall').then(function (response) {
                                $scope.departments = response.data;
                            });

                        } else {
                            alert("Something happened")
                        }
                    }, function (error) {
                        alert(error.status);
                    });
                }

            }
        ]
    )
    .controller(
        'DepartmentsModifyController',
        [
            '$scope',
            '$http',
            '$location',
            function ($scope, $http, $location) {

                $scope.post_to = function (action, department) {

                    if (action == 'add') {

                        let url = '/api/department/create';

                        if (department && department.Name) {
                            $http({
                                method: 'POST',
                                url: url,
                                data: JSON.stringify(department)
                            })
                                .then(function (success) {
                                    if (success.data) {
                                        alert("Successfully added");
                                        window.location = "#!/departments";
                                    } else {
                                        alert("Something happened")
                                    }
                                }, function (error) {
                                    alert(error.status);
                                });
                        } else {
                            alert("Empty Name field");
                        }
                    }

                    if (action == 'edit') {

                        let url = '/api/department/update';

                        if (department && department.Name) {

                            department.Id = $location.search().id;

                            $http({
                                method: 'POST',
                                url: url,
                                data: JSON.stringify(department)
                            })
                                .then(function (success) {
                                    if (success.data) {
                                        alert("Successfully updated");
                                        window.location = "#!/departments";
                                    } else {
                                        alert("Something happened")
                                    }
                                }, function (error) {
                                    alert(error.status);
                                });
                        } else {
                            alert("Empty Name field");
                        }
                    }

                }

                $scope.$on('$viewContentLoaded', function () {
                    let action = $location.search().action;
                    let id = $location.search().id;
                    if (action == '2') {
                        $scope.action_name = "Edit";
                        $scope.action_name_id = "edit";

                        $scope.departmentId = id;

                        $http.get('/api/department/get/' + id)
                            .then(function (response) {
                                $scope.departmentName = response.data.name;
                            })

                    }
                    else {
                        $scope.action_name = "Add";
                        $scope.action_name_id = "add";
                    }
                });

            }
        ]
    )
    .controller(
        'EmployeesController',
        [
            '$scope',
            '$http',
            function ($scope, $http) {

                $scope.employees = [];
                $http.get('/api/employee/getall').then(function (response) {
                    $scope.employees = response.data;
                })

                $scope.add_form = function () {
                    window.location = "#!/employees/modify?action=1";
                }

                $scope.edit_form = function ($event) {
                    let id = $($event.target).data('id');
                    window.location = "#!/employees/modify?action=2&id=" + id;
                }

                $scope.delete = function ($event) {
                    let id = $($event.target).data('id');
                    let url = '/api/employee/delete/' + id;

                    $http({
                        method: 'GET',
                        url: url,
                    })
                        .then(function (success) {
                            if (success.data) {
                                alert("Successfully deleted");
                                window.location = "#!/employees";
                            } else {
                                alert("Something happened")
                            }
                        }, function (error) {
                            alert(error.status);
                        });
                }
            }
        ]
    );
