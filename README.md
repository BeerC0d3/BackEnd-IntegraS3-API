# BACKEND - INTEGRAS3-API
Este proyecto es una API para administrar el context de los manuales de IntegraS3 y realizar la conexión con ChatGPT y Firebase.

El proyecto esta basado en una arquitectura *unit of work and repository*, el cual ayuda a aislar su aplicación de los cambios en el almacén de datos y puede facilitar las pruebas unitarias automatizadas.

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
La solución esta formado por 4 capas, los cuales interactuan para llevar acabo la conexión con la API de ChatGpt y regresar la información solicitada.
1. BeerC0d3.API
2. BeerC0d3.Core 
3. BeerC0d3.Firebase
4. BeerC0d3.Infrastructure

A continuación se describe la funcionalidad de cada capa:   
1. BeerC0d3.API. "Capa encargada de manejar todos los controladores necesarios para ser consumidos por el cliente"
  - En esta capa el cliente puede autenticarse y obtener su token que le permitira realizar peticiones futuras.
  - Esta capa permite inicializar un contexto ademas de cargar nuevo contexto mediante archivos txt.
  - Permite la conexión con la API de ChatGPT. 

2. BeerC0d3.Core. "Capa encargada de la creación de entidades"
  - Encargado de la creción de entidades.
  - Encargada de la creación de interfaces para el uso de repositorios.
  - Encargado de manejar el context de la base de datos.

3. BeerC0d3.Firebase. "Firebase"
  - Encargado de realizar la conexión con Firebase.
  - Realiza cargas y actualizaciónes al repositorio de Firebase.
    
4. BeerC0d3.Infrastructure "Capa encargada de la creación de repositorios"
  - Permite la creción de los repositorios sobre contextos, usuarios, menus.
  - Configuración (Data) para Catalogos, Menus, Tokens, Usuarios, Contextos.
  - Creación de Esquemas en la base de datos.
    
Este proyecto fue desarrollado con la finalidad de aportar una harremienta que ayude a resolver dudas a los usuarios que interactúan con IntegraS3, desde modulos como Kiosko, Estructura etc.

### Equipo de desarrolladores:
- Juan Diego Luna 
- José Luis Martínez Cisneros
- José Antonio Martínez Neri
- Jorge Cruz 

