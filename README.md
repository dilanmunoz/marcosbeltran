# Sistema de Gestión de Tareas (Task Manager)

Este es un proyecto web desarrollado con **ASP.NET MVC** que permite gestionar tareas de manera sencilla.

## Funcionalidades principales

- Crear nueva tarea
- Ver listado de tareas
- Editar tarea existente
- Eliminar tarea
- Marcar como completada o no completada

## Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

- Visual Studio 2022 (o superior)
- .NET Framework (versión usada en el proyecto)
- SQL Server Express
- SQL Server Management Studio (opcional)
- NuGet actualizado

## Instrucciones de instalación

### 1. Clonar o descargar el proyecto

Puedes clonar el repositorio desde GitHub:

git clone https://github.com/usuario/repositorio.git


O descargar el proyecto como archivo ZIP y descomprimirlo en tu máquina.

### 2. Abrir la solución en Visual Studio

Haz doble clic en el archivo `.sln` incluido en el proyecto para abrirlo con Visual Studio.

### 3. Restaurar los paquetes NuGet

Visual Studio normalmente lo hace automáticamente al abrir el proyecto. Si no es así:

- Haz clic derecho sobre la solución
- Selecciona **"Restore NuGet Packages"**

### 4. Configurar la cadena de conexión

Asegúrate de que la cadena de conexión en el archivo `Web.config` esté configurada correctamente. Debe apuntar a tu instancia local de SQL Server Express. Por ejemplo:

<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=task;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>

Puedes modificar `Initial Catalog` si deseas usar otro nombre para la base de datos.

### 5. Crear la base de datos

Este proyecto utiliza **Entity Framework con enfoque Code First**, lo que significa que la base de datos se genera automáticamente a partir del modelo.

Sigue estos pasos:

1. Abre la consola del administrador de paquetes:  
   En Visual Studio, ve a **Tools > NuGet Package Manager > Package Manager Console**.

2. Ejecuta el siguiente comando para aplicar las migraciones y crear la base de datos:

   Update-Database


Esto generará la base de datos en tu servidor SQL local con las tablas necesarias.

### 6. Ejecutar la aplicación

Presiona `F5` o haz clic en el botón de **Iniciar** en Visual Studio. Esto compilará el proyecto y abrirá la aplicación en tu navegador por defecto.

## Notas técnicas

- Las vistas utilizan un layout compartido (`_Layout.cshtml`) y diseño responsive con Bootstrap.
- Se aplican validaciones en cliente y servidor.
- Se usan `TempData` para mostrar mensajes de éxito o error después de las operaciones.
- Se implementaron migraciones para facilitar el despliegue con Entity Framework.

