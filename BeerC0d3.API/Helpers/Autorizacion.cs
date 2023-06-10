namespace BeerC0d3.API.Helpers
{
    public class Autorizacion
    {
        public enum Roles
        {
            Administrador,
            Gerente,
            Empleado
        }

        public const Roles rol_predeterminado = Roles.Administrador;
    }
}
