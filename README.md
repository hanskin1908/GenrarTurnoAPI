
# Instrucciones para la Prueba del Desarrollador .NET

Este repositorio contiene los scripts y pasos necesarios para realizar la prueba del desarrollador .NET. Sigue las siguientes instrucciones:

## Pasos de Configuración

1. Ejecuta el script `01_Create e InsertTable` para crear e insertar la tabla necesaria.
2. Ejecuta el script del stored procedure `02_StoreProcedure_GenerarTurnos`.
3. Opcional: Ejecuta el stored procedure con el comando `03_Exec storeprocedure GenerarTurnos` si es necesario.
4. Cambia el nombre del servidor y de la base de datos en el archivo `appsettings.Development`.


## Evidencia de Prueba Unitaria Exitosa

Asegúrate de incluir evidencia de la prueba unitaria exitosa en esta sección.

## Evidencia de Prueba en Swagger

Incluye pruebas de escenarios exitosos utilizando Swagger en esta sección.

## Evidencia de Escenario: Formato Incorrecto de Fecha

Añade evidencia de prueba para escenarios donde se presenta un formato incorrecto de fecha.

### Notas Importantes

- Si se envía una fecha que ya tiene turnos asignados, la base de datos devolverá un mensaje indicando que ya existe y mostrará solo los registros actuales ya existentes.
  
- Si se envía una fecha nueva que no tiene turnos asignados, se devolverá el total de registros asignados para ese servicio.
