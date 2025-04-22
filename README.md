# ClinicaTurnos API

API REST desarrollada con ASP.NET Core 9.0 para la gestión de turnos en una clínica. Permite administrar clínicas, profesionales, pacientes, equipos y la asignación de turnos con validaciones de disponibilidad.

---

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server
- Entity Framework Core
- Visual Studio o Visual Studio Code

---

## 🛠️ Instalación y ejecución

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/tu-usuario/ClinicaTurnos.git
   cd ClinicaTurnos
   ```

2. **Restaurar dependencias:**

   ```bash
   dotnet restore
   ```

3. **Aplicar migraciones y crear base de datos:**

   ```bash
   dotnet ef database update
   ```

4. **Ejecutar el proyecto:**

   ```bash
   dotnet run
   ```

   El proyecto por defecto corre en: [http://localhost:5000](http://localhost:5000)

---

## 📦 Estructura del Proyecto

```
ClinicaTurnos/
├── Controllers/           # Controladores Web API
├── Data/                  # DbContext y configuración de EF Core
├── Models/                # Entidades del dominio
├── Migrations/            # Migraciones de EF Core
├── Program.cs             # Configuración de la aplicación
└── appsettings.json       # Configuración de conexión y otros
```

---

## 📌 Endpoints Principales

| Recurso     | Verbo  | Endpoint              | Descripción                             |
|-------------|--------|-----------------------|-----------------------------------------|
| Turnos      | GET    | /api/turnos           | Obtener listado de turnos               |
| Turnos      | POST   | /api/turnos           | Crear nuevo turno                       |
| Profesionales | GET  | /api/profesional      | Obtener todos los profesionales         |
| Profesionales | POST | /api/profesional      | Crear un nuevo profesional              |
| Pacientes   | GET    | /api/paciente         | Obtener todos los pacientes             |
| Equipos     | POST   | /api/equipo           | Crear un nuevo equipo                   |
| Clínicas    | GET    | /api/clinica          | Obtener todas las clínicas              |

---

## ✅ Validaciones de Turnos

Al crear un turno se valida que:

- El profesional no tenga otro turno asignado en el mismo horario.
- El equipo no esté ocupado en el mismo horario.
- El paciente no tenga otro turno a la misma hora.

---

## 🧪 Pruebas

Podés probar los endpoints usando herramientas como [Postman](https://www.postman.com/) o [curl](https://curl.se/).  
Asegurate de enviar los datos en formato `application/json`.

---

## 📝 Licencia

Este proyecto es de uso libre para fines educativos y de aprendizaje.

---

## ✉️ Contacto

Para sugerencias o mejoras, no dudes en abrir un Issue o Pull Request en el repositorio.
