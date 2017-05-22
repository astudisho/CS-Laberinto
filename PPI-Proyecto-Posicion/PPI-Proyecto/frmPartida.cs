using System;
using System.Windows.Forms;

namespace PPI_Proyecto
{
	public partial class frmPartida : Form
	{
		private Partida partida;
		private Jugador jugadorLocal;

		public frmPartida()
		{
			InitializeComponent();

			jugadorLocal = Globales.listaJugadores.Find(x => x.Nombre == Globales.nickname);
		}

		private void frmPartida_Load(object sender, EventArgs e)
		{
			Globales.partida = (partida = new Partida(this));
			DoubleBuffered = true;

		}

		private void frmPartida_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.S:
				case Keys.Down:
					//Globales.cliente.enviarMovimiento(CodOps.MOV_ABAJO); break;
					partida.procesarMovimiento(jugadorLocal, CodOps.MOV_ABAJO); break;
				case Keys.Up:
				case Keys.W: //Globales.cliente.enviarMovimiento(CodOps.MOV_ARRIBA); break;
					partida.procesarMovimiento(jugadorLocal, CodOps.MOV_ARRIBA); break;
				case Keys.Left:
				case Keys.A: //Globales.cliente.enviarMovimiento(CodOps.MOV_IZQ); break;
					partida.procesarMovimiento(jugadorLocal, CodOps.MOV_IZQ); break;
				case Keys.Right:
				case Keys.D: //Globales.cliente.enviarMovimiento(CodOps.MOV_DER); break;
					partida.procesarMovimiento(jugadorLocal, CodOps.MOV_DER); break;
				case Keys.Space: Invalidate(); break;
			}
		}

		private void frmPartida_Paint(object sender, PaintEventArgs e)
		{
			partida.dibujarEscenario(e.Graphics);

			foreach (var jugador in Globales.listaJugadores)
			{
				partida.dibujarJugador(e.Graphics, jugador);
			}
		}

	}
}
//23456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789