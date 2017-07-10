angular.module("WebBiblios").service("BibliotecaService", function ($http, apiUrl) {
    return {
        getLivros: function () {            
            return $http.get(apiUrl.GETLIVROS);
        },

        salvarLivro: function (livro) {            
            return $http.post(apiUrl.SALVARLIVRO, livro)
        },
        deletarLivro: function (livro) {
            return $http.post(apiUrl.DELETARLIVRO, livro);
        }
    }
});