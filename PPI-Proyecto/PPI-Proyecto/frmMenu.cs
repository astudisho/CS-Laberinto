using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace PPI_Proyecto
{
	public partial class frmMenu : Form
	{
		private Cliente cliente;
		private Servidor servidor;
		private Jugador jugadorLocal;
		private delegate void actualizarDataSource(DataGridView dgv,List<Jugador> lista);

		public frmMenu()
		{
			InitializeComponent();
		}

		private void frmMenu_Load(object sender, EventArgs e)
		{
			actualizarDataGridJugadores(dgvJugadores,Globales.listaJugadores);
			Globales.dataGrid = dgvJugadores;
		}

		private void btnServidor_Click(object sender, EventArgs e)
		{
			string nick = txtNickname.Text;

			if (nick != "")
			{
				Globales.nickname = nick;
				Globales.soyServidor = true;
				jugadorLocal = new Jugador(nick);
				servidor = new Servidor();
				cliente = new Cliente(IPAddress.Loopback);
				Globales.cliente = cliente;
				Globales.listaJugadores.Add((jugadorLocal));

				desactivarFormas();
				actualizarDataGridJugadores(dgvJugadores,Globales.listaJugadores);
			}
			else
			{
				MessageBox.Show("Nickname incorrecto");
			}
		}

		public static void actualizarDataGridJugadores(DataGridView dgv,List<Jugador> lista)
		{
			if (dgv.InvokeRequired)
			{
				dgv.Invoke(new actualizarDataSource(actualizarDataGridJugadores)
					, new object[] { dgv,lista });
			}
			else
			{
				dgv.DataSource = null;
				dgv.DataSource = lista;
			}
		}

		private void desactivarFormas()
		{
			txtNickname.Enabled = false;
			txtIpServidor.Enabled = false;
			btnUnirse.Enabled = false;
			btnServidor.Enabled = false;
		}

		private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				cliente.detener();
				servidor.detener();
			}
			catch (Exception)
			{
				//throw;
			}			
		}

		private void btnUnirse_Click(object sender, EventArgs e)
		{
			string nick = txtNickname.Text;
			IPAddress direccionServidor;

			if (nick != "" && IPAddress.TryParse(txtIpServidor.Text,out direccionServidor))
			{
				Globales.nickname = nick;
				Globales.soyServidor = false;
				jugadorLocal = new Jugador(nick);
				servidor = new Servidor();
				cliente = new Cliente(direccionServidor);
				Globales.cliente = cliente;

				cliente.unirsePartida(nick);

				actualizarDataGridJugadores( dgvJugadores,Globales.listaJugadores);
				desactivarFormas();
			}
			else
			{
				MessageBox.Show("Nickname incorrecto o ip incorrecta");
			}
		}

		private void btnIniciarJuego_Click(object sender, EventArgs e)
		{
			this.Visible = false;
			new frmPartida().ShowDialog(this);
			this.Visible = true;
		}
	}
}
//23456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789