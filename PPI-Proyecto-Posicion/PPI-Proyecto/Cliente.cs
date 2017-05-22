using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;


namespace PPI_Proyecto
{
	class Cliente
	{
		private Thread hilo;
		private TcpClient cliente;
		private IPAddress direccion;
		private readonly object bloqueo;
		private string paquete;
		private bool seguirConectado, mensajeListo;
		private BinaryWriter flujoSalida;

		public Cliente(IPAddress direccion)
		{
			mensajeListo = false;
			seguirConectado = true;
			this.direccion = direccion;
			bloqueo = new object();

			(hilo = new Thread(new ThreadStart(() => conectar()))).Start();

		}

		private void conectar()
		{
			try
			{
				cliente = new TcpClient();
				cliente.Connect(new IPEndPoint(direccion, Globales.PUERTO_ESCUCHA));
				flujoSalida = new BinaryWriter(cliente.GetStream(), Encoding.ASCII);
				do
				{
					try
					{
						lock (bloqueo)
						{
							while (!mensajeListo && seguirConectado)
								Monitor.Wait(bloqueo);

							MessageBox.Show("Cliente envia: " + paquete);
							flujoSalida.Write(paquete);							
							mensajeListo = false;
						}
					}
					catch (SocketException se)
					{
						throw;
					}
					catch (Exception e)
					{
						throw;
					}
				} while (seguirConectado);
			}
			catch (SocketException se)
			{
				//No se pudo conectar
				throw;
			}
			catch (Exception e)
			{
				throw;
			}			
		}

		public void detener()
		{
			seguirConectado = false;
			notificarHilo();

			flujoSalida.Close();
			flujoSalida.Dispose();
			cliente.Close();
		}

		private void notificarHilo()
		{
			lock(bloqueo)
				Monitor.PulseAll(bloqueo);
		}

		public void unirsePartida(string nombre)
		{
			paquete = CodOps.CO_UNIRSE.ToString() + CodOps.SEPARADOR +
				nombre;

			mensajeListo = true;
			notificarHilo();
		}

		public void jugadorListo(string nombre)
		{
			paquete = CodOps.CO_JUGADOR_LISTO.ToString() + CodOps.SEPARADOR +
				nombre;

			mensajeListo = true;
			notificarHilo();
		}

		public void reenviarPaquete(string paquete)
		{
			this.paquete = paquete;

			mensajeListo = true;
			notificarHilo();
		}
		/*
		public void enviarMovimiento(byte direccion)
		{
			paquete = CodOps.CO_MOVIMIENTO.ToString() + CodOps.SEPARADOR +
				Globales.nickname + CodOps.SEPARADOR + direccion;

			mensajeListo = true;
			notificarHilo();
		}
		*/
		public void enviarMovimiento(Jugador player)
		{
			this.paquete = CodOps.CO_MOVIMIENTO.ToString() + CodOps.SEPARADOR +
				Globales.nickname + CodOps.SEPARADOR +
				player.getPosicion().x.ToString() + CodOps.SEPARADOR +
				player.getPosicion().y.ToString();

			mensajeListo = true;
			notificarHilo();
		}
	}
}
