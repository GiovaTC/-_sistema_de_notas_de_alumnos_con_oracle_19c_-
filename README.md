# -_sistema_de_notas_de_alumnos_con_oracle_19c_- :.
# Sistema de Notas de Alumnos con Oracle 19c:

<img width="1024" height="1024" alt="image" src="https://github.com/user-attachments/assets/72b4782e-387f-4503-8354-a7ecddbe1b8f" />  

<img width="2552" height="1079" alt="image" src="https://github.com/user-attachments/assets/2bbb6fc2-fd5b-41fa-9320-0a33a0f694c4" />  

```
Aplicacion de escritorio desarrollada en **Visual Studio 2022 (C# Windows Forms)** que permite:

- Registrar hasta **87 alumnos**.
- Ingresar **5 notas por alumno**.
- Calcular automáticamente:
  - Suma de las 5 notas.
  - Promedio de las 5 notas.
- Guardar la información en **Oracle Database 19c**.
- Consultar registros almacenados.
- Mostrar los datos en un **DataGridView**.

---

# Tecnologías Utilizadas

- Visual Studio 2022
- C# (.NET 8 o .NET Framework 4.8)
- Windows Forms (WinForms)
- Oracle Database 19c
- ODP.NET Managed Driver
- DataGridView

---

# Estructura del Proyecto

```text
NotasOracleWinForms/

│
├── Form1.cs
├── Form1.Designer.cs
├── ConexionOracle.cs
├── Alumno.cs
│
└── App.config
```

---

# Script Oracle 19c

```sql
CREATE TABLE ALUMNOS_NOTAS (
    ID NUMBER GENERATED ALWAYS AS IDENTITY,
    NOMBRE VARCHAR2(100),
    NOTA1 NUMBER(5,2),
    NOTA2 NUMBER(5,2),
    NOTA3 NUMBER(5,2),
    NOTA4 NUMBER(5,2),
    NOTA5 NUMBER(5,2),
    SUMA NUMBER(8,2),
    PROMEDIO NUMBER(8,2),
    FECHA_REGISTRO DATE DEFAULT SYSDATE,
    CONSTRAINT PK_ALUMNOS PRIMARY KEY(ID)
);
```

---

# Instalación del Driver Oracle

Instalar el paquete desde NuGet:

```powershell
Install-Package Oracle.ManagedDataAccess
```

---

# Clase Alumno.cs

```csharp
namespace NotasOracleWinForms
{
    public class Alumno
    {
        public string Nombre { get; set; }

        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Nota4 { get; set; }
        public decimal Nota5 { get; set; }

        public decimal Suma { get; set; }
        public decimal Promedio { get; set; }
    }
}
```

---

# Clase ConexionOracle.cs

```csharp
using Oracle.ManagedDataAccess.Client;

namespace NotasOracleWinForms
{
    public class ConexionOracle
    {
        private string cadena =
            "User Id=SYSTEM;" +
            "Password=oracle;" +
            "Data Source=localhost:1521/XEPDB1";

        public OracleConnection ObtenerConexion()
        {
            return new OracleConnection(cadena);
        }
    }
}
```

---

# Diseño del Formulario

## Labels

- Nombre Alumno
- Nota 1
- Nota 2
- Nota 3
- Nota 4
- Nota 5
- Suma
- Promedio

## TextBox

- txtNombre
- txtNota1
- txtNota2
- txtNota3
- txtNota4
- txtNota5
- txtSuma
- txtPromedio

## Botones

- btnCalcular
- btnGuardar
- btnConsultar
- btnLimpiar

## DataGridView

- dgvDatos

---

# Código Form1.cs

```csharp
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace NotasOracleWinForms
{
    public partial class Form1 : Form
    {
        ConexionOracle conexion = new ConexionOracle();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal n1 = decimal.Parse(txtNota1.Text);
            decimal n2 = decimal.Parse(txtNota2.Text);
            decimal n3 = decimal.Parse(txtNota3.Text);
            decimal n4 = decimal.Parse(txtNota4.Text);
            decimal n5 = decimal.Parse(txtNota5.Text);

            decimal suma = n1 + n2 + n3 + n4 + n5;

            decimal promedio = suma / 5;

            txtSuma.Text = suma.ToString();
            txtPromedio.Text = promedio.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection cn =
                       conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql = @"
                    INSERT INTO ALUMNOS_NOTAS
                    (
                        NOMBRE,
                        NOTA1,
                        NOTA2,
                        NOTA3,
                        NOTA4,
                        NOTA5,
                        SUMA,
                        PROMEDIO
                    )
                    VALUES
                    (
                        :nombre,
                        :n1,
                        :n2,
                        :n3,
                        :n4,
                        :n5,
                        :suma,
                        :promedio
                    )";

                    OracleCommand cmd =
                        new OracleCommand(sql, cn);

                    cmd.Parameters.Add(":nombre",
                        txtNombre.Text);

                    cmd.Parameters.Add(":n1",
                        decimal.Parse(txtNota1.Text));

                    cmd.Parameters.Add(":n2",
                        decimal.Parse(txtNota2.Text));

                    cmd.Parameters.Add(":n3",
                        decimal.Parse(txtNota3.Text));

                    cmd.Parameters.Add(":n4",
                        decimal.Parse(txtNota4.Text));

                    cmd.Parameters.Add(":n5",
                        decimal.Parse(txtNota5.Text));

                    cmd.Parameters.Add(":suma",
                        decimal.Parse(txtSuma.Text));

                    cmd.Parameters.Add(":promedio",
                        decimal.Parse(txtPromedio.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Alumno guardado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection cn =
                       conexion.ObtenerConexion())
                {
                    cn.Open();

                    string sql =
                        "SELECT * FROM ALUMNOS_NOTAS";

                    OracleDataAdapter da =
                        new OracleDataAdapter(sql, cn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender,
            EventArgs e)
        {
            txtNombre.Clear();

            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNota4.Clear();
            txtNota5.Clear();

            txtSuma.Clear();
            txtPromedio.Clear();

            txtNombre.Focus();
        }
    }
}
```

---

# Validación Máxima de 87 Alumnos

Para limitar el registro a **87 estudiantes**, agregar el siguiente método:

```csharp
private bool LimiteAlumnos()
{
    using (OracleConnection cn =
           conexion.ObtenerConexion())
    {
        cn.Open();

        string sql =
            "SELECT COUNT(*) FROM ALUMNOS_NOTAS";

        OracleCommand cmd =
            new OracleCommand(sql, cn);

        int cantidad =
            Convert.ToInt32(cmd.ExecuteScalar());

        return cantidad >= 87;
    }
}
```

---

# Validación Antes de Guardar

Agregar al inicio del evento **btnGuardar_Click**:

```csharp
if (LimiteAlumnos())
{
    MessageBox.Show(
        "Ya se registraron los 87 alumnos.");
    return;
}
```

---

# Funcionalidades Finales

### ✅ Interfaz gráfica Windows Forms

### ✅ Registro de 87 alumnos

### ✅ Captura de 5 notas

### ✅ Cálculo de suma

### ✅ Cálculo de promedio

### ✅ Almacenamiento en Oracle 19c

### ✅ Consulta de registros

### ✅ DataGridView

### ✅ Validación de límite de alumnos

### ✅ Arquitectura lista para Visual Studio 2022

---

# Vista Esperada

```text
---------------------------------------------------------
| Nombre Alumno : [________________________]            |
---------------------------------------------------------
| Nota1 : [__]                                          |
| Nota2 : [__]                                          |
| Nota3 : [__]                                          |
| Nota4 : [__]                                          |
| Nota5 : [__]                                          |
---------------------------------------------------------
| Suma     : [__________]                               |
| Promedio : [__________]                               |
---------------------------------------------------------
| [Calcular] [Guardar] [Consultar] [Limpiar]            |
---------------------------------------------------------
|                                                       |
|                 DataGridView                          |
|                                                       |
---------------------------------------------------------
```

---

# Posibles Mejoras Futuras

El proyecto puede ampliarse para incluir:

- Cálculo de nota máxima.
- Cálculo de nota mínima.
- Cantidad de aprobados.
- Cantidad de reprobados.
- Promedio general de los 87 alumnos.
- Exportación a Excel.
- Exportación a PDF.
- Reportes con Crystal Reports.
- Reportes Oracle Reports.
- Dashboard estadístico.
- Gráficas de rendimiento académico.

---

# Autor

Proyecto académico desarrollado en:

- Visual Studio 2022
- C#
- Windows Forms
- Oracle Database 19c
- ODP.NET Managed Driver
:. . / .
