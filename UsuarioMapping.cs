using System;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(p => p.Codigo);

        builder.Property(p => p.Nome);
            .IsRequired();

        builder.Property(p => p.Email);
            .IsRequired();

        builder.Property(p => p.Senha)
            .IsRequired();

       
    }
}
