namespace OrdenesTrabajo
{
    partial class Pedidos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripSalir = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDataUser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.chbTodos = new System.Windows.Forms.CheckBox();
            this.chbIncluirBajas = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNroPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxGrilla = new System.Windows.Forms.GroupBox();
            this.panelGrilla = new System.Windows.Forms.Panel();
            this.dataGridViewPedidos = new System.Windows.Forms.DataGridView();
            this.toolStripGrilla = new System.Windows.Forms.ToolStrip();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tssEliminar = new System.Windows.Forms.ToolStripSeparator();
            this.btnVer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCantidad = new System.Windows.Forms.ToolStripLabel();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.bindingSourcePedidos = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripSalir.SuspendLayout();
            this.groupBoxFiltros.SuspendLayout();
            this.groupBoxGrilla.SuspendLayout();
            this.panelGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).BeginInit();
            this.toolStripGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSalir
            // 
            this.toolStripSalir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir,
            this.toolStripSeparator1,
            this.lblDataUser,
            this.toolStripSeparator12});
            this.toolStripSalir.Location = new System.Drawing.Point(0, 0);
            this.toolStripSalir.Name = "toolStripSalir";
            this.toolStripSalir.Size = new System.Drawing.Size(971, 25);
            this.toolStripSalir.TabIndex = 3;
            this.toolStripSalir.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 22);
            this.btnSalir.Text = "ESC - Salir";
            this.btnSalir.ToolTipText = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblDataUser
            // 
            this.lblDataUser.Name = "lblDataUser";
            this.lblDataUser.Size = new System.Drawing.Size(67, 22);
            this.lblDataUser.Text = "lblDataUser";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.chbTodos);
            this.groupBoxFiltros.Controls.Add(this.chbIncluirBajas);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaHasta);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaDesde);
            this.groupBoxFiltros.Controls.Add(this.label8);
            this.groupBoxFiltros.Controls.Add(this.label7);
            this.groupBoxFiltros.Controls.Add(this.txtUsuario);
            this.groupBoxFiltros.Controls.Add(this.label6);
            this.groupBoxFiltros.Controls.Add(this.txtNroPedido);
            this.groupBoxFiltros.Controls.Add(this.label1);
            this.groupBoxFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFiltros.Location = new System.Drawing.Point(0, 25);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(971, 100);
            this.groupBoxFiltros.TabIndex = 4;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros";
            // 
            // chbTodos
            // 
            this.chbTodos.AutoSize = true;
            this.chbTodos.Location = new System.Drawing.Point(457, 66);
            this.chbTodos.Name = "chbTodos";
            this.chbTodos.Size = new System.Drawing.Size(56, 17);
            this.chbTodos.TabIndex = 15;
            this.chbTodos.Text = "Todos";
            this.chbTodos.UseVisualStyleBackColor = true;
            this.chbTodos.CheckedChanged += new System.EventHandler(this.chbTodos_CheckedChanged);
            // 
            // chbIncluirBajas
            // 
            this.chbIncluirBajas.AutoSize = true;
            this.chbIncluirBajas.Location = new System.Drawing.Point(457, 24);
            this.chbIncluirBajas.Name = "chbIncluirBajas";
            this.chbIncluirBajas.Size = new System.Drawing.Size(52, 17);
            this.chbIncluirBajas.TabIndex = 14;
            this.chbIncluirBajas.Text = "Bajas";
            this.chbIncluirBajas.UseVisualStyleBackColor = true;
            this.chbIncluirBajas.CheckedChanged += new System.EventHandler(this.chbIncluirBajas_CheckedChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(315, 64);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaHasta.TabIndex = 7;
            this.dtpFechaHasta.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaHasta_Validating);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(315, 22);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(125, 20);
            this.dtpFechaDesde.TabIndex = 6;
            this.dtpFechaDesde.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaDesde_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Fecha Hasta: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha Desde: ";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(87, 64);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(125, 20);
            this.txtUsuario.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Usuario: ";
            // 
            // txtNroPedido
            // 
            this.txtNroPedido.Location = new System.Drawing.Point(87, 22);
            this.txtNroPedido.Name = "txtNroPedido";
            this.txtNroPedido.Size = new System.Drawing.Size(125, 20);
            this.txtNroPedido.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro Pedido: ";
            // 
            // groupBoxGrilla
            // 
            this.groupBoxGrilla.Controls.Add(this.panelGrilla);
            this.groupBoxGrilla.Controls.Add(this.toolStripGrilla);
            this.groupBoxGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrilla.Location = new System.Drawing.Point(0, 125);
            this.groupBoxGrilla.Name = "groupBoxGrilla";
            this.groupBoxGrilla.Size = new System.Drawing.Size(971, 284);
            this.groupBoxGrilla.TabIndex = 5;
            this.groupBoxGrilla.TabStop = false;
            // 
            // panelGrilla
            // 
            this.panelGrilla.Controls.Add(this.dataGridViewPedidos);
            this.panelGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrilla.Location = new System.Drawing.Point(3, 41);
            this.panelGrilla.Name = "panelGrilla";
            this.panelGrilla.Size = new System.Drawing.Size(965, 240);
            this.panelGrilla.TabIndex = 1;
            // 
            // dataGridViewPedidos
            // 
            this.dataGridViewPedidos.AllowUserToAddRows = false;
            this.dataGridViewPedidos.AllowUserToDeleteRows = false;
            this.dataGridViewPedidos.AllowUserToResizeColumns = false;
            this.dataGridViewPedidos.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPedidos.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPedidos.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPedidos.MultiSelect = false;
            this.dataGridViewPedidos.Name = "dataGridViewPedidos";
            this.dataGridViewPedidos.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewPedidos.RowHeadersVisible = false;
            this.dataGridViewPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPedidos.Size = new System.Drawing.Size(965, 240);
            this.dataGridViewPedidos.TabIndex = 1;
            // 
            // toolStripGrilla
            // 
            this.toolStripGrilla.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLimpiar,
            this.toolStripSeparator7,
            this.btnEliminar,
            this.tssEliminar,
            this.btnVer,
            this.toolStripSeparator8,
            this.btnBuscar,
            this.toolStripSeparator2,
            this.btnAgregar,
            this.toolStripSeparator5,
            this.btnEditar,
            this.toolStripSeparator3,
            this.btnImprimir,
            this.toolStripSeparator9,
            this.btnExportar,
            this.toolStripSeparator6,
            this.lblCantidad});
            this.toolStripGrilla.Location = new System.Drawing.Point(3, 16);
            this.toolStripGrilla.Name = "toolStripGrilla";
            this.toolStripGrilla.Size = new System.Drawing.Size(965, 25);
            this.toolStripGrilla.TabIndex = 1;
            this.toolStripGrilla.Text = "toolStrip1";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 22);
            this.btnLimpiar.Text = "F2 - Limpiar";
            this.btnLimpiar.ToolTipText = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(93, 22);
            this.btnEliminar.Text = "F3 - Eliminar";
            this.btnEliminar.ToolTipText = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tssEliminar
            // 
            this.tssEliminar.Name = "tssEliminar";
            this.tssEliminar.Size = new System.Drawing.Size(6, 25);
            // 
            // btnVer
            // 
            this.btnVer.Enabled = false;
            this.btnVer.Image = ((System.Drawing.Image)(resources.GetObject("btnVer.Image")));
            this.btnVer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(67, 22);
            this.btnVer.Text = "F4 - Ver";
            this.btnVer.ToolTipText = "Ver";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 22);
            this.btnBuscar.Text = "F5 - Buscar";
            this.btnBuscar.ToolTipText = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 22);
            this.btnAgregar.Text = "F6 - Agregar";
            this.btnAgregar.ToolTipText = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 22);
            this.btnEditar.Text = "F7 - Editar";
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExportar
            // 
            this.btnExportar.Enabled = false;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(99, 22);
            this.btnExportar.Text = "F12 - Exportar";
            this.btnExportar.ToolTipText = "Exportar a Excel";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // lblCantidad
            // 
            this.lblCantidad.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(13, 22);
            this.lblCantidad.Text = "c";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 22);
            this.btnImprimir.Text = "F11 - Imprimir";
            this.btnImprimir.ToolTipText = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // bindingSourcePedidos
            // 
            this.bindingSourcePedidos.CurrentChanged += new System.EventHandler(this.bindingSourcePedidos_CurrentChanged);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 409);
            this.Controls.Add(this.groupBoxGrilla);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.toolStripSalir);
            this.KeyPreview = true;
            this.Name = "Pedidos";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Pedidos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pedidos_KeyDown);
            this.toolStripSalir.ResumeLayout(false);
            this.toolStripSalir.PerformLayout();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.groupBoxGrilla.ResumeLayout(false);
            this.groupBoxGrilla.PerformLayout();
            this.panelGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).EndInit();
            this.toolStripGrilla.ResumeLayout(false);
            this.toolStripGrilla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripSalir;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblDataUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.CheckBox chbTodos;
        private System.Windows.Forms.CheckBox chbIncluirBajas;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNroPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxGrilla;
        private System.Windows.Forms.Panel panelGrilla;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
        private System.Windows.Forms.ToolStrip toolStripGrilla;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator tssEliminar;
        private System.Windows.Forms.ToolStripButton btnVer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel lblCantidad;
        private System.Windows.Forms.BindingSource bindingSourcePedidos;
    }
}