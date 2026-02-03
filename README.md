# Prueba Técnica - Smart Costa

Este repositorio contiene la solución a la prueba técnica requerida, implementada en **ASP.NET Core MVC** (.NET 10) y **SQL Server**.

La solución consta de dos partes principales:
1.  **Proyecto MVC**: Gestión de Libros (CRUD).
2.  **Base de Datos**: Scripts para tablas `Usuarios` y `Publicaciones` con sus relaciones, y persistencia de Libros mediante Entity Framework Core.

## Requisitos Previos

*   .NET SDK 10.0 (o superior).
*   SQL Server (Instancia local o remota).

## Configuración de Base de Datos

### 1. Tablas Usuarios y Publicaciones (SQL Script)
Para crear las tablas solicitadas en la prueba (independientes del módulo de libros):
1.  Abrir **SQL Server Management Studio (SSMS)**.
2.  Ejecutar el script `database_setup.sql` ubicado en la raíz de este repositorio.

### 2. Módulo de Libros (Entity Framework Core)
El proyecto utiliza **EF Core Code-First**. La base de datos `PruebaTecnicaDB` se crea y actualiza automáticamente mediante migraciones.

#### Cadena de Conexión
La configuración se encuentra en `PruebaTecnicaMvc/appsettings.json`.
Por defecto está configurada para:
*   **Servidor**: `TS-MJARAMILLO\MSSQLSERVER2025`
*   **Autenticación**: Windows (`Trusted_Connection=True`)

Si necesitas cambiar el servidor, edita la sección `ConnectionStrings`:
```json
"DefaultConnection": "Server=TU_SERVIDOR;Database=PruebaTecnicaDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
```

## Ejecución del Proyecto

1.  Navegar a la carpeta del proyecto:
    ```bash
    cd PruebaTecnicaMvc
    ```

2.  Aplicar migraciones pendientes (si es la primera vez):
    ```bash
    dotnet ef database update
    ```

3.  Ejecutar la aplicación:
    ```bash
    dotnet run
    ```

4.  Abrir el navegador en la URL indicada (generalmente `http://localhost:5108`).

## Estructura del Proyecto

*   **Models/Libro.cs**: Modelo de datos con validaciones (`Required`, `Display`, `Range`).
*   **Controllers/LibrosController.cs**: Controlador para gestionar el listado y creación de libros.
*   **Views/Libros/**: Vistas Razor para `Index` y `Crear`, utilizando estilos de Bootstrap.
*   **Data/AppDbContext.cs**: Contexto de base de datos de Entity Framework.
