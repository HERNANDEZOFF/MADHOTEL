USE MAD6

CREATE PROCEDURE spAgregarRolEmp
    @Rol VARCHAR(30),
    @Descripcion VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO RolEmp (Rol, Descripcion) VALUES (@Rol, @Descripcion);
END

EXEC spAgregarRolEmp 'Admin', 'Se encarga de todo';

EXEC spAgregarRolEmp 'Empleado', 'Se encarga de ayudar';

Select*from RolEmp

Delete RolEmp Where IdRol  > '1' 