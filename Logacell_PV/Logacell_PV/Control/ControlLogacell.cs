using Logacell.DataObject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logacell.Control
{
    
    class ControlLogacell
    {
        MySqlConnection conn;
        MySqlConnectionStringBuilder builder;
        MySqlCommand cmd;
        string server = "logacell.com";
        string userID = "logacell_logamel";
        string password = "Logamel82";
        string database = "logacell_logamysql";
        public static PuntoVenta idPV;
        public static Usuario currentUser;
        public static ControlLogacell instance;
        public ControlLogacell()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = userID;
            builder.Password = password;
            builder.Database = database;
        }

        public static ControlLogacell getInstance()
        {
            if (instance == null)
            {
                instance = new ControlLogacell();
                return instance;
            }
            else
                return instance;
        }


        //-------------------PRODUCTOS------------------//
        public bool agregarProducto(Producto producto)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO producto (Categoria,Nombre,Modelo, Precio, Marca) value ('"
                    +producto.categoria + "','" +producto.nombre + "','" +producto.modelo + "','" 
                    +producto.precio + "','" +producto.marca+"')";
                //cmd.CommandText = "SELECT * FROM Productos";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Producto a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerProductosTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    //MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.ID, P.Categoria, P.Nombre, P.Modelo, P.Marca, P.Precio, S.Cantidad FROM producto P WHERE P.Estado =1 and S.PuntoVenta ="+idPV.id+" INNER JOIN stockPV S  ON S.Producto = P.ID", conn);
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.ID, P.Categoria, P.Nombre, P.Modelo, P.Marca, P.Precio, S.Cantidad AS Stock FROM producto P LEFT JOIN stockPV S ON S.Producto = P.ID and S.PuntoVenta="+idPV.id+" WHERE P.Estado =1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerProductosTable(string parameter)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlString = "SELECT P.ID, P.Categoria, P.Nombre, P.Modelo, P.Marca, P.Precio, S.Cantidad AS Stock FROM producto P LEFT JOIN stockPV S ON S.Producto = P.ID and S.PuntoVenta=" + idPV.id + 
                        " WHERE "+ 
                        " (P.ID LIKE '%" + parameter + "%' or " +
                        " P.Categoria LIKE '%" + parameter + "%' or " +
                        " P.Nombre LIKE '%" + parameter + "%' or " +
                        " P.Modelo LIKE '%" + parameter + "%' or " +
                        " P.Marca LIKE '%" + parameter + "%' or " +
                        " P.Precio LIKE '%" + parameter + "%') AND P.Estado=1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlString, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public Producto consultarProducto(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto WHERE id='"+id+"'";
                conn.Open();
                try
                {
                    
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto p = new Producto();

                        p.id = reader.GetInt32(0);
                        p.categoria = reader.GetString(1);
                        p.nombre = reader.GetString(2);
                        p.modelo = reader.GetString(3);
                        p.marca = reader.GetString(4);
                        p.precio = reader.GetString(5);
                        conn.Close();
                        return p;
                    }
                    conn.Close();
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<Producto> obtenerProductos()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                        List<Producto> aux = new List<Producto>();
                        while (reader.Read())
                        {
                            Producto p = new Producto();

                            p.id = reader.GetInt32(0);
                            p.categoria = reader.GetString(1);
                            p.nombre= reader.GetString(2);
                            p.modelo= reader.GetString(3);
                            p.marca= reader.GetString(5);
                            p.precio= reader.GetString(4);
                            aux.Add(p);
                        }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarProducto(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE producto SET Estado=0 WHERE ID = '"+id+"'";
                conn.Open();
                try
                {
                    
                    int rowsAfected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al eliminar Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarProducto(Producto producto)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE producto SET Categoria= '" + producto.categoria +
                "',Nombre='" + producto.nombre + "',Modelo='" + producto.modelo + "',Precio='" + producto.precio +
                "',Marca='" + producto.marca + "', Estado = 1 WHERE ID='" + producto.id + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Productos";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

        //-------------------stock--------------------//
        public bool actualizarStockProducto(string id, int cantidad)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM stockPV WHERE Producto=" + id + " and PuntoVenta =" + idPV.id ;
                try
                {
                    //cmd.CommandText = "SELECT * FROM Productos";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    cmd.CommandText= "INSERT INTO stockPV (Cantidad, Producto, PuntoVenta) VALUES (" + cantidad + ", " + id + "," + idPV.id + ")";
                    rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar el stock del Producto en la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public int obtenerStockProducto(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText =  "SELECT Cantidad FROM stockPV WHERE Producto=" + id + " and PuntoVenta=" + idPV.id;
                conn.Open();
                try
                {
                    //cmd.CommandText = "SELECT * FROM Productos";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int x = reader.GetInt32(0);
                        conn.Close();
                        return x;
                    }
                    conn.Close();
                    return -1;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al obtener el stock del Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //-------------------SERVICIOS------------------//
        public bool agregarServicios(Servicio servicio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO servicio (Nombre,Descripcion, Costo, Duracion) value ('"
                    + servicio.nombre + "','" + servicio.descripcion + "','" + servicio.costo + "','"
                    + servicio.duracion + "')";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Servicio a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerServiciosTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Nombre, Descripcion, Costo, Duracion FROM servicio WHERE Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerServiciosTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT ID, Nombre, Descripcion, Costo, Duracion FROM servicio WHERE (" +
                                        "ID LIKE '%" + parametro + "%' or " +
                                        "Nombre LIKE '%" + parametro + "%' or " +
                                        "Descripcion LIKE '%" + parametro + "%' or " +
                                        "Costo LIKE '%" + parametro + "%' or " +
                                        "Duracion LIKE '%" + parametro + "%') and Estado = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public Servicio consultarServicio(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM servicio WHERE id='" + id + "'";
                conn.Open();
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Servicio s = new Servicio();

                        s.id = reader.GetInt32(0);
                        s.nombre = reader.GetString(1);
                        s.descripcion = reader.GetString(2);
                        s.costo = reader.GetString(3);
                        s.duracion = reader.GetString(4);
                        conn.Close();
                        return s;
                    }
                    conn.Close();
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<Servicio> obtenerServicios()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM servicio";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<Servicio> aux = new List<Servicio>();
                    while (reader.Read())
                    {
                        Servicio s = new Servicio();

                        s.id = reader.GetInt32(0);
                        s.nombre = reader.GetString(1);
                        s.descripcion = reader.GetString(2);
                        s.costo = reader.GetString(3);
                        s.duracion = reader.GetString(4);
                        aux.Add(s);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarServicio(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE servicio SET Estado=0 WHERE ID = '" + id + "'";
                conn.Open();
                try
                {

                    int rowsAfected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al eliminar Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarServicio(Servicio servicio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE servicio SET Nombre= '" + servicio.nombre +
                "',Descripcion='" + servicio.descripcion + "',Costo='" + servicio.costo + 
                "',Duracion='" + servicio.duracion +
                "', Estado = 1 WHERE ID='" + servicio.id + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //-------------------CLIENTE------------------//
        public bool agregarCliente(Cliente cliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO cliente (Nombre,Direccion, Telefono, Correo, Observaciones, Frecuente) value ('"
                    + cliente.nombre + "','" + cliente.direcion + "','" + cliente.telefono + "','" + cliente.correo + "','"
                    + cliente.observaciones + "'," + cliente.isFrecuente + ")";
                //cmd.CommandText = "SELECT * FROM Clientes";

                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Cliente a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerClientesTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Nombre,Direccion,Telefono,Correo,Frecuente,Observaciones FROM cliente where Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerClientesFrecuentesTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Nombre, Direccion, Telefono, Correo, Frecuente, Observaciones FROM cliente where Frecuente = true and Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerClientesTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT Nombre,Direccion,Telefono,Correo,Frecuente,Observaciones FROM cliente WHERE (" + 
                        " Nombre LIKE '%" + parametro + "%' OR " +
                        " Direccion LIKE '%" + parametro + "%' OR " +
                        " Telefono LIKE '%" + parametro + "%' OR " +
                        " Correo LIKE '%" + parametro + "%'" +
                        ") AND Estado = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerClientesFrecuentesTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT Nombre,Direccion,Telefono,Correo,Frecuente,Observaciones FROM cliente WHERE (" +
                        " Nombre LIKE '%" + parametro + "%' OR " +
                        " Direccion LIKE '%" + parametro + "%' OR " +
                        " Telefono LIKE '%" + parametro + "%' OR " +
                        " Correo LIKE '%" + parametro + "%'" +
                        ") AND Estado = 1 AND Frecuente = true";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public Cliente consultarCliente(string telefono)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM cliente WHERE Telefono='" + telefono + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente s = new Cliente();

                        s.nombre = reader.GetString(0);
                        s.direcion = reader.GetString(1);
                        s.telefono = reader.GetString(2);
                        s.correo = reader.GetString(3);
                        s.observaciones = reader.GetString(5);
                        s.isFrecuente = reader.GetBoolean(4);
                        conn.Close();
                        return s;
                    }
                    conn.Close();
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<Cliente> obtenerClientes()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM cliente";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<Cliente> aux = new List<Cliente>();
                    while (reader.Read())
                    {
                        Cliente s = new Cliente();

                        s.nombre = reader.GetString(0);
                        s.direcion = reader.GetString(1);
                        s.telefono = reader.GetString(2);
                        s.correo = reader.GetString(3);
                        s.observaciones = reader.GetString(5);
                        s.isFrecuente = reader.GetBoolean(4);
                        aux.Add(s);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarCliente(string telefono)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE cliente SET Estado = 0 WHERE Telefono = '" + telefono + "'";
                conn.Open();
                try
                {

                    int rowsAfected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al eliminar Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarCliente(Cliente cliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE cliente SET Nombre= '" + cliente.nombre +
                "',Direccion='" + cliente.direcion + "',Frecuente= " + cliente.isFrecuente +
                " ,Correo='" + cliente.correo + "',Observaciones='" + cliente.observaciones +
                "' ,Estado = 1 WHERE Telefono='" + cliente.telefono + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Clientes";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

        
        //------------------EMPLEADO------------------//
        public Empleado consultarEmpleado(string correo)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM empleado WHERE Correo='" + correo + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Empleado s = new Empleado();

                        s.nombre = reader.GetString(0);
                        s.direcion = reader.GetString(1);
                        s.telefono = reader.GetString(2);
                        s.correo = reader.GetString(3);
                        s.puesto = reader.GetString(4);
                        conn.Close();
                        return s;
                    }
                    conn.Close();
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Empleado de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool actualizarEmpleado(Empleado empleado)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE empleado SET Nombre= '" + empleado.nombre +
                "',Direccion='" + empleado.direcion + "',Telefono='" + empleado.telefono +
                "',Puesto='" + empleado.puesto +
                "', Estado = 1 WHERE Correo='" + empleado.correo + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar Empleado de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

       
        //------------------PUNTOVENTA------------------//
        public PuntoVenta consultarPuntoVenta(string ID)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM puntoVenta WHERE ID='" + ID + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PuntoVenta pv = new PuntoVenta();
                        pv.id = reader.GetInt32(0);
                        pv.nombre = reader.GetString(1);
                        pv.direcion = reader.GetString(2);
                        pv.telefono = reader.GetString(3);
                        pv.activo = reader.GetString(4);
                        pv.usuario = reader.GetString(5);
                        conn.Close();
                        return pv;
                    }
                    conn.Close();
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Punto de Ventas de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<PuntoVenta> obtenerPuntoVentas()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM puntoVenta WHERE Estado = true";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<PuntoVenta> aux = new List<PuntoVenta>();
                    while (reader.Read())
                    {
                        PuntoVenta pv = new PuntoVenta();

                        pv.id = reader.GetInt32(0);
                        pv.nombre = reader.GetString(1);
                        pv.direcion = reader.GetString(2);
                        pv.telefono = reader.GetString(3);
                        pv.activo = reader.GetString(5);
                        pv.usuario = reader.GetString(4);
                        aux.Add(pv);
                    }
                    conn.Close();
                    if (aux.Count!=0) 
                        return aux;
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Punto de Ventas de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public void setIDPV(string id)
        {
            idPV = consultarPuntoVenta(id);
        }

        
        //------------------USUARIO------------------//
        public Usuario consultarUsuario(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario WHERE Empleado='" + id + "' or Usuario ='"+id+"'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario pv = new Usuario();
                        pv.empleado = reader.GetString(0);
                        pv.usuario = reader.GetString(1);
                        pv.contraseña = reader.GetString(2);
                        conn.Close();
                        return pv;
                    }
                    conn.Close();
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Usuarios de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool actualizarUsuario(Usuario usuario)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE usuario SET Usuario= '" + usuario.usuario +
                "',Contraseña='" + usuario.contraseña +
                "',Estado = 1 WHERE Empleado='" + usuario.empleado + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar usuario de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

        public void setCurrentUser(string user)
        {
            currentUser = consultarUsuario(user);
        }
        //------------------VENTA------------------//
        public bool agregarVenta(Venta venta)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO venta (Fecha,Total,MetodoPago,PuntoVenta,Estado) value ('"
                    + venta.fecha + "','" + venta.total + "','" + venta.metodoPago + "','" + venta.puntoVenta + "',1)";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Venta a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerVentasTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Fecha, Total, MetodoPago, PuntoVenta FROM venta WHERE Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerVentasTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT ID, Fecha, Total, MetodoPago, PuntoVenta FROM venta WHERE (" +
                                        "ID LIKE '%" + parametro + "%' or" +
                                        "Fecha LIKE '%" + parametro + "%' or" +
                                        "Total LIKE '%" + parametro + "%' or" +
                                        "MetodoPago LIKE '%" + parametro + "%' or" +
                                        "PuntoVenta LIKE '%" + parametro + "%') and Estado = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public Venta consultarVenta(string ID)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM venta WHERE ID='" + ID + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (reader.HasRows)
                    {
                        Venta aux = null;
                        foreach (Venta p in reader)
                        {
                            aux = p;
                        }
                        return aux;
                    }
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Ventas de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<Venta> obtenerVentas()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM venta";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<Venta> aux = new List<Venta>();
                    while (reader.Read())
                    {
                        Venta v = new Venta();
                        v.id = reader.GetInt32(0);
                        v.fecha = reader.GetDateTime(1);
                        v.total = reader.GetString(2);
                        v.metodoPago = reader.GetString(3);
                        v.puntoVenta = reader.GetInt32(4);
                        aux.Add(v);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarVenta(string ID)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE venta WHERE SET Estado=0 WHERE ID = '" + ID + "'";
                conn.Open();
                try
                {

                    int rowsAfected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al eliminar Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarVenta(Venta venta)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE venta SET Fecha= '" + venta.fecha +
                "',Total='" + venta.total +
                "',MetodoPago='" + venta.metodoPago +
                "',PuntoVenta='" + venta.puntoVenta +
                "',Estado = 1 WHERE ID='" + venta.id + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

       
        //-------------------SERVICIOCLIENTE------------------//
        public bool agregarServiciosClientes(ServicioCliente servicioCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO servicioCliente (Descripcion,Estado, Servicio, Cliente, Presupuesto,Activo) value ('"
                    + servicioCliente.descripcion + "','" + servicioCliente.estado + "','"
                    + servicioCliente.servicio + "','" + servicioCliente.cliente + "','"
                    + servicioCliente.presupuesto + "',1)";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Servicio Cliente a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerServiciosClientesTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Descripcion, Estado, Servicio, Cliente, Presupuesto FROM servicioCliente WHERE Activo=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerServiciosClientesTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT ID, Descripcion, Estado, Servicio, Cliente, Presupuesto FROM servicioCliente WHERE (" +
                                        "ID LIKE '%" + parametro + "%' or" +
                                        "Descripcion LIKE '%" + parametro + "%' or" +
                                        "Estado LIKE '%" + parametro + "%' or" +
                                        "Servicio LIKE '%" + parametro + "%' or" +
                                        "Cliente LIKE '%" + parametro + "%' or" +
                                        "Presupuesto LIKE '%" + parametro + "%') and Activo = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public ServicioCliente consultarServicioCliente(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM servicioCliente WHERE id='" + id + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (reader.HasRows)
                    {
                        ServicioCliente aux = null;
                        foreach (ServicioCliente p in reader)
                        {
                            aux = p;
                        }
                        return aux;
                    }
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<ServicioCliente> obtenerServiciosClientes()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM servicioCliente";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<ServicioCliente> aux = new List<ServicioCliente>();
                    while (reader.Read())
                    {
                        ServicioCliente sc = new ServicioCliente();

                        sc.id = reader.GetInt32(0);
                        sc.descripcion = reader.GetString(1);
                        sc.estado = reader.GetString(2);
                        sc.servicio = reader.GetInt32(3);
                        sc.cliente = reader.GetString(4);
                        sc.presupuesto = reader.GetString(4);
                        aux.Add(sc);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicio Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarServicioCliente(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE servicioCliente WHERE SET Activo=0 WHERE ID = '" + id + "'";
                conn.Open();
                try
                {

                    int rowsAfected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al eliminar Servicio Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarServicioCliente(ServicioCliente servicioCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE servicioCliente SET Descripcion= '" + servicioCliente.descripcion +
                "',Estado='" + servicioCliente.estado + "',Servicio='" + servicioCliente.servicio +
                "',Cliente='" + servicioCliente.cliente + ",Presupuesto='" + servicioCliente.presupuesto +
                "', Activo = 1 WHERE ID='" + servicioCliente.id + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar Servicio Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool actualizarEstadoServicioCliente(String id, String estado)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE servicioCliente SET Estado='" + estado +
                "', Activo = 1 WHERE ID='" + id + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar el estado del Servicio en la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //-------------------SERVICIOCLIENTE------------------//
        public bool agregarCreaditoClientes(CreditoCliente creditoCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO creditoClientes (Cliente,LimiteCredito,Deuda,Abono,Pendiente,Venta,Estado) value ('"
                    + creditoCliente.cliente + "','" + creditoCliente.limiteCredito + "','"
                    + creditoCliente.deuda + "','" + creditoCliente.abono + "','"
                    + creditoCliente.pendiente + "','" + creditoCliente.venta + "',1)";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Credito Cliente a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerCreditoClientesTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Cliente, LimiteCredito, Deuda, Abono, Pendiente, Venta FROM creditoCliente WHERE Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerCreditoClientesTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT Cliente, LimiteCredito, Deuda, Abono, Pendiente, Venta FROM creditoCliente WHERE (" +
                                        "Cliente LIKE '%" + parametro + "%' or" +
                                        "LimiteCredito LIKE '%" + parametro + "%' or" +
                                        "Deuda LIKE '%" + parametro + "%' or" +
                                        "Abono LIKE '%" + parametro + "%' or" +
                                        "Pendiente LIKE '%" + parametro + "%' or" +
                                        "Venta LIKE '%" + parametro + "%') and Activo = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public CreditoCliente consultarCreditoCliente(string cliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM creditoCliente WHERE Cliente='" + cliente + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (reader.HasRows)
                    {
                        CreditoCliente aux = null;
                        foreach (CreditoCliente p in reader)
                        {
                            aux = p;
                        }
                        return aux;
                    }
                    else
                        return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<CreditoCliente> obtenerCreditoClientes()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM creditoCliente";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<CreditoCliente> aux = new List<CreditoCliente>();
                    while (reader.Read())
                    {
                        CreditoCliente cc = new CreditoCliente();

                        cc.cliente = reader.GetString(0);
                        cc.limiteCredito = reader.GetInt32(1);
                        cc.deuda = reader.GetInt32(2);
                        cc.abono = reader.GetInt32(3);
                        cc.pendiente = reader.GetInt32(4);
                        cc.venta = reader.GetInt32(4);
                        aux.Add(cc);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarCreditoCliente(string cliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE creditoCliente WHERE SET Estado=0 WHERE Cliente = '" + cliente + "'";
                conn.Open();
                try
                {

                    int rowsAfected = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al eliminar Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarCreditoCliente(CreditoCliente creditoCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE creditoCliente SET LimiteCredito= '" + creditoCliente.limiteCredito +
                "',Deuda='" + creditoCliente.deuda + "',Abono='" + creditoCliente.abono +
                "',Pendiente='" + creditoCliente.pendiente + ",Venta='" + creditoCliente.venta +
                "', Estado = 1 WHERE Cliente='" + creditoCliente.cliente + "'";
                try
                {
                    //cmd.CommandText = "SELECT * FROM Servicios";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al actualizar Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        public string leerUserDoc()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("thumbs.txt");
                //read de first line
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line == "us")
                    {
                        return sr.ReadLine();
                    }
                }
                //close the file
                sr.Close();
                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public string leerPVDoc()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("thumbs.txt");
                //read de first line
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    if (line == "pv")
                    {
                        return sr.ReadLine();
                    }
                }
                //close the file
                sr.Close();
                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public bool escribirDoc()
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("thumbs.txt");
                //Write a line of text
                if (currentUser.usuario != null)
                {
                    sw.WriteLine("us");
                    sw.WriteLine(currentUser.usuario);
                }
                if (idPV != null)
                {
                    sw.WriteLine("pv");
                    sw.WriteLine(idPV);
                }
                //Close the file
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
