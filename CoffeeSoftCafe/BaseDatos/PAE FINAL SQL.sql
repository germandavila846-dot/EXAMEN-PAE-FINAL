CREATE DATABASE CoffeeSoftCafe;
GO

USE CoffeeSoftCafe;
GO

-- =========================================
-- TABLA USUARIOS (LOGIN)
-- =========================================

CREATE TABLE Usuarios (
IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
Clave VARCHAR(100) NOT NULL,
NombreCompleto VARCHAR(150) NOT NULL,
Rol VARCHAR(50) NOT NULL
);

-- =========================================
-- TABLA CATEGORIAS
-- =========================================

CREATE TABLE Categorias (
IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
NombreCategoria VARCHAR(100) NOT NULL
);

-- =========================================
-- TABLA TIPOS DE CAFÉ
-- =========================================

CREATE TABLE TiposCafe (
IdTipoCafe INT IDENTITY(1,1) PRIMARY KEY,
NombreTipo VARCHAR(50) NOT NULL
);

-- =========================================
-- TABLA PRODUCTOS
-- =========================================

CREATE TABLE Productos (
IdProducto INT IDENTITY(1,1) PRIMARY KEY,
CodigoProducto VARCHAR(20) NOT NULL,
NombreProducto VARCHAR(150) NOT NULL,
PrecioUnitario DECIMAL(10,2) NOT NULL,
IdCategoria INT NOT NULL,
IdTipoCafe INT NULL,
CONSTRAINT FK_Productos_Categorias
    FOREIGN KEY (IdCategoria)
    REFERENCES Categorias(IdCategoria),

CONSTRAINT FK_Productos_TiposCafe
    FOREIGN KEY (IdTipoCafe)
    REFERENCES TiposCafe(IdTipoCafe)

);

-- =========================================
-- TABLA CLIENTES
-- =========================================

CREATE TABLE Clientes (
IdCliente INT IDENTITY(1,1) PRIMARY KEY,
NombreCompleto VARCHAR(150) NOT NULL,
Direccion VARCHAR(250),
Telefono VARCHAR(20)
);

-- =========================================
-- TABLA MÉTODOS DE PAGO
-- =========================================

CREATE TABLE MetodosPago (
IdMetodoPago INT IDENTITY(1,1) PRIMARY KEY,
NombreMetodo VARCHAR(50) NOT NULL
);

-- =========================================
-- TABLA FACTURAS
-- =========================================

CREATE TABLE Facturas (
IdFactura INT IDENTITY(1,1) PRIMARY KEY,
FechaFactura DATETIME NOT NULL DEFAULT GETDATE(),
IdCliente INT NOT NULL,
IdMetodoPago INT NOT NULL,

Subtotal DECIMAL(10,2) NOT NULL,
IVA DECIMAL(10,2) NOT NULL,
Total DECIMAL(10,2) NOT NULL,

CONSTRAINT FK_Facturas_Clientes
    FOREIGN KEY (IdCliente)
    REFERENCES Clientes(IdCliente),

CONSTRAINT FK_Facturas_MetodosPago
    FOREIGN KEY (IdMetodoPago)
    REFERENCES MetodosPago(IdMetodoPago)

);

-- =========================================
-- TABLA DETALLE FACTURA
-- =========================================

CREATE TABLE DetalleFactura (
IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
IdFactura INT NOT NULL,
IdProducto INT NOT NULL,

Cantidad INT NOT NULL,
PrecioUnitario DECIMAL(10,2) NOT NULL,
SubtotalLinea DECIMAL(10,2) NOT NULL,

CONSTRAINT FK_DetalleFactura_Facturas
    FOREIGN KEY (IdFactura)
    REFERENCES Facturas(IdFactura),

CONSTRAINT FK_DetalleFactura_Productos
    FOREIGN KEY (IdProducto)
    REFERENCES Productos(IdProducto)
);

-- =========================================
-- DATOS INICIALES
-- =========================================

INSERT INTO Usuarios
(
NombreUsuario,
Clave,
NombreCompleto,
Rol
)
VALUES
('admin','123456','Administrador General','Administrador'),
('cajero1','123456','María López','Cajero'),
('cajero2','123456','Juan Pérez','Cajero');

-- =========================================
-- CATEGORÍAS
-- =========================================

INSERT INTO Categorias (NombreCategoria)
VALUES
('Cafe'),
('Bebidas Frias'),
('Postres'),
('Bocadillos');

-- =========================================
-- TIPOS DE CAFÉ
-- =========================================

INSERT INTO TiposCafe (NombreTipo)
VALUES
('Instantaneo'),
('De palo');

-- =========================================
-- MÉTODOS DE PAGO
-- =========================================

INSERT INTO MetodosPago (NombreMetodo)
VALUES
('Efectivo'),
('Tarjeta de Credito'),
('Tarjeta de Debito'),
('Transferencia');

-- =========================================
-- PRODUCTOS
-- =========================================

INSERT INTO Productos
(
CodigoProducto,
NombreProducto,
PrecioUnitario,
IdCategoria,
IdTipoCafe
)
VALUES
('CAF001','Cafe Americano',40.00,1,2),
('CAF002','Cappuccino',55.00,1,1),
('CAF003','Frappe Chocolate',75.00,2,1),
('CAF004','Cafe Latte',60.00,1,2),
('POS001','Cheesecake',80.00,3,NULL),
('POS002','Brownie',65.00,3,NULL),
('BOC001','Croissant',35.00,4,NULL),
('BOC002','Sandwich Especial',95.00,4,NULL);

-- =========================================
-- CLIENTES
-- =========================================

INSERT INTO Clientes
(
NombreCompleto,
Direccion,
Telefono
)
VALUES
('Juan Perez','Managua','88888888'),
('María López','Masaya','87878787'),
('Carlos Hernández','Granada','89898989'),
('Ana González','Carazo','86868686'),
('Luis Martínez','Rivas','85858585');

DELETE FROM Clientes;
DBCC CHECKIDENT ('Clientes', RESEED, 0);

DELETE FROM Productos;
DBCC CHECKIDENT ('Productos', RESEED, 0);

DELETE FROM MetodosPago;
DBCC CHECKIDENT ('MetodosPago', RESEED, 0);

DELETE FROM TiposCafe;
DBCC CHECKIDENT ('TiposCafe', RESEED, 0);

DELETE FROM Categorias;
DBCC CHECKIDENT ('Categorias', RESEED, 0);

select * from MetodosPago;