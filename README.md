Indicaciones

Para lograr que la API funciones en su dispositivio, previamente debe ir a SqlServer y crear una base de datos con el nombre que usted desee. Luego, 
abrir la solución del codigo de la API en Visual Studio, cuando cargue, da doble click sobre el archivo de la solucion llamado "appsettings.json"

Cuando se encuentre dentro de este archivo, solo abra que editar la cadena de coneccion;

La cadena que lleva el código por defecto es la siguiente: 

**"Data Source=DESKTOP-03PS3SB\\SQLEXPRESS;Initial Catalog=ProductoAPI;Integrated Security=True;Trust Server Certificate=True"**

Lo unico que se debe hacer es cambiar el nombre de la instnacia de SqlServer, y el nombre que le dio a su base de datos.

Quedando algo similar a:

**"Data Source=Su_Instancia_de_Sql;Initial Catalog=Nombre_de_la_Base;Integrated Security=True;Trust Server Certificate=True"**

De la cadena anterior, solo hay que cambiar los parametros **Su_Instancia_de_Sql** y **Nombre_de_la_Base** por los datos que correspondan a su DB.

Cuando la cadena esté correctamente configurada, solo hay que abrir la **Consola de Administrador de Paquetes** en la solucionde la API de Visual Studio y realizar las migraciones 
