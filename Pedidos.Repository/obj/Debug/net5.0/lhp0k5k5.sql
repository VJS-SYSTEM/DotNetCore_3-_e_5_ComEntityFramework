IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [tbl_categoria_produto] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(50) NOT NULL,
    [ativo] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_categoria_produto] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tbl_cidade] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [uf] nvarchar(2) NOT NULL,
    [ativo] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_cidade] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tbl_imagem] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(20) NOT NULL,
    [nomearquivo] nvarchar(20) NOT NULL,
    [principal] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_imagem] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tbl_produto] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(50) NOT NULL,
    [codigo] nvarchar(50) NOT NULL,
    [descricao] nvarchar(100) NOT NULL,
    [preco] decimal(17,2) NOT NULL,
    [categoriaid] int NOT NULL,
    [ativo] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_produto] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_produto_tbl_categoria_produto_categoriaid] FOREIGN KEY ([categoriaid]) REFERENCES [tbl_categoria_produto] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_endereco] (
    [id] int NOT NULL IDENTITY,
    [tipo] tinyint NOT NULL,
    [logradouro] nvarchar(50) NOT NULL,
    [bairro] nvarchar(50) NOT NULL,
    [numero] nvarchar(10) NULL,
    [complemento] nvarchar(50) NULL,
    [cep] nvarchar(8) NULL,
    [cidadeid] int NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_endereco] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_endereco_tbl_cidade_cidadeid] FOREIGN KEY ([cidadeid]) REFERENCES [tbl_cidade] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_combo] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(50) NOT NULL,
    [preco] decimal(17,2) NOT NULL,
    [imagemid] int NOT NULL,
    [ativo] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_combo] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_combo_tbl_imagem_imagemid] FOREIGN KEY ([imagemid]) REFERENCES [tbl_imagem] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_imagem_produto] (
    [imagemid] int NOT NULL,
    [produtoid] int NOT NULL,
    CONSTRAINT [PK_tbl_imagem_produto] PRIMARY KEY ([imagemid], [produtoid]),
    CONSTRAINT [FK_tbl_imagem_produto_tbl_imagem_imagemid] FOREIGN KEY ([imagemid]) REFERENCES [tbl_imagem] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_imagem_produto_tbl_produto_produtoid] FOREIGN KEY ([produtoid]) REFERENCES [tbl_produto] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_promocao_produto] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(50) NOT NULL,
    [preco] decimal(17,2) NOT NULL,
    [imagemid] int NOT NULL,
    [produtoid] int NOT NULL,
    [ativo] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_promocao_produto] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_promocao_produto_tbl_imagem_imagemid] FOREIGN KEY ([imagemid]) REFERENCES [tbl_imagem] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_promocao_produto_tbl_produto_produtoid] FOREIGN KEY ([produtoid]) REFERENCES [tbl_produto] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_cliente] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [cpf] nvarchar(50) NOT NULL,
    [enderecoid] int NOT NULL,
    [ativo] bit NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_cliente] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_cliente_tbl_endereco_enderecoid] FOREIGN KEY ([enderecoid]) REFERENCES [tbl_endereco] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_produto_combo] (
    [produtoid] int NOT NULL,
    [comboid] int NOT NULL,
    CONSTRAINT [PK_tbl_produto_combo] PRIMARY KEY ([produtoid], [comboid]),
    CONSTRAINT [FK_tbl_produto_combo_tbl_combo_comboid] FOREIGN KEY ([comboid]) REFERENCES [tbl_combo] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_produto_combo_tbl_produto_produtoid] FOREIGN KEY ([produtoid]) REFERENCES [tbl_produto] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_pedido] (
    [id] int NOT NULL IDENTITY,
    [numero] nvarchar(10) NOT NULL,
    [valortotal] decimal(17,2) NOT NULL,
    [entrega] time NOT NULL,
    [clienteid] int NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_pedido] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_pedido_tbl_cliente_clienteid] FOREIGN KEY ([clienteid]) REFERENCES [tbl_cliente] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_produto_pedido] (
    [id] int NOT NULL IDENTITY,
    [quantidade] int NOT NULL,
    [preco] decimal(17,2) NOT NULL,
    [produtoid] int NOT NULL,
    [pedidoid] int NOT NULL,
    [criadoem] datetime2 NOT NULL,
    CONSTRAINT [PK_tbl_produto_pedido] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tbl_produto_pedido_tbl_pedido_pedidoid] FOREIGN KEY ([pedidoid]) REFERENCES [tbl_pedido] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_produto_pedido_tbl_produto_produtoid] FOREIGN KEY ([produtoid]) REFERENCES [tbl_produto] ([id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_tbl_cliente_enderecoid] ON [tbl_cliente] ([enderecoid]);
GO

CREATE INDEX [IX_tbl_combo_imagemid] ON [tbl_combo] ([imagemid]);
GO

CREATE INDEX [IX_tbl_endereco_cidadeid] ON [tbl_endereco] ([cidadeid]);
GO

CREATE INDEX [IX_tbl_imagem_produto_produtoid] ON [tbl_imagem_produto] ([produtoid]);
GO

CREATE INDEX [IX_tbl_pedido_clienteid] ON [tbl_pedido] ([clienteid]);
GO

CREATE INDEX [IX_tbl_produto_categoriaid] ON [tbl_produto] ([categoriaid]);
GO

CREATE INDEX [IX_tbl_produto_combo_comboid] ON [tbl_produto_combo] ([comboid]);
GO

CREATE INDEX [IX_tbl_produto_pedido_pedidoid] ON [tbl_produto_pedido] ([pedidoid]);
GO

CREATE INDEX [IX_tbl_produto_pedido_produtoid] ON [tbl_produto_pedido] ([produtoid]);
GO

CREATE INDEX [IX_tbl_promocao_produto_imagemid] ON [tbl_promocao_produto] ([imagemid]);
GO

CREATE INDEX [IX_tbl_promocao_produto_produtoid] ON [tbl_promocao_produto] ([produtoid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210217005243_Init', N'5.0.3');
GO

COMMIT;
GO

