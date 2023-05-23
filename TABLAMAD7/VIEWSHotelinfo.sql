use MAD7

CREATE VIEW HotelNombreIdView AS
SELECT IdHotel, Nombre, CantHabitaciones FROM Hotel;

 DROP VIEW HotelNombreIdView

SELECT IdHotel, Nombre , CantHabitaciones FROM HotelNombreIdView

CREATE PROCEDURE ObtenerHotelNombreId
AS
BEGIN
    SELECT IdHotel, Nombre , CantHabitaciones FROM HotelNombreIdView;
END
