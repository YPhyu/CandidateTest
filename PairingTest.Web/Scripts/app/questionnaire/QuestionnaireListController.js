(function() {
	'use strict';

	window.app.controller('QuestionnaireController', QuestionnaireController);
	
	QuestionnaireController.$inject = ['questionnaireSvc'];

	function QuestionnaireController(questionnaireSvc) {
	    var vm = this;
	    vm.save = saveAnswers;
	    vm.clear = clearAnswers;
	    vm.questionnaire = [];
	    vm.errorMessage = null;
	    vm.answers = [];
	    getAll();

	    function getAll() {
	        questionnaireSvc.getAll()
	        .then(function (data) {
	            vm.questionnaire = data;
	            });	       
	    }

	    function saveAnswers() {
	        //Save answer vm.answers;
	    }

	    function clearAnswers() {
	        angular.forEach(vm.answers, function (value, key) {
	            if (value.answerText != undefined)
	                value.answerText = "";
	        });
	    }
	}
})();