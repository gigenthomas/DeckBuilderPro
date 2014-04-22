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

    $routeProvider.when("/Deck/:id", {
        controller: "SingleDeckController",
        templateUrl: "/Content/AngularTemplates/ngListDeck.html"
    });


    $routeProvider.otherwise("/");
}]);

module.factory("dataService", function ($http, $q) {

    var _decks = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }

    var _getDecks = function () {

        var deferred = $q.defer();

        $http.get("/api/Decks")
            .then(function (result) {
                angular.copy(result.data, _decks);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                //error
                deferred.reject();
            });

        return deferred.promise;
    };

    var _addDeck = function (newDeck) {
        var deffered = $q.defer();

        $http.post("/api/Decks", newDeck)
            .then(
                function (result) {
                    //success
                    var newCreatedDeck = result.data;
                    _decks.splice(0, 0, newCreatedDeck);
                    deffered.resolve(newCreatedDeck);
                },
                function () {
                    //error
                    deferred.reject();
                }
            )
        return deffered.promise;
    };

    return {
        decks: _decks,
        getDecks: _getDecks,
        addDeck: _addDeck,
        isReady: _isReady
    };
});

function DecksController($scope, $http, dataService) {
    $scope.data = dataService;
    $scope.isBusy = false;

    if (dataService.isReady() == false) {
        dataService.getDecks()
            .then(function () {
                //success
                $scope.isBusy = true;
            },
            function () {
                //error
                alert("Could not load Decks")
            })
        .then(function () {
            $scope.isBusy = false;
        });
    }
}

function NewDeckController($scope, $http, $window, dataService) {
    $scope.newDeck = {};
    $scope.game = null;
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
        if ($scope.game && $scope.game.id && $scope.game.id > 0) return true;
        return false;
    }



    $scope.save = function () {
        $scope.newDeck.GameId = $scope.game.Id;

        dataService.addDeck($scope.newDeck)
            .then(
                function (result) {
                    //success
                    $window.location = "#/"
                },
                function () {
                    //error
                    alert("Cannot save the new Deck");
                }
            );
    };
}

function SingleDeckController($scope, $http, $window, $routeParams) {
    $scope.deck = [];

    $http.get("/api/Decks/" + $routeParams.id)
        .then(function (result) {
            angular.copy(result.data, $scope.deck);
        },
        function () {
            alert("Handle Error");
        })
        .then(function () {
            $scope.isBusy = false;
        });
}