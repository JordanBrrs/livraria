using Biblios.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblios.Data.EntidadesConfig
{
    public class LivroConfiguracao: EntityTypeConfiguration<Livro>
    {
        public LivroConfiguracao()
        {
            HasKey(l => l.Id);

            Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Autor)
                .HasMaxLength(150);
            
        }    
    }
}
