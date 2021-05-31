# CsvImporter - Facundo Canigia

![CsvImporter](https://i.imgur.com/2Ha1fgR.png)

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

## Features

### Execution time and resource usage
- download file: between 2m and 3m, 100mb connection 

> `Successfully Downloaded File "https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV" in 00:03:14.12`

- open and parse 17m rows: more or less 1 minute 

> `Elapsed time to open file and transform to object list 00:01:08.38`

- bulk insert 17m rowns: less than a minute 

> `Elapsed time to insert rows 00:00:45.72`


Running from VS 2019 (not code):
- CPU usage is around 8% during all the process. 
- RAM usage between 3.8gb and 6gb. 

From EXE:
- Download: 
![CsvImporter](/Other/resources.png)
- Open and parse: 
![CsvImporter](/Other/transform.png)
- Bulk insert: 
![CsvImporter](/Other/bulk.png)

### Configuration file (appsettings.json)
File: 

```sh
"CSVImporter": {
    "BatchSize": 10000,
    "DestinationFolder": "C:\\DEV\\CSharp\\CsvImporter\\CsvImporter\\DownloadedFiles\\",
    "FileUrl": "https://storage10082020.blob.core.windows.net/y9ne9ilzmfld/Stock.CSV",
    "Title": "PointOfSale;Product;Date;Stock"
},
"ConnectionStrings": {  
    "Default": "Data Source=BONUZKTOP\\FNCSQL;Initial Catalog=Importer;Integrated Security=True;"
}  
```
#### Parameters
BatchSize: batch size of the bulk insert can be configured. This will change the ratio between ram and cpu. 
DestinationFolder: folder where the downloaded files will be saved. 
FileUrl: url of the file with the stock information. 
Title: title text in the file, first row. 

### Unit Testing
Tests:

- ImportOriginalFile
- ImportTestFile1000Rows
- ImportTestFile30Rows
- ImportTestFile1000RowsWithoutTitleInFile
- Download1000RowsFileAndCheckIfExists
- Download30RowsFileAndCheckIfExists

### Other

- StopWatch
- ILogger
- DI

## How?

1. Start the application.
2. Read stock file url and start downloading it, using WebClient (System.Net).
3. Once downloaded, it is opened using a StreamReader and saved as a list of strings.
4. Then that list is converted to a list of Stock objects.
5. Finally, and using SqlBulkCopy, that list is inserted in the database.
6. Cleanup and close.

### Discarded

Tried to convert the file contents to an array/list and then to a data table, this resulted in an even slower process.

```sh
private DataTable GetStockToInsert(string filePath)
{
    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("PointOfSale", typeof(string)));
    dt.Columns.Add(new DataColumn("Product", typeof(string)));
    dt.Columns.Add(new DataColumn("Date", typeof(string)));
    dt.Columns.Add(new DataColumn("Stock", typeof(int)));
    dt.Columns.Add(new DataColumn("StockId", typeof(int)));

    foreach (String record in GetRecordsList(filePath))
    {
        if (record != "")
        {
            string[] textpart = record.Split(';');
            var row = dt.NewRow();
            row["PointOfSale"] = textpart[0];
            row["Product"] = textpart[1];
            row["Date"] = textpart[2];
            row["Stock"] = Convert.ToInt32(textpart[3].Replace("\r", ""));

            dt.Rows.Add(row);
        }
    }

    return dt;
}
```
Also discarded converting the file to an array first, it was as fast as the list. And lists provide better tools.

## Out of scope

- Auth
- Tx while inserting
- Logging to file

