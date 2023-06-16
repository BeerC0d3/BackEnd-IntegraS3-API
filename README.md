# BACKEND - INTEGRAS3-API
Este proyecto es una API para administrar el context de los manuales de IntegraS3 y realizar la conexión con ChatGPT y Firebase.

El proyecto esta basado en una arquitectura *unit of work and repository*, el cual ayuda a aislar su aplicación de los cambios en el almacén de datos y puede facilitar las pruebas unitarias automatizadas.
La solución esta formado por 4 capas.

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
2. Debera tener una instancia de SQL Server con la base de datos "IntegraChatGpt".
3. Debera realizar la configuración en los config para la conexión con SQL Server, para esto necesita la instancia, usuario y password.
4. Tener una cuenta en google firebase para realizar el guardado de archivos.

### Estructura del proyecto
1. BeerC0d3.API. "En esta capa encontraras todos los controladores necesarios para ser consumidos por el cliente"
  - En esta capa el cliente puede autenticarse y obtener su token que le permitira realizar peticiones futuras.
  - Esta capa permite inicializar un contexto ademas de cargar nuevo contexto mediante archivos txt.
  - Permite obteneter las conversaciones mediante peticiones. 

2. BeerC0d3.Core. "Capa encargada de la creación de entidades"
  - Encargado de la creción de entidades.
  - Encargada creación de las interfaces repositorio. 

3. BeerC0d3.Firebase. "Firebase"
  - Encargado de realizar la conexión con Firebase.
  - Realiza cargas y actualizaciónes al repositorio de Firebase.
    
4. BeerC0d3.Infrastructure "Capa encargada de la creación de repositorios"
  - Permite la creción de los repositorios.
  - Configuración del Data.

