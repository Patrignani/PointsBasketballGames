app.service('scoreServices', ['$http', 'apiBase', function ($http, apiBase) {

    this.getResult = function () {
        return $http.get(apiBase.api + "api/v1/Scores")
    };

    this.postScore = function (score) {
        return $http.post(apiBase.api + "api/v1/Scores", score)
    }

}]);