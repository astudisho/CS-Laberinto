using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace PPI_Proyecto
{
	class Servidor
	{
		private Thread hilo;
		private TcpListener manejador;
		private readonly object bloqueo;
		private bool seguirEscuchando;
		private List<Trabajador> listaConexiones;

		public Servidor()
		{
			seguirEscuchando = true;
			bloqueo = new object();
			listaConexiones = new List<Trabajador>();

			(hilo = new Thread(new ThreadStart(() => iniciaEscucha()))).Start();

		}

		public void iniciaEscucha()
		{
			try
			{
				manejador = new TcpListener(new IPEndPoint(IPAddress.Any,Globales.PUERTO_ESCUCHA));
				manejador.Start();

				do
				{
					try
					{
						listaConexiones.Add(new Trabajador(manejador.AcceptTcpClient()));
						MessageBox.Show("Servidor recibe conexion");
					}
					catch (SocketException)
					{
						throw;
					}
					catch (Exception e)
					{
						throw;
					}
				} while (seguirEscuchando);
			}
			catch (SocketException se)
			{
				//Log.escribirLog(se);
				//throw;
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public void detener()
		{
			foreach (var trabajador in listaConexiones)
			{
				trabajador.detener();
			}

			seguirEscuchando = false;
			manejador.Stop();
			
		}
	}
}
//01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567