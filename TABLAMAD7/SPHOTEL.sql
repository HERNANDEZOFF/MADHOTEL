USE MAD7

CREATE PROCEDURE SPHotel
    @IdHotel INT = NULL,
    @Nombre VARCHAR(30)=NULL,
    @Ciudad VARCHAR(100)=NULL,
    @Estado VARCHAR(100)=NULL,
    @Pais VARCHAR(100)=NULL,
    @Calle VARCHAR(100)=NULL,
    @Numero VARCHAR(100)=NULL,
    @CodigoPostal VARCHAR(100)=NULL,
    @CantPisos VARCHAR(100)=NULL,
    @CantHabitaciones VARCHAR(100)=NULL,
    @ZonaTuristica VARCHAR(100)=NULL,
    @Servicios VARCHAR(100)=NULL,
    @Amenidades VARCHAR(100)=NULL,
    @FecOperaciones DATETIME=NULL,
    @FecAlta DATETIME=NULL,
    @CreadoPor INT=NULL,
    @Accion CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'A'
    BEGIN
		IF @FecAlta IS NULL
        SET @FecAlta = GETDATE() -- si no se proporciona valor, asignar la fecha actual

        INSERT INTO Hotel (Nombre, Ciudad, Estado, Pais, Calle, Numero, CodigoPostal, CantPisos, CantHabitaciones, ZonaTuristica, Servicios, Amenidades, FecOperaciones, FecAlta, CreadoPor)
        VALUES (@Nombre, @Ciudad, @Estado, @Pais, @Calle, @Numero, @CodigoPostal, @CantPisos, @CantHabitaciones, @ZonaTuristica, @Servicios, @Amenidades, @FecOperaciones, GETDATE(), @CreadoPor);

        SELECT SCOPE_IDENTITY() AS IdHotel; -- Devuelve el ID generado para el nuevo hotel
    END
    ELSE IF @Accion = 'E'
    BEGIN
        DELETE FROM Hotel WHERE IdHotel = @IdHotel;
    END
    ELSE IF @Accion = 'M'
    BEGIN
        UPDATE Hotel
        SET Nombre = @Nombre,
            Ciudad = @Ciudad,
            Estado = @Estado,
            Pais = @Pais,
            Calle = @Calle,
            Numero = @Numero,
            CodigoPostal = @CodigoPostal,
            CantPisos = @CantPisos,
            CantHabitaciones = @CantHabitaciones,
            ZonaTuristica = @ZonaTuristica,
            Servicios = @Servicios,
            Amenidades = @Amenidades,
            FecOperaciones = @FecOperaciones
        WHERE IdHotel = @IdHotel;
    END
	ELSE IF @Accion='S'
	BEGIN
	SELECT IdHotel, Nombre, Ciudad, Estado, Pais, Calle, Numero, CodigoPostal, CantPisos, CantHabitaciones,
	ZonaTuristica, Servicios, Amenidades, FecOperaciones, FecAlta, CreadoPor
	FROM Hotel
	END;
END

SELECT *from Hotel