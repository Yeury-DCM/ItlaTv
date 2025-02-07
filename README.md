# ITLATV 

## 📌 Descripción
Esta es una app de streaming que se creó utilizando ASP .NET Core 9 MVC y EF Core. En esta se implementa una **arquitectura basada en Clean Architecture **, asegurando una clara separación de responsabilidades entre sus capas.

## 🖼️ Imágenes del proyecto

### Home
![Home](https://github.com/user-attachments/assets/8931ce27-7f55-4662-85c7-1fcaa298f0b0)

### Mantenimiento de series
![SerieCrud](https://github.com/user-attachments/assets/d27d5bd7-6638-4459-b555-2fe348b45ee8)

### Detalle de la serie (Vista con reproductor)
![Detail](https://github.com/user-attachments/assets/847cedd8-c3df-47f7-b0f7-374f1a6da328)

### Mantenimiento de géneros
![GenreCrud](https://github.com/user-attachments/assets/6c700948-96a6-4495-987b-bd1706433b86)

## 🏛️ Estructura del Proyecto

```
ITLATV
│── backend
│   │── ItlaTv.Application  (Casos de uso, servicios y ViewModels)
│   │── ItlaTv.Domain       (Entidades y contratos - Reglas de negocio puras)
│   │── ItlaTv.Persistence  (Implementación de repositorios y contexto de BD)   
│── frontend
│   │── ItlaTv.Web          (Capa de presentación - Inyección de dependencias )
```

## 📂 Capas y Responsabilidades

### **1️⃣ ItlaTv.Domain (Capa de Dominio - Core del negocio)**
- Define las **entidades de dominio** y las **interfaces de repositorios**.
- No depende de ninguna otra capa, cumpliendo el principio de inversión de dependencias.
- Contiene las **reglas de negocio puras**.

### **2️⃣ ItlaTv.Application (Capa de Aplicación)**
- Contiene la lógica de los **casos de uso y servicios**.
- Interactúa con el dominio pero no accede directamente a la persistencia.
- Define **ViewModels** para desacoplar el dominio de la UI.

### **3️⃣ ItlaTv.Persistence (Capa de Persistencia)**
- Implementa los repositorios definidos en `Domain`.
- Contiene el **DbContext y Migrations** para la base de datos.
- Cumple con los principios de Clean Architecture al no afectar la capa de dominio.

### **4️⃣ ItlaTv.Web (Capa de Presentación e Inyección de Dependencias)**
- Implementa la interfaz gráfica del sistema.
- Inyecta los repositorios de `Persistence` y los casos de uso de `Application`.


## 🎯 **Principios Clave**
✅ **Clean Architecture**: El dominio permanece independiente de detalles de infraestructura.    
✅ **Inversión de Dependencias**: Las capas internas no dependen de implementaciones externas.  
✅ **Separación de Responsabilidades**: Cada capa tiene un propósito bien definido.  
✅ **Escalabilidad y Mantenibilidad**: Facilita la evolución del proyecto con mínimo impacto.

## ⚙️ **Tecnologías Usadas**
- **ASP.NET Core MVC** para la capa web.
- **Entity Framework Core** para persistencia de datos.
- **C# y .NET** como tecnologías principales.
- **Razor y Bosstrap** para la interfaz de usuario.
d
## 🚀 **Cómo Ejecutar el Proyecto**
1. Restaurar paquetes NuGet:
   ```sh
   dotnet restore
   ```
2. Aplicar migraciones:
   ```sh
   dotnet ef database update
   ```
3. Ejecutar la aplicación:
   ```sh
   dotnet run --project ItlaTv.Web
   ```

---

Este diseño garantiza una **alta mantenibilidad, testabilidad y escalabilidad**, permitiendo un desarrollo ágil y estructurado. 💡🔥
