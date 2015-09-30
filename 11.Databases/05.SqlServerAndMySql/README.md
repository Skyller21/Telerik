## SQL Server and MySQL - Introduction
### _Homework_

1.	Download and install SQL Server Express. Install also SQL Server Management Studio Express (this could take some effort but be persistent).
1.	Connect to the SQL Server with SQL Server Management Studio
	*	Use Windows authentication.
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/01-02.Connected.png)
1.	Create a new database `Pubs` and create new login with permissions to connect to it. Execute the script `install_pubs.sql` to populate the DB contents (you may need slightly to edit the script before).
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/03.Pubs.png)
1.	Attach the database `Northwind` (use the files `Northwind.mdf` and `Northwind.ldf`) to SQL Server and connect to it.
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/04.AttachNorthwind.png)
1.	Backup the database `Northwind` into a file named `northwind-backup.bak` and restore it as database named `North`.
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/05.Backup01.png)
	[https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/northwind-backup.bak](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/northwind-backup.bak)
1.	Export the entire `Northwind` database as SQL script
	*	Use `[Tasks]` > `[Generate Scripts]`
	*	Ensure you have exported table data rows (not only the schema).
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/06.ExportNorthwind.png)
1.	Create a database NW and execute the script in it to create the database and populate table data.
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/07.CreateNW.png)
	[https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/northwind-script-modified-NW.sql](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/northwind-script-modified-NW.sql)
1.	Detatch the database NW and attach it on another computer in the training lab
	*	In case of name collision, preliminary rename the database.
	* ****DONE****
1.	Download and install MySQL Community Server  + MySQL Workbench + the sample databases.
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/09.MySqlDownload.png)
1.	Export the MySQL sample database "`world`" as SQL script.
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/10.ExportToScript.png)
	[https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/world.sql](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/world.sql)
1.	Modify the script and execute it to restore the database world as "`worldNew`".
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/11.WorldNew.png)
	[https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/worldNew.sql](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/worldNew.sql)
1.	Connect through the MySQL console client and list the first 20 tons from the database "`worldNew`".
	![](https://github.com/vesheff/Telerik/blob/master/11.Databases/05.SqlServerAndMySql/media/12.Top20TownsMySql.png)
