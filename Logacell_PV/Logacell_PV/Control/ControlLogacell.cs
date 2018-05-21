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
        //string database = "logacell_logacell";
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public List<Producto> obtenerProductosByPV()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT p.ID, p.Categoria, p.Nombre, p.Marca, p.Modelo,p.Precio, s.Cantidad FROM producto p INNER JOIN stockPV s on p.ID = s.Producto where s.PuntoVenta="+idPV.id+" and s.Cantidad > 0;";
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
                        p.nombre = reader.GetString(2);
                        p.modelo = reader.GetString(4);
                        p.marca = reader.GetString(3);
                        p.precio = reader.GetString(5);
                        p.cantidad = reader.GetInt32(6);
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public int consultarUltimoIDProducto()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID FROM producto ORDER BY ID DESC LIMIT 1";
                conn.Open();
                int id;
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        conn.Close();
                        return id;
                    }
                    conn.Close();
                    return 0;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public string[] obtenerArregloProductos(string param)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT CONCAT( ID, ' - ', nombre, ' ' , Marca, ' ', Modelo) FROM producto where" +
                    " Nombre Like '%"+param+"%' or "+
                    " Marca Like '%" + param + "%' or "+
                    " Modelo Like '%" + param + "%'";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<string> aux = new List<string>();
                    while (reader.Read())
                    {
                        aux.Add(reader.GetString(0));
                    }
                    conn.Close();
                    if (aux.Count != 0)
                    {
                        return aux.ToArray();
                    }
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
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
                    cmd.CommandText= "INSERT INTO stockPV (Cantidad, Producto, PuntoVenta) VALUES (" + cantidad + ", " + id + ", '" + idPV.id + "')";
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
                conn.Close();
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public MySqlDataAdapter obtenerStockProductoPV(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT PV.Nombre AS 'Punto Venta', S.Cantidad AS Stock FROM producto P, stockPV S , puntoVenta PV WHERE P.Estado =1 and S.Producto = P.ID and PV.ID = S.PuntoVenta and P.ID =" + id , conn);
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                cmd.CommandText = "INSERT INTO cliente (Nombre,Direccion, Telefono, Correo, Observaciones) value ('"
                    + cliente.nombre + "','" + cliente.direcion + "','" + cliente.telefono + "','" + cliente.correo + "','"
                    + cliente.observaciones + "')";
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
                conn.Close();
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Nombre,Direccion,Telefono,Correo,Observaciones, is_Credito AS 'Crédito' FROM cliente where Estado=1", conn);
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
                conn.Close();
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
                    string sqlQuery = "SELECT Nombre,Direccion,Telefono,Correo,Observaciones,is_Credito AS 'Crédito' FROM cliente WHERE (" + 
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
                conn.Close();
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
                        s.observaciones = reader.GetString(4);
                        s.is_credito= reader.GetBoolean(6);
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
                conn.Close();
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
                        s.observaciones = reader.GetString(4);
                        s.is_credito = reader.GetBoolean(6);
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
                conn.Close();
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
                conn.Close();
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
                "',Direccion='" + cliente.direcion +
                "' ,Correo='" + cliente.correo + "',Observaciones='" + cliente.observaciones +
                "',is_Credito= " + cliente.is_credito + " ,Estado = 1 WHERE Telefono='" + cliente.telefono+"'";
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                        pv.prefijo = reader.GetString(7);
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                conn.Close();
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
                /**
                 START TRANSACTION;
                 SELECT @A:=SUM(salary) FROM table1 WHERE type=1;
                 UPDATE table2 SET summary=@A WHERE type=1;
                 COMMIT;
                 * **/
                string insertDetallesVenta = "";
                string updateStocks = "";
                foreach(DetalleVenta cv in venta.productos)
                {
                    insertDetallesVenta += " INSERT INTO detalleVenta (Producto, Venta, Cantidad,Total, Descuento) values (" +
                        cv.idProducto + ", '" + cv.folio + "'," + cv.cantidadProducto + "," + cv.total + "," + cv.descuento + "); ";
                    updateStocks += "UPDATE stockPV SET Cantidad = Cantidad - " + cv.cantidadProducto +
                        " WHERE Producto= " + cv.idProducto + " and PuntoVenta = "+idPV.id+"; ";
                }
                string insertPagosVenta = "";
                foreach (PagosVentas pv in venta.pagos)
                {
                    insertPagosVenta += " INSERT INTO pagosVentas (IDVenta, Pago, MetodoPago) values ('" +
                        pv.idVenta+"',"+ pv.pago+",'"+pv.formaPago+"'); ";
                }
                string insertVenta = "INSERT INTO venta (ID, Fecha, Total,PuntoVenta, Estado, Vendedor) values ('" +
                venta.id + "', '" + formatearFecha(DateTime.Now) + "','" + venta.total + "','" + idPV.id + "',1,'"+currentUser.empleado+"'); ";

                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    insertVenta + 
                                    insertDetallesVenta + 
                                    insertPagosVenta + 
                                    updateStocks +
                                    " COMMIT;";
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
                    throw new Exception("Error..! Error al agregar Venta a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT V.ID, V.Fecha, V.Total, PV.Nombre AS 'Punto de Venta', E.Nombre AS 'Vendedor' FROM venta V INNER JOIN puntoVenta PV ON PV.ID=V.PuntoVenta INNER JOIN empleado E ON E.Correo=V.Vendedor WHERE V.Estado=1", conn);
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
                conn.Close();
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
                    string sqlQuery = "SELECT V.ID, V.Fecha, V.Total, PV.Nombre AS 'Punto de Venta', E.Nombre AS 'Vendedor' FROM venta V INNER JOIN puntoVenta PV ON PV.ID=V.PuntoVenta INNER JOIN empleado E ON E.Correo=V.Vendedor WHERE (" +
                                        "V.ID LIKE '%" + parametro + "%' or " +
                                        "V.Fecha LIKE '%" + parametro + "%' or " +
                                        "V.Total LIKE '%" + parametro + "%' or " +
                                        "E.Nombre LIKE '%" + parametro + "%' or " +
                                        "PV.Nombre LIKE '%" + parametro + "%') and V.Estado = 1";
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
                conn.Close();
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
                conn.Close();
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
                        v.id = reader.GetInt32(0).ToString();
                        v.fecha = reader.GetDateTime(1);
                        v.total = reader.GetInt32(2);
                        v.puntoVenta = reader.GetInt32(3);
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public string folioVenta()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID FROM venta WHERE PuntoVenta="+idPV.id+" ORDER BY ID DESC LIMIT 1";
                conn.Open();
                try
                {
                    string folio="";
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        folio = reader.GetString(0);
                    }
                    conn.Close();
                    if (folio != "")
                    {
                        string prefijo = folio.Substring(0, 3);
                        folio = folio.Substring(5, 7);
                        int num = Convert.ToInt32(folio);
                        num++;
                        return prefijo + "-V" + num.ToString("0000000");
                    }
                    else
                        return idPV.prefijo + "-V0000001";
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Ventas de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //-------------------SOLICITUD SERVICIO------------------//
        public bool agregarSolicitudServicios(SolicitudServicio servicio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO solicitudServicio (Folio, NombreCliente, TelefonoCliente, Total, Anticipo, Pendiente, IDPuntoVenta) values ('"
                        + servicio.Folio + "','" + servicio.nombreCliente + "','" + servicio.telefonoCliente + "',"
                        + Convert.ToInt32(servicio.total) + "," + Convert.ToInt32(servicio.anticipo) + "," + Convert.ToInt32(servicio.pendiente) + ", '"+idPV.id+"' )";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0) { 
                        foreach (ServicioCliente serv in servicio.servicios)
                        {
                            agregarServiciosClientes(servicio.Folio, serv);
                        }
                        return true;
                    }
                    else
                        throw new Exception("Error..! Error al agregar la solicitud de servicio a la Base de Datos");
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Servicio Cliente a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public SolicitudServicio consultarSolicitudServicio(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM SolicitudServicio WHERE Folio='" + folio + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    SolicitudServicio sc = null;
                    while (reader.Read())
                    {
                        sc = new SolicitudServicio();
                        sc.Folio = reader.GetString(0);
                        sc.nombreCliente = reader.GetString(1);
                        sc.telefonoCliente = reader.GetString(2);
                        sc.total = reader.GetInt32(3).ToString();
                        sc.anticipo = reader.GetInt32(4).ToString();
                        sc.pendiente = reader.GetInt32(5).ToString();

                    }
                    if (sc != null)
                        return sc;
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
                conn.Close();
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT S.Folio, S.NombreCliente AS 'Nombre de Cliente', S.TelefonoCliente AS 'Telefono de Cliente', S.Total, S.Anticipo, S.Pendiente FROM solicitudServicio S  WHERE IDPuntoVenta = '" + idPV.id + "'", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicios solicitados de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
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
                    string sqlQuery = "SELECT S.Folio, S.NombreCliente AS 'Nombre de Cliente', S.TelefonoCliente AS 'Telefono de Cliente', S.Total, S.Anticipo, S.Pendiente FROM solicitudServicio S WHERE " +
                                        "( S.Folio LIKE '%" + parametro + "%' or " +
                                        "S.NombreCliente LIKE '%" + parametro + "%' or " +
                                        "S.TelefonoCliente LIKE '%" + parametro + "%') and S.IDPuntoVenta = '" + idPV.id + "'";
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public List<ServicioCliente> obtenerServiciosClientes(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM servicioCliente where Folio = '" + folio + "'";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<ServicioCliente> aux = new List<ServicioCliente>();
                    while (reader.Read())
                    {
                        ServicioCliente sc = new ServicioCliente();

                        sc.folio = reader.GetString(0);
                        sc.descripcion = reader.GetString(1);
                        sc.estado = reader.GetString(2);
                        sc.presupuesto = reader.GetString(3);
                        sc.contrasena = reader.GetString(4);
                        sc.patron = reader.GetString(5);
                        sc.pila = reader.GetBoolean(6);
                        sc.tapa = reader.GetBoolean(7);
                        sc.memoria = reader.GetBoolean(8);
                        sc.chip = reader.GetBoolean(9);

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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public string folioServicio()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Folio FROM solicitudServicio WHERE IDPuntoVenta=" + idPV.id + " ORDER BY ID DESC LIMIT 1";
                conn.Open();
                try
                {
                    string folio = "";
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        folio = reader.GetString(0);
                    }
                    conn.Close();
                    if (folio != "")
                    {
                        string prefijo = folio.Substring(0, 3);
                        folio = folio.Substring(5, 7);
                        int num = Convert.ToInt32(folio);
                        num++;
                        return prefijo + "-S" + num.ToString("0000000");
                    }
                    else
                        return idPV.prefijo + "-S0000001";
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Ventas de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

        //-------------------SERVICIO CLIENTE------------------//
        public bool agregarServiciosClientes(string folio, ServicioCliente servicio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO servicioCliente (Folio, Descripcion, Estado, Presupuesto, Contrasena, Patron, Pila, Tapa, Memoria, Chip) values ('"
                        + folio + "','" + servicio.descripcion + "','" + servicio.estado + "','"
                        + servicio.presupuesto + "','" + servicio.contrasena + "','" + servicio.patron +  "'," + servicio.pila + ","
                        + servicio.tapa + "," + servicio.memoria + "," + servicio.chip + " )";
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
                        throw new Exception("Error..! Error al agregar Servicio '"+ servicio.descripcion + "' a la Base de Datos");
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Servicio Cliente a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public ServicioCliente consultarServicioCliente(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM servicioCliente WHERE Folio='" + folio + "'";
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool actualizarEstadoServicioCliente(string id, string estado)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE servicioCliente WHERE SET Estado= '"+ estado +"' WHERE ID = '" + id + "'";
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
                    throw new Exception("Error..! Error al actualizar estado de Servicio de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
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
                "',Estado='" + servicioCliente.estado +",Presupuesto='" + servicioCliente.presupuesto +
                "',Contrasena='" + servicioCliente.contrasena + "',Patron='" + servicioCliente.patron +
                "',Pila='" + servicioCliente.pila + "',Tapa='" + servicioCliente.tapa + "',Memoria='" + servicioCliente.memoria +
                "',Chip='" + servicioCliente.chip + "' WHERE ID='" + servicioCliente.id + "'";
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public MySqlDataAdapter obtenerDetalleServiciosClientesTable(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Descripcion, Estado, Contrasena, Patron, Pila, Tapa, Memoria, Chip from servicioCliente where Folio = '"+folio+"'", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Servicios solicitados de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }


        //-------------------CREDITO CLIENTE------------------//
        public bool agregarCreditoClientes(CreditoCliente creditoCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO creditoCliente (Cliente,LimiteCredito,Deuda,Pendiente,Estado) values ('"
                    + creditoCliente.cliente + "','" + creditoCliente.limiteCredito + "','"
                    + creditoCliente.deuda + "','"   + creditoCliente.pendiente + "',1);"
                    +" update cliente set is_Credito=1 where Telefono='"+creditoCliente.cliente+"'";
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
                conn.Close();
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Cliente, LimiteCredito, Deuda,  Pendiente, Venta FROM creditoCliente WHERE Estado=1", conn);
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
                conn.Close();
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
                    string sqlQuery = "SELECT Cliente, LimiteCredito, Deuda, Pendiente, Venta FROM creditoCliente WHERE (" +
                                        "Cliente LIKE '%" + parametro + "%' or" +
                                        "LimiteCredito LIKE '%" + parametro + "%' or" +
                                        "Deuda LIKE '%" + parametro + "%' or" +
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
                conn.Close();
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
                    CreditoCliente c = new CreditoCliente();
                    while (reader.Read())
                    {
                        c.cliente = reader.GetString(0);
                        c.limiteCredito = reader.GetInt32(1);
                        c.deuda = reader.GetInt32(2);
                        c.pendiente = reader.GetInt32(3);
                        conn.Close();
                        return c;
                    }
                        return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
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
                        cc.pendiente = reader.GetInt32(3);
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
                conn.Close();
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarCreditoCliente(CreditoCliente creditoCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                int lim = 0;
                if (creditoCliente.limiteCredito == 0)
                    lim = 0;
                else
                    lim = 1;
                cmd.CommandText = "UPDATE cliente C INNER JOIN creditoCliente R ON R.Cliente = C.Telefono "+
                    "SET C.is_Credito="+lim+", R.LimiteCredito= '" + creditoCliente.limiteCredito +
                "',R.Deuda='" + creditoCliente.deuda + "',R.Pendiente='" + creditoCliente.pendiente +
                "', R.Estado = 1 WHERE C.Telefono='" + creditoCliente.cliente + "'";
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool cancelarCreditoCliente(CreditoCliente creditoCliente)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE cliente C INNER JOIN creditoCliente R ON R.Cliente = C.Telefono SET R.LimiteCredito=0 ,C.is_Credito=0" +
                " WHERE C.Telefono='" + creditoCliente.cliente + "'";
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        //---------------ABONO A CRÉDITO-----------------//
        public bool agregarAbonoCredito(AbonoCredito abono)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO abono (Cliente,Abono,Empleado,Fecha,PuntoVenta) value ('"
                    + abono.cliente + "','" + abono.abono + "','"
                    + abono.empleado + "','" + formatearFecha(DateTime.Now) + "',"
                    + idPV.id + ")";
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
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public AbonoCredito consultarAbonoCredito(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM abono WHERE ID='" + id + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    AbonoCredito c = new AbonoCredito();
                    while (reader.Read())
                    {
                        c.id = reader.GetInt32(0);
                        c.cliente = reader.GetString(1);
                        c.abono = reader.GetInt32(2);
                        c.empleado = reader.GetString(3);
                        c.fecha = reader.GetDateTime(4);
                        c.puntoVenta = reader.GetInt32(5);
                        conn.Close();
                        return c;
                    }
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Credito Cliente de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //----------------------Control--------------///
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
                    line = sr.ReadLine();
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
                    sw.WriteLine(idPV.id);
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
        public string formatearFecha(DateTime fecha)
        {
            DateTime aux;
            if (fecha != null)
                aux = DateTime.Now;
            else
                aux = fecha;

            string day;
            if (aux.Day.ToString().Length == 1)
                day = "0" + aux.Day.ToString();
            else
                day = aux.Day.ToString();
            string month;
            if (aux.Month.ToString().Length == 1)
                month = "0" + aux.Month.ToString();
            else
                month = aux.Month.ToString();
            string hour;
            if (aux.Hour.ToString().Length == 1)
                hour = "0" + aux.Hour.ToString();
            else
                hour = aux.Hour.ToString();
            string second;
            if (aux.Second.ToString().Length == 1)
                second = "0" + aux.Second.ToString();
            else
                second = aux.Second.ToString();
            string minute;
            if (aux.Minute.ToString().Length == 1)
                minute = "0" + aux.Minute.ToString();
            else
                minute = aux.Minute.ToString();

            return aux.Year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
        }

    }
}
