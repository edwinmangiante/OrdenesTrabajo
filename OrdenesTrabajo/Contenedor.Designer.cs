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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Ordenes");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Pedidos");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Opciones", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeViewOpciones = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeViewOpciones
            // 
            this.treeViewOpciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewOpciones.Location = new System.Drawing.Point(0, 0);
            this.treeViewOpciones.Name = "treeViewOpciones";
            treeNode1.Name = "NodeOrd";
            treeNode1.Text = "Ordenes";
            treeNode2.Name = "NodePed";
            treeNode2.Text = "Pedidos";
            treeNode3.Name = "NodOpc";
            treeNode3.Text = "Opciones";
            this.treeViewOpciones.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeViewOpciones.Size = new System.Drawing.Size(156, 407);
            this.treeViewOpciones.TabIndex = 1;
            this.treeViewOpciones.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewOpciones_NodeMouseClick);
            // 
            // ContenedorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 407);
            this.Controls.Add(this.treeViewOpciones);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "ContenedorFrm";
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