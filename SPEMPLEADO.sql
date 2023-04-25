USE MAD1

CREATE PROCEDURE SPEmpleado
    @IdEmpleado INT = NULL,
    @Correo VARCHAR(30) = NULL,
    @Nombre VARCHAR(30) = NULL,
    @ApPaterno VARCHAR(30) = NULL,
    @ApMaterno VARCHAR(30) = NULL,
    @NumNomina VARCHAR(30) = NULL,
    @FechaNacimiento DATE = NULL,
    @Calle VARCHAR(100) = NULL,
    @Numero VARCHAR(100) = NULL,
    @Colonia VARCHAR(100) = NULL,
    @CodigoPostal VARCHAR(100) = NULL,
    @Telefono VARCHAR(15) = NULL,
    @Celular VARCHAR(15) = NULL,
    @IdRolEmp INT = NULL,
    @Contra1 VARCHAR(50) = NULL,
    @UsuarioAlta VARCHAR(30) = NULL,
    @FechaHoraAlta DATETIME = NULL, -- nueva variable de entrada
    @UsuarioModif VARCHAR(30) = NULL,
    @FechaHoraModif DATETIME = NULL,
    @Activo BIT = NULL,
	@Accion CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'A' -- Alta
    BEGIN
			IF @FechaHoraAlta IS NULL
            SET @FechaHoraAlta = GETDATE() -- si no se proporciona valor, asignar la fecha actual
        
		INSERT INTO Empleado (Correo, Nombre, ApPaterno, ApMaterno, NumNomina, FechaNacimiento, Calle, Numero, Colonia, CodigoPostal, Telefono, Celular, FecAlta, IdRolEmp, Contra1, UsuarioAlta, FechaHoraAlta)
        VALUES (@Correo, @Nombre, @ApPaterno, @ApMaterno, @NumNomina, @FechaNacimiento, @Calle, @Numero, @Colonia, @CodigoPostal, @Telefono, @Celular, GETDATE(), @IdRolEmp, @Contra1, @UsuarioAlta, @FechaHoraAlta)

        SELECT SCOPE_IDENTITY() AS IdEmpleado
    END
    ELSE IF @Accion = 'M' -- Modificación
    BEGIN
        UPDATE Empleado
        SET Correo = COALESCE(@Correo, Correo),
            Nombre = COALESCE(@Nombre, Nombre),
            ApPaterno = COALESCE(@ApPaterno, ApPaterno),
            ApMaterno = COALESCE(@ApMaterno, ApMaterno),
            NumNomina = COALESCE(@NumNomina, NumNomina),
            FechaNacimiento = COALESCE(@FechaNacimiento, FechaNacimiento),
            Calle = COALESCE(@Calle, Calle),
            Numero = COALESCE(@Numero, Numero),
            Colonia = COALESCE(@Colonia, Colonia),
            CodigoPostal = COALESCE(@CodigoPostal, CodigoPostal),
            Telefono = COALESCE(@Telefono, Telefono),
            Celular = COALESCE(@Celular, Celular),
            IdRolEmp = COALESCE(@IdRolEmp, IdRolEmp),
            Contra1 = COALESCE(@Contra1, Contra1)
        WHERE IdEmpleado = @IdEmpleado
    END
    ELSE IF @Accion = 'E' -- Eliminación
    BEGIN
        DELETE FROM Empleado WHERE IdEmpleado = @IdEmpleado
    END
    ELSE IF @Accion = 'B' -- Baja lógica
    BEGIN
        UPDATE Empleado
        SET Activo = 0
        WHERE IdEmpleado = @IdEmpleado
    END
END

EXEC SPEmpleado 
    @Accion  = 'A',
    @Correo = 'john@example.com',
    @Nombre = 'John',
    @ApPaterno = 'Doe',
	@ApMaterno = 'Doe',
    @NumNomina = '123456',
    @FechaNacimiento = '1990-01-01',
    @Calle = 'Calle 123',
    @Numero = '456',
    @Colonia = 'Colonia XYZ',
    @CodigoPostal = '12345',
    @Telefono = '555-1234',
    @Celular = '555-5678',
    @IdRolEmp = 1,
    @Contra1 = '123',
    @UsuarioAlta = 'admin'

	select*from Empleado