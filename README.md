# BibliotecaUT

BibliotecaUT es una aplicación web desarrollada con ASP.NET Core y C#. Es un sistema de gestión de bibliotecas que permite administrar editoriales, libros, préstamos, autores, personas, estados de préstamos y categorías.

## Características

- **Editoriales**: Administra las editoriales de los libros.
- **Libros**: Gestión de libros disponibles en la biblioteca.
- **Préstamos**: Control y seguimiento de los préstamos de libros.
- **Autores**: Registro y gestión de los autores de los libros.
- **Personas**: Administración de los usuarios de la biblioteca.
- **Estado del Préstamo**: Seguimiento del estado de cada préstamo.
- **Categorías**: Organización de libros por categorías.

## Tecnologías Utilizadas

- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server (o cualquier otro sistema de gestión de bases de datos compatible)
- HTML/CSS
- JavaScript

## Requisitos Previos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (u otro sistema de gestión de bases de datos compatible)

## Instalación

1. Clona el repositorio:
   ```bash
   git clone https://github.com/JoseLazaro15/BibliotecaUT.git
    ```
2. Navega al directorio del proyecto:
  ```bash
  cd BibliotecaUT
  ```
3. Restaura los paquetes NuGet:
   ```bash
   dotnet restore
   ```
4. Configura la cadena de conexion de **Appsettings.json**
   
5. Crea la migracion de la base de datos:
  ```bash
  dotnet ef database update
  ```
6. Ejecuta la aplicacion:
   ```bash
   dotnet run
   ```
## Uso
Una vez que la aplicación esté en funcionamiento, puedes acceder a ella en tu navegador web en http://localhost:5000 (o el puerto que se haya configurado). Desde allí, podrás navegar entre las diferentes pestañas para administrar la biblioteca.

## Contribuciones
Agradecimiento por las contribuciones a:
 - Misael Anzures
 - Antonio Cervantes
 - Liliana De Jesus
 - Iris Lopez
 - Shekinha Degante
   
## Licencia
Este proyecto está licenciado bajo la **MIT License**.
