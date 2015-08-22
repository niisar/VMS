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
angular.module('taskWebApp').directive('bsNavbar', bsNavbar).directive('showtab', showtab)
