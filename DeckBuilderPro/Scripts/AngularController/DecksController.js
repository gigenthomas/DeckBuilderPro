var module = angular.module("DecksIndex", ['ngRoute']);

module.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "DecksController",
        templateUrl: "/Content/AngularTemplates/ngDecksIndex.html",
    });

    $routeProvider.when("/NewDeck", {
        controller: "NewDeckController",
        templateUrl: "/Content/AngularTemplates/ngNewDeck.html"
    });

    $routeProvider.when("/ListDeck", {
        controller: "ListDeckController",
        templateUrl: "/Content/AngularTemplates/ngListDeck.html"
    });


    $routeProvider.otherwise("/");
}]);

function DecksController($scope, $http) {
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/Decks")
        .then(function (result) {
            angular.copy(result.data, $scope.data);
        },
        function () {
            alert("Handle Error");
        })
        .then(function () {
            $scope.isBusy = false;
        });

}

function NewDeckController($scope, $http, $window)
{
    $scope.newDeck = {};
    $scope.game = {}; 
    $scope.games = [];



    $http.get("/api/Games")
        .then(function (result) {
            angular.copy(result.data, $scope.games);
        },
        function () {
            alert("Handle Error");
        })
        .then(function () {
            //$scope.isBusy = false;
        });


    $scope.reqGameId = function () {
        if ($scope.game && $scope.game.id && $scope.game.id > 0 ) return true;
        return false;
    }



    $scope.save = function () {
        $scope.newDeck.GameId = $scope.game.Id;
        $http.post("/api/Decks", $scope.newDeck)
            .then(
                function (result) {
                    //success
                    var newDeck = result.data;
                    $window.location = "#/"
                },
                function () {
                    //error
                    alert("Cannot save the new Deck");
                }
            )
        alert($scope.newDeck.Name);
        alert($scope.newDeck.GameId);
    };
}