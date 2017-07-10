angular.module("WebBiblios").controller('BibliotecaCtrl', ['$scope', 'BibliotecaService', function ($scope, BibliotecaService) {


    $scope.salvarLivro = function () {
        BibliotecaService.salvarLivro($scope.livro).then(function (response) {
            if (response.status === 200) {
                //alert("Livro salvo com sucesso!")
                toastr.success("Livro salvo com sucesso!");
                carregaLivros();
            }
        }).catch(function (response) {
            if (response.status == 406) {
                toastr.error("Dados inválidos, favor rever informações!");                

            } else
                toastr.error("Ocorreram erros ao salvar livro!");                
        });
    }

    $scope.editarLivro = function (livro) {
        $scope.livro = angular.copy(livro);
        $scope.abreCadastroLivros();
    }

    $scope.deletarLivro = function (livro) {
        var confirmar = confirm("Tem certeza que deseja excluir o Livro" + livro.Titulo + "?");
        if (confirmar) {            
            BibliotecaService.deletarLivro(livro).then(function (response) {                
                if (response.status === 200) {
                    if (response.data) {
                        carregaLivros();
                    }
                }
            }).catch(function (response) {
                toastr.error("Ocorreram erros ao buscar livros!");
            });
        }
    }

    function carregaLivros() {
        $scope.limparTela();
        BibliotecaService.getLivros().then(function (response) {
            if (response.status === 200) {
                $scope.livros = response.data;
            }
        }).catch(function (response) {
            toastr.error("Ocorreram erros ao buscar livros!");            
        });
    }

    function recolheCadastroLivros() {
        $('.divLivros').slideUp();
    }

    $scope.abreCadastroLivros = function () {
        if ($('.divLivros').css("display") == 'none')
            $('.divLivros').slideToggle();

        $("#titulo").focus();

    }

    $scope.limparTela = function () {
        if ($scope.livro !== undefined) {
            $scope.livro.Titulo = undefined;
            $scope.livro.Autor = undefined;
            $scope.livro.Genero = undefined;
            $scope.livro.Estoque = undefined;
        }
        recolheCadastroLivros();
    }

    function carregaGeneros() {
        $scope.generos = [{ id: 1, nome: "Romance" }, { id: 2, nome: "Ficção Científica" }]
    }

    function init() {
        carregaLivros();
        carregaGeneros();
    }

    init();

}]);