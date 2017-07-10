using Biblios.Data.Repositorios;
using Biblios.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Biblios.BL
{
    public static class LivroBL
    {
        public static bool SalvarLivro(Livro livro)
        {
            bool retorno = false;

            if(livro.Titulo.Trim() == string.Empty || livro.Autor.Trim() == string.Empty
                || livro.Genero == 0 || livro.Estoque == 0
                )
            {
                throw new Exception("Dados Inválidos!");
            }

            using (var repositorio = new LivroRepositorio())
            {

                if (livro.Id > 0)
                    repositorio.Atualizar(livro);
                else
                    repositorio.Adicionar(livro);
                
                var salvou = repositorio.SalvarTodos();
                if (salvou > 0)                
                    retorno = true;                

            }

            return retorno;
        }

        public static List<Livro> getAllLivros()
        {
            using (var repositorio = new LivroRepositorio())
            {
                return repositorio.GetAll().ToList<Livro>();
            }
        }

        public static bool DeletarLivro(Livro livro)
        {
            if(!(livro.Id > 0))
            {
                throw new Exception("Livro inválido");
            }

            using (var repositorio = new LivroRepositorio())
            {
                repositorio.Excluir(l => l.Id == livro.Id);
                repositorio.SalvarTodos();
            }

            return true;
        }
    }
}
