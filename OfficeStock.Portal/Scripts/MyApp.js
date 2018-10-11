var app = angular.module('myApp', ['angularTreeview']);
app.controller('myController', ['$scope','$htpp',function($scope,$http){
    http.get('/Home/Location').then(function(response)){
    $scope.List = response.data.treeList;
    })
}])
