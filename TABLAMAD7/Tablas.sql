CREATE DATABASE MAD7;
USE MAD7;

CREATE TABLE RolEmp (
    IdRol INT IDENTITY(1,1) NOT NULL,
    Rol VARCHAR(30) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    CONSTRAINT PK_Rol PRIMARY KEY (IdRol)
);

CREATE TABLE Empleado (
    IdEmpleado INT IDENTITY(1,1) NOT NULL,
    Correo VARCHAR(30) NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    ApPaterno VARCHAR(30) NOT NULL,
    ApMaterno VARCHAR(30) NOT NULL,
    NumNomina VARCHAR(30) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Calle VARCHAR(100) NOT NULL,
    Numero VARCHAR(100) NOT NULL,
    Colonia VARCHAR(100) NOT NULL,
    CodigoPostal VARCHAR(100) NOT NULL,
    Telefono VARCHAR(15) NOT NULL,
    Celular VARCHAR(15) NOT NULL,
    FecAlta DATE NOT NULL,
    IdRolEmp INT NOT NULL,
    ContraError INT NOT NULL DEFAULT 0,
    Contra1 VARCHAR(50) NULL,
    Contra2 VARCHAR(50) NULL,
    Contra3 VARCHAR(50) NULL,
    UsuarioAlta VARCHAR(30) NOT NULL,
    FechaHoraAlta DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_Empleado PRIMARY KEY (IdEmpleado),
    CONSTRAINT FK_RolEmpleado FOREIGN KEY (IdRolEmp) REFERENCES RolEmp (IdRol)
);

CREATE TABLE ContrasenasAnteriores (
    IdContrasenaAnt INT IDENTITY(1,1) NOT NULL,
    ContrasenaAnterior VARCHAR(50) NOT NULL,
    FechaHoraCambio DATETIME NOT NULL DEFAULT GETDATE(),
    IdEmpleado INT NOT NULL,
    CONSTRAINT PK_ContAnteriores PRIMARY KEY (IdContrasenaAnt),
    CONSTRAINT FK_ContraAnterioresEmp FOREIGN KEY (IdEmpleado) REFERENCES Empleado (IdEmpleado)
);

CREATE TABLE Hotel (
    IdHotel INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Ciudad VARCHAR(100) NOT NULL,
    Estado VARCHAR(100) NOT NULL,
    Pais VARCHAR(100) NOT NULL,
    Calle VARCHAR(100) NOT NULL,
    Numero VARCHAR(100) NOT NULL,
    CodigoPostal VARCHAR(100) NOT NULL,
    CantPisos VARCHAR(100) NOT NULL,
    CantHabitaciones VARCHAR(100) NOT NULL,
    ZonaTuristica VARCHAR(100) NOT NULL,
    Servicios VARCHAR(100) NOT NULL,
    Amenidades VARCHAR(100) NOT NULL,
    FecOperaciones DATETIME NOT NULL,
    FecAlta DATETIME NOT NULL,
    CreadoPor INT NOT NULL,
    CONSTRAINT PK_Hotel PRIMARY KEY (IdHotel),
    CONSTRAINT FK_Creado FOREIGN KEY (CreadoPor) REFERENCES Empleado (IdEmpleado)
);

CREATE TABLE ServicioExtra (
    IdServicio INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Costo MONEY NOT NULL,
    CONSTRAINT PK_ServicioExtra PRIMARY KEY (IdServicio)
);

CREATE TABLE HotelServicioExtra (
    IdHotel INT NOT NULL,
    IdServicio INT NOT NULL,
    CONSTRAINT PK_HotelServicioExtra PRIMARY KEY (IdHotel, IdServicio),
    CONSTRAINT FK_HotelServicioExtra_Hotel FOREIGN KEY (IdHotel) REFERENCES Hotel (IdHotel),
    CONSTRAINT FK_HotelServicioExtra_ServicioExtra FOREIGN KEY (IdServicio) REFERENCES ServicioExtra (IdServicio)
);


CREATE TABLE TipoHabitacion (
    IdHabitacion INT IDENTITY(1,1) NOT NULL,
    TipoHabitacion VARCHAR(30) NOT NULL,
    CantCamas VARCHAR(30) NOT NULL,
    TipoCama VARCHAR(30) NOT NULL,
    Precio MONEY NOT NULL,
    CantPersonas VARCHAR(30) NOT NULL,
    Caracteristicas VARCHAR(30) NOT NULL,
    Amenidades VARCHAR(200) NOT NULL,
    FecAlta DATETIME NOT NULL,
    IdEmpleadoHo INT NOT NULL,
    IdHotel INT NOT NULL,
    NombreHotel VARCHAR(100) NOT NULL,
    CONSTRAINT PK_TipoHab PRIMARY KEY (IdHabitacion),
    CONSTRAINT FK_RegEmpleado FOREIGN KEY (IdEmpleadoHo) REFERENCES Empleado (IdEmpleado),
    CONSTRAINT FK_IdHotel FOREIGN KEY (IdHotel) REFERENCES Hotel (IdHotel)
);

CREATE TABLE Habitacion (
    IdHabitacion INT IDENTITY(1,1) NOT NULL,
    NumHabitacion INT NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    IdTipoHabitacion INT NOT NULL,
    IdHotel INT NOT NULL,
    Disponible BIT NOT NULL DEFAULT 1, -- Columna para indicar la disponibilidad de la habitación
    CONSTRAINT PK_Habitacion PRIMARY KEY (IdHabitacion),
    CONSTRAINT FK_TipoHabitacion FOREIGN KEY (IdTipoHabitacion) REFERENCES TipoHabitacion (IdHabitacion),
    CONSTRAINT FK_Hotel FOREIGN KEY (IdHotel) REFERENCES Hotel (IdHotel)
);

CREATE TABLE HabitacionesDisponibles (
	IdHabitacionDisponible INT IDENTITY(1,1) NOT NULL,
	IdHotel INT NOT NULL,
	IdTipoHabitacion INT NOT NULL,
	CantidadDisponible INT NOT NULL,
	Ocupada BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_HabitacionesDisponibles PRIMARY KEY (IdHabitacionDisponible),
	CONSTRAINT FK_HabitacionesDisponibles_Hotel FOREIGN KEY (IdHotel) REFERENCES Hotel (IdHotel),
	CONSTRAINT FK_HabitacionesDisponibles_TipoHabitacion FOREIGN KEY (IdTipoHabitacion) REFERENCES TipoHabitacion (IdHabitacion)
);

CREATE TABLE Cliente (
	IdCliente INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(30) NOT NULL,
	ApPaterno VARCHAR(30) NOT NULL,
	ApMaterno VARCHAR(30) NOT NULL,
	RFC VARCHAR(30) NOT NULL,
	Correo VARCHAR(30) NOT NULL,
	Referencia VARCHAR(30) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	EstadoCivil VARCHAR(30) NOT NULL,
	CreadoPor INT NOT NULL,
	FechaAlta DATETIME NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificacion VARCHAR(30) NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente),
	CONSTRAINT FK_CreadoPor FOREIGN KEY (CreadoPor) REFERENCES Empleado (IdEmpleado)
);

CREATE TABLE Reservacion (
    IdReservacion UNIQUEIDENTIFIER NOT NULL,
    CodigoReservacion UNIQUEIDENTIFIER DEFAULT CONVERT(UNIQUEIDENTIFIER, '00000000-0000-0000-0000-000000000064') NOT NULL,
    Correo VARCHAR(30) NOT NULL,
    IdEmpleado INT NOT NULL,
    FecReservacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
	IdCliente INT NOT NULL,
    CantidadHabitaciones INT NOT NULL,
    IdHotel INT NOT NULL,
    IdHabitacion INT NOT NULL,
    NumHabitaciones INT NOT NULL,
    CantPersonas INT NOT NULL,
    CostoNoche MONEY NOT NULL,
    Anticipo MONEY NOT NULL,
	MetodoPago VARCHAR(100) NOT NULL,
	Llegada BIT NOT NULL DEFAULT 0, -- Columna para indicar la llegada del cliente al hotel
    IdServicioContratado INT NULL,
    CONSTRAINT PK_Reservacion PRIMARY KEY(CodigoReservacion),
    CONSTRAINT FK_Reservacion_Cliente FOREIGN KEY (Correo) REFERENCES Cliente (Correo),
    CONSTRAINT FK_Reservacion_Empleado FOREIGN KEY (IdEmpleado) REFERENCES Empleado (IdEmpleado),
    CONSTRAINT FK_Reservacion_Hotel FOREIGN KEY (IdHotel) REFERENCES Hotel (IdHotel),
    CONSTRAINT FK_Reservacion_TipoHabitacion FOREIGN KEY (IdHabitacion) REFERENCES TipoHabitacion (IdHabitacion),
    CONSTRAINT FK_Reservacion_ServicioContratado FOREIGN KEY (IdServicioContratado) REFERENCES ServicioContratado (IdServicioContratado)
);

CREATE TABLE HistorialServiciosExtras (
    IdHistorialServicio INT IDENTITY(1,1) NOT NULL,
    IdReservacion INT NOT NULL,
    IdServicio INT NOT NULL,
    FechaServicio DATETIME NOT NULL,
    NombreServicio VARCHAR(50) NOT NULL,
    CostoServicio MONEY NOT NULL,
    CONSTRAINT PK_HistorialServiciosExtras PRIMARY KEY (IdHistorialServicio),
    CONSTRAINT FK_HistorialServiciosExtras_Reservacion FOREIGN KEY (IdReservacion) REFERENCES Reservacion (IdReservacion),
    CONSTRAINT FK_HistorialServiciosExtras_ServicioExtra FOREIGN KEY (IdServicio) REFERENCES ServicioExtra (IdServicio)
);


CREATE TABLE Cancelaciones (
    IdCancelacion INT IDENTITY(1,1) NOT NULL,
    CodigoReservacion UNIQUEIDENTIFIER NOT NULL,
    FechaCancelacion DATETIME NOT NULL,
    Motivo VARCHAR(100) NOT NULL,
    IdEmpleadoCa INT NOT NULL,
    CONSTRAINT PK_Cancelaciones PRIMARY KEY (IdCancelacion),
    CONSTRAINT FK_Cancelaciones_Reservacion FOREIGN KEY (CodigoReservacion) REFERENCES Reservacion (CodigoReservacion),
    CONSTRAINT FK_Cancelaciones_Empleado FOREIGN KEY (IdEmpleadoCa) REFERENCES Empleado (IdEmpleado)
);
