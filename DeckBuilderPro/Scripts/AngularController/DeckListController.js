var module = angular.module("DeckList", []);

module.factory("dataService", function ($http, $filter, $q) {

    var _deck = [];
    var _isInit = false;
    var _collections = [];

    var _isReady = function () {
        return _isInit;
    }

    var _getCollections = function () {
        var deferred = $q.defer();
        $http.get("/api/VsSystem/Collections/")
            .then(function (result) {
                angular.copy(result.data, _collections);
                deferred.resolve();
            },
            function () {
                //Error
                deferred.reject();
            });
        return deferred.promise;
    };

    var _getDeck = function (DeckId) {

        var deferred = $q.defer();

        $http.get("/api/VsSystem/Decks/" + DeckId)
            .then(function (result) {
                angular.copy(result.data, _deck);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                //error
                deferred.reject();
            });

        return deferred.promise;
    };

    var _addCards = function (newCards) {
        var deffered = $q.defer();

        $http.post("/api/VsSystemDeckCards/", newCards)
            .then(
                function (result) {
                    //success
                    var deckCard = result.data;
                    var found = false;

                    for (i = 0; i < _deck.CardsInDeck.length; ++i) {
                        var cardInDeck = _deck.CardsInDeck[i];
                        if (cardInDeck.Id === deckCard.Id) {
                            _deck.CardCount -= cardInDeck.Quantity;
                            _deck.CardCount += deckCard.Quantity;

                            cardInDeck.Quantity = deckCard.Quantity;
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        _deck.CardsInDeck.splice(0, 0, deckCard);
                        _deck.CardCount += deckCard.Quantity;

                    }

                    deffered.resolve(deckCard);
                },
                function () {
                    //error
                    deferred.reject();
                }
            )
        return deffered.promise;
    };

    var _removeCards = function (id) {
        var deffered = $q.defer();

        $http.delete("/api/VsSystem/DeckCards/" + id)
            .then(
                function (result) {
                    //success
                    if (result.data == "true") {
                        deffered.resolve();
                    }
                    deffered.reject();

                },
                function () {
                    //error
                    deffered.reject();
                }
            )
        return deffered.promise;
    };

    var _updateCard = function (updatedCard) {
        var deffered = $q.defer();

        $http.put("/api/VsSystem/DeckCards", updatedCard)
            .then(
                function (result) {
                    //success
                    var updated = result.data;
                    if (updated == "true") {
                        for (i = 0; i < _deck.CardsInDeck.length; ++i) {
                            var cardInDeck = _deck.CardsInDeck[i];
                            if (cardInDeck.Id === updatedCard.Id) {
                                cardInDeck.Quantity = updatedCard.Quantity;
                                break;
                            }
                        }
                        deffered.resolve();
                    }

                    deffered.reject();
                },
                function () {
                    //error
                    deferred.reject();
                }
            )
        return deffered.promise;
    };

    var _updateDeckCount = function (deckId) {
        var deffered = $q.defer();

        $http.get("/Decks/UpdateDeckCount/" + deckId)
            .then(
                function (result) {
                    //success
                    var updatedCount = result.data;
                    _deck.CardCount = updatedCount;
                        deffered.resolve();
                },
                function () {
                    //error
                    deferred.reject();
                }
            )
        return deffered.promise;
    };

    return {
        deck: _deck,
        collections: _collections,
        getDeck: _getDeck,
        isReady: _isReady,
        addCards: _addCards,
        removeCards: _removeCards,
        updateCard: _updateCard,
        updateDeckCount: _updateDeckCount,
        getCollections: _getCollections
    };
});


function DeckList($scope, $http, $filter, dataService) {
    $scope.isBusy = true;
    $scope.data = dataService;
    $scope.newCards = {};
    $scope.updatedCard = {};
    $scope.deleteCard = {};
    $scope.collection = null;

    $scope.deck = null;
    $scope.decks = [];


    $scope.reqDeckId = function () {
        if ($scope.deck && $scope.deck.id && $scope.deck.id > 0) return true;
        return false;
    }

    $scope.PlotTwist = function (item) {
        return (item.Card.CardType.Name == 'Plot Twist');
    };

    $scope.Equipment = function (item) {
        return (item.Card.CardType.Name == 'Equipment');
    };

    $scope.Character = function (item) {
        return (item.Card.CardType.Name == 'Character');
    };

    $scope.Location = function (item) {
        return (item.Card.CardType.Name == 'Location');
    };


    $scope.Sum = function (Cards) {
        if (Cards) {
            var total = 0;
            for (var i = 0; i < Cards.length; i++) {
                total = total + Cards[i].Quantity;
            }
            return total;
        }
    };

    $scope.addCards = function () {
        $scope.newCards.DeckId = $scope.data.deck.Id;
        $scope.newCards.CardIdentifier = $('#newCardIdentifier').val();

        if ($scope.newCards.AddToCollection == true)
        {
            $scope.newCards.CollectionId = $scope.collection.Id;
        }

        dataService.addCards($scope.newCards)
            .then(
                function (result) {
                    //success
                    $('#addCardsModal').modal('hide');
                    $scope.updateChart();
                },
                function () {
                    //error
                    alert("Cannot add cards");
                }
            );
    };

    $scope.deleteCards = function(id)
    {
        dataService.removeCards(id).then(
            function () {
                //success
                $scope.data.deck.CardsInDeck.splice($scope.data.deck.CardsInDeck.indexOf($scope.deleteCard), 1);
                $scope.data.deck.CardCount -= $scope.deleteCard.Quantity;
                $scope.deleteCard = null;
            },
            function () {
        error
                alert("error");
                $scope.deleteCard = null;
            }
        );
        $('#deleteCardsModal').modal('hide');
    }

    $scope.resetDeleteCard = function () {
        $scope.deleteCard = null;
    };

    $scope.removeCards = function (card) {

        $scope.deleteCard = card;
        $('#deleteCardsModal').modal('show');
    };

    $scope.updateCard = function (card) {
        $scope.updatedCard = {};
        $scope.updatedCard.CardIdentifier = card.Card.CardIdentifier;
        $scope.updatedCard.Quantity = card.Quantity;
        $scope.updatedCard.OldQuantity = card.Quantity;
        $scope.updatedCard.Id = card.Id;
        //$scope.updatedCard.OldQuantity = card.Quantity;
        $('#updateCardModal').modal('show');
    };

    $scope.updateCards = function (card) {
        $scope.updatedCard.DeckId = $scope.data.deck.Id;

        if ($scope.updatedCard.AddToCollection == true) {
            $scope.updatedCard.CollectionId = $scope.collection.Id;
        }


        dataService.updateCard($scope.updatedCard)
            .then(
                function (result) {
                    //success
                    $('#updateCardModal').modal('hide')
                    $scope.data.deck.CardCount -= $scope.updatedCard.OldQuantity;
                    $scope.data.deck.CardCount += $scope.updatedCard.Quantity;
                    },
                function () {
                    //error
                    alert("Cannot add cards");
                }
            );
    };

    $scope.reqCollectionIdAdd = function () {
        if ($scope.newCards.AddToCollection == undefined || $scope.newCards.AddToCollection == false) return false;
        if ($scope.newCards.AddToCollection == true && $scope.collection && $scope.collection.Id && $scope.collection.Id > 0) return false;
        return true;
    }

    $scope.reqCollectionIdUpdate = function () {
        if ($scope.updatedCard.AddToCollection == undefined || $scope.updatedCard.AddToCollection == false) return false;
        if ($scope.updatedCard.AddToCollection == true && $scope.collection && $scope.collection.Id && $scope.collection.Id > 0) return false;
        return true;
    }

    $scope.updateDeckCount = function(deckId)
    {
        dataService.updateDeckCount(deckId)
    }

    $scope.updateChart = function () {
        chartData = [
            ['Plottwists', $scope.Sum($filter('filter')($scope.data.deck.CardsInDeck, $scope.PlotTwist))],
            ['Charaters', $scope.Sum($filter('filter')($scope.data.deck.CardsInDeck, $scope.Character))],
            ['Equipments', $scope.Sum($filter('filter')($scope.data.deck.CardsInDeck, $scope.Equipment))],
            ['Locations', $scope.Sum($filter('filter')($scope.data.deck.CardsInDeck, $scope.Location))]
        ];
        drawChart();
    };

    if (dataService.isReady() == false) {
        dataService.getDeck(DeckId)
            .then(function () {
                //success
                $scope.isBusy = true;
            },
        function () {
            //error
            alert("Could not load Deck");
        }).then(dataService.getCollections().then(
            function () {  },
            function () {
                alert('Error Loading Coolection');
            }
            )
        ).then(function () {
            $scope.isBusy = false;
            
        }).then(function () { $scope.updateChart(); });
    }



}

