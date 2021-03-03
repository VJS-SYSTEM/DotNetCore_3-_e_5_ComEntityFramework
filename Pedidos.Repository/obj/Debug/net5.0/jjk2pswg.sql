﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "tbl_CategoriaProduto" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(50) NOT NULL,
    "Ativo" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_CategoriaProduto" PRIMARY KEY ("ID")
);

CREATE TABLE "tbl_Cidade" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(100) NOT NULL,
    "UF" character varying(2) NOT NULL,
    "Ativo" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Cidade" PRIMARY KEY ("ID")
);

CREATE TABLE "tbl_Imagem" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(20) NOT NULL,
    "NomeArquivo" character varying(20) NOT NULL,
    "Principal" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Imagem" PRIMARY KEY ("ID")
);

CREATE TABLE "tbl_Produto" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(50) NOT NULL,
    "Codigo" character varying(50) NOT NULL,
    "Descricao" character varying(100) NOT NULL,
    "Preco" numeric(17,2) NOT NULL,
    "CategoriaID" integer NOT NULL,
    "Ativo" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Produto" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_Produto_tbl_CategoriaProduto_CategoriaID" FOREIGN KEY ("CategoriaID") REFERENCES "tbl_CategoriaProduto" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_Endereco" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "TipoEndereco" smallint NOT NULL,
    "Logradouro" character varying(50) NOT NULL,
    "Bairro" character varying(50) NOT NULL,
    "Numero" character varying(10) NULL,
    "Complemento" character varying(50) NULL,
    "Cep" character varying(8) NULL,
    "CidadeID" integer NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Endereco" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_Endereco_tbl_Cidade_CidadeID" FOREIGN KEY ("CidadeID") REFERENCES "tbl_Cidade" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_Combo" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(50) NOT NULL,
    "Preco" numeric(17,2) NOT NULL,
    "ImagemID" integer NOT NULL,
    "Ativo" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Combo" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_Combo_tbl_Imagem_ImagemID" FOREIGN KEY ("ImagemID") REFERENCES "tbl_Imagem" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_ImagemProduto" (
    "ImagemID" integer NOT NULL,
    "ProdutoID" integer NOT NULL,
    CONSTRAINT "PK_tbl_ImagemProduto" PRIMARY KEY ("ImagemID", "ProdutoID"),
    CONSTRAINT "FK_tbl_ImagemProduto_tbl_Imagem_ImagemID" FOREIGN KEY ("ImagemID") REFERENCES "tbl_Imagem" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_tbl_ImagemProduto_tbl_Produto_ProdutoID" FOREIGN KEY ("ProdutoID") REFERENCES "tbl_Produto" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_PromocaoProduto" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(50) NOT NULL,
    "Preco" numeric(17,2) NOT NULL,
    "ImagemID" integer NOT NULL,
    "ProdutoID" integer NOT NULL,
    "Ativo" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_PromocaoProduto" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_PromocaoProduto_tbl_Imagem_ImagemID" FOREIGN KEY ("ImagemID") REFERENCES "tbl_Imagem" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_tbl_PromocaoProduto_tbl_Produto_ProdutoID" FOREIGN KEY ("ProdutoID") REFERENCES "tbl_Produto" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_Cliente" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(100) NOT NULL,
    "CPF" character varying(50) NOT NULL,
    "EnderecoID" integer NOT NULL,
    "Ativo" boolean NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Cliente" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_Cliente_tbl_Endereco_EnderecoID" FOREIGN KEY ("EnderecoID") REFERENCES "tbl_Endereco" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_ProdutoCombo" (
    "ProdutoID" integer NOT NULL,
    "ComboID" integer NOT NULL,
    CONSTRAINT "PK_tbl_ProdutoCombo" PRIMARY KEY ("ProdutoID", "ComboID"),
    CONSTRAINT "FK_tbl_ProdutoCombo_tbl_Combo_ComboID" FOREIGN KEY ("ComboID") REFERENCES "tbl_Combo" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_tbl_ProdutoCombo_tbl_Produto_ProdutoID" FOREIGN KEY ("ProdutoID") REFERENCES "tbl_Produto" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_Pedido" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Numero" character varying(10) NOT NULL,
    "ValorTotal" numeric(17,2) NOT NULL,
    "Entrega" interval NOT NULL,
    "ClienteID" integer NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_Pedido" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_Pedido_tbl_Cliente_ClienteID" FOREIGN KEY ("ClienteID") REFERENCES "tbl_Cliente" ("ID") ON DELETE CASCADE
);

CREATE TABLE "tbl_ProdutoPedido" (
    "ID" integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
    "Quantidade" integer NOT NULL,
    "Preco" numeric(17,2) NOT NULL,
    "ProdutoID" integer NOT NULL,
    "PedidoID" integer NOT NULL,
    "CriadoEM" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_tbl_ProdutoPedido" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_tbl_ProdutoPedido_tbl_Pedido_PedidoID" FOREIGN KEY ("PedidoID") REFERENCES "tbl_Pedido" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_tbl_ProdutoPedido_tbl_Produto_ProdutoID" FOREIGN KEY ("ProdutoID") REFERENCES "tbl_Produto" ("ID") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_tbl_Cliente_EnderecoID" ON "tbl_Cliente" ("EnderecoID");

CREATE INDEX "IX_tbl_Combo_ImagemID" ON "tbl_Combo" ("ImagemID");

CREATE INDEX "IX_tbl_Endereco_CidadeID" ON "tbl_Endereco" ("CidadeID");

CREATE INDEX "IX_tbl_ImagemProduto_ProdutoID" ON "tbl_ImagemProduto" ("ProdutoID");

CREATE INDEX "IX_tbl_Pedido_ClienteID" ON "tbl_Pedido" ("ClienteID");

CREATE INDEX "IX_tbl_Produto_CategoriaID" ON "tbl_Produto" ("CategoriaID");

CREATE INDEX "IX_tbl_ProdutoCombo_ComboID" ON "tbl_ProdutoCombo" ("ComboID");

CREATE INDEX "IX_tbl_ProdutoPedido_PedidoID" ON "tbl_ProdutoPedido" ("PedidoID");

CREATE INDEX "IX_tbl_ProdutoPedido_ProdutoID" ON "tbl_ProdutoPedido" ("ProdutoID");

CREATE INDEX "IX_tbl_PromocaoProduto_ImagemID" ON "tbl_PromocaoProduto" ("ImagemID");

CREATE INDEX "IX_tbl_PromocaoProduto_ProdutoID" ON "tbl_PromocaoProduto" ("ProdutoID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210203003718_Init', '5.0.2');

COMMIT;
