using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SivilabApp;
using MySql.Data.MySqlClient;
namespace SivilabApp
{

    public class Metodos
    {
        public bool ValidarUsuario(string contrasena, out string curpUsuario)
        {
            curpUsuario = null; // Inicializamos el parámetro de salida como nulo

            // Verificar que el usuario esté en sesión
            if (Session.UsuarioActual == null || string.IsNullOrEmpty(Session.UsuarioActual.NombreUsuario))
            {
                return false; // Si no hay usuario en sesión, retornar false
            }

            string nombreUsuario = Session.UsuarioActual.NombreUsuario;

            string query = "SELECT Curp_usuario FROM Usuarios WHERE Nombre_usuario = @NombreUsuario AND Contrasena_Usuario = @Contrasena";

            // Crear instancia de la clase de conexión
            ConexionSql conexionSql = new ConexionSql();

            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                if (conn == null) // Verificar que la conexión no sea nula
                {
                    return false; // Si no se pudo abrir la conexión, retornar false
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Usar AddWithValue para agregar parámetros
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario); // Usamos el nombre de usuario de la sesión
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena); // Contraseña que se pasa como parámetro

                    // Ejecutar la consulta y obtener el resultado
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        curpUsuario = result.ToString(); // Asignamos el CURP a la variable de salida
                        return true; // El usuario y la contraseña son válidos
                    }
                    else
                    {
                        return false; // No se encontró un usuario con esas credenciales
                    }
                }
            } // La conexión se cerrará automáticamente aquí
        }
        public bool AgregarSolicitud(string folio, string apellidoPaterno, string apellidoMaterno, string nombreSolicitante, string rfc, string curp, string correo, DateTime fechaNacimiento, string escolaridad, string genero, decimal telefono, string direccion, string cvcCedula, string curpUsuario)
        {
            bool solicitudAgregada = false;

            // Tu consulta ya usa el folio correctamente
            string query = "INSERT INTO Solicitud (Folio, ApellidoPaterno, ApellidoMaterno, Nombre_solicitante, Rfc, Curp, Correo, Fecha_Nacimiento, Escolaridad, Genero, Telefono, Direccion, Cvc_cedula, Curp_usuario) " +
                           "VALUES (@Folio, @ApellidoPaterno, @ApellidoMaterno, @NombreSolicitante, @Rfc, @Curp, @Correo, @FechaNacimiento, @Escolaridad, @Genero, @Telefono, @Direccion, @CvcCedula, @CurpUsuario)";

            // Crear instancia de la clase de conexión
            ConexionSql conexionSql = new ConexionSql();

            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                if (conn == null) // Verificar que la conexión no sea nula
                {
                    return solicitudAgregada; // Si no se pudo abrir la conexión, retornar false
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Agregar los parámetros a la consulta
                    cmd.Parameters.AddWithValue("@Folio", folio);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@NombreSolicitante", nombreSolicitante);
                    cmd.Parameters.AddWithValue("@Rfc", rfc);
                    cmd.Parameters.AddWithValue("@Curp", curp);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Escolaridad", escolaridad);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@CvcCedula", cvcCedula);
                    cmd.Parameters.AddWithValue("@CurpUsuario", curpUsuario);

                    // Ejecutar el comando y verificar si se insertó correctamente
                    solicitudAgregada = cmd.ExecuteNonQuery() > 0;
                }
            } // La conexión se cerrará automáticamente aquí

            return solicitudAgregada;
        }

        public bool ActualizarSolicitud(string folio, string apellidoPaterno, string apellidoMaterno, string nombreSolicitante, string rfc, string curp, string correo, DateTime fechaNacimiento, string escolaridad, string genero, decimal telefono, string direccion, string cvcCedula, string curpUsuario)
        {
            ConexionSql conexionSql = new ConexionSql();
            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                string query = "UPDATE Solicitud SET ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno, Nombre_solicitante = @NombreSolicitante, Rfc = @Rfc, Curp = @Curp, Correo = @Correo, Fecha_Nacimiento = @FechaNacimiento, Escolaridad = @Escolaridad, Genero = @Genero, Telefono = @Telefono, Direccion = @Direccion, Cvc_cedula = @CvcCedula, Curp_usuario = @CurpUsuario WHERE Folio = @Folio";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Folio", folio);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@NombreSolicitante", nombreSolicitante);
                    cmd.Parameters.AddWithValue("@Rfc", rfc);
                    cmd.Parameters.AddWithValue("@Curp", curp);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@Escolaridad", escolaridad);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@CvcCedula", cvcCedula);
                    cmd.Parameters.AddWithValue("@CurpUsuario", curpUsuario);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable ConsultarSolicitudes()
        {
            ConexionSql conexionSql = new ConexionSql();
            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                string query = "SELECT * FROM Solicitud";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tablaSolicitudes = new DataTable();
                    adapter.Fill(tablaSolicitudes);
                    return tablaSolicitudes;
                }
            }
        }
        public bool AgregarDependencia(
         string cvcDependencia, string rfcDependencia, string nombre, string categoria, string telefono,
         string correo, string estatus, string estado, string colonia, string calle, int codigoPostal,
         string gmail, int noTrabajadores, string puesto, int diasDuracion, string motivoEnt, DateTime horaEnt,
         string ciudad, int noExterior, string folio, string nombreUsuario, string contrasena)
        {
            try
            {
                // Establecer conexión con la base de datos
                using (var conexionSql = new ConexionSql())
                {
                    using (MySqlConnection connection = conexionSql.EstablecerConexion())
                    {
                        if (connection == null || connection.State != ConnectionState.Open)
                        {
                            Console.WriteLine("No se pudo abrir la conexión.");
                            return false;
                        }

                        // Validar usuario y obtener CURP
                        string curpUsuario = null;
                        if (!ValidarUsuario( contrasena, out curpUsuario))
                        {
                            Console.WriteLine("El usuario o la contraseña no son válidos.");
                            return false; // Si la validación falla
                        }

                        Console.WriteLine("Curp del usuario logueado: " + curpUsuario); // Depuración

                        // Insertar en la tabla Dependencia
                        try
                        {
                            string queryDependencia = @"
                    INSERT INTO Dependencia (
                        CvcDependencia, Nombre, RFC_dependencia, Estado, Colonia, Calle, Telefono, 
                        Actividad_economica, Tipo_servicio, Correo, Ciudad, Codigo_postal, No_trabajadores, 
                        Puesto, No_ext, Curp_usuario
                    )
                    VALUES (
                        @CvcDependencia, @Nombre, @RFC_dependencia, @Estado, @Colonia, @Calle, @Telefono, 
                        @Actividad_economica, @Tipo_servicio, @Correo, @Ciudad, @Codigo_postal, @No_trabajadores, 
                        @Puesto, @No_ext, @Curp_usuario
                    )";

                            using (var commandDependencia = new MySqlCommand(queryDependencia, connection))
                            {
                                commandDependencia.Parameters.AddWithValue("@CvcDependencia", cvcDependencia);
                                commandDependencia.Parameters.AddWithValue("@RFC_dependencia", rfcDependencia);
                                commandDependencia.Parameters.AddWithValue("@Nombre", nombre);
                                commandDependencia.Parameters.AddWithValue("@Actividad_economica", categoria);
                                commandDependencia.Parameters.AddWithValue("@Telefono", telefono);
                                commandDependencia.Parameters.AddWithValue("@Correo", correo);
                                commandDependencia.Parameters.AddWithValue("@Tipo_servicio", estatus);
                                commandDependencia.Parameters.AddWithValue("@Estado", estado);
                                commandDependencia.Parameters.AddWithValue("@Colonia", colonia);
                                commandDependencia.Parameters.AddWithValue("@Calle", calle);
                                commandDependencia.Parameters.AddWithValue("@Codigo_postal", codigoPostal);
                                commandDependencia.Parameters.AddWithValue("@Ciudad", ciudad);
                                commandDependencia.Parameters.AddWithValue("@No_trabajadores", noTrabajadores);
                                commandDependencia.Parameters.AddWithValue("@Puesto", puesto);
                                commandDependencia.Parameters.AddWithValue("@No_ext", noExterior);
                                commandDependencia.Parameters.AddWithValue("@Curp_usuario", curpUsuario);

                                int resultDependencia = commandDependencia.ExecuteNonQuery();

                                if (resultDependencia <= 0)
                                {
                                    Console.WriteLine("No se insertaron filas en Dependencia.");
                                    return false; // Si la inserción de Dependencia falla, retorna false
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al insertar en la tabla Dependencia: " + ex.Message);
                            return false;
                        }

                        // Insertar en la tabla Entrevista
                        try
                        {
                            string queryEntrevista = @"
                    INSERT INTO Entrevista (
                        Folio, Observaciones, Hora, Dias_duracion, Curp_usuario
                    )
                    VALUES (
                        @Folio, @Observaciones, @Hora, @Dias_duracion, @Curp_usuario
                    )";

                            using (var commandEntrevista = new MySqlCommand(queryEntrevista, connection))
                            {
                                commandEntrevista.Parameters.AddWithValue("@Folio", folio);
                                commandEntrevista.Parameters.AddWithValue("@Observaciones", motivoEnt);
                                commandEntrevista.Parameters.AddWithValue("@Hora", horaEnt);
                                commandEntrevista.Parameters.AddWithValue("@Dias_duracion", diasDuracion);
                                commandEntrevista.Parameters.AddWithValue("@Curp_usuario", curpUsuario);

                                int resultEntrevista = commandEntrevista.ExecuteNonQuery();

                                if (resultEntrevista <= 0)
                                {
                                    Console.WriteLine("Error al agregar la entrevista.");
                                    return false; // Si la inserción de Entrevista falla, retorna false
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al insertar en la tabla Entrevista: " + ex.Message);
                            return false;
                        }
                    }
                }

                return true; // Si todo fue exitoso
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return false;
            }
        }
        public DataTable ConsultarDependencias()
        {
            ConexionSql conexionSql = new ConexionSql();
            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                string query = "SELECT * FROM Dependencia";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tablaDependencias = new DataTable();
                    adapter.Fill(tablaDependencias);
                    return tablaDependencias;
                }
            }
        }
        public bool AgregarVacante(
           string cvcVacante,
            string curpUsuario,
            DateTime vigencia,
            string prestaciones,
            string estatus,
            string tipoVacante,
            string tipoEmp,
            string puestoSolicita,
            string cvcDependencia,
            string salarioM,
            string no_pla,
            string horas,
            string turno,
            string tipoEmpRequerido,
            string escolaridad,
            string sexo,
            bool licencia,
            bool cartilla,
            string rangoEdad)
        {
            using (var conexionSql = new ConexionSql())
            using (var conn = conexionSql.EstablecerConexion())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insertar en la tabla Vacante
                        string queryVacante = "INSERT INTO Vacante (CvcVacante, Vigencia, Otras_prestaciones, Estatus, Puesto_solicta, SalarioM, NoPla, Curp_usuario) " +
                                              "VALUES (@CvcVacante, @Vigencia, @Prestaciones, @Estatus, @PuestoSolicita, @SalarioM, @NoPla, @CurpUsuario)";

                        using (MySqlCommand cmdVacante = new MySqlCommand(queryVacante, conn, transaction))
                        {
                            cmdVacante.Parameters.AddWithValue("@CvcVacante", cvcVacante);
                            cmdVacante.Parameters.AddWithValue("@Vigencia", vigencia);
                            cmdVacante.Parameters.AddWithValue("@Prestaciones", prestaciones);
                            cmdVacante.Parameters.AddWithValue("@Estatus", estatus);
                            cmdVacante.Parameters.AddWithValue("@PuestoSolicita", puestoSolicita);
                            cmdVacante.Parameters.AddWithValue("@SalarioM", salarioM);
                            cmdVacante.Parameters.AddWithValue("@NoPla", no_pla);
                            cmdVacante.Parameters.AddWithValue("@CurpUsuario", curpUsuario);
                            cmdVacante.ExecuteNonQuery();
                        }

                        // Insertar en la tabla vacante_oferta_dependencia
                        string queryOfertaDependencia = "INSERT INTO vacante_oferta_dependencia (CvcDependencia, Curp_usuario, SalarioM, No_pla, CvcVacante, Tipo, Modalidad, Horas) " +
                                                          "VALUES (@CvcDependencia, @CurpUsuario, @SalarioM, @NoPla, @CvcVacante, @Tipo, @Modalidad, @Horas)";

                        using (MySqlCommand cmdOfertaDependencia = new MySqlCommand(queryOfertaDependencia, conn, transaction))
                        {
                            cmdOfertaDependencia.Parameters.AddWithValue("@CurpUsuario", curpUsuario);
                            cmdOfertaDependencia.Parameters.AddWithValue("@CvcVacante", cvcVacante);
                            cmdOfertaDependencia.Parameters.AddWithValue("@Tipo", tipoEmp);
                            cmdOfertaDependencia.Parameters.AddWithValue("@Modalidad", horas);
                            cmdOfertaDependencia.Parameters.AddWithValue("@Horas", horas);
                            cmdOfertaDependencia.ExecuteNonQuery();
                        }

                        // Insertar en la tabla requisitos
                        string queryRequisitos = "INSERT INTO Requisitos (CvcVacante, Tipo_Vacante, Turno, Escolaridad, Sexo, Licencia_de_manejo, Cartilla, Experiencia, Rango_edad) " +
                                                  "VALUES (@CvcVacante, @TipoVacante, @Turno, @Escolaridad, @Sexo, @Licencia, @Cartilla, @Experiencia, @RangoEdad)";

                        using (MySqlCommand cmdRequisitos = new MySqlCommand(queryRequisitos, conn, transaction))
                        {
                            cmdRequisitos.Parameters.AddWithValue("@CvcVacante", cvcVacante);
                            cmdRequisitos.Parameters.AddWithValue("@TipoVacante", tipoVacante);
                            cmdRequisitos.Parameters.AddWithValue("@Turno", null); // Cambia según sea necesario
                            cmdRequisitos.Parameters.AddWithValue("@Escolaridad", escolaridad);
                            cmdRequisitos.Parameters.AddWithValue("@Sexo", sexo);
                            cmdRequisitos.Parameters.AddWithValue("@Licencia", licencia);
                            cmdRequisitos.Parameters.AddWithValue("@Cartilla", cartilla);
                            cmdRequisitos.Parameters.AddWithValue("@Experiencia", null); // Cambia según sea necesario
                            cmdRequisitos.Parameters.AddWithValue("@RangoEdad", rangoEdad);
                            cmdRequisitos.ExecuteNonQuery();
                        }

                        // Confirmar la transacción si todo va bien
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, revertir la transacción
                        transaction.Rollback();
                        throw new Exception("Error al agregar vacante: " + ex.Message);
                    }
                }
            }
        }

        public bool ActualizarVacante(string cvcVacante, string curp, DateTime vigencia, string prestaciones, string estatus, string actividades, string puestoSolicita, string cvcDependencia, string curpUsuario)
        {
            ConexionSql conexionSql = new ConexionSql();
            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                string query = "UPDATE Vacante SET Curp = @Curp, Vigencia = @Vigencia, Otras_prestaciones = @Prestaciones, Estatus = @Estatus, Actividades = @Actividades, Puesto_solicta = @PuestoSolicita, CvcDependencia = @CvcDependencia, Curp_usuario = @CurpUsuario WHERE CvcVacante = @CvcVacante";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CvcVacante", cvcVacante);
                    cmd.Parameters.AddWithValue("@Curp", curp);
                    cmd.Parameters.AddWithValue("@Vigencia", vigencia);
                    cmd.Parameters.AddWithValue("@Prestaciones", prestaciones);
                    cmd.Parameters.AddWithValue("@Estatus", estatus);
                    cmd.Parameters.AddWithValue("@Actividades", actividades);
                    cmd.Parameters.AddWithValue("@PuestoSolicita", puestoSolicita);
                    cmd.Parameters.AddWithValue("@CvcDependencia", cvcDependencia);
                    cmd.Parameters.AddWithValue("@CurpUsuario", curpUsuario);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable ConsultarVacantes()
        {
            ConexionSql conexionSql = new ConexionSql();
            using (MySqlConnection conn = conexionSql.EstablecerConexion())
            {
                string query = "SELECT * FROM Vacante";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tablaVacantes = new DataTable();
                    adapter.Fill(tablaVacantes);
                    return tablaVacantes;
                }
            }
        }
    }
}