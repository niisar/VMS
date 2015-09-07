function bsNavbar($window, $location) {
    var defaults = this.defaults = {
        activeClass: 'active',
        routeAttr: 'data-match-route',
        strict: true
    };
    return {
        restrict: 'A',
        link: function postLink(scope, element, attr, controller) {
            var options = angular.copy(defaults);
            angular.forEach(Object.keys(defaults), function (key) {
                if (angular.isDefined(attr[key])) options[key] = attr[key];
            });
            scope.$watch(function () {
                return $location.path();
            }, function (newValue, oldValue) {
                var liElements = element[0].querySelectorAll('li[' + options.routeAttr + '],li > a[' + options.routeAttr + ']');
                angular.forEach(liElements, function (li) {
                    var liElement = angular.element(li);
                    var pattern = liElement.attr(options.routeAttr).replace('/', '\\/');
                    if (options.strict) {
                        pattern = '^' + pattern;
                    }
                    var regexp = new RegExp(pattern, ['i']);
                    if (regexp.test(newValue)) {
                        liElement.addClass(options.activeClass);
                    } else {
                        liElement.removeClass(options.activeClass);
                    }
                });
                var op = $('#sidebar-nav').find('.open:not(.active)');
                op.children('.submenu').slideUp('fast');
                op.removeClass('open');
            });
        }
    };
}

function gd(year, day, month) {
    return new Date(year, month - 1, day).getTime();
}

function showtab() {
    return {
        link: function (scope, element, attrs) {
            element.click(function (e) {
                e.preventDefault();
                $(element).tab('show');
            });
        }
    };
}
var ngLazyShowDirective = ['$animate', function ($animate) {

    return {
        multiElement: true,
        transclude: 'element',
        priority: 600,
        terminal: true,
        restrict: 'A',
        link: function ($scope, $element, $attr, $ctrl, $transclude) {
            var loaded;
            $scope.$watch($attr.ngLazyShow, function ngLazyShowWatchAction(value) {
                if (loaded) {
                    $animate[value ? 'removeClass' : 'addClass']($element, 'ng-hide');
                }
                else if (value) {
                    loaded = true;
                    $transclude(function (clone) {
                        clone[clone.length++] = document.createComment(' end ngLazyShow: ' + $attr.ngLazyShow + ' ');
                        $animate.enter(clone, $element.parent(), $element);
                        $element = clone;
                    });
                }
            });
        }
    };

}];

angular.module('taskWebApp').directive('bsNavbar', bsNavbar).directive('ngLazyShow', ngLazyShowDirective)

angular.module('taskWebApp').directive('bsNavbar', bsNavbar).directive('showtab', showtab)
