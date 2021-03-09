create table Viajeros (
    Id INT IDENTITY (1,1) PRIMARY KEY,
    Cedula varchar(20),
    Nombre varchar(200),
    Direccion varchar(200),
    Telefono varchar(50)
)

create table Paises (
    Id INT IDENTITY (1,1) PRIMARY KEY,
    Nombre varchar(50)
)

create TABLE Viajes (
    Id INT IDENTITY (1,1) PRIMARY KEY,
    CodigoViaje varchar(50),
    NumeroPlazas int,
    DestinoId int,
    OrigenId int,
    Precio decimal(18,8),
    Disponible bit,
    FOREIGN key (DestinoId) REFERENCES Paises(Id),
    FOREIGN key (OrigenId) REFERENCES Paises(Id),
)

create table Reservas (
    Id INT IDENTITY (1,1) PRIMARY KEY,
    IdViajero int,
    IdViaje int,
    FOREIGN key (IdViajero) REFERENCES Viajeros(Id),
    FOREIGN KEY (IdViaje) REFERENCES Viajes(Id)
)
