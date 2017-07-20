namespace OrdenesTrabajo
{
    partial class Contenedor
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Opciones");
            this.treeViewOpciones = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewOpciones
            // 
            this.treeViewOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewOpciones.Location = new System.Drawing.Point(0, 0);
            this.treeViewOpciones.Name = "treeViewOpciones";
            treeNode1.Name = "Opciones";
            treeNode1.Text = "Opciones";
            this.treeViewOpciones.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewOpciones.Size = new System.Drawing.Size(121, 407);
            this.treeViewOpciones.TabIndex = 4;
            this.treeViewOpciones.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewOpciones_NodeMouseClick);
            // 
            // Contenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 407);
            this.Controls.Add(this.treeViewOpciones);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Contenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContenedorFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewOpciones;
    }
}