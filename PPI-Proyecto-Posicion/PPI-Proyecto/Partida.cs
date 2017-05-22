using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PPI_Proyecto
{
	
	class Partida
	{
		private frmPartida formaPartida;
		public const int RANDOM_SEED = 1;
		public const short ANCHO_MATRIZ = 80, ALTO_MATRIZ = 23, BORDE_X = ANCHO_MATRIZ -1, 
			BORDE_Y = ALTO_MATRIZ -1, ANCHO_CELDA = 10, ALTO_CELDA = 15,ANCHO_PLUMA = 5, 
			ANCHO_FORMA = ANCHO_MATRIZ * ANCHO_CELDA + 25,
			ALTO_FORMA = ALTO_MATRIZ * ALTO_CELDA + 55, NUMERO_MUROS = 500, NUMERO_MONEDAS= 100;

		private List<Point> listaMonedas;
		private byte[,] matrizMiniMundo;

		public byte[,] MatrizMiniMundo { get { return matrizMiniMundo; } }

		private Icon MONEDA = new Icon(@".\Recursos\coin.ico",ANCHO_CELDA,ALTO_CELDA),
					JUGADOR = new Icon(@".\Recursos\baby_mario.ico",ANCHO_CELDA,ALTO_CELDA);

		enum objetos
		{
			VACIO = 0 ,JUGADOR , MURO, MONEDA
		}

		public Partida(frmPartida formaPadre)
		{
			this.formaPartida = formaPadre;
			matrizMiniMundo = new byte[ANCHO_MATRIZ, ALTO_MATRIZ];
			listaMonedas = new List<Point>();

			objetosAleatorios((byte)objetos.MURO,NUMERO_MUROS);
			crearMonedas(NUMERO_MONEDAS);

			foreach (var jugador in Globales.listaJugadores)
			{
				sortearPosicionJugadores(jugador);
			}
		}

		private void crearMonedas(short numMonedas)
		{
			Random rnd = new Random(RANDOM_SEED);
			int numero, x, y;

			for (int i = 0; i < numMonedas; i++)
			{
				numero = rnd.Next();

				x = numero % ANCHO_MATRIZ;
				y = numero % ALTO_MATRIZ;

				if (!listaMonedas.Contains(new Point(x, y)))
				{
					listaMonedas.Add(new Point(x, y));
					matrizMiniMundo[x, y] = (byte)objetos.MONEDA;
				}
			}
		}

		private void objetosAleatorios(byte objeto, int numeroObjetos)
		{
			Random rnd = new Random(RANDOM_SEED);
			int numero;

			for (int i = 0; i < numeroObjetos; i++)
			{
				numero = rnd.Next();

				matrizMiniMundo[numero % ANCHO_MATRIZ, numero % ALTO_MATRIZ] = objeto;
			}
		}

		private void dibujarCelda(Graphics g, int x, int y)
		{
			g.FillRectangle(Brushes.SkyBlue, x * ANCHO_CELDA, y * ALTO_CELDA,ANCHO_CELDA,ALTO_CELDA);
		}

		public void dibujarJugador(Graphics g, Jugador player)
		{
			g.DrawIcon(JUGADOR, player.getPosicion().x * ANCHO_CELDA, 
							  player.getPosicion().y * ALTO_CELDA);
		}

		public void dibujarEscenario(Graphics g)
		{
			Pen pluma = new Pen(Color.DarkMagenta, ANCHO_PLUMA);
			int x, y;

			for (int i = 0; i < ANCHO_MATRIZ; i++)
			{
				for (int j = 0; j < ALTO_MATRIZ; j++)
				{
					x = i * ANCHO_CELDA;
					y = j * ALTO_CELDA;

					if (matrizMiniMundo[i, j] == (byte)objetos.MURO)

						g.FillRectangle(Brushes.Black, x, y, ANCHO_CELDA, ALTO_CELDA);

					else if (matrizMiniMundo[i, j] == (byte)objetos.MONEDA)
						g.DrawIcon(MONEDA, x, y);
					else
						continue;
				}
			}
		}

		public void procesarMovimiento(Jugador player, byte direccion)
		{
			try
			{
				int x = player.getPosicion().x, y = player.getPosicion().y, posicionFutura;
				byte muro = (byte)objetos.MURO, jugador = (byte) objetos.JUGADOR, 
					moneda = (byte)objetos.MONEDA;
				//MessageBox.Show("Posicion antes de procesar de "+ player.Nombre + " x " + x + " y " + y);
				matrizMiniMundo[x, y] = (int)objetos.VACIO;

				switch (direccion)
				{
					case CodOps.MOV_ABAJO:
						if (y < BORDE_Y && matrizMiniMundo[x, y + 1] != muro && 
							matrizMiniMundo[x, y + 1] != jugador)
							player.aumentarY();	break;
					case CodOps.MOV_ARRIBA:
						if (y > 0  && matrizMiniMundo[x, y - 1] != muro &&
							matrizMiniMundo[x, y - 1] != jugador)
							player.restarY(); break;
					case CodOps.MOV_IZQ:
						if (x > 0 && matrizMiniMundo[x - 1, y] != muro && 
							matrizMiniMundo[x - 1, y] != jugador)
							player.restarX(); break;
					case CodOps.MOV_DER:
						if (x < BORDE_X && matrizMiniMundo[x+1,y] != muro && 
							matrizMiniMundo[x+1,y] != jugador)
							player.aumentarX(); break;
				}
				x = player.getPosicion().x;
				y = player.getPosicion().y;
				//MessageBox.Show("Posicion despues de procesar de " + player.Nombre + " x " + x + " y " + y);
				if (matrizMiniMundo[x,y] == moneda)
				{
					listaMonedas.Remove(new Point(x,y));
					player.aumentarPuntaje();
				}
				//MessageBox.Show(player.Nombre + " puntaje " + player.Puntaje);
				matrizMiniMundo[x, y] = jugador;

				//Zona modificada
				Globales.cliente.enviarMovimiento(player);

				formaPartida.Invalidate();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		private void sortearPosicionJugadores(Jugador player)
		{
			Random rnd = new Random(player.Nombre.GetHashCode());

			int x = rnd.Next() % ANCHO_MATRIZ, y = rnd.Next() % ALTO_MATRIZ;

			player.setPosicion(x, y);
		}
	}
}
//23456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789