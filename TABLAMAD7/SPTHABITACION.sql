USE MAD7
GO

CREATE PROCEDURE SPTipoHab
    @IdHabitacion INT = NULL,
    @TipoHabitacion VARCHAR(30) = NULL,
    @CantCamas VARCHAR(30) = NULL,
    @TipoCama VARCHAR(30) = NULL,
    @Precio MONEY = NULL,
    @CantPersonas VARCHAR(30) = NULL,
    @Caracteristicas VARCHAR(30) = NULL,
    @Amenidades VARCHAR(200) = NULL,
    @FecAlta DATETIME = NULL,
    @IdEmpleadoHo INT = NULL,
    @IdHotel INT = NULL,
    @NombreHotel VARCHAR(100) = NULL,
    @Accion CHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Accion = 'A'
    BEGIN
        -- Insertar la información de TipoHabitacion
        INSERT INTO TipoHabitacion (TipoHabitacion, CantCamas, TipoCama, Precio, CantPersonas, Caracteristicas, Amenidades, FecAlta, IdEmpleadoHo, IdHotel, NombreHotel)
        VALUES (@TipoHabitacion, @CantCamas, @TipoCama, @Precio, @CantPersonas, @Caracteristicas, @Amenidades, @FecAlta, @IdEmpleadoHo, @IdHotel, @NombreHotel);
    END
    ELSE IF @Accion = 'E'
    BEGIN
        -- Eliminar TipoHabitacion
        DELETE FROM TipoHabitacion WHERE IdHabitacion = @IdHabitacion;
    END
    ELSE IF @Accion = 'M'
    BEGIN
        -- Actualizar la información de TipoHabitacion
        UPDATE TipoHabitacion
        SET TipoHabitacion = @TipoHabitacion,
            CantCamas = @CantCamas,
            TipoCama = @TipoCama,
            Precio = @Precio,
            CantPersonas = @CantPersonas,
            Caracteristicas = @Caracteristicas,
            Amenidades = @Amenidades,
            FecAlta = @FecAlta,
            IdEmpleadoHo = @IdEmpleadoHo,
            IdHotel = @IdHotel,
            NombreHotel = @NombreHotel
        WHERE IdHabitacion = @IdHabitacion;
    END
END
