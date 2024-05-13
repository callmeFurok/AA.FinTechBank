# FinTechBank Test Kruger

El presente documento contiene las instrucciones para usar la aplicacion de prueba desarrollada.
---
- ⚠️ **Todo: Implementar las pruebas unitarias**
- ⚠️ **Todo: Implementar Fronted**
-  [Repositorio Docker Hub](https://hub.docker.com/r/aguirrealfredodev772/aafintechbankapi)
-  [Repositorio Github](https://github.com/callmeFurok/AA.FinTechBank)

---

## Tabla de contenidos:
---

- [Historia de Usuario](#historia-de-usuario)
- [Prerrequisitos](#prerrequisitos)
- [Guía de instalación](#guía-de-instalación)
- [Construido con](#construido-con)
- [#Guia de Uso ](guia-de-uso)

---
# Historia de Usuario
 👨‍💼**Como Product Owner, requiero poder gestionar la informacion de los clientes mediante una aplicacion
 donde pueda crear,borrar,actualizar y listar todos los clientes**

---
# Prerrequisitos
- 🐋 **Docker Desktop**

---
# Guía de instalación

⚠️ **Seguir los paso en orden, caso contrario no funcionara**

1.- Creacion de un contenedor con el nombre **db** que consumira la aplicacion. Usar el siguiente comando:

    docker run --name db -e POSTGRES_PASSWORD=secretP4ssword -p 5432:5432 -d postgres

2.- Creacion de un contenedor con la aplicacion y conectado a la base de datos. Usar el siguiente comando:

     docker run --name FintechMicro --link db:fintechpostgres -p 8080:8080 -d guirrealfredodev772/aafintechbankapi:1.0

3.- Accedemos a la ruta en el navegador, donde se nos desplegara Swagger para usar los endpoints.
    
    http://localhost:8080/index.html

---
#Guia de Uso 
- Es necesario registarse para posteior a esto obtener un token
- Una vez registrado, logueamos con las credenciales del registro y obtendremos el token
- Se hace uso del token para poder acceder a los endpoints de ciente
- Se debe crear algunos clientes para listar todos los clientes
- Usar el archivo de postman para validar el funcionamiento de los endpoints:
  
      FintechTest.postman_collection.json
---
# Construido con

* [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - Framework web usado 💻
* [Entity Framework](https://docs.microsoft.com/en-us/ef/) - ORM utilizado 🗃️
* [Docker](https://docker.com/) - Contenedorización 🐋
