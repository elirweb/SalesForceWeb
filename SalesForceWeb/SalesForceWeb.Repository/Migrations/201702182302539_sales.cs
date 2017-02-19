namespace SalesForceWeb.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        IDDocumento = c.Int(nullable: false, identity: true),
                        RG = c.String(maxLength: 20, unicode: false),
                        CPF = c.String(maxLength: 8000, unicode: false),
                        IDUsuario = c.Int(nullable: false),
                        DtInclusao = c.DateTime(nullable: false, storeType: "date"),
                        DtAlteracao = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.IDDocumento)
                .ForeignKey("dbo.Usuario", t => t.IDUsuario)
                .Index(t => t.IDUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IDUsuario = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        SobreNome = c.String(maxLength: 50, unicode: false),
                        Sexo = c.String(maxLength: 10, unicode: false),
                        Idade = c.String(maxLength: 4, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Login = c.String(),
                        Senha = c.String(maxLength: 300, unicode: false),
                        Hora = c.String(maxLength: 5, unicode: false),
                        Token = c.String(maxLength: 8000, unicode: false),
                        DtInclusao = c.DateTime(nullable: false, storeType: "date"),
                        DtAlteracao = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.IDUsuario);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        IDEndereco = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(maxLength: 200, unicode: false),
                        Numero = c.String(maxLength: 10, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Uf = c.Int(nullable: false),
                        IDUsuario = c.Int(nullable: false),
                        DtInclusao = c.DateTime(nullable: false, storeType: "date"),
                        DtAlteracao = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.IDEndereco)
                .ForeignKey("dbo.Usuario", t => t.IDUsuario)
                .Index(t => t.IDUsuario);
            
            CreateTable(
                "dbo.Itens",
                c => new
                    {
                        IDItens = c.Int(nullable: false, identity: true),
                        CodigoVeiculo = c.Int(nullable: false),
                        CodigoVenda = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DtInclusao = c.DateTime(nullable: false),
                        DtAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDItens)
                .ForeignKey("dbo.Veiculo", t => t.CodigoVeiculo)
                .ForeignKey("dbo.Venda", t => t.CodigoVenda)
                .Index(t => t.CodigoVeiculo)
                .Index(t => t.CodigoVenda);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        IDVeiculo = c.Int(nullable: false, identity: true),
                        CodigoModelo = c.Int(nullable: false),
                        Ano = c.String(maxLength: 10, unicode: false),
                        Cor = c.String(maxLength: 50, unicode: false),
                        CodigoTipo = c.Int(nullable: false),
                        Renavam = c.String(maxLength: 90, unicode: false),
                        Placa = c.String(maxLength: 10, unicode: false),
                        DtInclusao = c.DateTime(nullable: false, storeType: "date"),
                        DtAlteracao = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.IDVeiculo)
                .ForeignKey("dbo.Modelo", t => t.CodigoModelo)
                .ForeignKey("dbo.Tipo", t => t.CodigoTipo)
                .Index(t => t.CodigoModelo)
                .Index(t => t.CodigoTipo);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        IDModelo = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        IDMarca = c.Int(nullable: false),
                        DtInclusao = c.DateTime(nullable: false),
                        DtAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDModelo)
                .ForeignKey("dbo.Marca", t => t.IDMarca)
                .Index(t => t.IDMarca);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        IDMarca = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        DtInclusao = c.DateTime(nullable: false),
                        DtAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDMarca);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        IDTipo = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 100, unicode: false),
                        DtInclusao = c.DateTime(nullable: false),
                        DtAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDTipo);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        IDVenda = c.Int(nullable: false, identity: true),
                        TokenVenda = c.String(maxLength: 8000, unicode: false),
                        IDUsuario = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DtInclusao = c.DateTime(nullable: false),
                        DtAlteracao = c.DateTime(),
                    })
                .PrimaryKey(t => t.IDVenda)
                .ForeignKey("dbo.Usuario", t => t.IDUsuario)
                .Index(t => t.IDUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Itens", "CodigoVenda", "dbo.Venda");
            DropForeignKey("dbo.Venda", "IDUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Itens", "CodigoVeiculo", "dbo.Veiculo");
            DropForeignKey("dbo.Veiculo", "CodigoTipo", "dbo.Tipo");
            DropForeignKey("dbo.Veiculo", "CodigoModelo", "dbo.Modelo");
            DropForeignKey("dbo.Modelo", "IDMarca", "dbo.Marca");
            DropForeignKey("dbo.Endereco", "IDUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Documento", "IDUsuario", "dbo.Usuario");
            DropIndex("dbo.Itens", new[] { "CodigoVenda" });
            DropIndex("dbo.Venda", new[] { "IDUsuario" });
            DropIndex("dbo.Itens", new[] { "CodigoVeiculo" });
            DropIndex("dbo.Veiculo", new[] { "CodigoTipo" });
            DropIndex("dbo.Veiculo", new[] { "CodigoModelo" });
            DropIndex("dbo.Modelo", new[] { "IDMarca" });
            DropIndex("dbo.Endereco", new[] { "IDUsuario" });
            DropIndex("dbo.Documento", new[] { "IDUsuario" });
            DropTable("dbo.Venda");
            DropTable("dbo.Tipo");
            DropTable("dbo.Marca");
            DropTable("dbo.Modelo");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Itens");
            DropTable("dbo.Endereco");
            DropTable("dbo.Usuario");
            DropTable("dbo.Documento");
        }
    }
}
