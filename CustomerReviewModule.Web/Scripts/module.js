// Call this to register your module to main application
var moduleName = "customerReviewModule";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $stateProvider
                .state('workspace.customerReviewModuleState', {
                    url: '/customerReviewModule',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        '$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'customerReviewModule.helloWorldController',
                                template: 'Modules/$(customerReviewModule)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['platformWebApp.mainMenuService', 'platformWebApp.widgetService', '$state',
        function (mainMenuService, widgetService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/customerReviewModule',
                icon: 'fa fa-cube',
                title: 'CustomerReviewModule',
                priority: 100,
                action: function () { $state.go('workspace.customerReviewModuleState'); },
                permission: 'customerReviewModule:access'
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
