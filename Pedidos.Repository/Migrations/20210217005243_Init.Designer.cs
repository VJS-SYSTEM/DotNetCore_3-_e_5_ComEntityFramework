﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pedidos.Repository;

namespace Pedidos.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210217005243_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pedidos.Domain.CategoriaProduto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.HasKey("id");

                    b.ToTable("tbl_categoria_produto");
                });

            modelBuilder.Entity("Pedidos.Domain.Cidade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("uf");

                    b.HasKey("id");

                    b.ToTable("tbl_cidade");
                });

            modelBuilder.Entity("Pedidos.Domain.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<int>("enderecoid")
                        .HasColumnType("int")
                        .HasColumnName("enderecoid");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("id");

                    b.HasIndex("enderecoid")
                        .IsUnique();

                    b.ToTable("tbl_cliente");
                });

            modelBuilder.Entity("Pedidos.Domain.Combo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<int>("imagemid")
                        .HasColumnType("int")
                        .HasColumnName("imagemid");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)")
                        .HasColumnName("preco");

                    b.HasKey("id");

                    b.HasIndex("imagemid");

                    b.ToTable("tbl_combo");
                });

            modelBuilder.Entity("Pedidos.Domain.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("cep")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("cep");

                    b.Property<int>("cidadeid")
                        .HasColumnType("int")
                        .HasColumnName("cidadeid");

                    b.Property<string>("complemento")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("complemento");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<string>("logradouro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("logradouro");

                    b.Property<string>("numero")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("numero");

                    b.Property<byte>("tipo")
                        .HasColumnType("tinyint")
                        .HasColumnName("tipo");

                    b.HasKey("id");

                    b.HasIndex("cidadeid");

                    b.ToTable("tbl_endereco");
                });

            modelBuilder.Entity("Pedidos.Domain.Imagem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("nome");

                    b.Property<string>("nomearquivo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("nomearquivo");

                    b.Property<bool>("principal")
                        .HasColumnType("bit")
                        .HasColumnName("principal");

                    b.HasKey("id");

                    b.ToTable("tbl_imagem");
                });

            modelBuilder.Entity("Pedidos.Domain.ImagemProduto", b =>
                {
                    b.Property<int>("imagemid")
                        .HasColumnType("int")
                        .HasColumnName("imagemid");

                    b.Property<int>("produtoid")
                        .HasColumnType("int")
                        .HasColumnName("produtoid");

                    b.HasKey("imagemid", "produtoid");

                    b.HasIndex("produtoid");

                    b.ToTable("tbl_imagem_produto");
                });

            modelBuilder.Entity("Pedidos.Domain.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("clienteid")
                        .HasColumnType("int")
                        .HasColumnName("clienteid");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<TimeSpan>("entrega")
                        .HasColumnType("time")
                        .HasColumnName("entrega");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("numero");

                    b.Property<decimal>("valortotal")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)")
                        .HasColumnName("valortotal");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.ToTable("tbl_pedido");
                });

            modelBuilder.Entity("Pedidos.Domain.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<int>("categoriaid")
                        .HasColumnType("int")
                        .HasColumnName("categoriaid");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("codigo");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descricao");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)")
                        .HasColumnName("preco");

                    b.HasKey("id");

                    b.HasIndex("categoriaid");

                    b.ToTable("tbl_produto");
                });

            modelBuilder.Entity("Pedidos.Domain.ProdutoCombo", b =>
                {
                    b.Property<int>("produtoid")
                        .HasColumnType("int")
                        .HasColumnName("produtoid");

                    b.Property<int>("comboid")
                        .HasColumnType("int")
                        .HasColumnName("comboid");

                    b.HasKey("produtoid", "comboid");

                    b.HasIndex("comboid");

                    b.ToTable("tbl_produto_combo");
                });

            modelBuilder.Entity("Pedidos.Domain.ProdutoPedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<int>("pedidoid")
                        .HasColumnType("int")
                        .HasColumnName("pedidoid");

                    b.Property<decimal>("preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)")
                        .HasColumnName("preco");

                    b.Property<int>("produtoid")
                        .HasColumnType("int")
                        .HasColumnName("produtoid");

                    b.Property<int>("quantidade")
                        .HasPrecision(2)
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.HasKey("id");

                    b.HasIndex("pedidoid");

                    b.HasIndex("produtoid");

                    b.ToTable("tbl_produto_pedido");
                });

            modelBuilder.Entity("Pedidos.Domain.PromocaoProduto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ativo");

                    b.Property<DateTime>("criadoem")
                        .HasColumnType("datetime2")
                        .HasColumnName("criadoem");

                    b.Property<int>("imagemid")
                        .HasColumnType("int")
                        .HasColumnName("imagemid");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nome");

                    b.Property<decimal>("preco")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)")
                        .HasColumnName("preco");

                    b.Property<int>("produtoid")
                        .HasColumnType("int")
                        .HasColumnName("produtoid");

                    b.HasKey("id");

                    b.HasIndex("imagemid");

                    b.HasIndex("produtoid");

                    b.ToTable("tbl_promocao_produto");
                });

            modelBuilder.Entity("Pedidos.Domain.Cliente", b =>
                {
                    b.HasOne("Pedidos.Domain.Endereco", "Endereco")
                        .WithOne("Cliente")
                        .HasForeignKey("Pedidos.Domain.Cliente", "enderecoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Pedidos.Domain.Combo", b =>
                {
                    b.HasOne("Pedidos.Domain.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("imagemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");
                });

            modelBuilder.Entity("Pedidos.Domain.Endereco", b =>
                {
                    b.HasOne("Pedidos.Domain.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("cidadeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("Pedidos.Domain.ImagemProduto", b =>
                {
                    b.HasOne("Pedidos.Domain.Imagem", "Imagens")
                        .WithMany()
                        .HasForeignKey("imagemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pedidos.Domain.Produto", "Produtos")
                        .WithMany()
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagens");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Pedidos.Domain.Pedido", b =>
                {
                    b.HasOne("Pedidos.Domain.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Pedidos.Domain.Produto", b =>
                {
                    b.HasOne("Pedidos.Domain.CategoriaProduto", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("categoriaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Pedidos.Domain.ProdutoCombo", b =>
                {
                    b.HasOne("Pedidos.Domain.Combo", "Combos")
                        .WithMany()
                        .HasForeignKey("comboid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pedidos.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combos");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Pedidos.Domain.ProdutoPedido", b =>
                {
                    b.HasOne("Pedidos.Domain.Pedido", "Pedido")
                        .WithMany("Produto")
                        .HasForeignKey("pedidoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pedidos.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Pedidos.Domain.PromocaoProduto", b =>
                {
                    b.HasOne("Pedidos.Domain.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("imagemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pedidos.Domain.Produto", "Produto")
                        .WithMany("PromocaoProdutos")
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Pedidos.Domain.CategoriaProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Pedidos.Domain.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Pedidos.Domain.Endereco", b =>
                {
                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Pedidos.Domain.Pedido", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Pedidos.Domain.Produto", b =>
                {
                    b.Navigation("PromocaoProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
