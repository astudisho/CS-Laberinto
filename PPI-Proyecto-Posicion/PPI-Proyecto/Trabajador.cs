using System;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace PPI_Proyecto
{
	class Trabajador
	{
		private TcpClient socket;
		private Thread hilo;
		private bool seguirConectado;
		private BinaryReader flujoEntrada;

		public Trabajador(TcpClient cliente)
		{
			this.socket = cliente;
			seguirConectado = true;

			(hilo = new Thread(new ThreadStart(procesarConexion))).Start();
		}

		private void procesarConexion()
		{
			try
			{
				flujoEntrada = new BinaryReader(socket.GetStream(), Encoding.ASCII);
				do
				{
					string paquete = flujoEntrada.ReadString();
					MessageBox.Show("Trabajador recibe " + paquete);
					procesarPaquete(paquete);					

				} while (seguirConectado);
			}
			catch(EndOfStreamException eose)
			{
				if (Globales.soyServidor)
					MessageBox.Show("Se desconecto un cliente");
				else
					MessageBox.Show("Se perdio la conexion con el servidor");
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void procesarPaquete(string paquete)
		{
			byte codop = byte.Parse(paquete.Split(CodOps.SEPARADOR)[0]);

			switch (codop)
			{
				case CodOps.CO_UNIRSE: unirse(paquete); break;
				case CodOps.CO_JUGADOR_LISTO: jugadorListo(paquete); break;
				case CodOps.CO_MOVIMIENTO: movimiento(paquete); break;
				default: break;
			}
		}

		private void unirse(string paquete)
		{
			string[] datos = paquete.Split(CodOps.SEPARADOR);
			string nombre = datos[1];

			MessageBox.Show("Entra a unirse");

			if (Globales.soyServidor)
			{
				MessageBox.Show("Soy servidor");
				Globales.listaJugadores.Add(new Jugador(nombre));
				MessageBox.Show("Lista de jugadores " + Globales.listaJugadores.Count);
				IPAddress direccionRemota = ((IPEndPoint)socket.Client.RemoteEndPoint).Address;
				Cliente auxCliente = new Cliente(direccionRemota);

				foreach (var conexion in Globales.getDiccionarioConexiones())
				{
					conexion.Value.reenviarPaquete(paquete);
				}
				foreach (var jugador in Globales.listaJugadores)
				{
					auxCliente.unirsePartida(jugador.Nombre);
					MessageBox.Show("Enviando unirse " + jugador.Nombre);
				}

				Globales.agregarDiccionarioConexiones(nombre, auxCliente);
			}
			else
			{
				MessageBox.Show("No Soy servidor");
				Globales.listaJugadores.Add(new Jugador(nombre));
				MessageBox.Show("Lista de jugadores " + Globales.listaJugadores.Count);
			}
			frmMenu.actualizarDataGridJugadores(Globales.dataGrid, Globales.listaJugadores);
		}

		private void jugadorListo(string paquete)
		{
			
		}
		
		private void movimiento(string paquete)
		{
			string[] datos = paquete.Split(CodOps.SEPARADOR);
			string nick = datos[1];
			byte direccion = byte.Parse(datos[2]);

			if (Globales.soyServidor)
			{
				foreach(var conexion in Globales.getDiccionarioConexiones())
				{
					conexion.Value.reenviarPaquete(paquete);
				}
			}

			Jugador player = Globales.listaJugadores.Find(x => x.Nombre == nick);

			Globales.partida.procesarMovimiento(player,direccion);
		}
		
		/*
		private void movimiento(String paquete)
		{
			string[] datos = paquete.Split(CodOps.SEPARADOR);
			string nick = datos[1];
			short x = short.Parse(datos[2]), y = short.Parse(datos[3]);

			if (Globales.soyServidor)
			{
				foreach (var conexion in Globales.getDiccionarioConexiones())
				{
					if (conexion.Key != nick)
					{
						conexion.Value.reenviarPaquete(paquete);
					}
					else
					{
						continue;
					}					
				}
			}

			Jugador player = Globales.listaJugadores.Find(j => j.Nombre == nick);
			
			player.setPosicion(x, y);
		}
		*/
		public void detener()
		{
			seguirConectado = false;
			flujoEntrada.Close();
			flujoEntrada.Dispose();
			socket.Close();
		}
	}
}
//234567890012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890