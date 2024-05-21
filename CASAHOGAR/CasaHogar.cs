using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace CASAHOGAR
{
    internal class CasaHogar
    {
        public string Conexion()
        {
            string connectionString = @"Data Source=THE-MARAUDERS-M\TBD_DARD_23;Initial Catalog=CASAHOGAR;Integrated Security=True";
            return connectionString;
        }

        // VISTAS
        #region VistaDonantes
        public DataTable VistaDonantes()
        {
            string conectionString;
            string Query = "SELECT * FROM vwDonantes WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaDonaciones
        public DataTable VistaDonaciones()
        {
            string conectionString;
            string Query = "SELECT * FROM vwDonaciones with(nolock)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaEmpleados
        public DataTable VistaEmpleados()
        {
            string conectionString;
            string Query = "SELECT * FROM vwEmpleados WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaMobiliario
        public DataTable VistaMobiliario()
        {
            string conectionString;
            string Query = "SELECT * FROM vwMobiliario WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaVentas
        public DataTable VistaVentas(DateTime fecha)
        {
            string conectionString;
            string Query = "SELECT * FROM vwVentas WHERE CAST([Fecha de Venta] AS DATE) = @Fecha";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@Fecha", fecha);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region VistaVentasPorDia
        public DataTable VistaVentasPorDia()
        {
            string conectionString;
            string Query = "SELECT * FROM vwVentasPorDia WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaProductos
        public DataTable VistaProductos()
        {
            string conectionString;
            string Query = "SELECT * FROM vwProductos WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaUsuarios
        public DataTable VistaUsuarios()
        {
            string conectionString;
            string Query = "SELECT * FROM vwUsuarios WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaInsumos
        public DataTable VistaInsumos()
        {
            string conectionString;
            string Query = "SELECT * FROM vwInsumos WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region VistaConsumos
        public DataTable VistaConsumos()
        {
            string conectionString;
            string Query = "SELECT * FROM vwConsumos WITH(NOLOCK)";

            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);

                    connection.Close();
                    return dataTable;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }
            }
        }
        #endregion

        #region Obtener Donantes
        public DataTable ObtenerDonantes()
        {
            string CadenaConexion;

            CadenaConexion = Conexion();

            using (SqlConnection connection = new SqlConnection(CadenaConexion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spr_ObtenerDonantes", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        DataTable data = new DataTable();

                        data.Load(reader);

                        connection.Close();
                        return data;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        #endregion

        #region Obtener Productos
        public DataTable ObtenerProductos()
        {
            string CadenaConexion;

            CadenaConexion = Conexion();

            using (SqlConnection connection = new SqlConnection(CadenaConexion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spr_ObtenerProducto", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        DataTable data = new DataTable();

                        data.Load(reader);

                        connection.Close();
                        return data;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        #endregion

        #region Obtener Insumos
        public DataTable ObtenerInsumos()
        {
            string CadenaConexion;

            CadenaConexion = Conexion();

            using (SqlConnection connection = new SqlConnection(CadenaConexion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spr_ObtenerInsumo", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        DataTable data = new DataTable();

                        data.Load(reader);

                        connection.Close();
                        return data;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        #endregion

        #region Obtener Cantidad
        public DataTable ObtenerCantidad()
        {
            string CadenaConexion;

            CadenaConexion = Conexion();

            using (SqlConnection connection = new SqlConnection(CadenaConexion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spr_ObtenerCantidad", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        DataTable data = new DataTable();

                        data.Load(reader);

                        connection.Close();
                        return data;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        #endregion

        #region Obtener Precio
        public DataTable ObtenerPrecio()
        {
            string CadenaConexion;

            CadenaConexion = Conexion();

            using (SqlConnection connection = new SqlConnection(CadenaConexion))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spr_ObtenerPrecios", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        DataTable data = new DataTable();

                        data.Load(reader);

                        connection.Close();
                        return data;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        #endregion

        #region ActualizarCantidades
        public void ActualizarCantidades(int IdInsumo, int IdConsumo, decimal CantidadConsumida, decimal CantidadDisponible, string UnidadMedida)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_ActualizarConsumosInsumos", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@IdInsumo", IdInsumo);
                    command.Parameters.AddWithValue("@IdConsumo", IdConsumo);
                    command.Parameters.AddWithValue("@CantidadConsumida", CantidadConsumida);
                    command.Parameters.AddWithValue("@CantidadDisponible", CantidadDisponible);
                    command.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        // PROCEDIMIENTOS

        // ----------- DONANTES ---------------- 
        #region Alta Donantes
        public void AltaDonantes(string Nombre, string Apellido, string Telefono, string Email)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaDonantes", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@NombreDonante", Nombre);
                    command.Parameters.AddWithValue("@ApellidoDonante", Apellido);
                    command.Parameters.AddWithValue("@TelefonoDonante", Telefono);
                    command.Parameters.AddWithValue("@EmailDonante", Email);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar Donante
        public void EliminarRegistroDonante(string idDonante)
        {
            string connectionString;
            connectionString = Conexion();

            // Consulta SQL para deshabilitar la restricción de referencia en la tabla 
            string disableConstraintQuery = "ALTER TABLE dbo.Donaciones NOCHECK CONSTRAINT FK_DonantesDonaciones";

            string deleteQuery = "DELETE FROM dbo.Donantes WHERE idDonante = @IdDonante";

            // Consulta SQL para habilitar nuevamente la restricción de referencia en la tabla sales
            string enableConstraintQuery = "ALTER TABLE dbo.Donaciones CHECK CONSTRAINT FK_DonantesDonaciones";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Deshabilitar la restricción de referencia en la tabla sales
                    using (SqlCommand command = new SqlCommand(disableConstraintQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@IdDonante", idDonante);
                        command.ExecuteNonQuery();
                    }

                    // Habilitar nuevamente la restricción de referencia en la tabla sales
                    using (SqlCommand command = new SqlCommand(enableConstraintQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Deshacer la transacción en caso de error
                    transaction.Rollback();
                    throw new Exception("Error al eliminar el registro del donante: " + ex.Message);
                }
            }
        }
        #endregion

        // ----------- DONACIONES ---------------- 

        #region Alta Donaciones
        public void AltaDonaciones(string ProductoDonado, int CantidadDonada, DateTime FechaDonacion, int IdDonante, string NombreDonante)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaDonaciones", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@ProductoDonado", ProductoDonado);
                    command.Parameters.AddWithValue("@CantidadDonada", CantidadDonada);
                    command.Parameters.AddWithValue("@FechaDonacion", FechaDonacion);
                    command.Parameters.AddWithValue("@IdDonante", IdDonante);
                    command.Parameters.AddWithValue("@NombreDonante", NombreDonante);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar Donaciones
        public void EliminarRegistroDonaciones(string idDonaciones)
        {
            string conectionString;
            conectionString = Conexion();
            // Consulta SQL para eliminar el registro con el ID proporcionado
            string query = "DELETE FROM Donaciones WHERE idDonacion = @IdDonacion";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para el ID
                    command.Parameters.AddWithValue("@IdDonacion", idDonaciones);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        throw new Exception("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        // ----------- VENTAS ---------------- 

        #region Alta Ventas
        public void AltaVentas(int IdProducto, string Producto, int CantidadVendida, decimal MontoPagado, DateTime FechaVenta)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaVentas", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@CantidadVendida", CantidadVendida);
                    command.Parameters.AddWithValue("@MontoPagado", MontoPagado);
                    command.Parameters.AddWithValue("@FechaVenta", FechaVenta);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar Ventas
        public void EliminarRegistroVentas(string idVentas)
        {
            string conectionString;
            conectionString = Conexion();
            // Consulta SQL para eliminar el registro con el ID proporcionado
            string query = "DELETE FROM Ventas WHERE idVenta = @IdVenta";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para el ID
                    command.Parameters.AddWithValue("@IdVenta", idVentas);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        throw new Exception("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        // ----------- PRODUCTOS ---------------- 

        #region Alta Productos
        public void AltaProductos(string Nombre, int Precio, string Informacion)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaProductos", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@NombreProducto", Nombre);
                    command.Parameters.AddWithValue("@PrecioUnitarioProducto", Precio);
                    command.Parameters.AddWithValue("@InformacionAdicional", Informacion);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar Productos
        public void EliminarRegistroProducto(string idProducto)
        {
            string connectionString;
            connectionString = Conexion();

            // Consulta SQL para deshabilitar la restricción de referencia en la tabla 
            string disableConstraintQuery = "ALTER TABLE dbo.Ventas NOCHECK CONSTRAINT FK_VentasProductos";

            string deleteQuery = "DELETE FROM dbo.Productos WHERE idProducto = @IdProducto";

            // Consulta SQL para habilitar nuevamente la restricción de referencia en la tabla sales
            string enableConstraintQuery = "ALTER TABLE dbo.Ventas CHECK CONSTRAINT FK_VentasProductos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Deshabilitar la restricción de referencia en la tabla sales
                    using (SqlCommand command = new SqlCommand(disableConstraintQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@IdProducto", idProducto);
                        command.ExecuteNonQuery();
                    }

                    // Habilitar nuevamente la restricción de referencia en la tabla sales
                    using (SqlCommand command = new SqlCommand(enableConstraintQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Deshacer la transacción en caso de error
                    transaction.Rollback();
                    throw new Exception("Error al eliminar el registro del donante: " + ex.Message);
                }
            }
        }
        #endregion

        // ----------- EMPLEADOS ---------------- 

        #region Alta Empleados
        public void AltaEmpleados(string Nombre, string Apellido, string Telefono, string Email, string Horario, string Puesto)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaEmpleados", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@NombreEmpleado", Nombre);
                    command.Parameters.AddWithValue("@ApellidoEmpleado", Apellido);
                    command.Parameters.AddWithValue("@TelefonoEmpleado", Telefono);
                    command.Parameters.AddWithValue("@EmailEmpleado", Email);
                    command.Parameters.AddWithValue("@HorarioLaboral", Horario);
                    command.Parameters.AddWithValue("@PuestoTrabajo", Puesto);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar Empleados
        public void EliminarRegistroEmpleados(string idEmpleado)
        {
            string conectionString;
            conectionString = Conexion();
            // Consulta SQL para eliminar el registro con el ID proporcionado
            string query = "DELETE FROM Empleados WHERE idEmpleado = @IdEmpleado";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para el ID
                    command.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        throw new Exception("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        // ----------- MOBILIARIO Y EQUIPO ---------------- 

        #region Alta MobiliarioEquipo
        public void AltaMobiliarioEquipo(string Nombre, int CantidadDisponible, string DescripcionMobiliario, string EstadoArticulo)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaMobiliarioEquipo", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@NombreMobiliario", Nombre);
                    command.Parameters.AddWithValue("@CantidadDisponible", CantidadDisponible);
                    command.Parameters.AddWithValue("@DescripcionMobiliario", DescripcionMobiliario);
                    command.Parameters.AddWithValue("@EstadoArticulo", EstadoArticulo);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar MobiliarioEquipo
        public void EliminarRegistroMobiliario(string idMobiliario)
        {
            string conectionString;
            conectionString = Conexion();
            // Consulta SQL para eliminar el registro con el ID proporcionado
            string query = "DELETE FROM MobiliarioEquipo WHERE idMobiliario = @IdMobiliario";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para el ID
                    command.Parameters.AddWithValue("@IdMobiliario", idMobiliario);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        throw new Exception("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        // ----------- USUARIOS ---------------- 

        #region Alta Usuarios
        public void AltaUsuarios(string Nombre, string Contraseña, bool EsAdministrador)
        {
            //Obtenemos la cadena de conexión de nuestra base de datos
            string conectionString;
            conectionString = Conexion();

            //Generamos la conexión
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    //Abrimos la conexión
                    connection.Open();
                    //Indicamos el comando que se va a ejecutar en este caso un stored procedure
                    SqlCommand command = new SqlCommand("spi_AltaUsuarios", connection);
                    //Le indicamos que tipo de componente es
                    command.CommandType = CommandType.StoredProcedure;

                    //Le mandamos las variables ingresadas en los texbox
                    command.Parameters.AddWithValue("@NombreUsuario", Nombre);
                    command.Parameters.AddWithValue("@ContraseñaUsuario", Contraseña);
                    command.Parameters.AddWithValue("@EsAdministrador", EsAdministrador);

                    //Ejecutamos el componente "Similar a EXEC en SQL"
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    // Manejar específicamente errores de SQL Server
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                catch (Exception ex)
                {
                    // Otros tipos de errores
                    Console.WriteLine("Error al ejecutar el stored procedure: " + ex.Message);
                    throw; // Relanzar la excepción para que pueda ser capturada en el bloque catch de tu código de presentación
                }
                finally
                {
                    connection.Close(); // Asegúrate de cerrar la conexión
                }
            }
        }
        #endregion

        #region Eliminar Usuarios
        public void EliminarRegistroUsuario(string idUsuario)
        {
            string conectionString;
            conectionString = Conexion();
            // Consulta SQL para eliminar el registro con el ID proporcionado
            string query = "DELETE FROM Usuarios WHERE idUsuario = @IdUsuario";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para el ID
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        throw new Exception("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        // ----------- CONSUMOS ---------------- 
        #region Alta Consumos
        public void AltaConsumos(int IdInsumo, string Insumo, decimal CantidadConsumida, decimal CantidadDisponible, string UnidadMedida)
        {
            string conectionString;
            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spi_AltaConsumos", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdInsumo", IdInsumo);
                    command.Parameters.AddWithValue("@Insumo", Insumo);
                    command.Parameters.AddWithValue("@CantidadConsumida", CantidadConsumida);
                    command.Parameters.AddWithValue("@CantidadDisponible", CantidadDisponible);
                    command.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);

                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al ejecutar el stored procedure para alta de consumos: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar el stored procedure para alta de consumos: " + ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region Eliminar Consumos
        public void EliminarRegistroConsumos(string idConsumos)
        {
            string conectionString;
            conectionString = Conexion();
            // Consulta SQL para eliminar el registro con el ID proporcionado
            string query = "DELETE FROM Consumos WHERE idConsumo = @IdConsumo";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para el ID
                    command.Parameters.AddWithValue("@IdConsumo", idConsumos);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Manejar cualquier error
                        throw new Exception("Error al eliminar el registro: " + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region Actualizar Cantidad Consumida
        public void ActualizarCantidad(SqlConnection connection, int idConsumo, decimal nuevaCantidadConsumida)
        {
            // Definir las consultas SQL
            string updateConsumoQuery = "UPDATE Consumos SET CantidadConsumida = @NuevaCantidad WHERE idConsumo = @IdConsumo";
            string updateDisponibleQuery = "UPDATE Insumos SET CantidadDisponible = @NuevaCantidad WHERE idInsumo = (SELECT idInsumo FROM Consumos WHERE idConsumo = @IdConsumo)";

            // Iniciar una transacción
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Actualizar la cantidad consumida en la tabla Consumos
                using (SqlCommand command = new SqlCommand(updateConsumoQuery, connection, transaction))
                {
                    // Asignar parámetros
                    command.Parameters.AddWithValue("@NuevaCantidad", nuevaCantidadConsumida);
                    command.Parameters.AddWithValue("@IdConsumo", idConsumo);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();
                }

                // Actualizar la cantidad disponible en la tabla Insumos
                using (SqlCommand command = new SqlCommand(updateDisponibleQuery, connection, transaction))
                {
                    // Asignar parámetros
                    command.Parameters.AddWithValue("@NuevaCantidad", nuevaCantidadConsumida);
                    command.Parameters.AddWithValue("@IdConsumo", idConsumo);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();
                }

                // Confirmar la transacción
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Si ocurre algún error, hacer rollback de la transacción
                Console.WriteLine("Error: " + ex.Message);
                transaction.Rollback();
            }
        }
        #endregion

        // ----------- INSUMOS ---------------- 
        #region Alta Insumos
        public void AltaInsumos(string NombreInsumo, decimal CantidadDisponible, string UnidadMedida, string DescripcionProducto)
        {
            string conectionString;
            conectionString = Conexion();

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spi_AltaInsumos", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NombreInsumo", NombreInsumo);
                    command.Parameters.AddWithValue("@CantidadDisponible", CantidadDisponible);
                    command.Parameters.AddWithValue("@UnidadMedida", UnidadMedida);
                    command.Parameters.AddWithValue("@DescripcionProducto", DescripcionProducto);

                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al ejecutar el stored procedure para alta de insumos: " + ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar el stored procedure para alta de insumos: " + ex.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region Eliminar Insumos
        public void EliminarRegistroInsumos(string idInsumos)
        {
            string connectionString;
            connectionString = Conexion();

            // Consulta SQL para deshabilitar la restricción de referencia en la tabla 
            string disableConstraintQuery = "ALTER TABLE dbo.Consumos NOCHECK CONSTRAINT FK_InsumosConsumos";

            string deleteQuery = "DELETE FROM dbo.Insumos WHERE idInsumo = @IdInsumo";

            // Consulta SQL para habilitar nuevamente la restricción de referencia en la tabla sales
            string enableConstraintQuery = "ALTER TABLE dbo.Consumos CHECK CONSTRAINT FK_InsumosConsumos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Deshabilitar la restricción de referencia en la tabla sales
                    using (SqlCommand command = new SqlCommand(disableConstraintQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@IdInsumo", idInsumos);
                        command.ExecuteNonQuery();
                    }

                    // Habilitar nuevamente la restricción de referencia en la tabla sales
                    using (SqlCommand command = new SqlCommand(enableConstraintQuery, connection, transaction))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Deshacer la transacción en caso de error
                    transaction.Rollback();
                    throw new Exception("Error al eliminar el registro del donante: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
    
