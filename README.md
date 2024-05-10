# VetApp - Aplicación Veterinaria🐶

`VetApp` es una aplicación que nace con la necesidad de una veterinaria que desea optimizar sus recursos.

Desde `Dima` los usuarios de la veterinaria pueden: Agregar un cliente, Ver inventario, Agregar una mascota, Agendar una cita, Realizar un metodo de pago y tener un historal.
---

**Tecnologías utilizadas:**

<a href="https://dotnet.microsoft.com/en-us/learn/csharp" title="C#"><img src="Dima/Dima/Readme_Images/csharp.png" height="55px"/></a>
<a href="https://www.w3schools.com/html/" title="HTML"><img src="Dima/Dima/Readme_Images/html.png" height="55px"/></a>
<a href="https://www.w3schools.com/css/" title="CSS"><img src="Dima/Dima/Readme_Images/css.png" height="55px"/></a>
<a href="https://getbootstrap.com/" title="Bootstrap"><img src="Dima/Dima/Readme_Images/bootstrap.png" height="55px"/></a>
<a href="https://git-scm.com/" title="Git"><img src="Dima/Dima/Readme_Images/git.png" height="55px"/></a>
<a href="https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver16" title="SQL Server Management Studio SSMS"><img src="Dima/Dima/Readme_Images/sql.png" height="55px"/></a>
<a href="https://www.postman.com/" title="Postman"><img src="Dima/Dima/Readme_Images/postman.png" height="55px"/></a>

## Secciones

## Configura Dima localmente

**Script**

Copiar el contenido del archivo llamado `script.sql` ubicado en la carpeta `ProyectoDimaWeb/SQL`

**SQL Server Management Studio SSMS**

Pegar y ejecutar el script en [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

**Dima API**

Se debe agregar el modelo de la base de datos al proyecto API siguiendo los siguientes pasos:

* Primero debe ir al archivo llamado `Web.config` ubicado en la raíz de la carpeta llamada `Dima_Api` ubicada en `ProyectoDimaWeb/`
    * Una vez esté en el archivo llamado `Web.config` busque la etiqueta `<connectionStrings> </connectionStrings>` y **asegurese** que la etiqueta esté **vacía**. **NO** eliminar las etiquetas
* Una vez se **aseguró** las etiquetas **sí** existen, pero están **vacías**, dar clic derecho sobre la carpeta llamada `ModeloBD`
* Clic  en `Aregar` y en `Nuevo elemento`
* Seleccionar `Datos` de las opciones de la izquierda
* Seleccionar la opción `ADO.NET Entity Data Model` y `Seleccionar`
* Clic en `EF Designer desde base de datos` y `Siguiente`
* `Nueva conexión...`
* En nombre del servido colocar el exactamente el mismo que muestra SQL Server Management Studio para crear una conexión
* Dar clic en el dropdown `Seleccionar o escribir el nombre de la base de datos:` y seleccionar la base de datos llamada `docmed` y `Aceptar`
* La ventana se cerrará, dar clic en `Siguiente`
* Desplegar la primera opción llamada `Tablas` y marcar la opción `dbo` y la última llamada `Funciones y procedimientos alamacenados` y marcar la opción `dbo`
* Por último dar clic en `Finalizar` y esperar al rededor de 35 segundos
* Una vez se haya generado el model saldrá una advertencia, dar clic en `Sí a todo`
