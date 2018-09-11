using Logacell_Admin.DataObject;
using Logacell_Admin.DataObject;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logacell_Admin.Control
{
    class ControlLogacell_Admin
    {
        MySqlConnection conn;
        MySqlConnectionStringBuilder builder;
        MySqlCommand cmd;
        string server = "logacell.com";
        string userID = "logacell_logamel";
        string password = "Logamel82";
        //string database = "logacell_logamysql";
        string database = "logacell_logacell";
        public static Usuario currentUser;
        public static ControlLogacell_Admin instance;
        public ControlLogacell_Admin()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = userID;
            builder.Password = password;
            builder.Database = database;
            builder.AllowUserVariables = true;
            builder.ConvertZeroDateTime = true;
            builder.AllowZeroDateTime = true;
        }

        public static ControlLogacell_Admin getInstance()
        {
            if (instance == null)
            {
                instance = new ControlLogacell_Admin();
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
                    + producto.categoria + "','" + producto.nombre + "','" + producto.modelo + "','"
                    + producto.precio + "','" + producto.marca + "')";
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Categoria, Nombre, Modelo, Marca, Precio FROM producto WHERE Estado =1", conn);
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
                    string sqlString = "SELECT P.ID, P.Categoria, P.Nombre, P.Modelo, P.Marca, P.Precio FROM producto P WHERE " +
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
                cmd.CommandText = "SELECT * FROM producto WHERE id='" + id + "'";
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
                        p.nombre = reader.GetString(2);
                        p.modelo = reader.GetString(3);
                        p.marca = reader.GetString(4);
                        p.precio = reader.GetString(5);
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
                cmd.CommandText = "SELECT p.ID, p.Categoria, p.Nombre, p.Marca, p.Modelo,p.Precio, s.Cantidad FROM producto p INNER JOIN stockPV s on p.ID = s.Producto where and s.Cantidad > 0;";
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
                cmd.CommandText = "UPDATE producto SET Estado=0 WHERE ID = '" + id + "'";
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
                    " Nombre Like '%" + param + "%' or " +
                    " Marca Like '%" + param + "%' or " +
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
        public bool actualizarStockProducto(string id, int cantidad, int pv)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM stockPV WHERE Producto=" + id + " and PuntoVenta =" + pv;
                try
                {
                    //cmd.CommandText = "SELECT * FROM Productos";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO stockPV (Cantidad, Producto, PuntoVenta) VALUES (" + cantidad + ", " + id + ", '" + pv + "')";
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
        public int obtenerStockProducto(string id, int pv)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Cantidad FROM stockPV WHERE Producto=" + id + " and PuntoVenta=" + pv;
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
        public int obtenerStockProducto(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT sum(Cantidad) FROM stockPV WHERE Producto=" + id;
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT PV.Nombre AS 'Punto Venta', S.Cantidad AS Stock FROM producto P, stockPV S , puntoVenta PV WHERE P.Estado =1 and S.Producto = P.ID and P.ID =" + id, conn);
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
        public bool actualizarMinMaxProducto(string id, int min, int max)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM productoMinMax WHERE Producto=" + id;
                try
                {
                    //cmd.CommandText = "SELECT * FROM Productos";
                    conn.Open();
                    int rowsAfected = cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO productoMinMax (Producto, Minimo, Maximo) VALUES (" + id + ", " + min + ", '" + max + "')";
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
        public int[] obtenerMinMaxProducto(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Minimo, Maximo FROM productoMinMax WHERE Producto=" + id;
                conn.Open();
                try
                {
                    //cmd.CommandText = "SELECT * FROM Productos";
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int[] x = new int[2];
                        x[0] = reader.GetInt32(0);
                        x[1] = reader.GetInt32(1);
                        conn.Close();
                        return x;
                    }
                    conn.Close();
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al obtener el min/max del Producto de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }

        //---------------------------TRASPASOS-----------------//
        public Traspaso consultarTraspaso(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT ID, Origen, Destino,Producto, Cantidad, Estado, Observaciones FROM traspaso WHERE ID='" + id + "';";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Traspaso tras = new Traspaso();
                        tras.id = reader.GetInt32(0);
                        tras.idOrigen = reader.GetInt32(1);
                        tras.idDestino = reader.GetInt32(2);
                        tras.producto = reader.GetInt32(3);
                        tras.cantidad = reader.GetInt32(4);
                        tras.estado = reader.GetString(5);
                        tras.observaciones = reader.GetString(6);
                        conn.Close();
                        return tras;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al obtener traspaso a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerTraspasosTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT T.ID, PV.Nombre AS 'Origen', PV2.Nombre AS 'Destino', T.Cantidad, P.Nombre AS 'Producto' , T.Estado, T.Observaciones FROM traspaso T, producto P, puntoVenta PV ,puntoVenta PV2 WHERE PV.ID=T.Origen AND PV2.ID=T.Destino AND T.Producto = P.ID", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de traspasos de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerTraspasosTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT T.ID, PV.Nombre AS 'Origen', PV2.Nombre AS 'Destino', T.Cantidad, P.Nombre  AS 'Producto', T.Estado, T.Observaciones FROM traspaso T, producto P, puntoVenta PV ,puntoVenta PV2 WHERE " +
                        "(PV.Nombre LIKE '%" + parametro + "%' or " +
                        "T.ID LIKE '%" + parametro + "%' or " +
                        "PV2.Nombre LIKE '%" + parametro + "%' or " +
                        "P.Nombre LIKE '%" + parametro + "%' or " +
                        "T.Estado LIKE '%" + parametro + "%'" +
                        ") AND PV.ID=T.Origen AND PV2.ID=T.Destino AND T.Producto = P.ID", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de traspasos de la Base de Datos");
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
                        s.is_credito = reader.GetBoolean(6);
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
                "',is_Credito= " + cliente.is_credito + " ,Estado = 1 WHERE Telefono='" + cliente.telefono + "'";
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
        public bool agregarEmpleados(Empleado empleado, Usuario usuario)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());

                cmd = conn.CreateCommand();
                string emp = "INSERT INTO empleado (Nombre,Direccion,Telefono,Correo,Puesto,Estado) values ('"
                    + empleado.nombre + "','" + empleado.direcion + "','" + empleado.telefono + "','"
                    + empleado.correo + "','" + empleado.puesto + "',1);";
                //cmd.CommandText = "SELECT * FROM Servicios";
                string user = "";
                if (usuario!=null)
                    user = "INSERT INTO usuario (Usuario,Empleado, Contrasena, Estado) VALUES ('" + usuario.usuario +
                "','" + usuario.contraseña + "','" + empleado.correo + "'," + usuario.estado + ");";
                cmd.CommandText = emp +  user;
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 2)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al agregar Empleado a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerEmpleadosTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Nombre, Direccion, Telefono, Correo, Puesto FROM empleado WHERE Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
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
        public MySqlDataAdapter obtenerEmpleadosTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT Nombre, Direccion, Telefono, Correo, Puesto FROM empleado WHERE (" +
                                        "Nombre LIKE '%" + parametro + "%' or" +
                                        "Direccion LIKE '%" + parametro + "%' or" +
                                        "Telefono LIKE '%" + parametro + "%' or" +
                                        "Correo LIKE '%" + parametro + "%' or" +
                                        "Puesto LIKE '%" + parametro + "%') and Estado = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Empleados de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
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
        public bool actualizarEmpleado(Empleado empleado, string usuario, string contrasena, bool acceso)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
               string emp = "UPDATE empleado SET Nombre= '" + empleado.nombre +
                "',Direccion='" + empleado.direcion + "',Telefono='" + empleado.telefono +
                "',Puesto='" + empleado.puesto +
                "', Estado = 1 WHERE Correo='" + empleado.correo + "';";
                string user = "UPDATE usuario SET Usuario= '" + usuario +
                "',Contrasena='" + contrasena +
                "',Estado = "+acceso+" WHERE Empleado='" + empleado.correo + "';";
                cmd.CommandText = "START TRANSACTION; " +
                                    emp +
                                    user +
                                    " COMMIT;";
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

        public List<Empleado> obtenerEmpleados()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM empleado";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<Empleado> aux = new List<Empleado>();
                    while (reader.Read())
                    {
                        Empleado e = new Empleado();

                        e.nombre = reader.GetString(0);
                        e.direcion = reader.GetString(1);
                        e.telefono = reader.GetString(2);
                        e.correo = reader.GetString(3);
                        e.puesto = reader.GetString(4);
                        aux.Add(e);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
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
        public bool eliminarEmpleado(string correo)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE empleado SET Estado=0 WHERE Correo = '" + correo + "'";
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
                    throw new Exception("Error..! Error al eliminar Empleado de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool entradaEmpleado()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO bitacoraEmpleados (Empleado, Fecha, CheckOut, IDPuntoVenta) values ('" +
                    currentUser.empleado + "', now(), null, 0 );";
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
                    throw new Exception("Error..! Error al ingresar entrada de empleado");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool salidaEmpleado()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SET @id = 0; " +
                "SELECT @id := ID FROM bitacoraEmpleados WHERE Empleado = '" + currentUser.empleado + "' ORDER BY ID DESC LIMIT 1; " +
                "UPDATE bitacoraEmpleados SET CheckOut = CURRENT_TIME() WHERE ID = @id;";
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
                    throw new Exception("Error..! Error al registrar salida de empleado");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //------------------PUNTOVENTA------------------//
        public bool agregarPuntoVentas(PuntoVenta puntoVenta)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO puntoVenta (Nombre,Direccion,Telefono,Activo,Usuario,Estado) value ('"
                    + puntoVenta.nombre + "','" + puntoVenta.direcion + "','" + puntoVenta.telefono + "','"
                    + puntoVenta.activo + "','" + puntoVenta.usuario + "',1)";
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
                    throw new Exception("Error..! Error al agregar Punto de Venta a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerPuntoVentasTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Nombre, Direccion, Telefono, Activo, Usuario FROM puntoVenta WHERE Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Punto de Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerPuntoVentasTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT ID, Nombre, Direccion, Telefono, Activo, Usuario FROM puntoVenta WHERE (" +
                                        "ID LIKE '%" + parametro + "%' or" +
                                        "Nombre LIKE '%" + parametro + "%' or" +
                                        "Direccion LIKE '%" + parametro + "%' or" +
                                        "Telefono LIKE '%" + parametro + "%' or" +
                                        "Activo LIKE '%" + parametro + "%' or" +
                                        "Usuario LIKE '%" + parametro + "%') and Estado = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
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
                cmd.CommandText = "SELECT * FROM puntoVenta";
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
                    if (aux.Count != 0)
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
        public bool eliminarPuntoVenta(string ID)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE puntoVenta WHERE SET Estado=0 WHERE ID = '" + ID + "'";
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
                    throw new Exception("Error..! Error al eliminar Punto de Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool actualizarPuntoVenta(PuntoVenta puntoVenta)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE puntoVenta SET Nombre= '" + puntoVenta.nombre +
                "',Direccion='" + puntoVenta.direcion + "',Telefono='" + puntoVenta.telefono +
                "',Activo='" + puntoVenta.activo + "',Usuario='" + puntoVenta.usuario +
                "',Estado = 1 WHERE ID='" + puntoVenta.id + "'";
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
                    throw new Exception("Error..! Error al actualizar Punto de Venta de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }


        //------------------USUARIO------------------//
        public bool agregarUsuario(Usuario usuario)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO usuario (Empleado,Usuario,Contrasena,Estado) value ('"
                    + usuario.empleado + "','" + usuario.usuario + "','" + usuario.contraseña + "',1)";
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
                    throw new Exception("Error..! Error al agregar Usuario a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerUsuario()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT Empleado, Usuario, Contrasena FROM usuario WHERE Estado=1", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Usuario de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerUsuariosTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    string sqlQuery = "SELECT Empleado, Usuario, Contrasena FROM usuario WHERE (" +
                                        "Empleado LIKE '%" + parametro + "%' or" +
                                        "Usuario LIKE '%" + parametro + "%') and Estado = 1";
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter(sqlQuery, conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Usuario de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public List<Usuario> obtenerUsuarios()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<Usuario> aux = new List<Usuario>();
                    while (reader.Read())
                    {
                        Usuario u = new Usuario();
                        u.empleado = reader.GetString(0);
                        u.usuario = reader.GetString(1);
                        u.contraseña = reader.GetString(2);
                        aux.Add(u);
                    }
                    conn.Close();
                    if (aux.Count != 0) return aux;
                    else return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Usuario de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public bool eliminarUsuario(string empleado)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE usuario WHERE SET Estado=0 WHERE Empleado = '" + empleado + "'";
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
                    throw new Exception("Error..! Error al eliminar Usuario de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public Usuario consultarUsuario(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario WHERE Empleado='" + id + "' or Usuario ='" + id + "'";
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
                        pv.estado = reader.GetBoolean(3);
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
            try
            {
                currentUser = consultarUsuario(user);
            }
            catch (Exception ex)
            {

            }
        }

        //------------------VENTA------------------//
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
                                        "PV.Nombre LIKE '%" + parametro + "%') and V.Estado = 1 ";
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
                    while (reader.Read())
                    {
                        Venta aux = new Venta();
                        aux.id = reader.GetString(0);
                        aux.fecha = reader.GetDateTime(1);
                        aux.total = reader.GetDouble(2);
                        aux.puntoVenta = reader.GetInt32(3);
                        aux.vendedor = reader.GetString(5);
                        conn.Close();
                        return aux;
                    }
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
        public MySqlDataAdapter obtenerDetalleVentasTable(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT V.ID, P.Nombre AS 'Producto', V.Cantidad, V.Total AS 'Subtotal' , V.Descuento, V.Total-V.Descuento AS 'Total' FROM detalleVenta V INNER JOIN producto P ON P.ID=V.Producto WHERE V.Venta='" + folio + "'", conn);
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

        //-------------------SOLICITUD SERVICIO------------------//
        public SolicitudServicio consultarSolicitudServicio(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM solicitudServicio WHERE Folio='" + folio + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
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
                    conn.Close();
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT S.Folio, S.NombreCliente AS 'Nombre de Cliente', S.TelefonoCliente AS 'Telefono', C.Estado, S.Total, S.Anticipo, S.Pendiente FROM solicitudServicio S, servicioCliente C  WHERE C.Folio=S.Folio ", conn);
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
                    string sqlQuery = "SELECT S.Folio, S.NombreCliente AS 'Nombre de Cliente', S.TelefonoCliente AS 'Telefono', C.Estado, S.Total, S.Anticipo, S.Pendiente FROM solicitudServicio S, servicioCliente C WHERE " +
                                        "( S.Folio LIKE '%" + parametro + "%' or " +
                                        "S.NombreCliente LIKE '%" + parametro + "%' or " +
                                        "C.Estado LIKE '%" + parametro + "%' or " +
                                        "C.Descripcion LIKE '%" + parametro + "%' or " +
                                        "S.Fecha LIKE '%" + parametro + "%' or " +
                                        "S.TelefonoCliente LIKE '%" + parametro + "%') and C.Folio=S.Folio ";
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

        //-------------------SERVICIO CLIENTE------------------//
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
                    while (reader.Read())
                    {
                        ServicioCliente aux = new ServicioCliente();
                        aux.id = reader.GetInt32(0);
                        aux.folio = reader.GetString(1);
                        aux.descripcion = reader.GetString(2);
                        aux.estado = reader.GetString(3);
                        aux.presupuesto = reader.GetString(4);
                        aux.contrasena = reader.GetString(5);
                        aux.patron = reader.GetString(6);
                        aux.pila = reader.GetBoolean(7);
                        aux.tapa = reader.GetBoolean(8);
                        aux.memoria = reader.GetBoolean(9);
                        aux.chip = reader.GetBoolean(10);
                        aux.IMEI = reader.GetString(11);

                        conn.Close();
                        return aux;
                    }
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
                cmd.CommandText = "UPDATE servicioCliente SET Estado= '" + estado + "' WHERE Folio='" + id + "';";
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
        public bool cancelarServicioCliente(ServicioCliente servicio)
        {
            try
            {
                string updateEstado = "UPDATE servicioCliente SET Estado= 'Cancelado' WHERE ID = '" + servicio.id + "';";
                string updateSolicitud = "UPDATE solicitudServicio SET Total = Total-" + servicio.presupuesto + " , Pendiente = Total - Anticipo WHERE Folio = '" + servicio.folio + "';";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();

                cmd.CommandText = "START TRANSACTION; " +
                                    updateEstado +
                                    updateSolicitud +
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
                "',Estado='" + servicioCliente.estado + ",Presupuesto='" + servicioCliente.presupuesto +
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Descripcion, Estado, Contrasena, Patron, Pila, Tapa, Memoria, Chip, IMEI from servicioCliente where Folio = '" + folio + "'", conn);
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
                    + creditoCliente.deuda + "','" + creditoCliente.pendiente + "',1);"
                    + " update cliente set is_Credito=1 where Telefono='" + creditoCliente.cliente + "'";
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
                cmd.CommandText = "UPDATE cliente C INNER JOIN creditoCliente R ON R.Cliente = C.Telefono " +
                    "SET C.is_Credito=" + lim + ", R.LimiteCredito= '" + creditoCliente.limiteCredito +
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

        //---------------INGRESOS EGRESOS-----------------//
        public IngresoEgreso consultarIngresosEgreso(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM movimientosCaja WHERE ID='" + id + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    IngresoEgreso c = new IngresoEgreso();
                    while (reader.Read())
                    {
                        c.id = reader.GetInt32(0);
                        c.pago = reader.GetDouble(1);
                        c.fecha = reader.GetDateTime(2);
                        c.tipo = reader.GetString(3);
                        c.concepto = reader.GetString(4);
                        c.idPV = reader.GetInt32(5);
                        c.Empleado = reader.GetString(6);
                        conn.Close();
                        return c;
                    }
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de movimiento de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public MySqlDataAdapter obtenerMovimientosTable(int pv)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT * FROM movimientosCaja WHERE IDPuntoVenta=" + pv + ";", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de movimientos de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerMovimientosTable(string param, int pv)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT * FROM movimientosCaja WHERE " +
                        "( Fecha LIKE '%" + param + "%' OR " +
                        "Tipo LIKE '%" + param + "%' OR " +
                        "Concepto LIKE '%" + param + "%' OR " +
                        "Empleado LIKE '%" + param + "%' OR " +
                        "Pago LIKE '%" + param +
                        "%') AND IDPuntoVenta=" + pv + ";", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de movimientos de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        //---------------COMPRAS-----------------//
        public bool cancelarCompra(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE compra SET Estado= 0 WHERE ID=" + id + ";";
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
        public Compra consultarCompra(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM compra WHERE ID='" + id + "'";
                conn.Open();
                try
                {

                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Compra c = new Compra();
                    while (reader.Read())
                    {
                        c.id = reader.GetString(0);
                        c.fecha = reader.GetDateTime(1);
                        c.total = reader.GetDouble(2);
                        c.idPV = reader.GetInt32(3);
                        c.Empleado = reader.GetString(5);
                        conn.Close();
                        return c;
                    }
                    return null;

                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de movimiento de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }

        }
        public MySqlDataAdapter obtenerComprasTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, C.Fecha, C.Total, PV.Nombre, C.Empleado, SUM(D.Cantidad) FROM compra C, puntoVenta PV, detalleCompra D WHERE PV.ID=C.PuntoVenta AND D.Compra=C.ID GROUP BY C.ID;", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de compra de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerComprasTable(string param)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, C.Fecha, C.Total, PV.Nombre, C.Empleado, SUM(D.Cantidad) FROM compra C, puntoVenta PV, detalleCompra D WHERE PV.ID=C.PuntoVenta AND D.Compra=C.ID AND" +
                        "( C.Fecha LIKE '%" + param + "%' OR " +
                        "C.Empleado LIKE '%" + param + "%' OR " +
                        "C.Total LIKE '%" + param +
                        "%') GROUP BY C.ID ;", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de compra de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerDetalleComprasTable(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.Compra, P.Nombre, C.Cantidad, C.Total FROM detalleCompra C, producto P WHERE P.ID = C.Producto AND C.Compra='" + id + "';", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de compra de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        //--------------CAJAS---------------//
        public Caja consultarCaja(int pv)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM  caja WHERE PuntoVenta=" + pv + ";";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    //int rowsAfected = cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Caja c = new Caja();
                    while (reader.Read())
                    {
                        c.id = reader.GetInt32(0);
                        c.puntoVenta = reader.GetInt32(1);
                        c.fondoInicial = reader.GetDecimal(2);
                        c.estado = reader.GetString(3);
                        c.fondoActual = reader.GetDecimal(4);
                        c.fecha = reader.GetDateTime(5);
                        conn.Close();
                        return c;
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception("Error..! Error al obtener datos de Caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerCajasTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, PV.Nombre, C.FondoInicial, C.Estado, C.FondoActual, C.Fecha AS 'Fecha de apertura' FROM caja C, puntoVenta PV WHERE PV.ID=C.PuntoVenta;", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de compra de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerCajasTable(string param)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, PV.Nombre, C.FondoInicial, C.Estado, C.FondoActual, C.Fecha AS 'Fecha de apertura' FROM caja C, puntoVenta PV WHERE PV.ID=C.PuntoVenta AND" +
                        "( C.Fecha LIKE '%" + param + "%' OR " +
                        "PV.Nombre LIKE '%" + param + "%' OR " +
                        "C.FondoActual LIKE '%" + param + "%' OR " +
                        "C.Estado LIKE '%" + param + "%' OR " +
                        "C.FondoInicial LIKE '%" + param +
                        "%') GROUP BY C.ID ;", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de compra de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        //---------------CORTE DE CAJA --------------- -//
        public List<double> datosCorteCaja(int pv, string inicio, string fin, string idCC)
        {
            try
            {
                Caja caja = consultarCaja(pv);
                string fechaInicio = inicio.Substring(6, 4) + "-" + inicio.Substring(3, 2) + "-" + inicio.Substring(0, 2) + " " + inicio.Substring(11, 8);
                string fechaFin = fin.Substring(6, 4) + "-" + fin.Substring(3, 2) + "-" + fin.Substring(0, 2) + " " + fin.Substring(11, 8);
                List<double> aux = new List<double>();
                List<string> qwerys = new List<string>();
                //ingreso
                qwerys.Add("SELECT SUM(Pago)FROM movimientosCaja WHERE IDPuntoVenta = " + pv + " and Tipo = 'Ingreso' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //egreso
                qwerys.Add("SELECT SUM(Pago) FROM movimientosCaja WHERE IDPuntoVenta = " + pv + "  and Tipo = 'Egreso' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //compras
                qwerys.Add("SELECT SUM(Total) FROM compra WHERE PuntoVenta = 1 and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //servicios efectivo
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + pv + "  and(Concepto = 'Pago servicio' OR Concepto = 'Anticipo servicio') and MetodoPago = 'Efectivo' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //servicios tarjeta
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + pv + "  and Concepto = 'Pago servicio' and (MetodoPago='Tarjeta de Crédito' OR MetodoPago='Tarjeta de Dédito') and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //ventas efectivo
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + pv + "  and Concepto = 'Pago de venta' and MetodoPago = 'Efectivo' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //ventas tarjeta
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + pv + "  and Concepto = 'Pago de venta' and (MetodoPago = 'Tarjeta de Crédito' OR MetodoPago = 'Tarjeta de Dédito') and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //abonos efectivo
                qwerys.Add("SELECT SUM(Abono)FROM abono WHERE PuntoVenta = " + pv + "  and FormaPago = 'Efectivo' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //total servicios
                qwerys.Add("SELECT SUM(Pago)FROM pagos WHERE PuntoVenta = " + pv + "  and (Concepto = 'Pago servicio' OR Concepto='Anticipo servicio') and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //total ventas
                qwerys.Add("SELECT SUM(Pago)FROM pagos WHERE PuntoVenta = " + pv + "  and Concepto = 'Pago de venta' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "';");
                //datos de corte de caja
                qwerys.Add("SELECT FondoInicial FROM corteCaja WHERE ID=" + idCC + ";");
                qwerys.Add("SELECT TotalEnCaja FROM corteCaja WHERE ID=" + idCC + ";");

                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT * FROM Servicios";
                try
                {
                    foreach (string s in qwerys)
                    {
                        cmd.CommandText = s;
                        conn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                aux.Add(reader.GetDouble(0));
                            else aux.Add(0);
                        }
                        conn.Close();
                    }
                    return aux;
                }
                catch (Exception e)
                {
                    conn.Close();

                    throw new Exception("Error..! Error al obtener datos de corte de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter corteCajaTable(int pv, string inicio, string fin)
        {
            try
            {
                Caja caja = consultarCaja(pv);
                string fechaInicio = inicio.Substring(6, 4) + "-" + inicio.Substring(3, 2) + "-" + inicio.Substring(0, 2) + " " + inicio.Substring(11, 8);
                string fechaFin = fin.Substring(6, 4) + "-" + fin.Substring(3, 2) + "-" + fin.Substring(0, 2) + " " + fin.Substring(11, 8);
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT 'Ingreso', CONCAT(Concepto, '-', MetodoPago), Folio, Pago FROM pagos WHERE PuntoVenta = " + pv + " and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' UNION SELECT 'Egreso', 'Compra', ID, Total FROM compra WHERE PuntoVenta = " + pv + " and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "'", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de movimientos de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerCortesTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, PV.Nombre AS 'Punto de Venta', C.Fecha AS 'Fecha de corte', C.Total, C.Vendedor, DATE_FORMAT(C.FechaInicio,'%d-%m-%Y %H:%i:%s') AS 'Fecha de apertura', DATE_FORMAT(C.FechaFin,'%d-%m-%Y %H:%i:%s') AS 'Fecha de cierre' FROM corteCaja C, puntoVenta PV WHERE PV.ID=C.PuntoVenta;", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de cortes de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter obtenerCortesTable(string param)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, PV.Nombre AS 'Punto de Venta', C.Fecha AS 'Fecha de corte', C.Total, C.Vendedor, DATE_FORMAT(C.FechaInicio,'%d-%m-%Y %H:%i:%s') AS 'Fecha de apertura', DATE_FORMAT(C.FechaFin,'%d-%m-%Y %H:%i:%s') AS 'Fecha de cierre'  FROM corteCaja C, puntoVenta PV WHERE PV.ID=C.PuntoVenta AND" +
                        "( C.Fecha LIKE '%" + param + "%' OR " +
                        "PV.Nombre LIKE '%" + param + "%' OR " +
                        "C.Total LIKE '%" + param + "%' OR " +
                        "C.Vendedor LIKE '%" + param + "%' OR " +
                        "C.FechaInicio LIKE '%" + param + "%' OR " +
                        "C.FechaFin LIKE '%" + param + "%' OR " +
                        "C.ID LIKE '%" + param +
                        "%');", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de cortes de caja de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        //-------------------FINANZAS---------------------//
        internal MySqlDataAdapter datosTablaFinanzasProductos(DateTime inicio, DateTime fin, List<int> puntosVenta)
        {
            try
            {
                string pvs = "";
                foreach (int x in puntosVenta)
                {
                    if (x != 0)
                    {
                        if (pvs != "")
                            pvs += " OR ";
                        else
                            pvs += "and (";
                        pvs += " B.PuntoVenta = " + x;
                    }
                }
                if (pvs != "")
                    pvs += ")";

                string fechaInicio = inicio.ToShortDateString().Substring(6, 4) + "-" + inicio.ToShortDateString().Substring(3, 2) + "-" + inicio.ToShortDateString().Substring(0, 2) + " 00:00:01";
                string fechaFin = fin.ToShortDateString().Substring(6, 4) + "-" + fin.ToShortDateString().Substring(3, 2) + "-" + fin.ToShortDateString().Substring(0, 2) + " 23:59:59";

                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.Nombre,P.Modelo,P.Marca, SUM(V.Cantidad) FROM detalleVenta V, producto P, venta B WHERE B.ID=V.Venta and P.id = V.Producto AND B.Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + " group by P.ID", conn);
                conn.Close();
                return mdaDatos;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener datos de productos vendidos de la Base de Datos");
            }
        }
        internal MySqlDataAdapter datosTablaFinanzasServicios(DateTime inicio, DateTime fin, List<int> puntosVenta)
        {
            try
            {
                string pvs = "";
                foreach (int x in puntosVenta)
                {
                    if (x != 0)
                    {
                        if (pvs != "")
                            pvs += " OR ";
                        else
                            pvs += "and (";
                        pvs += " S.IDPuntoVenta = " + x;
                    }
                }
                if (pvs != "")
                    pvs += ")";
                string fechaInicio = inicio.ToShortDateString().Substring(6, 4) + "-" + inicio.ToShortDateString().Substring(3, 2) + "-" + inicio.ToShortDateString().Substring(0, 2) + " 00:00:01";
                string fechaFin = fin.ToShortDateString().Substring(6, 4) + "-" + fin.ToShortDateString().Substring(3, 2) + "-" + fin.ToShortDateString().Substring(0, 2) + " 23:59:59";
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT count(*) AS 'Cantidad', SUBSTRING_INDEX(D.Descripcion,':',1) AS 'Telefono' FROM servicioCliente D, solicitudServicio S WHERE D.Folio=S.Folio and S.Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + " group bY SUBSTRING_INDEX(D.Descripcion,':',1);", conn);
                conn.Close();
                return mdaDatos;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener datos de productos vendidos de la Base de Datos");
            }
        }
        internal List<double> datosFinanzas(DateTime inicio, DateTime fin, List<int> puntosVenta)
        {
            string pvs = "";
            foreach (int x in puntosVenta)
            {
                if (x != 0)
                {
                    if (pvs != "")
                        pvs += " OR ";
                    else
                        pvs += "and (";
                    pvs += " PuntoVenta = " + x;
                }
            }
            if (pvs != "")
                pvs += ")";
            string fechaInicio = inicio.ToShortDateString().Substring(6, 4) + "-" + inicio.ToShortDateString().Substring(3, 2) + "-" + inicio.ToShortDateString().Substring(0, 2) + " 00:00:01";
            string fechaFin = fin.ToShortDateString().Substring(6, 4) + "-" + fin.ToShortDateString().Substring(3, 2) + "-" + fin.ToShortDateString().Substring(0, 2) + " 23:59:59";
            List<double> aux = new List<double>();
            List<string> qwerys = new List<string>();
            //ventas efectivo
            qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE Concepto = 'Pago de venta' and MetodoPago = 'Efectivo' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' "+pvs+";");
            //ventas tarjeta credito/debito
            qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE Concepto = 'Pago de venta' and (MetodoPago = 'Tarjeta de Crédito' OR MetodoPago = 'Tarjeta de Débito') and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + ";");
            //ventas totales
            qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE Concepto = 'Pago de venta' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + ";");
            //servicios efectivo
            qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE (Concepto = 'Pago servicio' OR Concepto = 'Anticipo servicio') and MetodoPago = 'Efectivo' and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + ";");
            //servicios tarjeta credito/debito
            qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE (Concepto = 'Pago servicio' OR Concepto = 'Anticipo servicio') and (MetodoPago = 'Tarjeta de Crédito' OR MetodoPago = 'Tarjeta de Débito') and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + ";");
            //servicios totales
            qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE (Concepto = 'Pago servicio' OR Concepto = 'Anticipo servicio')  and Fecha BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " + pvs + ";");

            conn = new MySqlConnection(builder.ToString());
            cmd = conn.CreateCommand();
            //cmd.CommandText = "SELECT * FROM Servicios";
            try
            {
                foreach (string s in qwerys)
                {
                    cmd.CommandText = s;
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            aux.Add(reader.GetDouble(0));
                        else aux.Add(0);
                    }
                    conn.Close();
                }
                return aux;
            }
            catch (Exception e)
            {
                conn.Close();

                throw new Exception("Error..! Error al obtener datos de corte de caja de la Base de Datos");
            }
        }

        //-------------------MINIMOS Y MAXIMOS--------------------//
        internal MySqlDataAdapter datosTablaStock()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.ID, P.Nombre, SUM(S.Cantidad) AS 'Stock' FROM stockPV S, producto P WHERE P.ID= S.Producto GROUP BY S.Producto ;", conn);
                conn.Close();
                return mdaDatos;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener datos de stock productos de la Base de Datos");
            }
        }
        internal MySqlDataAdapter datosTablaMin()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.ID, P.Nombre, SUM(S.Cantidad) AS 'Stock', M.Minimo, M.Maximo FROM stockPV S, producto P, productoMinMax M WHERE P.ID= S.Producto AND S.Producto=M.Producto AND (SELECT SUM(F.Cantidad) FROM stockPV F where F.Producto = P.ID GROUP BY F.Producto) <= M.Minimo and M.Minimo<>0 GROUP BY S.Producto", conn);
                conn.Close();
                return mdaDatos;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener datos de stock productos de la Base de Datos");
            }
        }
        internal MySqlDataAdapter datosTablaMax()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.ID, P.Nombre, SUM(S.Cantidad) AS 'Stock', M.Minimo, M.Maximo FROM stockPV S, producto P, productoMinMax M WHERE P.ID= S.Producto AND S.Producto=M.Producto AND (SELECT SUM(F.Cantidad) FROM stockPV F where F.Producto = P.ID GROUP BY F.Producto) >= M.Maximo and M.Maximo<>0 GROUP BY S.Producto;", conn);
                conn.Close();
                return mdaDatos;
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener datos de stock productos de la Base de Datos");
            }
        }

        //----------------------CONFG--------------///
        public string leerUserDoc()
        {
            String line;
            StreamReader sr = null;
            string user = "";
            try
            {
                string archivo = "thumbs.txt";
                // comprobar si el fichero ya existe
                if (File.Exists(archivo))
                {
                    //Pass the file path and file name to the StreamReader constructor
                    sr = new StreamReader(archivo);
                    //read de first line
                    line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        if (line == "us")
                        {
                            user = sr.ReadLine();
                            break;
                        }
                    }
                    //close the file
                    sr.Close();
                    sr.Dispose();
                }
                return user;
            }
            catch (Exception e)
            {
                sr.Dispose();
                return "";
            }
        }
        public bool escribirDoc()
        {
            StreamWriter sw = null;
            try
            {
                string archivo = "thumbs.txt";
                // comprobar si el fichero ya existe
                if (!File.Exists(archivo))
                {
                    File.Create(archivo).Close();
                }
                //Pass the file path and file name to the StreamReader constructor
                sw = new StreamWriter(archivo);
                //Write a line of text
                if (currentUser.usuario != null)
                {
                    sw.WriteLine("us");
                    sw.WriteLine(currentUser.usuario);
                }
                //Close the file
                sw.Close();
                sw.Dispose();
                return true;
            }
            catch (Exception e)
            {
                sw.Dispose();
                return false;
            }
        }
        public string formatearFecha(DateTime fecha)
        {
            DateTime aux;
            if (fecha == null)
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
