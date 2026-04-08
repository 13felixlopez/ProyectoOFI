# ProyectoOFI (Dry System OFI)

Aplicacion de escritorio en C# WinForms para controlar el flujo operativo del beneficio de cafe: recepcion, secado, analisis, almacen y reporteria.

Este README esta escrito para que puedas construir un diagrama de flujo directamente (incluyendo GitDiagram) a partir de los bloques y transiciones aqui definidos.

## Objetivo funcional

El sistema recibe tickets/lotes de cafe, les da seguimiento por etapas de proceso, registra resultados operativos y de calidad, y genera reportes para control y toma de decisiones.

## Componentes del sistema

- UI principal: `Login` + `FrmMenu` + UserControls/Formularios por modulo.
- Capa de negocio/modelo: carpeta `Logica` (`L*`).
- Capa de acceso a datos: carpeta `Datos` (`D*`, SQL Server + Stored Procedures).
- Persistencia externa:
  - SQL Server.
  - `ConnectionString.xml` (cadena cifrada AES).
  - `C:\Log\logerror.txt` (errores).
- Integracion opcional HTTP: `Services/ApiService.cs` (`/api/ExcelLotesExcelCP`).

## Flujo principal del sistema (listo para diagramar)

### Nodos

- `N1_InicioAplicacion`
- `N2_CargarConfiguracionConexion`
- `N3_ValidarConexionSQL`
- `N4_MostrarPantallaConexion`
- `N5_IntentoLogin`
- `N6_ValidarCredenciales`
- `N7_MostrarMenuPrincipal`
- `N8_CargarPermisosUsuario`
- `N9_SeleccionModulo`
- `N10_EjecutarOperacionModulo`
- `N11_GuardarCambiosEnBD`
- `N12_GenerarReporte`
- `N13_CerrarSesion`
- `N14_SalirSistema`
- `N_ERR_RegistrarError`

### Decisiones

- `D1_ConexionValida?`
- `D2_CredencialesValidas?`
- `D3_UsuarioEsAdmin?`
- `D4_OperacionExitosa?`
- `D5_AccionUsuario` (Seleccion modulo / Cerrar sesion / Salir)

### Transiciones

- `N1_InicioAplicacion -> N2_CargarConfiguracionConexion`
- `N2_CargarConfiguracionConexion -> N3_ValidarConexionSQL`
- `N3_ValidarConexionSQL -> D1_ConexionValida?`
- `D1_ConexionValida? (Si) -> N5_IntentoLogin`
- `D1_ConexionValida? (No) -> N4_MostrarPantallaConexion`
- `N4_MostrarPantallaConexion -> N2_CargarConfiguracionConexion`
- `N5_IntentoLogin -> N6_ValidarCredenciales`
- `N6_ValidarCredenciales -> D2_CredencialesValidas?`
- `D2_CredencialesValidas? (No) -> N5_IntentoLogin`
- `D2_CredencialesValidas? (Si) -> N7_MostrarMenuPrincipal`
- `N7_MostrarMenuPrincipal -> N8_CargarPermisosUsuario`
- `N8_CargarPermisosUsuario -> D3_UsuarioEsAdmin?`
- `D3_UsuarioEsAdmin? (Si) -> N9_SeleccionModulo (Acceso total)`
- `D3_UsuarioEsAdmin? (No) -> N9_SeleccionModulo (Acceso segun permisos)`
- `N9_SeleccionModulo -> D5_AccionUsuario`
- `D5_AccionUsuario (Seleccion modulo) -> N10_EjecutarOperacionModulo`
- `D5_AccionUsuario (Cerrar sesion) -> N13_CerrarSesion`
- `D5_AccionUsuario (Salir) -> N14_SalirSistema`
- `N10_EjecutarOperacionModulo -> D4_OperacionExitosa?`
- `D4_OperacionExitosa? (Si, cambia datos) -> N11_GuardarCambiosEnBD`
- `D4_OperacionExitosa? (Si, consulta/reporte) -> N12_GenerarReporte`
- `D4_OperacionExitosa? (No) -> N_ERR_RegistrarError`
- `N11_GuardarCambiosEnBD -> N9_SeleccionModulo`
- `N12_GenerarReporte -> N9_SeleccionModulo`
- `N_ERR_RegistrarError -> N9_SeleccionModulo`
- `N13_CerrarSesion -> N5_IntentoLogin`
- `N14_SalirSistema -> FIN`

## Subflujos por modulo (narrativa funcional)

### 1) Transferencia / Recepcion

- Entrada: datos de ticket/lote recibido.
- Proceso: registro inicial, validaciones, persistencia.
- Salida: lote disponible para seguimiento en etapas posteriores.

Flujo:

- `M1_Recepcion_Inicio -> M1_ValidarDatos -> M1_GuardarRecepcion -> M1_ActualizarEstadoLote -> M1_Fin`

### 2) Secado Natural (Control Patio)

- Entrada: lotes en proceso natural.
- Proceso: seguimiento por etapas, filtros, paginacion, actualizacion de estado.
- Salida: avance del lote (tendido/enfarde/envio segun reglas de negocio).

Flujo:

- `M2_CP_Inicio -> M2_ListarLotes -> M2_SeleccionarLote -> M2_EditarProceso -> M2_GuardarCambios -> M2_Fin`

### 3) Secado Mecanico (SM)

- Entrada: lotes para secado mecanico.
- Proceso: operaciones de POA/PS/verticales/guardiolas/tolvas (segun pantalla usada).
- Salida: estado actualizado para seguimiento y reportes.

Flujo:

- `M3_SM_Inicio -> M3_SeleccionSubprocesoSM -> M3_RegistrarOperacion -> M3_GuardarEnBD -> M3_Fin`

### 4) Analisis (Muestras y Catacion)

- Entrada: lote disponible para control de calidad.
- Proceso: registro de muestra, catacion, metricas de rendimiento/calidad.
- Salida: resultados de analisis asociados al ticket.

Flujo:

- `M4_Analisis_Inicio -> M4_RegistrarMuestra -> M4_RegistrarCatacion -> M4_GuardarResultados -> M4_Fin`

### 5) Bodega (Almacen y Compra Directa)

- Entrada: lotes listos para almacen o compra directa.
- Proceso: ubicacion, empaque, pesos, movimientos y consolidacion.
- Salida: inventario actualizado y trazabilidad de movimientos.

Flujo:

- `M5_Bodega_Inicio -> M5_SeleccionOperacion -> M5_RegistrarMovimiento -> M5_GuardarMovimiento -> M5_Fin`

### 6) Reportes

- Entrada: informacion historica/operativa de BD.
- Proceso: consultas y agregaciones (ticket, historial, dashboard, consolidaciones, digitacion).
- Salida: visualizacion o exportacion de reporte.

Flujo:

- `M6_Reportes_Inicio -> M6_SeleccionTipoReporte -> M6_ConsultarDatos -> M6_MostrarExportar -> M6_Fin`

### 7) Configuracion

- Entrada: accion administrativa.
- Proceso: gestion de usuarios, catalogos y perfil.
- Salida: parametros maestros y accesos actualizados.

Flujo:

- `M7_Config_Inicio -> M7_SeleccionEntidad -> M7_CrearEditarEliminar -> M7_GuardarCambios -> M7_Fin`

## Mapa de carpetas (referencia para GitDiagram)

- `ProyectoOFI/Program.cs`: punto de entrada.
- `ProyectoOFI/Login.cs`: autenticacion y validacion de conexion.
- `ProyectoOFI/FrmConexionIP.cs`: configuracion manual de conexion SQL.
- `ProyectoOFI/FrmMenu.cs`: orquestador de modulos.
- `ProyectoOFI/Datos/`: consultas y ejecucion de SPs.
- `ProyectoOFI/Logica/`: entidades y utilidades (AES, encriptacion).
- `ProyectoOFI/Recepcion/`, `ControlPatio/`, `SM/`, `Analisis/`, `Almacen/`, `Compras/`, `Reportes/`, `Usuario/`, `Otros/`: modulos funcionales.
- `ProyectoOFI/Services/ApiService.cs`: cliente HTTP auxiliar.
- `ProyectoOFI/CoffeeTech.sql` y `ProyectoOFI/Ultima.sql`: scripts de base de datos.

## Requisitos de ejecucion

- Windows.
- Visual Studio 2022.
- .NET Framework 4.8.
- SQL Server accesible.
- Restauracion de paquetes NuGet del proyecto.

## Ejecucion local

1. Abrir `ProyectoOFI.sln`.
2. Restaurar NuGet.
3. Compilar (`Debug` o `Release`).
4. Ejecutar.
5. Si no hay conexion valida, configurar desde pantalla de conexion y reiniciar.

## Convencion recomendada para usar GitDiagram

Si quieres maximizar el resultado del diagrama:

- Usa la seccion `Flujo principal del sistema` como diagrama general.
- Usa `Subflujos por modulo` como diagramas hijos.
- Interpreta cada linea `Origen -> Destino` como arista.
- Interpreta nodos `D*` como rombos (decision) y `N*`/`M*` como procesos.
