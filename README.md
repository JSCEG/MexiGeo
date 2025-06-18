# MEXIGEO

Este proyecto utiliza un servicio SMTP para el envío de correos, por ejemplo, para la recuperación de contraseñas.  
El archivo `appsettings.json` no está incluido en el repositorio. Utilice el archivo `appsettings.example.json` como referencia para crear su configuración local.  Los valores se enlazan automáticamente a la clase `EmailSettings` mediante `IOptions<T>`.

```json
{
  "EmailSettings": {
    "TipoCuenta": "OutlookBasic",
    "Username": "tu_correo@example.com",
    "Password": "tu_contraseña_o_app_password",
    "SmtpOffice365": {
      "Host": "smtp.office365.com",
      "Port": 587,
      "EnableSsl": true
    },
    "SmtpExchange": {
      "Host": "mail.tudominio.com",
      "Port": 587,
      "EnableSsl": true
    },
    "SmtpOutlook": {
      "Host": "smtp-mail.outlook.com",
      "Port": 587,
      "EnableSsl": true
    }
  }
}
```

Copie este archivo como `appsettings.json` y rellene los valores con las credenciales apropiadas.  Seleccione `TipoCuenta` según la naturaleza de la cuenta:

- **OutlookBasic** – cuentas personales como `@outlook.com` o `@hotmail.com` (requiere contraseña de aplicación si está habilitada la autenticación en dos pasos).
- **Office365** – cuentas de Office 365 empresariales.
- **Exchange** – servidor Exchange local.

Para cuentas personales de Outlook/Hotmail es necesario crear una [contraseña de aplicación](https://support.microsoft.com/es-es/account-billing/contrase%C3%B1as-de-aplicaci%C3%B3n-y-autenticaci%C3%B3n-de-dos-factores-ecb8037b-a698-4b1e-82b9-29ec7cae87c4) y usarla en lugar de la contraseña normal.
