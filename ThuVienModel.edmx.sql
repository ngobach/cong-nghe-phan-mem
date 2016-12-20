
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2016 21:33:43
-- Generated from EDMX file: D:\Visual Studio\CongNghePhanMem\ThuVienModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CNPM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[CNPMModelStoreContainer].[fk_CTPhieuMuon_PhieuMuon_1]', 'F') IS NOT NULL
    ALTER TABLE [CNPMModelStoreContainer].[CTPhieuMuon] DROP CONSTRAINT [fk_CTPhieuMuon_PhieuMuon_1];
GO
IF OBJECT_ID(N'[CNPMModelStoreContainer].[fk_CTPhieuMuon_Sach_1]', 'F') IS NOT NULL
    ALTER TABLE [CNPMModelStoreContainer].[CTPhieuMuon] DROP CONSTRAINT [fk_CTPhieuMuon_Sach_1];
GO
IF OBJECT_ID(N'[dbo].[fk_PhieuMuon_DocGia_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhieuMuon] DROP CONSTRAINT [fk_PhieuMuon_DocGia_1];
GO
IF OBJECT_ID(N'[dbo].[fk_Sach_NhaXB_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [fk_Sach_NhaXB_1];
GO
IF OBJECT_ID(N'[dbo].[fk_Sach_TacGia_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [fk_Sach_TacGia_1];
GO
IF OBJECT_ID(N'[dbo].[fk_Sach_TheLoai_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sach] DROP CONSTRAINT [fk_Sach_TheLoai_1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DocGia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocGia];
GO
IF OBJECT_ID(N'[dbo].[NhaXB]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhaXB];
GO
IF OBJECT_ID(N'[dbo].[PhieuMuon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhieuMuon];
GO
IF OBJECT_ID(N'[dbo].[Sach]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sach];
GO
IF OBJECT_ID(N'[dbo].[TacGia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TacGia];
GO
IF OBJECT_ID(N'[dbo].[TheLoai]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TheLoai];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[CNPMModelStoreContainer].[CTPhieuMuon]', 'U') IS NOT NULL
    DROP TABLE [CNPMModelStoreContainer].[CTPhieuMuon];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DocGia'
CREATE TABLE [dbo].[DocGia] (
    [madocgia] varchar(20)  NOT NULL,
    [hoten] nvarchar(50)  NOT NULL,
    [diachi] nvarchar(200)  NOT NULL,
    [sodienthoai] varchar(20)  NOT NULL
);
GO

-- Creating table 'NhaXB'
CREATE TABLE [dbo].[NhaXB] (
    [manhaxb] varchar(20)  NOT NULL,
    [tennhaxb] nvarchar(50)  NOT NULL,
    [gioithieu] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'PhieuMuon'
CREATE TABLE [dbo].[PhieuMuon] (
    [maphieumuon] varchar(20)  NOT NULL,
    [nguoimuon] varchar(20)  NOT NULL,
    [ngaymuon] datetime  NOT NULL
);
GO

-- Creating table 'Sach'
CREATE TABLE [dbo].[Sach] (
    [masach] int  NOT NULL,
    [nhaxb] varchar(20)  NULL,
    [theloai] varchar(20)  NULL,
    [tacgia] varchar(20)  NULL,
    [tensach] nvarchar(100)  NOT NULL,
    [gioithieu] nvarchar(200)  NOT NULL,
    [sotrang] int  NOT NULL,
    [giatien] bigint  NOT NULL
);
GO

-- Creating table 'TacGia'
CREATE TABLE [dbo].[TacGia] (
    [matacgia] varchar(20)  NOT NULL,
    [tentacgia] nvarchar(50)  NOT NULL,
    [quequan] nvarchar(50)  NOT NULL,
    [gioithieu] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'TheLoai'
CREATE TABLE [dbo].[TheLoai] (
    [matheloai] varchar(20)  NOT NULL,
    [tentheloai] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [id] int  NOT NULL,
    [username] varchar(20)  NOT NULL,
    [password] varchar(20)  NOT NULL,
    [hoten] nvarchar(50)  NOT NULL,
    [gioitinh] nvarchar(20)  NOT NULL,
    [sodienthoai] varchar(20)  NOT NULL,
    [quequan] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'CTPhieuMuon'
CREATE TABLE [dbo].[CTPhieuMuon] (
    [PhieuMuon_maphieumuon] varchar(20)  NOT NULL,
    [Sach_masach] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [madocgia] in table 'DocGia'
ALTER TABLE [dbo].[DocGia]
ADD CONSTRAINT [PK_DocGia]
    PRIMARY KEY CLUSTERED ([madocgia] ASC);
GO

-- Creating primary key on [manhaxb] in table 'NhaXB'
ALTER TABLE [dbo].[NhaXB]
ADD CONSTRAINT [PK_NhaXB]
    PRIMARY KEY CLUSTERED ([manhaxb] ASC);
GO

-- Creating primary key on [maphieumuon] in table 'PhieuMuon'
ALTER TABLE [dbo].[PhieuMuon]
ADD CONSTRAINT [PK_PhieuMuon]
    PRIMARY KEY CLUSTERED ([maphieumuon] ASC);
GO

-- Creating primary key on [masach] in table 'Sach'
ALTER TABLE [dbo].[Sach]
ADD CONSTRAINT [PK_Sach]
    PRIMARY KEY CLUSTERED ([masach] ASC);
GO

-- Creating primary key on [matacgia] in table 'TacGia'
ALTER TABLE [dbo].[TacGia]
ADD CONSTRAINT [PK_TacGia]
    PRIMARY KEY CLUSTERED ([matacgia] ASC);
GO

-- Creating primary key on [matheloai] in table 'TheLoai'
ALTER TABLE [dbo].[TheLoai]
ADD CONSTRAINT [PK_TheLoai]
    PRIMARY KEY CLUSTERED ([matheloai] ASC);
GO

-- Creating primary key on [id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [PhieuMuon_maphieumuon], [Sach_masach] in table 'CTPhieuMuon'
ALTER TABLE [dbo].[CTPhieuMuon]
ADD CONSTRAINT [PK_CTPhieuMuon]
    PRIMARY KEY CLUSTERED ([PhieuMuon_maphieumuon], [Sach_masach] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [nguoimuon] in table 'PhieuMuon'
ALTER TABLE [dbo].[PhieuMuon]
ADD CONSTRAINT [fk_PhieuMuon_DocGia_1]
    FOREIGN KEY ([nguoimuon])
    REFERENCES [dbo].[DocGia]
        ([madocgia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_PhieuMuon_DocGia_1'
CREATE INDEX [IX_fk_PhieuMuon_DocGia_1]
ON [dbo].[PhieuMuon]
    ([nguoimuon]);
GO

-- Creating foreign key on [nhaxb] in table 'Sach'
ALTER TABLE [dbo].[Sach]
ADD CONSTRAINT [fk_Sach_NhaXB_1]
    FOREIGN KEY ([nhaxb])
    REFERENCES [dbo].[NhaXB]
        ([manhaxb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Sach_NhaXB_1'
CREATE INDEX [IX_fk_Sach_NhaXB_1]
ON [dbo].[Sach]
    ([nhaxb]);
GO

-- Creating foreign key on [tacgia] in table 'Sach'
ALTER TABLE [dbo].[Sach]
ADD CONSTRAINT [fk_Sach_TacGia_1]
    FOREIGN KEY ([tacgia])
    REFERENCES [dbo].[TacGia]
        ([matacgia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Sach_TacGia_1'
CREATE INDEX [IX_fk_Sach_TacGia_1]
ON [dbo].[Sach]
    ([tacgia]);
GO

-- Creating foreign key on [theloai] in table 'Sach'
ALTER TABLE [dbo].[Sach]
ADD CONSTRAINT [fk_Sach_TheLoai_1]
    FOREIGN KEY ([theloai])
    REFERENCES [dbo].[TheLoai]
        ([matheloai])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Sach_TheLoai_1'
CREATE INDEX [IX_fk_Sach_TheLoai_1]
ON [dbo].[Sach]
    ([theloai]);
GO

-- Creating foreign key on [PhieuMuon_maphieumuon] in table 'CTPhieuMuon'
ALTER TABLE [dbo].[CTPhieuMuon]
ADD CONSTRAINT [FK_CTPhieuMuon_PhieuMuon]
    FOREIGN KEY ([PhieuMuon_maphieumuon])
    REFERENCES [dbo].[PhieuMuon]
        ([maphieumuon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sach_masach] in table 'CTPhieuMuon'
ALTER TABLE [dbo].[CTPhieuMuon]
ADD CONSTRAINT [FK_CTPhieuMuon_Sach]
    FOREIGN KEY ([Sach_masach])
    REFERENCES [dbo].[Sach]
        ([masach])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CTPhieuMuon_Sach'
CREATE INDEX [IX_FK_CTPhieuMuon_Sach]
ON [dbo].[CTPhieuMuon]
    ([Sach_masach]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------