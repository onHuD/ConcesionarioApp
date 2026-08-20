Languages
C# 
POO
Functional
Imperative

BD SQL2021 :

            CREATE DATABASE ConcesionarioDB;
            
            CREATE TABLE Autos (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Marca NVARCHAR(50) NOT NULL,
                Modelo NVARCHAR(50) NOT NULL,
                Anio INT NOT NULL,
                Color NVARCHAR(30) NOT NULL,
                Precio DECIMAL(12,2) NOT NULL,
                Stock INT NOT NULL DEFAULT 0
            );
