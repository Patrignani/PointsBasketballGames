app.service('ScoreServices', function () {

    return {
        getResult: function ($http) {
            return $http.get('...')
                .then(function (response) {
                    return response.data;
                });
        }
    }
});