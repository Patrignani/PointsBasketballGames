app.controller('throwPointsController', ['$scope', 'scoreServices', 'toastr', function ($scope, scoreServices, toastr) {

    scoreServices.setModel('navBar','throwPoints');


    var valid = function (scoreObject) {
        var message = "";

        if (!scoreObject.GameDate) {
            message = "Data inválida. ";
        }
        else if (new Date(scoreObject.GameDate) > new Date()) {
            message = "A data informada é maior que a data atual. ";
        }

        if (scoreObject.ScoreValue == null || scoreObject.ScoreValue== undefined || scoreObject.ScoreValue < 0) {
            message +="Pontuação não pode ser menor do que zero. "
        }
       
        if (message != "") {
            toastr.error(message, 'Erro');
        }

        return message == "";

    }

    $scope.ScoreValue = 0;

    $scope.save = function () {
        var scoreObject = { ScoreValue: $scope.ScoreValue, GameDate: $scope.GameDate };

        if (valid(scoreObject)) {

            scoreServices.postScore(scoreObject).then(function (value) {
                var data = value.data;
                if (data.success) {
                    toastr.success('Item cadastrado.', 'Sucesso');
                }
                else {

                    toastr.error(data.messages.join(" "), 'Erro');
                }
            });
        }
    }
}]);