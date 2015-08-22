app.factory('myResource', function ($resource, $http) {
    var resource = $resource('http://localhost:1234/api/:pg/:obj', {
        pg: '@pg',
        obj: '@obj'
    },
        {
            'put': {
                method: 'PUT'
            },
            'get': { method: 'GET' },
            'save': { method: 'POST', headers: { 'Content-Type': 'application/json' } },
            'post': { method: 'POST', headers: { 'Content-Type': 'application/json' } },
            'query': { method: 'GET', isArray: true },
            'remove': { method: 'DELETE' },
            'delete': { method: 'DELETE' }
        }
        );
    return resource;
});