# 🏋️ Backend - Sistema de Gestión de Gimnasio

Sistema backend completo para la gestión integral de un gimnasio, desarrollado con **ASP.NET Core 9.0** siguiendo arquitectura de capas y principios SOLID.

---

## 📋 Tabla de Contenidos

- [Características](#-características)
- [Arquitectura](#-arquitectura)
- [Tecnologías](#-tecnologías)
- [Entidades del Sistema](#-entidades-del-sistema)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Instalación](#-instalación)
- [Configuración](#-configuración)
- [Uso de la API](#-uso-de-la-api)
- [Documentación de Endpoints](#-documentación-de-endpoints)
- [Ejemplos de Uso](#-ejemplos-de-uso)

---

## ✨ Características

### Gestión de Usuarios y Seguridad
- ✅ Autenticación y autorización con **JWT**
- ✅ Sistema de roles y permisos
- ✅ Gestión de usuarios con perfiles completos
- ✅ Recuperación de contraseñas por email

### Gestión de Servicios y Membresías
- ✅ Catálogo de servicios (mensual, semanal, diario, prueba)
- ✅ Gestión de membresías con fechas de inicio/fin
- ✅ Extensión automática de membresías
- ✅ Notificaciones de expiración

### Control de Asistencias
- ✅ Registro de asistencias (Manual, QR Code, Tarjeta)
- ✅ Verificación de asistencia diaria
- ✅ Estadísticas de asistencia por usuario
- ✅ Rankings de usuarios más frecuentes

### Gestión Financiera
- ✅ Registro de pagos con múltiples métodos
- ✅ Reportes de ingresos mensuales/anuales
- ✅ Estadísticas por método de pago
- ✅ Comparativas entre períodos

### Sistema de Notificaciones
- ✅ Notificaciones automáticas de expiración
- ✅ Promociones y recordatorios
- ✅ Gestión de notificaciones leídas/no leídas
- ✅ Limpieza automática de notificaciones antiguas

---

## 🏗️ Arquitectura

El proyecto sigue una **arquitectura en capas** con separación de responsabilidades:

```
┌─────────────────────────────────────┐
│         Presentation Layer          │
│         (Web - Controllers)         │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│         Business Layer              │
│    (Lógica de Negocio + DTOs)      │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│          Data Layer                 │
│   (Acceso a Datos + Repositorios)  │
└────────────┬────────────────────────┘
             │
┌────────────▼────────────────────────┐
│        Entity Layer                 │
│   (Modelos + DbContext + DTOs)     │
└─────────────────────────────────────┘
             │
┌────────────▼────────────────────────┐
│       Utilities Layer               │
│  (Helpers, Validators, Mappers)    │
└─────────────────────────────────────┘
```

### Capas del Proyecto

#### 1. **Entity** - Capa de Entidades
- Modelos de dominio
- DTOs (Data Transfer Objects)
- DbContext y configuración de EF Core
- Migraciones de base de datos

#### 2. **Data** - Capa de Acceso a Datos
- Interfaces de repositorios
- Implementaciones de repositorios
- Consultas optimizadas con Entity Framework Core
- Uso de Dapper para consultas complejas

#### 3. **Business** - Capa de Lógica de Negocio
- Interfaces de servicios
- Implementaciones de servicios
- Validaciones con FluentValidation
- Lógica de negocio compleja
- Mapeo entre entidades y DTOs con AutoMapper

#### 4. **Web** - Capa de Presentación
- Controllers API REST
- Configuración de middleware
- Configuración de servicios
- Documentación Swagger/OpenAPI

#### 5. **Utilities** - Utilidades
- Helpers (Password, JWT, Email, etc.)
- Servicios transversales (Email, generación de tokens)
- Manejo de excepciones personalizadas
- Perfiles de AutoMapper

---

## 🛠️ Tecnologías

| Categoría | Tecnología |
|-----------|-----------|
| **Framework** | ASP.NET Core 9.0 |
| **ORM** | Entity Framework Core 9.0 |
| **Base de Datos** | SQL Server |
| **Autenticación** | JWT (JSON Web Tokens) |
| **Validación** | FluentValidation |
| **Mapeo** | AutoMapper |
| **Documentación** | Swagger/OpenAPI |
| **Consultas** | LINQ + Dapper |
| **Email** | SMTP |
| **Logging** | ILogger (Microsoft.Extensions.Logging) |

---

## 📊 Entidades del Sistema

### 1. **User** (Usuario)
Representa a los usuarios del gimnasio (clientes y empleados).

**Propiedades:**
- `FirstName`, `LastName`: Nombre completo
- `Identification`: Documento de identidad
- `Phone`, `Email`: Contacto
- `RegistrationDate`: Fecha de registro
- `CurrentMembershipId`: Membresía activa

**Relaciones:**
- Múltiples `UserRole` (roles)
- Múltiples `Membership` (membresías)
- Múltiples `Payment` (pagos)
- Múltiples `Attendance` (asistencias)
- Múltiples `Notification` (notificaciones)

### 2. **Role** (Rol)
Define los roles del sistema (Admin, Usuario, etc.).

**Propiedades:**
- `Name`: Nombre del rol
- `Description`: Descripción

**Relaciones:**
- Múltiples `UserRole`
- Múltiples `RolePermission`

### 3. **Permission** (Permiso)
Permisos granulares del sistema.

**Propiedades:**
- `Name`: Nombre del permiso
- `Module`: Módulo al que pertenece

### 4. **Service** (Servicio)
Servicios/planes ofrecidos por el gimnasio.

**Propiedades:**
- `Name`: Nombre del servicio
- `Price`: Precio
- `IsSubscription`: Si es suscripción
- `Description`: Descripción

**Métodos Específicos:**
- `GetByNameAsync()`: Buscar por nombre
- `GetByPriceRangeAsync()`: Filtrar por rango de precio
- `GetMostPopularServiceAsync()`: Servicio más vendido

### 5. **Membership** (Membresía)
Membresías activas de usuarios.

**Propiedades:**
- `UserId`: Usuario dueño
- `ServiceId`: Servicio contratado
- `Type`: Tipo (mensual, semanal, diaria, prueba)
- `StartDate`, `EndDate`: Período de vigencia

**Métodos Específicos:**
- `GetExpiringMembershipsAsync()`: Próximas a vencer
- `ExtendMembershipAsync()`: Extender vigencia
- `HasActiveMembershipAsync()`: Verificar vigencia
- `GetByTypeAsync()`: Filtrar por tipo

### 6. **Payment** (Pago)
Registro de todos los pagos realizados.

**Propiedades:**
- `UserId`, `MembershipId`: Relaciones
- `Amount`: Monto pagado
- `Date`: Fecha del pago
- `Method`: Método (efectivo, tarjeta, transferencia)
- `Reference`: Referencia del pago

**Métodos Específicos:**
- `GetByPaymentMethodAsync()`: Filtrar por método
- `GetTotalIncomeByDateRangeAsync()`: Ingresos por período
- `GetRecentPaymentsAsync()`: Últimos pagos
- `GetPaymentStatsByMethodAsync()`: Estadísticas por método

### 7. **Attendance** (Asistencia)
Registro de asistencias al gimnasio.

**Propiedades:**
- `UserId`: Usuario que asistió
- `Date`: Fecha de asistencia
- `Time`: Hora de entrada
- `RegistrationMethod`: Método (Manual, QR Code, Card)

**Métodos Específicos:**
- `RegisterAttendanceAsync()`: Registrar ingreso
- `HasAttendanceTodayAsync()`: Verificar si ya ingresó hoy
- `GetTodayAttendanceCountAsync()`: Total de asistencias del día
- `GetTopAttendingUsersAsync()`: Usuarios más frecuentes
- `GetAverageDailyAttendanceAsync()`: Promedio diario

### 8. **ProfitReport** (Reporte de Ganancias)
Reportes mensuales de ingresos.

**Propiedades:**
- `Month`, `Year`: Período
- `TotalIncome`: Total de ingresos

**Métodos Específicos:**
- `GenerateReportAsync()`: Generar reporte automático
- `GetComparisonByYearAsync()`: Comparar años
- `GetYearlyTotalAsync()`: Total anual
- `GetBestMonthAsync()`: Mejor mes del año

### 9. **Notification** (Notificación)
Sistema de notificaciones para usuarios.

**Propiedades:**
- `UserId`: Destinatario
- `Type`: Tipo (expiration, promotion, reminder)
- `Message`: Contenido
- `SentDate`: Fecha de envío
- `IsRead`: Estado de lectura

**Métodos Específicos:**
- `SendNotificationAsync()`: Enviar notificación
- `MarkAsReadAsync()`: Marcar como leída
- `GetUnreadNotificationsAsync()`: No leídas
- `DeleteOldNotificationsAsync()`: Limpiar antiguas
- `SendExpirationNotificationsAsync()`: Notificar expiraciones

---

## 📁 Estructura del Proyecto

```
Backend/
├── Entity/
│   ├── Context/
│   │   └── ApplicationDbContext.cs
│   ├── Model/
│   │   ├── Base/
│   │   │   └── BaseEntity.cs
│   │   ├── User.cs
│   │   ├── Role.cs
│   │   ├── Permission.cs
│   │   ├── Service.cs
│   │   ├── Membership.cs
│   │   ├── Payment.cs
│   │   ├── Attendance.cs
│   │   ├── ProfitReport.cs
│   │   └── Notification.cs
│   └── Dtos/
│       ├── Base/
│       ├── UserDTO/
│       ├── ServiceDTO/
│       ├── MembershipDTO/
│       ├── PaymentDTO/
│       ├── AttendanceDTO/
│       ├── ProfitReportDTO/
│       └── NotificationDTO/
│
├── Data/
│   ├── Interfaces/
│   │   ├── Base/
│   │   │   └── IBaseData.cs
│   │   ├── IUserData.cs
│   │   ├── IServiceData.cs
│   │   ├── IMembershipData.cs
│   │   ├── IPaymentData.cs
│   │   ├── IAttendanceData.cs
│   │   ├── IProfitReportData.cs
│   │   └── INotificationData.cs
│   └── Implements/
│       ├── BaseData/
│       ├── UserData/
│       ├── ServiceData/
│       ├── MembershipData/
│       ├── PaymentData/
│       ├── AttendanceData/
│       ├── ProfitReportData/
│       └── NotificationData/
│
├── Business/
│   ├── Interfaces/
│   │   ├── Base/
│   │   │   └── IBaseBusiness.cs
│   │   ├── IUserBusiness.cs
│   │   ├── IServiceBusiness.cs
│   │   ├── IMembershipBusiness.cs
│   │   ├── IPaymentBusiness.cs
│   │   ├── IAttendanceBusiness.cs
│   │   ├── IProfitReportBusiness.cs
│   │   └── INotificationBusiness.cs
│   ├── Implements/
│   │   ├── Base/
│   │   ├── UserBusiness.cs
│   │   ├── ServiceBusiness.cs
│   │   ├── MembershipBusiness.cs
│   │   ├── PaymentBusiness.cs
│   │   ├── AttendanceBusiness.cs
│   │   ├── ProfitReportBusiness.cs
│   │   └── NotificationBusiness.cs
│   └── Services/
│       ├── AuthService.cs
│       └── JwtService.cs
│
├── Utilities/
│   ├── Helpers/
│   │   ├── PasswordHelper.cs
│   │   ├── ValidationHelper.cs
│   │   ├── DatetimeHelper.cs
│   │   └── GenericHelpers.cs
│   ├── Jwt/
│   │   └── GenerateTokenJwt.cs
│   ├── Mail/
│   │   ├── EmailService.cs
│   │   └── SmtpSettings.cs
│   ├── Mappers/
│   │   └── Profiles/
│   └── Exceptions/
│
└── Web/
    ├── Controllers/
    ├── ServiceExtension/
    │   ├── SwaggerExtensions.cs
    │   └── ApplicationServicesExtension.cs
    └── Program.cs
```

---

## 🚀 Instalación

### Prerrequisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (2019 o superior)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)

### Pasos de Instalación

1. **Clonar el repositorio**
```bash
git clone <repository-url>
cd Gym/Backend
```

2. **Restaurar paquetes NuGet**
```bash
dotnet restore
```

3. **Configurar la cadena de conexión**

Editar `appsettings.json` en el proyecto **Web**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

4. **Crear la base de datos con migraciones**

```bash
cd Entity
dotnet ef migrations add InitialCreate --startup-project ../Web
dotnet ef database update --startup-project ../Web
```

5. **Ejecutar el proyecto**

```bash
cd ../Web
dotnet run
```

La API estará disponible en: `https://localhost:5001`

---

## ⚙️ Configuración

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "JWT": {
    "Key": "TuClaveSecretaSuperSeguraDeAlMenos32Caracteres",
    "Issuer": "GymAPI",
    "Audience": "GymClients",
    "ExpiryInMinutes": 60
  },
  "SmtpSettings": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Sistema Gimnasio",
    "SenderEmail": "tu-email@gmail.com",
    "Username": "tu-email@gmail.com",
    "Password": "tu-password-app"
  },
  "OrigenesPermitidos": "http://localhost:3000;http://localhost:4200",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

---

## 📖 Uso de la API

### Swagger UI

Acceder a la documentación interactiva en:
```
https://localhost:5001/swagger
```

### Autenticación

Todas las rutas (excepto login y registro) requieren autenticación JWT.

**Headers necesarios:**
```
Authorization: Bearer {token}
Content-Type: application/json
```

---

## 🔌 Documentación de Endpoints

### 🔐 Autenticación

#### POST `/api/auth/login`
Inicia sesión y obtiene un token JWT.

**Request:**
```json
{
  "email": "usuario@gym.com",
  "password": "password123"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "expiration": "2024-01-01T10:00:00Z",
  "user": {
    "id": 1,
    "firstName": "Juan",
    "lastName": "Pérez",
    "email": "usuario@gym.com"
  }
}
```

---

### 👥 Usuarios

#### GET `/api/users`
Obtiene todos los usuarios.

#### GET `/api/users/{id}`
Obtiene un usuario por ID.

#### POST `/api/users`
Crea un nuevo usuario.

#### PUT `/api/users/{id}`
Actualiza un usuario completo.

#### PATCH `/api/users/{id}`
Actualiza parcialmente un usuario.

#### DELETE `/api/users/{id}`
Eliminación lógica de un usuario.

---

### 🏷️ Servicios

#### GET `/api/services`
Lista todos los servicios.

#### GET `/api/services/{id}`
Obtiene un servicio específico.

#### GET `/api/services/active`
Obtiene servicios activos.

#### GET `/api/services/subscriptions`
Obtiene servicios de suscripción.

#### GET `/api/services/by-name/{name}`
Busca servicio por nombre.

#### GET `/api/services/price-range?min={min}&max={max}`
Filtra por rango de precio.

#### GET `/api/services/most-popular`
Obtiene el servicio más popular.

#### POST `/api/services`
Crea un nuevo servicio.

#### PUT `/api/services/{id}`
Actualiza un servicio.

#### DELETE `/api/services/{id}`
Elimina un servicio.

---

### 💳 Membresías

#### GET `/api/memberships`
Lista todas las membresías.

#### GET `/api/memberships/user/{userId}`
Membresías de un usuario.

#### GET `/api/memberships/active`
Membresías activas.

#### GET `/api/memberships/expired`
Membresías expiradas.

#### GET `/api/memberships/current/{userId}`
Membresía actual del usuario.

#### GET `/api/memberships/expiring?days={days}`
Membresías próximas a vencer.

#### GET `/api/memberships/type/{type}`
Filtrar por tipo de membresía.

#### GET `/api/memberships/has-active/{userId}`
Verifica si tiene membresía activa.

#### GET `/api/memberships/count/active`
Conteo de membresías activas.

#### POST `/api/memberships`
Crea una nueva membresía.

#### POST `/api/memberships/{id}/extend?days={days}`
Extiende una membresía.

#### PUT `/api/memberships/{id}`
Actualiza una membresía.

#### DELETE `/api/memberships/{id}`
Elimina una membresía.

---

### 💰 Pagos

#### GET `/api/payments`
Lista todos los pagos.

#### GET `/api/payments/user/{userId}`
Pagos de un usuario.

#### GET `/api/payments/membership/{membershipId}`
Pagos de una membresía.

#### GET `/api/payments/date-range?start={start}&end={end}`
Pagos por rango de fechas.

#### GET `/api/payments/method/{method}`
Pagos por método.

#### GET `/api/payments/recent?count={count}`
Últimos pagos.

#### GET `/api/payments/income/month?month={month}&year={year}`
Ingreso mensual.

#### GET `/api/payments/income/range?start={start}&end={end}`
Ingreso por rango.

#### GET `/api/payments/stats/method?month={month}&year={year}`
Estadísticas por método.

#### POST `/api/payments`
Registra un nuevo pago.

---

### 📅 Asistencias

#### GET `/api/attendances`
Lista todas las asistencias.

#### GET `/api/attendances/user/{userId}`
Asistencias de un usuario.

#### GET `/api/attendances/date/{date}`
Asistencias de una fecha.

#### GET `/api/attendances/date-range?start={start}&end={end}`
Asistencias por rango.

#### GET `/api/attendances/user/{userId}/count?start={start}&end={end}`
Conteo de asistencias.

#### GET `/api/attendances/today/count`
Asistencias del día.

#### GET `/api/attendances/user/{userId}/today`
Verificar asistencia hoy.

#### GET `/api/attendances/top?start={start}&end={end}&count={count}`
Usuarios más frecuentes.

#### GET `/api/attendances/average?month={month}&year={year}`
Promedio diario.

#### POST `/api/attendances/register`
Registra asistencia.

**Request:**
```json
{
  "userId": 1,
  "registrationMethod": "QR Code"
}
```

---

### 📊 Reportes de Ganancias

#### GET `/api/profit-reports`
Lista todos los reportes.

#### GET `/api/profit-reports/month?month={month}&year={year}`
Reporte mensual.

#### GET `/api/profit-reports/year/{year}`
Reportes del año.

#### GET `/api/profit-reports/yearly-total/{year}`
Total anual.

#### GET `/api/profit-reports/best-month/{year}`
Mejor mes del año.

#### GET `/api/profit-reports/comparison?year1={year1}&year2={year2}`
Comparación entre años.

#### POST `/api/profit-reports/generate`
Genera reporte mensual.

**Request:**
```json
{
  "month": 1,
  "year": 2024
}
```

---

### 🔔 Notificaciones

#### GET `/api/notifications/user/{userId}`
Notificaciones de un usuario.

#### GET `/api/notifications/unread/{userId}`
Notificaciones no leídas.

#### GET `/api/notifications/type/{type}`
Filtrar por tipo.

#### GET `/api/notifications/recent/{userId}?count={count}`
Notificaciones recientes.

#### POST `/api/notifications/send`
Envía una notificación.

**Request:**
```json
{
  "userId": 1,
  "type": "promotion",
  "message": "¡Descuento del 20% en membresías!"
}
```

#### PUT `/api/notifications/{id}/mark-read`
Marca como leída.

#### POST `/api/notifications/send-expirations`
Envía notificaciones de expiración.

#### DELETE `/api/notifications/old?days={days}`
Elimina notificaciones antiguas.

---

## 💡 Ejemplos de Uso

### Ejemplo 1: Registrar un nuevo usuario y asignarle una membresía

```bash
# 1. Crear usuario
POST /api/users
{
  "firstName": "María",
  "lastName": "González",
  "identification": "123456789",
  "phone": "555-1234",
  "email": "maria@email.com",
  "registrationDate": "2024-01-15T10:00:00Z"
}

# 2. Crear membresía
POST /api/memberships
{
  "userId": 10,
  "serviceId": 1,
  "type": "monthly",
  "startDate": "2024-01-15T00:00:00Z",
  "endDate": "2024-02-15T00:00:00Z"
}

# 3. Registrar pago
POST /api/payments
{
  "userId": 10,
  "membershipId": 5,
  "amount": 50.00,
  "date": "2024-01-15T10:00:00Z",
  "method": "cash",
  "reference": "PAGO-001"
}
```

### Ejemplo 2: Registrar asistencia

```bash
POST /api/attendances/register
{
  "userId": 10,
  "registrationMethod": "QR Code"
}
```

### Ejemplo 3: Generar reporte mensual

```bash
POST /api/profit-reports/generate
{
  "month": 1,
  "year": 2024
}
```

---

## 📝 Notas Importantes

### Principios de Diseño

- **SOLID**: Cada capa tiene una responsabilidad única
- **DRY**: Reutilización de código con clases base genéricas
- **Separation of Concerns**: Clara separación entre capas
- **Dependency Injection**: Inyección de dependencias en toda la aplicación

### Buenas Prácticas Implementadas

- ✅ Borrado lógico (soft delete) para todas las entidades
- ✅ Auditoría automática (CreatedAt, UpdatedAt, DeletedAt)
- ✅ Validación de datos con FluentValidation
- ✅ Mapeo automático con AutoMapper
- ✅ Logging estructurado con ILogger
- ✅ Manejo de excepciones centralizado
- ✅ Documentación XML en todo el código
- ✅ DTOs para separar modelos de dominio de respuestas API

---

## 🔒 Seguridad

- Autenticación JWT con tokens de expiración configurable
- Passwords hasheados con BCrypt
- Protección contra SQL Injection (uso de LINQ y parámetros)
- CORS configurado
- HTTPS enforced en producción
- Validación de entrada en todos los endpoints

---

## 🤝 Contribución

Para contribuir al proyecto:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT.

---

## 👨‍💻 Autor

Desarrollado con ❤️ para la gestión eficiente de gimnasios.

---

## 📞 Soporte

Para soporte o preguntas, contactar a través de:
- Email: soporte@gym.com
- Issues: [GitHub Issues](https://github.com/tu-repo/issues)
