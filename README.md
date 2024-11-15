# Prueba Técnica: Sistema de Gestión de Archivos Médicos RRHH

## Objetivo
Desarrollar un sistema de gestión de archivos médicos para el departamento de RRHH, implementando una API RESTful que permita gestionar los registros médicos de los empleados.

## Requisitos Técnicos Obligatorios
- .NET 8
- PostgreSQL **(entorno local)**
- Entity Framework Core (Database first, Fluent API)
- AutoMapper
- Patrón Repository
- Patrón Service
- Swagger para documentación de API
- FluentValidation

## Estructura de Base de Datos

### Database Name: **RRHH_DB**

### Tabla: T_ARCHIVO_MEDICO
```sql
CREATE TABLE T_ARCHIVO_MEDICO (
    ID_ARCHIVO_MEDICO SERIAL PRIMARY KEY,
    AUDIOMETRIA VARCHAR(2),
    CAMBIO_PUESTO VARCHAR(2),
    DATOS_MADRE VARCHAR(2000),
    DIAGNOSTICO VARCHAR(100),
    DATOS_OTRO_FAMILIAR VARCHAR(2000),
    DATOS_PADRE VARCHAR(2000),
    EJECTUAR_MICROS VARCHAR(2),
    EJECUTAR_EXTRA VARCHAR(2),
    EVALUACION_VOZ VARCHAR(2),
    FEC_BAJA DATE,
    FEC_ING DATE,
    FEC_MOD DATE,
    FECHA_FIN DATE,
    FECHA_INICIO DATE,
    ID_ESTADO INTEGER,
    ID_TIPO_ARCHIVO_MEDICO INTEGER,
    INCAPACIDAD VARCHAR(2),
    JUNTA_MEDICA VARCHAR(200),
    MOTIVO_BAJA VARCHAR(2000),
    OBSERVACIONES VARCHAR(2000),
    PORCENTAJE_INCAP NUMERIC(10),
    USER_BAJA VARCHAR(2000),
    USER_ING VARCHAR(2000),
    USER_MOD VARCHAR(2000),
    CAMBIO_AREA VARCHAR(2)
);

CREATE TABLE ESTADO (
    ID_ESTADO SERIAL PRIMARY KEY,
    NOMBRE VARCHAR(100),
    DESCRIPCION VARCHAR(500)
);

CREATE TABLE TIPO_ARCHIVO_MEDICO (
    ID_TIPO_ARCHIVO_MEDICO SERIAL PRIMARY KEY,
    NOMBRE VARCHAR(100),
    DESCRIPCION VARCHAR(500)
);

ALTER TABLE T_ARCHIVO_MEDICO
ADD CONSTRAINT FK_ID_ESTADO_ARCHIVO
FOREIGN KEY (ID_ESTADO) REFERENCES ESTADO(ID_ESTADO);

ALTER TABLE T_ARCHIVO_MEDICO
ADD CONSTRAINT FK_ID_TIPO_ARCHIVO
FOREIGN KEY (ID_TIPO_ARCHIVO_MEDICO) REFERENCES TIPO_ARCHIVO_MEDICO(ID_TIPO_ARCHIVO_MEDICO);

-- Datos iniciales para pruebas
INSERT INTO ESTADO (NOMBRE, DESCRIPCION) VALUES 
('Activo', 'Archivo médico activo'),
('Inactivo', 'Archivo médico inactivo');

INSERT INTO TIPO_ARCHIVO_MEDICO (NOMBRE, DESCRIPCION) VALUES 
('Regular', 'Archivo médico regular'),
('Especial', 'Archivo médico especial');
```

## Requerimientos Funcionales

### 1. Endpoints a Implementar
- **GetFilterArchivosMedicos**: Listado de archivos médicos con paginación y filtros. Se debera poder filtrar por ID_ESTADO (opcional), FECHA_INICIO (opcional), FECHA_FIN (opcional) y ID_TIPO_ARCHIVO_MEDICO (opcional).
    Page y PageSize son parámetros obligatorios.
- **GetArchivMedicoById**: Obtener archivo médico por ID. Obtener una descripcion mas detallada y formateada del archivo médico.
- **AddArchivoMedico**: Crear nuevo archivo médico. Se deberá validar que los campos obligatorios estén presentes y que cumplan con las reglas de validación.
- **UpdateArchivoMedico**:Actualizar archivo médico existente. Se deberá validar que los campos obligatorios estén presentes y que cumplan con las reglas de validación.
- **DeleteArchivoMedico**: Eliminar archivo médico (baja lógica)

### 2. Validaciones Requeridas

#### 2.1 Control de Fechas
- La FECHA_INICIO no puede ser mayor a FECHA_FIN
- La FECHA_INICIO no puede ser una fecha futura
- Si existe FECHA_FIN, debe ser mayor a FECHA_INICIO
- FEC_ING (Fecha de Ingreso) es obligatoria y debe ser autogenerada al insertar el dato

#### 2.2 Campos Requeridos
Los siguientes campos son obligatorios:
- DIAGNOSTICO
- FECHA_INICIO
- ID_ESTADO
- ID_TIPO_ARCHIVO_MEDICO
- ID_LEGAJO
- USER_ING

#### 2.3 Validación de Registros Relacionados
- ID_ESTADO debe existir en la tabla ESTADO
- ID_TIPO_ARCHIVO_MEDICO debe existir en la tabla TIPO_ARCHIVO_MEDICO
- No se puede dar de baja un registro si no se proporciona MOTIVO_BAJA
- Al crear o modificar un registro, el estado debe ser válido según las siguientes reglas:
  * No se puede asignar un estado 'Inactivo' al crear un nuevo registro
  * Para cambiar a estado 'Inactivo' debe proporcionarse MOTIVO_BAJA

#### 2.4 Validación de Longitud Máxima
- DIAGNOSTICO: máximo 100 caracteres
- DATOS_MADRE: máximo 2000 caracteres
- DATOS_PADRE: máximo 2000 caracteres
- DATOS_OTRO_FAMILIAR: máximo 2000 caracteres
- JUNTA_MEDICA: máximo 200 caracteres
- MOTIVO_BAJA: máximo 2000 caracteres
- OBSERVACIONES: máximo 2000 caracteres
- Campos de dos caracteres (deben ser 'SI' o 'NO'):
  * AUDIOMETRIA
  * CAMBIO_PUESTO
  * EJECTUAR_MICROS
  * EJECUTAR_EXTRA
  * EVALUACION_VOZ
  * INCAPACIDAD
  * CAMBIO_AREA

#### 2.5 Control de Estados Válidos
Estados permitidos y sus reglas:
1. Activo (ID: 1)
   - Estado inicial por defecto para nuevos registros
   - Permite modificación de todos los campos
   - Requiere USER_ING

2. Inactivo (ID: 2)
   - Requiere MOTIVO_BAJA
   - Requiere FECHA_FIN
   - Requiere USER_BAJA
   - No permite modificaciones posteriores
   - Debe registrar FEC_BAJA

#### 2.6 Reglas Adicionales de Validación
- PORCENTAJE_INCAP debe estar entre 0 y 100 cuando INCAPACIDAD = 'SI'
- Si CAMBIO_PUESTO = 'SI', el campo OBSERVACIONES es obligatorio
- Si existe FECHA_FIN, el registro debe pasar a estado Inactivo
- Los campos USER_ING, USER_MOD y USER_BAJA deben registrar el usuario que realiza la operación
- FEC_MOD debe actualizarse automáticamente al modificar cualquier campo

### 3. Manejo de Respuestas

#### 3.1 Modelo de Respuesta Base
```csharp
public class BaseResponse<T>
{
    public bool? Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int? Code { get; set; }
    public int? TotalRows { get; set; }
    public string? Exception { get; set; }
}
```

#### 3.2 Códigos de Respuesta HTTP
- 200 OK: Petición exitosa (GET, PUT/PATCH)
- 400 Bad Request: Errores de validación
- 404 Not Found: Recurso no encontrado
- 500 Internal Server Error: Errores no controlados

## Entregables
1. Repositorio Git con el código fuente completo
2. Instrucciones de instalación y ejecución en el README

## Criterios de Evaluación
- Estructura y organización del código
- Implementación correcta de patrones solicitados
- Manejo de validaciones y excepciones
- Uso adecuado de AutoMapper
- Código limpio y comentado adecuadamente
- Correcta aplicacion de Gitflow (Main -> Development -> Feat)

## Tiempo de Entrega
- 5 días hábiles desde la recepción de la prueba
- La entrega se confimara mediante la creacion de una PR Release a main

## Instrucciones de Instalación
## 1. Instalar PostgreSQL
1. **Descargar** PostgreSQL desde el siguiente enlace: [PostgreSQL Downloads](https://www.postgresql.org/download/)
2. **Instalar PostgreSQL** siguiendo el asistente de instalación.
3. Durante la instalación, se abrirá una terminal donde se pedirá indicar el puerto donde escucha PostgreSQL.  
   - Por defecto, el puerto de PostgreSQL es **5432**.
4. También se pedirá configurar una contraseña para el usuario.  
   - El **usuario por defecto** es **postgres**.

## 2. Ejecutar el script de base de datos
Para administrar PostgreSQL,se puede elegir una de las siguientes herramientas:

- **PgAdmin**: [Descargar PgAdmin](https://www.pgadmin.org/)
- **Azure Data Studio**: [Descargar Azure Data Studio](https://learn.microsoft.com/en-us/azure-data-studio/download-azure-data-studio?view=sql-server-ver16&tabs=win-install%2Cwin-user-install%2Credhat-install%2Cwindows-uninstall%2Credhat-uninstall)
- **DataGrip**: [Descargar DataGrip](https://www.jetbrains.com/datagrip/download/#section=windows)

Una vez instalada la herramienta:

1. Conéctarse al motor de base de datos PostgreSQL. Dependiendo de la herramienta seleccionada, es posible que sea necesario instalar un plugin para conectarte a PostgreSQL.
2. Conéctarse utilizando el servidor **localhost**, el **puerto 5432** o el puerto configurado durante la instalación, y las credenciales del usuario creado (nombre de usuario y contraseña).
3. Ejecuta el script SQL (`DBScript.Sql` en la carpeta fuente del proyecto) para crear la base de datos y sus respectivas tablas.

## 3. Configurar Entity Framework Core y ejecutar Scaffold-DbContext
Si hay algún cambio en el modelo, probablemente será necesario ejecutar el siguiente comando desde la consola del administrador de Paquetes NuGet de Visual Studio:

```bash
Scaffold-DbContext "Host=HOST:PUERTO;Database=DATABASE_NAME;Username=USER_NAME;Password=USER_PASS" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models
Donde Host es el Host de nuestro DBMS, por defecto localhost; PUERTO: el puerto que configuramos previamente, por defecto es 5432.
USER_NAME y USER_PASS son el usuario y contraseña creados previamente.

## 4. Configurar el proyecto (cadena de conexión, DbContext, etc.)
1. Antes de ejecutar el proyecto, dirígete al archivo `appsettings.json` y modifica la cadena de conexión llamada `ChallengeConnectionString` con los siguientes parámetros:

```json
"ChallengeConnectionString": "Host=HOST_IP;Port=PUERTO;Database=DATABASE_NAME;Username=USER_NAME;Password=USER_PASS"

Donde HOST_IP es el ip de la maquina host, debido a que el proyecto se corre desde un Dockerfile, para que se pueda comunicar con la BD de la maquina host y no el localhost del Contenedor de Docker.
Se puede obtener utilizando el comando ipconfig en Windows, donde indica Dirección IPv4.
PUERTO es el puerto configurado previamente y los demas campos se rellenan como fue indicado previamente.

## Extras (No Obligatorios)
- Docker

## Formato de Entrega
- Repositorio Git (GitHub, GitLab, Bitbucket)
- El repositorio debe incluir este README actualizado con las instrucciones de instalación específicas de tu implementación

---
*Nota: Para cualquier duda o aclaración sobre los requerimientos, por favor crear un issue en el repositorio.*
