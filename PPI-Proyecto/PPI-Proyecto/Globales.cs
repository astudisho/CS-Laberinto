using System.Collections.Generic;
using System.Windows.Forms;

namespace PPI_Proyecto
{

	static class Globales
	{
		public const int PUERTO_ESCUCHA = 2001;
		public static bool soyServidor;
		public static string nickname;
		public static DataGridView dataGrid;
		public static Cliente cliente;
		public static Partida partida;

		public static List<Jugador> listaJugadores = new List<Jugador>();
		private  static Dictionary<string, Cliente> diccionarioConexiones =
			new Dictionary<string, Cliente>();


		public static Dictionary<string,Cliente> getDiccionarioConexiones()
		{
			return diccionarioConexiones;
		}

		public static void agregarDiccionarioConexiones(string nombre,Cliente val)
		{
			if (diccionarioConexiones.ContainsKey(nombre))
			{
				diccionarioConexiones[nombre] = val;
			}
			else
			{
				diccionarioConexiones.Add(nombre, val);
			}
		}

		public static List<Cliente> getTodasConexionesDiccionario()
		{
			List<Cliente> clientes = new List<Cliente>();

			foreach (var cliente in diccionarioConexiones)
			{
				clientes.Add(cliente.Value);
			}

			return clientes;
		}

		public static Cliente getConexionDiccionario(string val)
		{
			Cliente cliente;

			diccionarioConexiones.TryGetValue(val,out cliente);

			return cliente;
		}

		public static bool existeLlaveDiccionarioConexiones(string val)
		{
			return diccionarioConexiones.ContainsKey(val);
		}
	}

	static class CodOps
	{
		public const byte CO_UNIRSE = 0x01, CO_JUGADOR_LISTO = 0x02, CO_MOVIMIENTO = 0x03,
			MOV_ARRIBA = 0x01, MOV_ABAJO = 0x02, MOV_IZQ = 0x03, MOV_DER = 0x04;

		public const char SEPARADOR= (char)4;
	}
}
