namespace OrdenesTrabajo
{
    partial class AEUsuarios
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
            this.groupBoxBtns = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDominio = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.grpGrillaOpc = new System.Windows.Forms.GroupBox();
            this.dataGridViewOpciones = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanInsert = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CanBajaAlta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceOpciones = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxBtns.SuspendLayout();
            this.grpGrillaOpc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOpciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBtns
            // 
            this.groupBoxBtns.Controls.Add(this.btnAceptar);
            this.groupBoxBtns.Controls.Add(this.btnCancelar);
            this.groupBoxBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxBtns.Location = new System.Drawing.Point(0, 389);
            this.groupBoxBtns.Name = "groupBoxBtns";
            this.groupBoxBtns.Size = new System.Drawing.Size(584, 67);
            this.groupBoxBtns.TabIndex = 1;
            this.groupBoxBtns.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(373, 26);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(485, 26);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dominio: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nombre: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Apellido: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Perfil: ";
            // 
            // txtDominio
            // 
            this.txtDominio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDominio.Enabled = false;
            this.txtDominio.Location = new System.Drawing.Point(197, 18);
            this.txtDominio.Name = "txtDominio";
            this.txtDominio.ReadOnly = true;
            this.txtDominio.Size = new System.Drawing.Size(251, 20);
            this.txtDominio.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsuario.Location = new System.Drawing.Point(197, 58);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(251, 20);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsuario_Validating);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(197, 98);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(251, 20);
            this.txtContraseña.TabIndex = 10;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(197, 138);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(251, 20);
            this.txtNombre.TabIndex = 11;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(197, 178);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(251, 20);
            this.txtApellido.TabIndex = 12;
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(197, 218);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(251, 21);
            this.cmbPerfil.TabIndex = 13;
            this.cmbPerfil.SelectedIndexChanged += new System.EventHandler(this.cmbPerfil_SelectedIndexChanged);
            // 
            // grpGrillaOpc
            // 
            this.grpGrillaOpc.Controls.Add(this.dataGridViewOpciones);
            this.grpGrillaOpc.Location = new System.Drawing.Point(0, 248);
            this.grpGrillaOpc.Name = "grpGrillaOpc";
            this.grpGrillaOpc.Size = new System.Drawing.Size(584, 144);
            this.grpGrillaOpc.TabIndex = 14;
            this.grpGrillaOpc.TabStop = false;
            this.grpGrillaOpc.Text = "Opciones:";
            // 
            // dataGridViewOpciones
            // 
            this.dataGridViewOpciones.AllowUserToAddRows = false;
            this.dataGridViewOpciones.AllowUserToDeleteRows = false;
            this.dataGridViewOpciones.AllowUserToResizeColumns = false;
            this.dataGridViewOpciones.AllowUserToResizeRows = false;
            this.dataGridViewOpciones.AutoGenerateColumns = false;
            this.dataGridViewOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.CanSelect,
            this.CanInsert,
            this.CanUpdate,
            this.CanDelete,
            this.CanBajaAlta});
            this.dataGridViewOpciones.DataSource = this.bindingSourceOpciones;
            this.dataGridViewOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOpciones.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewOpciones.MultiSelect = false;
            this.dataGridViewOpciones.Name = "dataGridViewOpciones";
            this.dataGridViewOpciones.ReadOnly = true;
            this.dataGridViewOpciones.RowHeadersVisible = false;
            this.dataGridViewOpciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOpciones.Size = new System.Drawing.Size(578, 125);
            this.dataGridViewOpciones.TabIndex = 0;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // CanSelect
            // 
            this.CanSelect.DataPropertyName = "CanSelect";
            this.CanSelect.HeaderText = "Selecciona";
            this.CanSelect.Name = "CanSelect";
            this.CanSelect.ReadOnly = true;
            this.CanSelect.Width = 75;
            // 
            // CanInsert
            // 
            this.CanInsert.DataPropertyName = "CanInsert";
            this.CanInsert.HeaderText = "Agrega";
            this.CanInsert.Name = "CanInsert";
            this.CanInsert.ReadOnly = true;
            this.CanInsert.Width = 75;
            // 
            // CanUpdate
            // 
            this.CanUpdate.DataPropertyName = "CanUpdate";
            this.CanUpdate.HeaderText = "Edita";
            this.CanUpdate.Name = "CanUpdate";
            this.CanUpdate.ReadOnly = true;
            this.CanUpdate.Width = 75;
            // 
            // CanDelete
            // 
            this.CanDelete.DataPropertyName = "CanDelete";
            this.CanDelete.HeaderText = "Elimina";
            this.CanDelete.Name = "CanDelete";
            this.CanDelete.ReadOnly = true;
            this.CanDelete.Width = 75;
            // 
            // CanBajaAlta
            // 
            this.CanBajaAlta.DataPropertyName = "CanBajaAlta";
            this.CanBajaAlta.HeaderText = "Alta/Baja";
            this.CanBajaAlta.Name = "CanBajaAlta";
            this.CanBajaAlta.ReadOnly = true;
            this.CanBajaAlta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CanBajaAlta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CanBajaAlta.Width = 75;
            // 
            // AEUsuarios
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(584, 456);
            this.Controls.Add(this.grpGrillaOpc);
            this.Controls.Add(this.cmbPerfil);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtDominio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxBtns);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AEUsuarios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AEUsuarios_Load);
            this.groupBoxBtns.ResumeLayout(false);
            this.grpGrillaOpc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOpciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBtns;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDominio;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.GroupBox grpGrillaOpc;
        private System.Windows.Forms.DataGridView dataGridViewOpciones;
        private System.Windows.Forms.BindingSource bindingSourceOpciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanSelect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanInsert;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanUpdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CanBajaAlta;
    }
}