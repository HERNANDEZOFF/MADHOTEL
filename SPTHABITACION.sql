USE MAD6

CREATE PROCEDURE SPTipoHab
    @IdHabitacion INT = NULL,
    @TipoHabitacion VARCHAR(30)=NULL,
    @CantCamas VARCHAR(30)=NULL,
    @TipoCama VARCHAR(30)=NULL,
    @Precio MONEY=NULL,
    @CantPersonas VARCHAR(30)=NULL,
    @CantTipoHab VARCHAR(30)=nULL, 
    @Caracteristicas VARCHAR(30)=NULL,
    @Amenidades VARCHAR(200)=NULL,
    @FecAlta DATETIME=NULL,
    @IdEmpleadoHo INT=NULL,
    @IdHotel INT=NULL,
    @NombreHotel VARCHAR(100)=NULL,
    @CantHabitaciones INT=NULL,
    @Accion VARCHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'A'
    BEGIN
        -- Verificar la disponibilidad de habitaciones
        DECLARE @HabitacionesDisponibles INT;
        SELECT @HabitacionesDisponibles = CantHabitaciones FROM Hotel WHERE IdHotel = @IdHotel;

        IF @CantTipoHab > @HabitacionesDisponibles
        BEGIN
            RAISERROR ('La cantidad de habitaciones requeridas supera la cantidad de habitaciones disponibles en el hotel.', 16, 1);
            RETURN;
        END

        -- Insertar la información de TipoHabitacion
        INSERT INTO TipoHabitacion (TipoHabitacion, CantCamas, TipoCama, Precio, CantPersonas, CantTipoHab, Caracteristicas, Amenidades, FecAlta, IdEmpleadoHo, IdHotel, NombreHotel, CantHabitaciones)
        VALUES (@TipoHabitacion, @CantCamas, @TipoCama, @Precio, @CantPersonas, @CantTipoHab, @Caracteristicas, @Amenidades, @FecAlta, @IdEmpleadoHo, @IdHotel, @NombreHotel, @CantHabitaciones);
    END
    ELSE IF @Accion = 'E'
    BEGIN
        DELETE FROM TipoHabitacion WHERE IdHotel = @IdHotel AND IdHabitacion = @IdHabitacion;
    END
    ELSE IF @Accion = 'M'
    BEGIN
        -- Verificar la disponibilidad de habitaciones
        DECLARE @HabitacionesDisponiblesM INT;
        SELECT @HabitacionesDisponiblesM = CantHabitaciones FROM Hotel WHERE IdHotel = @IdHotel;

        IF @CantTipoHab > @HabitacionesDisponiblesM
        BEGIN
            RAISERROR ('La cantidad de habitaciones requeridas supera la cantidad de habitaciones disponibles en el hotel.', 16, 1);
            RETURN;
        END

        -- Actualizar la información de TipoHabitacion
        UPDATE TipoHabitacion
        SET TipoHabitacion = @TipoHabitacion,
            CantCamas = @CantCamas,
            TipoCama = @TipoCama,
            Precio = @Precio,
            CantPersonas = @CantPersonas,
            CantTipoHab = @CantTipoHab,
            Caracteristicas = @Caracteristicas,
            Amenidades = @Amenidades,
            FecAlta = @FecAlta,
            NombreHotel = @NombreHotel,
            CantHabitaciones = @CantHabitaciones
        WHERE IdHotel = @IdHotel AND IdHabitacion = @IdHabitacion;
    END
	ELSE IF @Accion='S'
	BEGIN
	SELECT IdHabitacion, TipoHabitacion, CantCamas, TipoCama, Precio, CantPersonas, CantTipoHab,
	Caracteristicas, Amenidades, FecAlta,
	IdEmpleadoHo, IdHotel,NombreHotel,CantHabitaciones
	FROM TipoHabitacion
	END;
END;

SELECT * FROM TipoHabitacion
SELECT *FROM Hotel

EXECUTE SPTipoHab
    @TipoHabitacion = 'Individual',
    @CantCamas = '1',
    @TipoCama = 'Individual',
    @Precio = 100.00,
    @CantPersonas = '1',
    @CantTipoHab = '4',
    @Caracteristicas = '...',
    @Amenidades = '...',
    @FecAlta = '2023-05-17',
    @IdEmpleadoHo = 1,
    @IdHotel = 1,
    @Operacion = 'A';

	Update TipoHabitacion set NombreHotel='x' where IdHabitacion=3
		Update TipoHabitacion set CantHabitaciones=10 where IdHabitacion=3

		Delete TipoHabitacion WHERE IdHabitacion =4