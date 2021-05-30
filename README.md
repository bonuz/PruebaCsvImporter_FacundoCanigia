# CsvImporter - Facundo Canigia

## Requirements:
- desarrollar un programa de consola .NET Core en C#, que lea un fichero .csv e inserte su contenido en una BD
- el programa es para Acme Corporation (un clásico) y se debe llamar CsvImporter
- el fichero .csv está disponible en https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV
- antes de insertar en la BD, tendrás que eliminar el contenido de una posible previa importación
- además de un código bien escrito, siguiendo las mejoras prácticas, nos importa el tiempo de proceso y el consumo de recursos (RAM, CPU, etc.) ¡tenlo en cuenta!
- en la inserción puedes asumir que no es necesaria una transacción.
- si usas sabiamente el framework, te ayudará con la configuración, registro de dependencias, logging, etc.
- por supuesto, si acompañas tu código de testing, serás nuestro mejor amigo.
- podrás usar las librerías que creas oportuno.
- también nos gustaría saber el porqué de las decisiones que tomaste (y también de las que descartaste).
- si acompañas el proyecto con un buen README.md, ¡nos harías muy felices!
- por último, si consideras necesario agregar algo de testing automatizado para ganar más confianza, ¡nunca viene mal!

## Stack:
 
.Net Core 3.1  
C# 
MS SQL Server Express 2019 

### Libraries:
FastMember 
Microsoft.Extensions.Configuration  
Microsoft.Extensions.DependencyInjection  
Microsoft.Extensions.Hosting  
System.Net.WebClient  
System.Data.SqlClient  
NUnit  

## Test files:
Original: https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV  
1000 rows w/header: https://csvimporteraa.blob.core.windows.net/csvfiles/OriginalStock_1000Rows.CSV  
30 rowsw/header: https://csvimporteraa.blob.core.windows.net/csvfiles/OriginalStock_30Rows.CSV  

## Database

Name: Importer

### Tables

#### dbo.Stock
| Row | Type |
| ------ | ------ |
| StockId | int |
| PointOfSale |varchar(50) |
| Product | varchar(50)|
| Date | varchar(50) |
| Stock | int |

#### dbo.DownloadedFiles
| Row | Type |
| ------ | ------ |
| FileId | int |
| DownloadDate | datetime |
| FileName | varchar(50) |
| InsertedRows | int |


