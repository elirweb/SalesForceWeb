using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class DocumentoConfiguration: EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Documento>
    {
        public DocumentoConfiguration()
        {
            ToTable("Documento");

            HasKey(c => c.Id);

            Property(c => c.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDDocumento");

            Property(c => c.CPF.Codigo).
                HasColumnName("CPF").HasColumnType("VARCHAR");
              

            Property(c => c.RG.CodigoRG).HasColumnName("RG").HasColumnType("VARCHAR").HasMaxLength(20);

            Property(c => c.DtAlteracao).HasColumnType("DATE");
            Property(c => c.DtInclusao).HasColumnType("DATE");



            HasRequired(x => x.UsuarioModel)
                               .WithMany()
                               .HasForeignKey(x => x.IDUsuario);


        }
    }
}
