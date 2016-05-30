(function () {
    'use strict';

    window.app.directive('answer', answer);
    function answer() {
        return {
            scope: {
                question: '='
            },
            templateUrl: '/answer/template/answer.tmpl.cshtml',
            controller: controller,
            controllerAs: 'vm'
        }
    }

    controller.$inject = ['$scope'];
    function controller($scope) {
        var vm = this;
        vm.question = $scope.question;
        vm.answer = {};
        vm.answer["questionId"] = vm.question.id;
        $scope.$parent.vm.answers.push(vm.answer);
    }
})();