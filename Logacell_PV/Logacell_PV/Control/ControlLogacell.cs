﻿using Logacell.DataObject;
using Logacell_PV.DataObject;
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
        //string database = "logacell_logamysql";
        string database = "logacell_logacell";
        public static PuntoVenta idPV;
        public static Usuario currentUser;
        public static ControlLogacell instance;
        public static Caja caja;
        public ControlLogacell()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = userID;
            builder.Password = password;
            builder.Database = database;
            builder.AllowUserVariables = true;
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
                            p.marca= reader.GetString(4);
                            p.precio= reader.GetString(5);
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
        public List<Producto> obtenerProductosByPV(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT p.ID, p.Categoria, p.Nombre, p.Marca, p.Modelo,p.Precio, s.Cantidad FROM producto p INNER JOIN stockPV s on p.ID = s.Producto where s.PuntoVenta="+id+" and s.Cantidad > 0 ORDER BY p.Nombre ASC;";
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
        public List<Producto> obtenerProductosByPV()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT p.ID, p.Categoria, p.Nombre, p.Marca, p.Modelo,p.Precio, s.Cantidad FROM producto p INNER JOIN stockPV s on p.ID = s.Producto where s.PuntoVenta="+idPV.id+" and s.Cantidad > 0 ORDER BY p.Nombre ASC;";
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
                    return 0;
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
        public int obtenerStockProducto(string id, int pv)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText =  "SELECT Cantidad FROM stockPV WHERE Producto='" + id +"' and PuntoVenta='" + pv+"';";
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
                    return 0;
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

        //---------------------------TRASPASOS-----------------//
        public Traspaso consultarTraspaso(string id)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT ID, Origen, Destino,Producto, Cantidad, Estado, Observaciones FROM traspaso WHERE ID='"+id+"';";
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
        public bool agregarTraspaso(Traspaso traspaso)
        {
            try
            {
                string agregarTraspaso = "INSERT INTO traspaso (Origen, Destino,Producto, Cantidad, Estado, Observaciones) values ('"
                    + traspaso.idOrigen + "','" + traspaso.idDestino + "','" + traspaso.producto + "','" + traspaso.cantidad + "','Enviado','" + traspaso.observaciones + "');";
                string stock = "UPDATE stockPV SET Cantidad= Cantidad -"+traspaso.cantidad+" WHERE Producto=" + traspaso.producto + " and PuntoVenta =" + traspaso.idOrigen+";";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION;" +
                                    agregarTraspaso +
                                    stock +
                                    "COMMIT;";
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
                    throw new Exception("Error..! Error al agregar traspaso a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool aceptarTraspaso(Traspaso traspaso)
        {
            try
            {
                string agregarTraspaso = "UPDATE traspaso SET Estado='Recibido' , Observaciones='" + traspaso.observaciones + "' WHERE ID = '" + traspaso.id + "';";
                string stock = "UPDATE stockPV SET Cantidad= Cantidad +" + traspaso.cantidad + " WHERE Producto=" + traspaso.producto + " and PuntoVenta =" + traspaso.idDestino + ";";
                string insertStocks = "INSERT INTO stockPV(Cantidad, Producto, PuntoVenta) SELECT '0', '" + traspaso.producto + "', '" + traspaso.idDestino + "' FROM DUAL WHERE NOT EXISTS(SELECT * FROM stockPV  WHERE Producto='" + traspaso.producto + "' and PuntoVenta ='" + traspaso.idDestino +"'); ";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION;" +
                                    agregarTraspaso +
                                    insertStocks +
                                    stock +
                                    "COMMIT;";
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
                    throw new Exception("Error..! Error al recibir traspaso de la Base de Datos");
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
        public MySqlDataAdapter obtenerTraspasosPVDestinoTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT T.ID, PV.Nombre AS 'Origen', PV2.Nombre AS 'Destino', T.Cantidad, P.Nombre AS 'Producto' , T.Estado, T.Observaciones FROM traspaso T, producto P, puntoVenta PV ,puntoVenta PV2 WHERE PV.ID=T.Origen AND PV2.ID=T.Destino AND T.Producto = P.ID AND T.Destino =" + idPV.id, conn);
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
        public MySqlDataAdapter obtenerTraspasosPVDestinoTable(string parametro)
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
                        ") AND PV.ID=T.Origen AND PV2.ID=T.Destino AND T.Producto = P.ID AND T.Destino =" + idPV.id, conn);
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
        public MySqlDataAdapter obtenerTraspasosPVOrigenTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT T.ID,PV.Nombre AS 'Origen', PV2.Nombre AS 'Destino', T.Cantidad, P.Nombre AS 'Producto' , T.Estado, T.Observaciones FROM traspaso T, producto P, puntoVenta PV ,puntoVenta PV2 WHERE PV.ID=T.Origen AND PV2.ID=T.Destino AND T.Producto = P.ID AND T.Origen =" + idPV.id, conn);
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
        public MySqlDataAdapter obtenerTraspasosPVOrigenTable(string parametro)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT T.ID,PV.Nombre AS 'Origen', PV2.Nombre AS 'Destino', T.Cantidad, P.Nombre AS 'Producto' , T.Estado, T.Observaciones FROM traspaso T, producto P, puntoVenta PV ,puntoVenta PV2 WHERE " +
                        "(PV.Nombre LIKE '%" + parametro + "%' or " +
                        "PV2.Nombre LIKE '%" + parametro + "%' or " +
                        "T.ID LIKE '%" + parametro + "%' or " +
                        "P.Nombre LIKE '%" + parametro + "%' or " +
                        "T.Estado LIKE '%" + parametro + "%'" +
                        ") AND PV.ID=T.Origen AND PV2.ID=T.Destino AND T.Producto = P.ID AND T.Origen =" + idPV.id, conn);
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
        public bool entradaEmpleado()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO bitacoraEmpleados (Empleado, Fecha, CheckOut, IDPuntoVenta) values ('"+
                    currentUser.empleado+ "', now(), null,"+idPV.id+" );";
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
                "SELECT @id := ID FROM bitacoraEmpleados WHERE Empleado = '"+currentUser.empleado+"' ORDER BY ID DESC LIMIT 1; " +
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
                double pagoEfectivo = 0;
                string insertDetallesVenta = "";
                string updateStocks = "";
                string actualizarCaja = "";
                foreach (DetalleVenta cv in venta.productos)
                {
                    insertDetallesVenta += " INSERT INTO detalleVenta (Producto, Venta, Cantidad,Total, Descuento) values (" +
                        cv.idProducto + ", '" + cv.folio + "'," + cv.cantidadProducto + "," + cv.total + "," + cv.descuento + "); ";
                    updateStocks += "UPDATE stockPV SET Cantidad = Cantidad - " + cv.cantidadProducto +
                        " WHERE Producto= " + cv.idProducto + " and PuntoVenta = " + idPV.id + "; ";
                }
                string insertPagosVenta = "";
                foreach (Pagos pv in venta.pagos)
                {
                    insertPagosVenta += " INSERT INTO pagos (Folio, Pago, MetodoPago, Concepto, PuntoVenta) values ('" +
                        pv.folio + "'," + pv.pago + ",'" + pv.formaPago + "', 'Pago de venta'," + idPV.id +"); ";
                    if (pv.formaPago == "Efectivo")
                        pagoEfectivo += pv.pago;
                }
                string insertVenta = "INSERT INTO venta (ID, Fecha, Total,PuntoVenta, Estado, Vendedor) values ('" +
                venta.id + "', '" + formatearFecha(DateTime.Now) + "','" + venta.total + "','" + idPV.id + "',1,'" + currentUser.empleado + "'); ";
                actualizarCaja = "UPDATE caja SET FondoActual= FondoActual +" + pagoEfectivo + " WHERE PuntoVenta=" + idPV.id + ";";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    insertVenta +
                                    insertDetallesVenta +
                                    insertPagosVenta +
                                    updateStocks +
                                    actualizarCaja +
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT V.ID, V.Fecha, V.Total, PV.Nombre AS 'Punto de Venta', E.Nombre AS 'Vendedor' FROM venta V INNER JOIN puntoVenta PV ON PV.ID=V.PuntoVenta INNER JOIN empleado E ON E.Correo=V.Vendedor WHERE V.Estado=1 and V.PuntoVenta="+idPV.id, conn);
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
                                        "PV.Nombre LIKE '%" + parametro + "%') and V.Estado = 1 and V.PuntoVenta=" + idPV.id;
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
        public MySqlDataAdapter obtenerDetalleVentasTable(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT V.ID, P.Nombre AS 'Producto', V.Cantidad, V.Total AS 'Subtotal' , V.Descuento, V.Total-V.Descuento AS 'Total' FROM detalleVenta V INNER JOIN producto P ON P.ID=V.Producto WHERE V.Venta='"+folio+"'", conn);
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
        public bool agregarSolicitudServicios(SolicitudServicio servicio)
        {
            try
            {
                string insertarSolicitud = "INSERT INTO solicitudServicio (Folio, NombreCliente, TelefonoCliente, Total, Anticipo, Pendiente, IDPuntoVenta) values ('"
                        + servicio.Folio + "','" + servicio.nombreCliente + "','" + servicio.telefonoCliente + "',"
                        + Convert.ToInt32(servicio.total) + "," + Convert.ToInt32(servicio.anticipo) + "," + Convert.ToInt32(servicio.pendiente) + ", '" + idPV.id + "'); ";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();

                cmd.CommandText = "START TRANSACTION; " +
                                    insertarSolicitud +
                                    " COMMIT;";
                //cmd.CommandText = "SELECT * FROM Servicios";
                conn.Open();
                try
                {
                    int rowsAfected = cmd.ExecuteNonQuery();
                    //MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    if (rowsAfected > 0)
                    {
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
        public bool agregarSolicitudServicios(SolicitudServicio servicio, List<Pagos> pagos)
        {
            try
            {
                double pagoEfectivo = 0;
                string insertarSolicitud = "INSERT INTO solicitudServicio (Folio, NombreCliente, TelefonoCliente, Total, Anticipo, Pendiente, IDPuntoVenta) values ('"
                        + servicio.Folio + "','" + servicio.nombreCliente + "','" + servicio.telefonoCliente + "',"
                        + Convert.ToInt32(servicio.total) + "," + Convert.ToInt32(servicio.anticipo) + "," + Convert.ToInt32(servicio.pendiente) + ", '" + idPV.id + "' ); ";
                string insertPagosVenta = "";
                foreach (Pagos pv in pagos)
                {
                    insertPagosVenta += " INSERT INTO pagos (Folio, Pago, MetodoPago, Concepto,PuntoVenta) values ('" +
                        servicio.Folio + "'," + pv.pago + ",'" + pv.formaPago + "','Anticipo Servicio',"+idPV.id+"); ";
                    if (pv.formaPago == "Efectivo")
                        pagoEfectivo += pv.pago;
                }
                string actualizarCaja = "UPDATE caja SET FondoActual= FondoActual +" + pagoEfectivo + " WHERE PuntoVenta=" + idPV.id + ";";

                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();

                cmd.CommandText = "START TRANSACTION; " +
                                    insertarSolicitud +
                                    insertPagosVenta +
                                    actualizarCaja +
                                    " COMMIT;";
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
        public bool agregarPagoServicio(SolicitudServicio sc, List<Pagos> pagos)
        {
            try
            {
                string insertPagos = "";
                double total = 0;
                double pagoEfectivo = 0;
                foreach (Pagos pv in pagos)
                {
                    insertPagos += " INSERT INTO pagos (Folio, Pago, MetodoPago, Concepto, PuntoVenta) values ('" +
                        pv.folio + "'," + pv.pago + ",'" + pv.formaPago + "', 'Pago servicio'," + idPV.id + "); ";
                    total += pv.pago;
                    if (pv.formaPago == "Efectivo")
                        pagoEfectivo += pv.pago;
                }
                string updateServicio = "UPDATE solicitudServicio SET Anticipo= Anticipo +" + total.ToString() + ", Pendiente= Pendiente - " + total.ToString() +
                    " WHERE Folio = '" + sc.Folio + "'; ";
                string actualizarCaja = "UPDATE caja SET FondoActual= FondoActual +" + pagoEfectivo + " WHERE PuntoVenta=" + idPV.id + ";";

                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    updateServicio +
                                    insertPagos +
                                    actualizarCaja+
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
                    throw new Exception("Error..! Error al agregar pagos a la Base de Datos");
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT S.Folio, S.NombreCliente AS 'Nombre de Cliente', S.TelefonoCliente AS 'Telefono', C.Estado, S.Total, S.Anticipo, S.Pendiente FROM solicitudServicio S, servicioCliente C  WHERE C.Folio=S.Folio AND IDPuntoVenta = '" + idPV.id + "'", conn);
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
                                        "S.TelefonoCliente LIKE '%" + parametro + "%') and C.Folio=S.Folio and S.IDPuntoVenta = '" + idPV.id + "'";
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
                cmd.CommandText = "SELECT Folio FROM solicitudServicio WHERE IDPuntoVenta=" + idPV.id + " ORDER BY Folio DESC LIMIT 1";
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
                cmd.CommandText = "INSERT INTO servicioCliente (Folio, Descripcion, Estado, Presupuesto, Contrasena, Patron, Pila, Tapa, Memoria, Chip, IMEI) values ('"
                        + folio + "','" + servicio.descripcion + "','" + servicio.estado + "','"
                        + servicio.presupuesto + "','" + servicio.contrasena + "','" + servicio.patron +  "'," + servicio.pila + ","
                        + servicio.tapa + "," + servicio.memoria + "," + servicio.chip + ",'"+servicio.IMEI+"' )";
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
                cmd.CommandText = "UPDATE servicioCliente SET Estado= '"+ estado +"' WHERE ID = '" + id + "'";
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
        public bool actualizarServicioClienteCotizacion(String id, string presupuesto, string folio)
        {
            try
            {
                string updateServicio = "UPDATE servicioCliente SET Presupuesto='" + presupuesto +
                 "' WHERE ID='" + id + "';";
                string updateSolicitud = "UPDATE solicitudServicio S SET S.Total = (SELECT SUM(C.Presupuesto) FROM servicioCliente C WHERE C.Folio = '" + folio + "' ), S.Pendiente = (SELECT SUM(C.Presupuesto) FROM servicioCliente C WHERE C.Folio = '"+folio+ "') - S.Anticipo WHERE S.Folio ='" + folio + "';";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION;"+
                    updateServicio+
                    updateSolicitud+
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT ID, Descripcion, Estado, Contrasena, Patron, Pila, Tapa, Memoria, Chip, IMEI from servicioCliente where Folio = '"+folio+"'", conn);
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
        public bool agregarAbonoCredito(AbonoCredito abono, string formapago)
        {
            try
            {
                string insertarAbono = "INSERT INTO abono (Cliente,Abono,Empleado,Fecha,PuntoVenta,FormaPago) values ('"
                    + abono.cliente + "','" + abono.abono + "','"
                    + abono.empleado + "','" + formatearFecha(DateTime.Now) + "',"
                    + idPV.id + ", "+formapago+"); ";
                string actualizarCaja = "";
                if (formapago=="Efectivo")
                    actualizarCaja = "UPDATE caja SET FondoActual= FondoActual +" + abono.abono + " WHERE PuntoVenta=" + idPV.id + ";";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    insertarAbono +
                                    actualizarCaja +
                                    " COMMIT;";
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

        //---------------INGRESOS EGRESOS-----------------//
        public bool agregarIngresoEgreso(IngresoEgreso pago, string tipo)
        {
            try
            {
                string actualizarCaja="";
                string movimientoCaja = "INSERT INTO movimientosCaja (Pago,Concepto,Tipo,IDPuntoVenta,Empleado) values ("
                    + pago.pago + ",'" + pago.concepto + "','" + tipo + "'," +
                    +idPV.id + ",'" + currentUser.empleado + "');";
                if(tipo=="Ingreso")
                    actualizarCaja = "UPDATE caja SET FondoActual= FondoActual +" + pago.pago + " WHERE PuntoVenta=" + idPV.id + ";";
                if (tipo == "Egreso")
                    actualizarCaja = "UPDATE caja SET FondoActual= FondoActual -" + pago.pago + " WHERE PuntoVenta=" + idPV.id + ";";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    movimientoCaja +
                                    actualizarCaja +
                                    " COMMIT;";
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
        public bool actualizarIngresoEgreso(IngresoEgreso pago, string tipo)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE movimientosCaja SET Pago="+ pago.pago + ", Concepto='" + pago.concepto + 
                    "', Tipo='" + tipo + "' WHERE ID="+idPV.id + ";";
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
        public MySqlDataAdapter obtenerMovimientosTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT * FROM movimientosCaja WHERE IDPuntoVenta="+idPV.id+";", conn);
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
        public MySqlDataAdapter obtenerMovimientosTable(string param)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT * FROM movimientosCaja WHERE "+
                        "( Fecha LIKE '%"+param+"%' OR "+
                        "Tipo LIKE '%" + param + "%' OR " +
                        "Concepto LIKE '%" + param + "%' OR " +
                        "Empleado LIKE '%" + param + "%' OR " +
                        "Pago LIKE '%" + param +
                        "%') AND IDPuntoVenta=" + idPV.id + ";", conn);
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
        public bool agregarCompra(List<Producto> lista, string total)
        {
            try
            {
                string insertDetallesCompra = "";
                string updateStocks = "";
                string insertStocks = "";
                string folioCompra = this.folioCompra();
                foreach (Producto p in lista)
                {
                    insertDetallesCompra += " INSERT INTO detalleCompra (Producto, Compra, Cantidad, Total) values (" +
                        p.id + ",'"+ folioCompra + "'," + p.cantidad + "," + Convert.ToDecimal(p.precio)*Convert.ToDecimal(p.cantidad) + "); ";
                    updateStocks += "UPDATE stockPV SET Cantidad = Cantidad + " + p.cantidad +
                        " WHERE Producto= " + p.id + " and PuntoVenta = " + idPV.id + "; ";
                    insertStocks += "INSERT INTO stockPV(Cantidad, Producto, PuntoVenta) SELECT '0', '" + p.id+ "', '" + idPV.id + "' FROM DUAL WHERE NOT EXISTS(SELECT * FROM stockPV WHERE Producto = '" + p.id + "' AND PuntoVenta = '" + idPV.id +"'); ";
                }
                string actualizarCaja = "UPDATE caja SET FondoActual= FondoActual -" + total + " WHERE PuntoVenta=" + idPV.id + ";";
                string insertCompra = "INSERT INTO compra (ID,Fecha, Total,PuntoVenta, Estado, Empleado) values ('" +
                folioCompra+"',"+"'"+formatearFecha(DateTime.Now) + "'," + total + ",'" + idPV.id + "',1,'" + currentUser.empleado + "'); ";
                
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    insertCompra +
                                    insertDetallesCompra +
                                    insertStocks +
                                    updateStocks +
                                    actualizarCaja +
                                    " COMMIT;";
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
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, C.Fecha,C.Total,P.Nombre AS 'PuntoVenta',C.Estado,C.Empleado FROM compra C, puntoVenta P WHERE  P.ID=C.PuntoVenta AND PuntoVenta=" + idPV.id + ";", conn);
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
        public MySqlDataAdapter obtenerComprasTable(string param)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT C.ID, C.Fecha,C.Total,P.Nombre AS 'PuntoVenta',C.Estado,C.Empleado FROM compra C, puntoVenta P WHERE " +
                        "( C.Fecha LIKE '%" + param + "%' OR " +
                        "C.Empleado LIKE '%" + param + "%' OR " +
                        "C.Total LIKE '%" + param +
                        "%') AND P.ID=C.PuntoVenta AND C.PuntoVenta=" + idPV.id + ";", conn);
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
        public MySqlDataAdapter obtenerDetalleComprasTable(string folio)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT P.Nombre AS 'Producto', DC.Cantidad, (DC.Total/DC.Cantidad) AS 'Precio de compra' , DC.Total FROM detalleCompra DC INNER JOIN producto P ON P.ID = DC.Producto WHERE DC.Compra='" + folio + "'", conn);
                    conn.Close();
                    return mdaDatos;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener datos de Compra de la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        public string folioCompra()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID FROM compra WHERE PuntoVenta=" + idPV.id + " ORDER BY ID DESC LIMIT 1";
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
                        return prefijo + "-C" + num.ToString("0000000");
                    }
                    else
                        return idPV.prefijo + "-C0000001";
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

        //--------------CAJAS---------------//
        public bool agregarCaja()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO caja (PuntoVenta) VALUES (" + idPV.id + ");";
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
                    throw new Exception("Error..! Error al agregar Caja a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public Caja consultarCaja()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM  caja WHERE PuntoVenta=" + idPV.id + ";";
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
        public bool actualizarCaja(Caja c)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE caja SET FondoInicial=" + c.fondoInicial + ", FondoActual=" + c.fondoActual + ", Estado = '" + c.estado+"' WHERE PuntoVenta=" + idPV.id + ";";
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
        public bool cerrarCaja(string salida)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE caja SET FondoActual= FondoActual-" + salida + ", Estado = 'Cerrada', SET Fecha=CURRENT_TIMESTAMP WHERE PuntoVenta=" + idPV.id + ";";
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
                    throw new Exception("Error..! Error al agregar caja a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public bool abrirCaja(string entrada)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE caja SET FondoActual= " + entrada + ", FondoInicial= " + entrada + ", Estado = 'Abierta', Fecha=CURRENT_TIMESTAMP WHERE PuntoVenta=" + idPV.id + ";";
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
                    throw new Exception("Error..! Error al agregar caja a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public void setCaja()
        {
            try
            {
                caja = consultarCaja();
                if (caja == null)
                {
                    agregarCaja();
                    caja = consultarCaja();
                }
            }
            catch (Exception ex) {
                
            }
        }
        public bool agregarEntradaCaja(string entrada)
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE caja SET FondoActual= FondoActual +" + entrada + " WHERE PuntoVenta=" + idPV.id + ";";
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
                    throw new Exception("Error..! Error al agregar caja a la Base de Datos");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }

        //---------------CORTE DE CAJA------------------//
        public List<double> datosCorteCaja()
        {
            try
            {
                Caja caja = consultarCaja();
                List<double> aux = new List<double>();
                List<string> qwerys = new List<string>();
                //ingreso
                qwerys.Add("SELECT SUM(Pago)FROM movimientosCaja WHERE IDPuntoVenta = "+idPV.id+" and Tipo = 'Ingreso' and Fecha BETWEEN '"+formatearFecha(caja.fecha) +"' AND CURRENT_TIMESTAMP;");
                //egreso
                qwerys.Add("SELECT SUM(Pago) FROM movimientosCaja WHERE IDPuntoVenta = "+idPV.id+"  and Tipo = 'Egreso' and Fecha BETWEEN '"+ formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //compras
                qwerys.Add("SELECT SUM(Total) FROM compra WHERE PuntoVenta = 1 and Fecha BETWEEN '"+ formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //servicios efectivo
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + idPV.id + "  and(Concepto = 'Pago servicio' OR Concepto = 'Anticipo servicio') and MetodoPago = 'Efectivo' and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //servicios tarjeta
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + idPV.id + "  and Concepto = 'Pago servicio' and (MetodoPago='Tarjeta de Crédito' OR MetodoPago='Tarjeta de Dédito') and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //ventas efectivo
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + idPV.id + "  and Concepto = 'Pago de venta' and MetodoPago = 'Efectivo' and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //ventas tarjeta
                qwerys.Add("SELECT SUM(Pago) FROM pagos WHERE PuntoVenta = " + idPV.id + "  and Concepto = 'Pago de venta' and (MetodoPago = 'Tarjeta de Crédito' OR MetodoPago = 'Tarjeta de Dédito') and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //abonos efectivo
                qwerys.Add("SELECT SUM(Abono)FROM abono WHERE PuntoVenta = " + idPV.id + "  and FormaPago = 'Efectivo' and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //total servicios
                qwerys.Add("SELECT SUM(Pago)FROM pagos WHERE PuntoVenta = " + idPV.id + "  and (Concepto = 'Pago servicio' OR Concepto='Anticipo servicio') and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                //total ventas
                qwerys.Add("SELECT SUM(Pago)FROM pagos WHERE PuntoVenta = " + idPV.id + "  and Concepto = 'Pago de venta' and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP;");
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT * FROM Servicios";
                try
                {
                    foreach (string s in qwerys) {
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
        public bool corteDeCaja(string salida)
        {
            try
            {
                Caja caja = consultarCaja();
                string cerraCaja = "UPDATE caja SET FondoActual= FondoActual-" + salida + ", Estado = 'Cerrada', Fecha=CURRENT_TIMESTAMP WHERE PuntoVenta=" + idPV.id + ";";
                string insertCorteCaja = "INSERT INTO corteCaja ( Total, PuntoVenta, Vendedor, FechaInicio, FondoInicial,TotalEnCaja) VALUES (" +
                    salida + "," + idPV.id + ",'" + currentUser.empleado + "','" + formatearFecha(caja.fecha) + "',"+caja.fondoInicial+","+caja.fondoActual+");";
                conn = new MySqlConnection(builder.ToString());
                cmd = conn.CreateCommand();
                cmd.CommandText = "START TRANSACTION; " +
                                    insertCorteCaja +
                                    cerraCaja +
                                    " COMMIT;";
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
                    throw new Exception("Error..! Error al realizar corte de caja");
                }
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception("Error al establecer conexión con el servidor");
            }
        }
        public MySqlDataAdapter corteCajaTable()
        {
            try
            {
                conn = new MySqlConnection(builder.ToString());
                conn.Open();
                try
                {
                    MySqlDataAdapter mdaDatos = new MySqlDataAdapter("SELECT 'Ingreso', CONCAT(Concepto, '-', MetodoPago), Folio, Pago FROM pagos WHERE PuntoVenta = " + idPV.id + " and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP UNION SELECT 'Egreso', 'Compra', ID, Total FROM compra WHERE PuntoVenta = " + idPV.id + " and Fecha BETWEEN '" + formatearFecha(caja.fecha) + "' AND CURRENT_TIMESTAMP", conn);
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


        //---------------------CONFG-------------------//
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
        public string leerPVDoc()
        {
            String line;
            StreamReader sr = null;
            string pv = "";
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
                        if (line == "pv")
                        {
                            pv = sr.ReadLine();
                            break;
                        }
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    sr.Dispose();
                }
                return pv;
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
                if (idPV != null)
                {
                    sw.WriteLine("pv");
                    sw.WriteLine(idPV.id);
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

