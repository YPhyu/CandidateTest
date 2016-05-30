(function() {
    window.app.factory('questionnaireSvc', questionnaireSvc);

	questionnaireSvc.$inject = ['$http', '$q'];
	function questionnaireSvc($http, $q) {
	    var errorMessage="";

	    var deferred = $q.defer();

	    var svc = {		    
		    getAll: loadQuestionnaire,
            errorMessage: errorMessage
		};

		return svc;

		function loadQuestionnaire() {
           
		    $http.post('/Questionnaire/All')
            .success(function (data) {
                deferred.resolve(data);                
            }).error(deferred.reject);		    

		    return deferred.promise;
		}
	}
})();