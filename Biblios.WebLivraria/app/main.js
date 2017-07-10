angular.module("WebBiblios", [])
    .constant("apiUrl", (function () {

        var api = "http://localhost:53370/"
        return {
            GETLIVROS: api + "livros/getlivros",
            SALVARLIVRO: api + "livros/salvarlivro",
            DELETARLIVRO: api + "livros/deletarlivro"
        }
    })());    