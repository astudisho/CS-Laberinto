namespace PPI_Proyecto
{
	partial class frmMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtNickname = new System.Windows.Forms.TextBox();
			this.txtIpServidor = new System.Windows.Forms.TextBox();
			this.btnUnirse = new System.Windows.Forms.Button();
			this.btnServidor = new System.Windows.Forms.Button();
			this.dgvJugadores = new System.Windows.Forms.DataGridView();
			this.btnListo = new System.Windows.Forms.Button();
			this.btnIniciarJuego = new System.Windows.Forms.Button();
			this.lblNickname = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).BeginInit();
			this.SuspendLayout();
			// 
			// txtNickname
			// 
			this.txtNickname.Location = new System.Drawing.Point(211, 22);
			this.txtNickname.Name = "txtNickname";
			this.txtNickname.Size = new System.Drawing.Size(325, 22);
			this.txtNickname.TabIndex = 0;
			// 
			// txtIpServidor
			// 
			this.txtIpServidor.Location = new System.Drawing.Point(211, 69);
			this.txtIpServidor.Name = "txtIpServidor";
			this.txtIpServidor.Size = new System.Drawing.Size(325, 22);
			this.txtIpServidor.TabIndex = 1;
			// 
			// btnUnirse
			// 
			this.btnUnirse.Location = new System.Drawing.Point(576, 22);
			this.btnUnirse.Name = "btnUnirse";
			this.btnUnirse.Size = new System.Drawing.Size(75, 23);
			this.btnUnirse.TabIndex = 2;
			this.btnUnirse.Text = "Unirse";
			this.btnUnirse.UseVisualStyleBackColor = true;
			this.btnUnirse.Click += new System.EventHandler(this.btnUnirse_Click);
			// 
			// btnServidor
			// 
			this.btnServidor.Location = new System.Drawing.Point(576, 69);
			this.btnServidor.Name = "btnServidor";
			this.btnServidor.Size = new System.Drawing.Size(75, 23);
			this.btnServidor.TabIndex = 3;
			this.btnServidor.Text = "Servidor";
			this.btnServidor.UseVisualStyleBackColor = true;
			this.btnServidor.Click += new System.EventHandler(this.btnServidor_Click);
			// 
			// dgvJugadores
			// 
			this.dgvJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvJugadores.Enabled = false;
			this.dgvJugadores.Location = new System.Drawing.Point(78, 124);
			this.dgvJugadores.Name = "dgvJugadores";
			this.dgvJugadores.RowTemplate.Height = 24;
			this.dgvJugadores.Size = new System.Drawing.Size(573, 176);
			this.dgvJugadores.TabIndex = 4;
			// 
			// btnListo
			// 
			this.btnListo.Location = new System.Drawing.Point(78, 328);
			this.btnListo.Name = "btnListo";
			this.btnListo.Size = new System.Drawing.Size(75, 23);
			this.btnListo.TabIndex = 5;
			this.btnListo.Text = "Listo";
			this.btnListo.UseVisualStyleBackColor = true;
			// 
			// btnIniciarJuego
			// 
			this.btnIniciarJuego.Location = new System.Drawing.Point(419, 320);
			this.btnIniciarJuego.Name = "btnIniciarJuego";
			this.btnIniciarJuego.Size = new System.Drawing.Size(117, 39);
			this.btnIniciarJuego.TabIndex = 6;
			this.btnIniciarJuego.Text = "Iniciar Juego";
			this.btnIniciarJuego.UseVisualStyleBackColor = true;
			this.btnIniciarJuego.Click += new System.EventHandler(this.btnIniciarJuego_Click);
			// 
			// lblNickname
			// 
			this.lblNickname.AutoSize = true;
			this.lblNickname.Location = new System.Drawing.Point(75, 25);
			this.lblNickname.Name = "lblNickname";
			this.lblNickname.Size = new System.Drawing.Size(110, 17);
			this.lblNickname.TabIndex = 7;
			this.lblNickname.Text = "Nombre jugador";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(111, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Ip servidor";
			// 
			// frmMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 382);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblNickname);
			this.Controls.Add(this.btnIniciarJuego);
			this.Controls.Add(this.btnListo);
			this.Controls.Add(this.dgvJugadores);
			this.Controls.Add(this.btnServidor);
			this.Controls.Add(this.btnUnirse);
			this.Controls.Add(this.txtIpServidor);
			this.Controls.Add(this.txtNickname);
			this.Name = "frmMenu";
			this.Text = "Menu";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
			this.Load += new System.EventHandler(this.frmMenu_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvJugadores)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtNickname;
		private System.Windows.Forms.TextBox txtIpServidor;
		private System.Windows.Forms.Button btnUnirse;
		private System.Windows.Forms.Button btnServidor;
		private System.Windows.Forms.DataGridView dgvJugadores;
		private System.Windows.Forms.Button btnListo;
		private System.Windows.Forms.Button btnIniciarJuego;
		private System.Windows.Forms.Label lblNickname;
		private System.Windows.Forms.Label label1;
	}
}

