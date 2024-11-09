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
        public bool AgregarSolicitud(
    string folio, string apellidoPaterno, string apellidoMaterno, string nombreSolicitante, string rfc, string curp, string cvcVacante,
    string correo, DateTime fechaNacimiento, string escolaridad, string genero, string telefono, string direccion,
    string cvcCedula, string curpUsuario, string ciudad, string estado, string calle, string colonia,
    int codigoPostal, string nacionalidad, int noExterior, string nombreUsuario, MySqlConnection connection)
        {
            bool solicitudAgregada = false;

            // Verificar si la conexión está abierta
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("No se pudo abrir la conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return solicitudAgregada;
            }

            // Iniciar la transacción
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // Insertar en la tabla Solicitud
                    string querySolicitud = @"
                INSERT INTO Solicitud (
                    Folio, ApellidoPaterno, ApellidoMaterno, Nombre_solicitante, Rfc, Correo, Estado_migratorio, 
                    Fecha_Nacimiento, Escolaridad, Genero, Telefono, Direccion, Cvc_cedula, Curp_Solicitante, Curp, Curp_usuario
                )
                VALUES (
                    @Folio, @ApellidoPaterno, @ApellidoMaterno, @NombreSolicitante, @Rfc, @Correo, @Estado_migratorio,  
                    @Fecha_Nacimiento, @Escolaridad, @Genero, @Telefono, @Direccion, @CvcCedula, @Curp_Solicitante, @Curp, @CurpUsuario
                )";

                    using (MySqlCommand cmdSolicitud = new MySqlCommand(querySolicitud, connection, transaction))
                    {
                        cmdSolicitud.Parameters.AddWithValue("@Folio", folio);
                        cmdSolicitud.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                        cmdSolicitud.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
                        cmdSolicitud.Parameters.AddWithValue("@NombreSolicitante", nombreSolicitante);
                        cmdSolicitud.Parameters.AddWithValue("@Rfc", rfc);
                        cmdSolicitud.Parameters.AddWithValue("@Curp_Solicitante", curp);
                        cmdSolicitud.Parameters.AddWithValue("@Correo", correo);
                        cmdSolicitud.Parameters.AddWithValue("@Estado_migratorio", nacionalidad);
                        cmdSolicitud.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento);
                        cmdSolicitud.Parameters.AddWithValue("@Escolaridad", escolaridad);
                        cmdSolicitud.Parameters.AddWithValue("@Genero", genero);
                        cmdSolicitud.Parameters.AddWithValue("@Telefono", telefono);
                        cmdSolicitud.Parameters.AddWithValue("@Direccion", direccion);
                        cmdSolicitud.Parameters.AddWithValue("@CvcCedula", cvcCedula);
                        cmdSolicitud.Parameters.AddWithValue("@Curp", cvcVacante);
                        cmdSolicitud.Parameters.AddWithValue("@CurpUsuario", curpUsuario);

                        try
                        {
                            cmdSolicitud.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al insertar en la tabla Solicitud: {ex.Message}", "Error en Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw; // Relanzar para manejar en el bloque catch principal
                        }
                    }

                    // Insertar en la tabla Direccion_Solicitante
                    string queryDireccion = @"
                    INSERT INTO direccion_solicitante (
                        Folio, Codigo_postal, Calle_1, Colonia, Ciudad, Estado, No_exterior
                    )
                    VALUES (
                        @Folio, @Codigo_postal, @Calle_1, @Colonia, @Ciudad, @Estado, @No_exterior
                    )";

                    using (MySqlCommand cmdDireccion = new MySqlCommand(queryDireccion, connection, transaction))
                    {
                        cmdDireccion.Parameters.AddWithValue("@Folio", folio);
                        cmdDireccion.Parameters.AddWithValue("@Codigo_postal", codigoPostal);
                        cmdDireccion.Parameters.AddWithValue("@Calle_1", calle);
                        cmdDireccion.Parameters.AddWithValue("@Colonia", colonia);
                        cmdDireccion.Parameters.AddWithValue("@Ciudad", ciudad);
                        cmdDireccion.Parameters.AddWithValue("@Estado", estado);
                        cmdDireccion.Parameters.AddWithValue("@No_exterior", noExterior);

                        try
                        {
                            cmdDireccion.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al insertar en la tabla Direccion_Solicitante: {ex.Message}", "Error en Direccion_Solicitante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw; // Relanzar para manejar en el bloque catch principal
                        }
                    }

                    // Confirmar la transacción si ambas inserciones fueron exitosas
                    transaction.Commit();
                    solicitudAgregada = true;
                }
                catch (Exception ex)
                {
                    // En caso de error, revertir la transacción
                    transaction.Rollback();
                    MessageBox.Show($"Se produjo un error inesperado durante la transacción: {ex.Message}", "Error de transacción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    solicitudAgregada = false;
                }
            }

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
                        if (!ValidarUsuario(contrasena, out curpUsuario))
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
      string cvcVacante, DateTime vigencia, string contrasena, string prestaciones, string estatus, string tipoVacante,
      string tipoEmp, string tipocontrato, string puesto_ofrecido, string cvcDependencia, decimal salarioM, int no_pla,
      int horas, string escolaridad, string sexo, bool licencia, bool cartilla, bool Disviajar, bool Disafuera,
      string rangoEdad, string habilidad, string nombreUsuario, MySqlConnection connection)
        {
            try
            {
                // Validar usuario y obtener CURP
                string curpUsuario = null;
                if (!ValidarUsuario(contrasena, out curpUsuario))
                {
                    MessageBox.Show("El usuario o la contraseña no son válidos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Si la validación falla, retornar false
                }

                // Insertar en la tabla Vacante
                try
                {
                    string queryVacante = @"
            INSERT INTO Vacante (
                CvcVacante, Vigencia, Tipo_de_vacante, Puesto_ofrecido, Turno_laboral, Salario_M, 
                NO_plazas, Tipo_contrato, Horarios, Escolaridad, Otras_prestaciones, Estado_civil, 
                Rango_edad, Habilidades, Sexo, Licencia_de_manejo, Cartilla, Disponible_viaje, 
                Disponible_afuera, CvcDependencia, Curp_usuario
            )
            VALUES (
                @CvcVacante, @Vigencia, @TipoVacante, @Puesto_ofrecido, @Turno_laboral, @Salario_M, 
                @NO_plazas, @Tipo_contrato, @Horarios, @Escolaridad, @Otras_prestaciones, @Estado_civil, 
                @Rango_edad, @Habilidades, @Sexo, @Licencia_de_manejo, @Cartilla, @Disponible_viaje, 
                @Disponible_afuera, @CvcDependencia, @CurpUsuario
            )";

                    using (var commandVacante = new MySqlCommand(queryVacante, connection))
                    {
                        // Agregar los parámetros a la consulta
                        commandVacante.Parameters.AddWithValue("@CvcVacante", cvcVacante);
                        commandVacante.Parameters.AddWithValue("@Vigencia", vigencia);
                        commandVacante.Parameters.AddWithValue("@Otras_prestaciones", prestaciones);
                        commandVacante.Parameters.AddWithValue("@Tipo_contrato", tipocontrato);
                        commandVacante.Parameters.AddWithValue("@Estado_civil", estatus);
                        commandVacante.Parameters.AddWithValue("@TipoVacante", tipoVacante);
                        commandVacante.Parameters.AddWithValue("@Puesto_ofrecido", puesto_ofrecido);
                        commandVacante.Parameters.AddWithValue("@Turno_laboral", tipoEmp);
                        commandVacante.Parameters.AddWithValue("@Salario_M", salarioM);
                        commandVacante.Parameters.AddWithValue("@NO_plazas", no_pla);
                        commandVacante.Parameters.AddWithValue("@Horarios", horas);
                        commandVacante.Parameters.AddWithValue("@Escolaridad", escolaridad);
                        commandVacante.Parameters.AddWithValue("@Sexo", sexo);
                        commandVacante.Parameters.AddWithValue("@Licencia_de_manejo", licencia ? 1 : 0);
                        commandVacante.Parameters.AddWithValue("@Cartilla", cartilla ? 1 : 0);
                        commandVacante.Parameters.AddWithValue("@Disponible_viaje", Disviajar ? 1 : 0);
                        commandVacante.Parameters.AddWithValue("@Disponible_afuera", Disafuera ? 1 : 0);
                        commandVacante.Parameters.AddWithValue("@Rango_edad", rangoEdad);
                        commandVacante.Parameters.AddWithValue("@Habilidades", habilidad);
                        commandVacante.Parameters.AddWithValue("@CvcDependencia", cvcDependencia);
                        commandVacante.Parameters.AddWithValue("@CurpUsuario", curpUsuario); // Usar el CURP obtenido

                        int resultVacante = commandVacante.ExecuteNonQuery();

                        if (resultVacante <= 0)
                        {
                            MessageBox.Show("No se insertaron filas en la tabla Vacante. Verifique los datos e intente nuevamente.", "Error al insertar vacante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false; // Si la inserción de Vacante falla, retornar false
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar en la tabla Vacante: " + ex.Message, "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true; // Si todo fue exitoso
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
        public bool AgregarCita(string cvcCita, string curpSolicitante, string nombreCompleto,
                        DateTime fecha, string hora, string curpUsuario, MySqlConnection connection)
        {
            try
            {
                // Aquí ya no es necesario validar la contraseña, ya se validó en el método btnGuardarCita_Click
                // No necesitamos esta parte de validación aquí, solo usamos curpUsuario.

                string queryCita = @"
        INSERT INTO Citas (Cvc_Cita, Nombre_completo, Curp_Solicitante, Fecha, Hora, Curp_usuario)
        VALUES (@Cvc_Cita, @NombreCompleto, @CurpSolicitante, @Fecha, @Hora, @Curp_usuario)";

                using (var commandCita = new MySqlCommand(queryCita, connection))
                {
                    // Agregar los parámetros a la consulta
                    commandCita.Parameters.AddWithValue("@Cvc_Cita", cvcCita);
                    commandCita.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                    commandCita.Parameters.AddWithValue("@CurpSolicitante", curpSolicitante);
                    commandCita.Parameters.AddWithValue("@Fecha", fecha);
                    commandCita.Parameters.AddWithValue("@Hora", hora);
                    commandCita.Parameters.AddWithValue("@Curp_usuario", curpUsuario);

                    int resultCita = commandCita.ExecuteNonQuery();

                    if (resultCita <= 0)
                    {
                        MessageBox.Show("No se insertaron filas en la tabla Citas. Verifique los datos e intente nuevamente.", "Error al insertar cita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Si la inserción de Cita falla, retornar false
                    }
                }

                return true; // Si todo fue exitoso
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Si ocurrió un error inesperado, retornar false
            }
        }
        public bool AgregarEvento(string folio,
     DateTime fechaRegistro, string descripcion, string nombreEvento, string tipo, string responsableEvento,
     string escuela, string observaciones, string direccionEvento, DateTime fechaEvento, string curpUsuario,
     string nombreUsuario, MySqlConnection connection)
        {
            try
            {
                // Consulta SQL para insertar el evento
                string query = @"
        INSERT INTO Eventos (
           Folio_Evento, Fecha_registro, Descripcion, NombreEvento, Tipo, Responsable_evento, Escuela, Observaciones,
            Direccion_evento, Fecha_evento, Curp_Usuario
        )
        VALUES (
             @Folio_Evento, @FechaRegistro, @Descripcion, @NombreEvento, @Tipo, @ResponsableEvento, @Escuela, @Observaciones,
            @DireccionEvento, @FechaEvento, @CurpUsuario
        )";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agregar los parámetros de la consulta
                    command.Parameters.AddWithValue("@Folio_Evento", folio);
                    command.Parameters.AddWithValue("@FechaRegistro", fechaRegistro);
                    command.Parameters.AddWithValue("@Descripcion", descripcion);
                    command.Parameters.AddWithValue("@NombreEvento", nombreEvento);
                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@ResponsableEvento", responsableEvento);
                    command.Parameters.AddWithValue("@Escuela", escuela);
                    command.Parameters.AddWithValue("@Observaciones", observaciones);
                    command.Parameters.AddWithValue("@DireccionEvento", direccionEvento);
                    command.Parameters.AddWithValue("@FechaEvento", fechaEvento);
                    command.Parameters.AddWithValue("@CurpUsuario", curpUsuario);

                    // Ejecutar la consulta de inserción
                    int result = command.ExecuteNonQuery();

                    return result > 0;  // Si el número de filas afectadas es mayor a 0, la inserción fue exitosa
                }
            }
            catch (MySqlException sqlEx)
            {
                // Errores específicos de MySQL
                MessageBox.Show($"Error al interactuar con la base de datos: {sqlEx.Message}", "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (InvalidOperationException invOpEx)
            {
                // Errores de operación no válida, por ejemplo, si la conexión no está abierta
                MessageBox.Show($"Operación no válida: {invOpEx.Message}", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (ArgumentException argEx)
            {
                // Errores de argumentos, por ejemplo, si alguno de los parámetros es inválido
                MessageBox.Show($"Error en los argumentos: {argEx.Message}", "Error de Argumento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción general
                MessageBox.Show($"Error al agregar el evento: {ex.Message}", "Error de Inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}