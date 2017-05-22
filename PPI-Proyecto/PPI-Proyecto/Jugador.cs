namespace PPI_Proyecto
{
	public class Posicion
	{
		public int x { get; set; }
		public int y { get; set; }
    }

	public class Jugador
	{
		private static byte numeroJugador = 0;
		private byte numero;
		private string nombre;
		private short puntaje;
		private Posicion posicion;
		private bool listo;

		public byte Numero { get { return numero; } }
		public string Nombre { get { return nombre; } }
		public bool Listo { get { return listo; } }
		public short Puntaje { get { return puntaje; } }

		public Jugador(string nombre)
		{
			this.numero = numeroJugador++;
			this.nombre = nombre;
			this.puntaje = 0;
			this.posicion = new Posicion();
			this.posicion.x = 0;
			this.posicion.y = 0;
			this.listo = false;
		}

		public void setPosicion(int x, int y)
		{
			this.posicion.x = x;
			this.posicion.y = y;
		}

		public void aumentarX()
		{
			this.posicion.x += 1;
		}

		public void aumentarY()
		{
			this.posicion.y += 1;
		}

		public void restarX()
		{
			this.posicion.x -= 1;
		}

		public void restarY()
		{
			this.posicion.y -= 1;
		}

		public Posicion getPosicion()
		{
			return posicion;
		}

		public void setPuntaje(short val)
		{
			this.puntaje = val;
		}

		public void aumentarPuntaje(short val = 1)
		{
			this.puntaje += val;
		}

		public void setListo()
		{
			this.listo = true;
		}

		public bool getListo()
		{
			return this.listo;
		}

		public string getNombre()
		{
			return this.nombre;
		}
	}
}
