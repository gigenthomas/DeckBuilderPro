var module = angular.module("DeckList", []);

module.factory("dataService", function ($http, $filter, $q) {

    var _deck = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }

    var _getDeck = function (DeckId) {

        var deferred = $q.defer();

        $http.get("/api/Decks/" + DeckId)
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

        $http.post("/api/DeckCards", newCards)
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

        $http.delete("/api/DeckCards/" + id)
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

        $http.put("/api/DeckCards", updatedCard)
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
        getDeck: _getDeck,
        isReady: _isReady,
        addCards: _addCards,
        removeCards: _removeCards,
        updateCard: _updateCard,
        updateDeckCount: _updateDeckCount
    };
});


function DeckList($scope, $http, dataService) {
    $scope.isBusy = true;
    $scope.data = dataService;
    $scope.newCards = {};
    $scope.updatedCard = {};
    $scope.deleteCard = {};

    $scope.deck = null;
    $scope.decks = [];

    $http.get("/api/Decks")
        .then(function (result) {
            angular.copy(result.data, $scope.decks);
        },
        function () {
            alert("Handle Error");
        })
        .then(function () {
            //$scope.isBusy = false;
        });

    if (dataService.isReady() == false) {
        dataService.getDeck(DeckId)
            .then(function () {
                //success
                $scope.isBusy = true;
            },
        function () {
            //error
            alert("Could not load Deck");
        })
    .then(function () {
        $scope.isBusy = false;
    });
    }

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

        dataService.addCards($scope.newCards)
            .then(
                function (result) {
                    //success
                    $('#addCardsModal').modal('hide');
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

        //$scope.deleteCard = null;
        //dataService.removeCards(card.Id).then(
        //    function () {
                //success
        //        $scope.data.deck.CardsInDeck.splice($scope.data.deck.CardsInDeck.indexOf(card), 1);
        //    },
        //    function () {
                //error
        //        alert("error");
        //    }
        // );
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

    $scope.updateDeckCount = function(deckId)
    {
        dataService.updateDeckCount(deckId)
    }
}

