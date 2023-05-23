use MAD7

CREATE PROCEDURE SPCliente
    @IdCliente INT = NULL,
    @Nombre VARCHAR(30) = NULL,
    @ApPaterno VARCHAR(30) = NULL,
    @ApMaterno VARCHAR(30) = NULL,
    @RFC VARCHAR(30) = NULL,
    @Correo VARCHAR(30) = NULL,
    @Referencia VARCHAR(30) = NULL,
    @FechaNacimiento DATE = NULL,
    @EstadoCivil VARCHAR(30) = NULL,
    @CreadoPor INT = NULL,
    @UsuarioModificacion VARCHAR(30) = NULL,
	@FechaModificacion DATE= NULL,
    @Accion CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'A' -- Alta
    BEGIN
        INSERT INTO Cliente (Nombre, ApPaterno, ApMaterno, RFC, Correo, Referencia, FechaNacimiento, EstadoCivil, CreadoPor, FechaAlta)
        VALUES (@Nombre, @ApPaterno, @ApMaterno, @RFC, @Correo, @Referencia, @FechaNacimiento, @EstadoCivil, @CreadoPor, GETDATE())
        
        SELECT SCOPE_IDENTITY() AS IdCliente
    END
    ELSE IF @Accion = 'M' -- Modificación
    BEGIN
        UPDATE Cliente
        SET Nombre = @Nombre,
            ApPaterno = @ApPaterno,
            ApMaterno = @ApMaterno,
            RFC = @RFC,
            Referencia = @Referencia,
            FechaNacimiento = @FechaNacimiento,
            EstadoCivil = @EstadoCivil,
            UsuarioModificacion = @UsuarioModificacion,
            FechaModificacion = GETDATE()
        WHERE IdCliente = @IdCliente
    END
    ELSE IF @Accion = 'B' -- Baja
    BEGIN
        DELETE FROM Cliente WHERE IdCliente = @IdCliente
    END;
	ELSE IF @Accion='S'
	BEGIN
	SELECT IdCliente, Nombre, ApPaterno, ApMaterno, RFC, Correo, Referencia,
		FechaNacimiento, EstadoCivil, CreadoPor, FechaAlta, FechaModificacion, UsuarioModificacion
	FROM Cliente
	END;

END

SELECT *fROM Cliente