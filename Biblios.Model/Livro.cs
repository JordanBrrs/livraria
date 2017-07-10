using System.ComponentModel.DataAnnotations;

namespace Biblios.Model
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public int Genero { get; set; }
        public int Estoque { get; set; }
        public int Alugado { get; set; }        
       
    }
}
