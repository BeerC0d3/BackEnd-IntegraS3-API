# BACKEND - INTEGRAS3-API
Este proyecto es una API para administrar el context de los manuales de IntegraS3 y realizar la conexión con ChatGPT y Firebase.

El proyecto esta basado en una arquitectura *unit of work and repository*, el cual esta formado por 4 proyectos dentro de la misma solución.

1. BeerC0d3.API
2. BeerC0d3.Core 
3. BeerC0d3.Firebase
4. BeerC0d3.Infrastructure


### Requerimientos

- Visual Studio 2022
- Framework .netCore  6.0 o superior.
- Sql Server 2012 o superior.
- Cuenta en GitHab.
- Postman

### Configuración
1. Estar registrado en GitHab para clonar el repositorio.
2. Debera realizar la conexión con SQL Server, para esto necesita la instancia, usuario y password.
3. Tener una cuenta en google firebase para realizar el guardado de archivos.

### Estructura del proyecto
1. BeerC0d3.API.
  - En este proyecto se encuentran los controlares a usar para realizar las solicitudes (Post,Get etc.), Aquí es donde el cliente se conecta mediante una llamada a UsuariosController para obtener el token que le permitira     realizar todas las peticiones que necesite.
  - El ContextoSoporteController permite realizar la carga y actualizar los contextos que son enviados a travez de archivos Base64 por el cliente.

2. BeerC0d3.Core.
  - Encargado de las interfaces que se implementan 

3. BeerC0d3.Firebase.
  - Encargado de realizar la conexión con Firebase, permite cargar y actualizar archivos.
4. BeerC0d3.Infrastructure
  - Permite la creción de los repositorios dentro de la base SQL, desde usuarios, tokens y menús.
  -
