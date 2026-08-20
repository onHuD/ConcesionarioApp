namespace ConcesionarioApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el diseñador de Windows Forms

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblMarca = new Label();
            txtMarca = new TextBox();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            lblColor = new Label();
            txtColor = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnMostrarTodos = new Button();
            dgvAutos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAutos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(309, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion de Autos - Concesionario";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(20, 63);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(43, 15);
            lblMarca.TabIndex = 1;
            lblMarca.Text = "Marca:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(90, 60);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(200, 23);
            txtMarca.TabIndex = 0;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(320, 63);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(51, 15);
            lblModelo.TabIndex = 2;
            lblModelo.Text = "Modelo:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(400, 60);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(200, 23);
            txtModelo.TabIndex = 1;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(20, 98);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(32, 15);
            lblAnio.TabIndex = 3;
            lblAnio.Text = "Año:";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(90, 95);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new Size(80, 23);
            txtAnio.TabIndex = 2;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(200, 98);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(39, 15);
            lblColor.TabIndex = 4;
            lblColor.Text = "Color:";
            // 
            // txtColor
            // 
            txtColor.Location = new Point(250, 95);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(150, 23);
            txtColor.TabIndex = 3;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(20, 133);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 5;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(90, 130);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(120, 23);
            txtPrecio.TabIndex = 4;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(230, 133);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 6;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(280, 130);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(80, 23);
            txtStock.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(20, 170);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 32);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(140, 170);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 32);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(260, 170);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 32);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(380, 170);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 32);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(20, 216);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(143, 15);
            lblBuscar.TabIndex = 10;
            lblBuscar.Text = "Buscar (marca o modelo):";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(200, 213);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(200, 23);
            txtBuscar.TabIndex = 10;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(410, 211);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 28);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Location = new Point(510, 211);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(110, 28);
            btnMostrarTodos.TabIndex = 12;
            btnMostrarTodos.Text = "Mostrar todos";
            btnMostrarTodos.UseVisualStyleBackColor = true;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // dgvAutos
            // 
            dgvAutos.AllowUserToAddRows = false;
            dgvAutos.AllowUserToDeleteRows = false;
            dgvAutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAutos.Location = new Point(20, 250);
            dgvAutos.MultiSelect = false;
            dgvAutos.Name = "dgvAutos";
            dgvAutos.ReadOnly = true;
            dgvAutos.RowHeadersWidth = 25;
            dgvAutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutos.Size = new Size(700, 305);
            dgvAutos.TabIndex = 13;
            dgvAutos.CellClick += dgvAutos_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 580);
            Controls.Add(lblTitulo);
            Controls.Add(lblMarca);
            Controls.Add(txtMarca);
            Controls.Add(lblModelo);
            Controls.Add(txtModelo);
            Controls.Add(lblAnio);
            Controls.Add(txtAnio);
            Controls.Add(lblColor);
            Controls.Add(txtColor);
            Controls.Add(lblPrecio);
            Controls.Add(txtPrecio);
            Controls.Add(lblStock);
            Controls.Add(txtStock);
            Controls.Add(btnAgregar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(btnLimpiar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnMostrarTodos);
            Controls.Add(dgvAutos);
            MinimumSize = new Size(650, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Concesionario - Gestión de Autos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.DataGridView dgvAutos;
    }
}