# Leeme

## Requisitos

Para ejecutar la aplicación es necesario tener las siguientes herramientas instaladas.

- SQL Server 2019 (15.X) o superior.
- Microsoft SQL Server Management Studio u otro cliente compatible.
- Visual Studio
- .Net 6.0 o superior
- npm

## Configurar y ejecutar la aplicación

1. Clonar el repositorio.
2. Abrir Microsoft SQL Server Management Studio y conectarse a la instancia de SQL Server.
    - Ejecutar los scripts de la carpeta `.\database\scripts` según el orden del prefijo númerico en el nombre de cada archivo. Omitir los archivos que tengan el prefijo `XXX`.
3. Abrir el archivo `.\api\Atm.sln` de proyecto de la API con Visual Studio.
    - Abrir el archivo `app.config` en el proyecto Atm y configurar el connectionString a la instancia de SQL Server donde está instalada la base de datos 'Atm'.
    - Asegurarse que el proyecto Atm sea el `Startup project` y que se ejecute con IIS Express.
    - Ejecutar la solución.
    - Llamar al endpoint `maintenance/hash` para generar el hash de los pines en la base de datos.
4. Abrir una terminal de cmd o powershell y dirigirse al directorio `.\web-app`
    - Ejecutar el comando `npm install` para instalar las dependencias.
    - Ejecutar el comando `npm start` para iniciar la aplicación web.
5. Datos de prueba para usar la aplicación:
    - Caso 1:
        - Número de tarjeta: 1234 1234 1234 5061
        - Pin: 5061
    - Caso 2:
        - Número de tarjeta: 1234 1234 1234 0002
        - Pin: 0002
    - Caso 3:
        - Número de tarjeta: 1111 1111 1111 1111
        - Pin: 1111
