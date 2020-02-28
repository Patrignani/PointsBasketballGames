app.controller('resultPointsController', ['$scope', 'scoreServices', 'toastr', function ($scope, scoreServices, toastr) {
    var formatDate = function (date) {
        console.log("Aqui =>>")
        var day = date.getDate().toString();
        var month = (date.getMonth() + 1).toString();

        day = day.length == 1 ? "0" + day : day;
        month = month.length == 1 ? "0" + month : month;

        return day + '/' + month + '/ ' + date.getFullYear();
    }


    scoreServices.getResult().then(function (data) {
       
        var value = data.data;
        if (value.success) {
            if (value.data.firstDate) {
                $scope.FirstDate = formatDate(new Date(value.data.firstDate));
            }
            else {
                $scope.FirstDate = "__/__/____";
            }

            if (value.data.endDate) {
                $scope.EndDate = formatDate(new Date(value.data.endDate));
            }
            else {
                $scope.EndDate = "__/__/____";
            }
           
            $scope.GamesPlayed = value.data.gamesPlayed;
            $scope.TotalPointsScoredSeason = value.data.totalPointsScoredSeason;
            $scope.AveragePointsPerGame = value.data.averagePointsPerGame;
            $scope.HighestScoreGame = value.data.highestScoreGame;
            $scope.LowestScoreGame = value.data.lowestScoreGame;
            $scope.TotalRecords = value.data.totalRecords;
        }
        else {
            toastr.error(value.messages.join(" "), 'Erro');
        }

    });
}]);