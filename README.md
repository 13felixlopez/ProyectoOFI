# ProyectoOFI (Dry System OFI)

Aplicacion de escritorio en **C# WinForms (.NET Framework 4.8)** para gestionar el flujo operativo del beneficio de cafe: recepcion, secado, analisis, almacen, reporteria y administracion de catalogos/usuarios.

Este README describe **solo** lo que existe en este repositorio.

## 1. Tecnologias y arquitectura

- UI: WinForms (`ProyectoOFI`).
- Base de datos: SQL Server (uso intensivo de procedimientos almacenados en la capa `Datos`).
- Estructura por capas:
  - `Logica/`: modelos/DTOs y utilidades (encriptacion, etc.).
  - `Datos/`: acceso SQL (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`).
  - `Forms/UserControls`: modulos funcionales.
- Integraciones:
  - Excel/archivos: `DocumentFormat.OpenXml`, `ExcelDataReader`, `NPOI`.
  - API HTTP local: `Services/ApiService.cs` (base URL configurada en codigo).

## 2. Flujo de arranque y operacion

1. `Program.cs` inicia el formulario `Login`.
2. `Login`:
   - valida conexion a SQL Server.
   - autentica usuario con SP (`Login`) usando password encriptada.
   - abre `FrmMenu` al autenticar.
3. `FrmMenu` carga los modulos dentro de `PlPrincipal` segun opcion seleccionada.
4. Permisos:
   - se consultan por usuario (`PermisosUser`).
   - el usuario cuyo login inicia con `Admin` obtiene acceso completo.

## 3. Modulos funcionales principales

Desde `FrmMenu`:

- `Transferencia` (Recepcion).
- `Secado`:
  - Secado Natural (`ControlPatio`).
  - Secado Mecanico (`SM`).
- `Analisis`:
  - `Muestras`.
  - `Catacion`.
- `Bodega`:
  - `Almacen`.
  - `Compra Directa`.
- `Reportes`:
  - Reporte Ticket.
  - Historial.
  - Dashboard.
  - Consolidaciones.
  - Digitacion.
- `Config`:
  - Usuario.
  - Catalogo.
  - Perfil.

## 4. Estructura de carpetas

Raiz:

- `ProyectoOFI.sln`: solucion principal.
- `ProyectoOFI/`: proyecto WinForms productivo.
- `Datos/`: proyecto de libreria legado (no referenciado por la solucion actual).
- `README.md`: este documento.

Dentro de `ProyectoOFI/`:

- `Program.cs`, `Login.cs`, `FrmMenu.cs`: arranque y navegacion principal.
- `Datos/`: repositorio SQL por modulo (`DControlPatio`, `DAlmacen`, `DReporte`, etc.).
- `Logica/`: entidades de negocio (`L*`) y utilidades de seguridad.
- `Recepcion/`, `ControlPatio/`, `SM/`, `Analisis/`, `Almacen/`, `Compras/`, `Reportes/`, `Usuario/`, `Otros/`: modulos de interfaz/operacion.
- `Services/`: cliente HTTP (`ApiService`).
- `Resources/`: iconos/imagenes/recursos visuales.
- `CoffeeTech.sql`, `Ultima.sql`: scripts de base de datos.

## 5. Requisitos para ejecutar en desarrollo

- Windows con Visual Studio 2022 (o MSBuild compatible con proyectos .NET Framework).
- .NET Framework 4.8 Developer Pack.
- SQL Server accesible desde la maquina cliente.
- Restaurar paquetes NuGet definidos en `ProyectoOFI.csproj`.

## 6. Configuracion de conexion a base de datos

La app usa un archivo local `ConnectionString.xml` con la cadena cifrada (AES).

- Si no existe, se crea automaticamente al iniciar con valor placeholder.
- El formulario `FrmConexionIP` permite configurar:
  - servidor,
  - base de datos,
  - usuario,
  - password.
- Al guardar, la app cifra la cadena y reinicia.

Notas:

- Se registran errores en `C:\Log\logerror.txt`.
- En el login hay una opcion oculta para mostrar cambio de servidor (clic derecho repetido en la etiqueta de acceso).

## 7. Base de datos

El repositorio incluye scripts SQL completos:

- `ProyectoOFI/CoffeeTech.sql`
- `ProyectoOFI/Ultima.sql`

Ambos crean estructura de BD (tablas, tipos, SPs, etc.) con nombres de base diferentes segun version del script (`OFI` y `coffeetec`).

## 8. Compilacion y ejecucion

Desde Visual Studio:

1. Abrir `ProyectoOFI.sln`.
2. Restaurar paquetes NuGet.
3. Compilar en `Debug` o `Release`.
4. Ejecutar (`F5`) y configurar conexion en el login si aplica.

Desde linea de comandos (MSBuild Developer Command Prompt):

```powershell
msbuild .\ProyectoOFI.sln /p:Configuration=Debug
```

## 9. Observaciones tecnicas relevantes

- El acceso a datos esta fuertemente acoplado a SQL Server y SPs.
- Parte de la funcionalidad de `ControlPatio` puede consumir un endpoint HTTP local (`/api/ExcelLotesExcelCP`).
- El proyecto tiene gran volumen de formularios y recursos embebidos; es un sistema de escritorio monolitico modular.

## 10. Alcance de este repositorio

Este codigo representa la **aplicacion de escritorio WinForms** y sus scripts SQL asociados.
No documenta aplicaciones moviles, servicios externos adicionales ni infraestructura fuera de lo versionado aqui.
