
namespace OrderSystem.PresentationLayer
{
    partial class CustomerForm
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
            this.itemslistViewCustomers = new System.Windows.Forms.ListView();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemslistViewCustomers
            // 
            this.itemslistViewCustomers.HideSelection = false;
            this.itemslistViewCustomers.Location = new System.Drawing.Point(136, 57);
            this.itemslistViewCustomers.Name = "itemslistViewCustomers";
            this.itemslistViewCustomers.Size = new System.Drawing.Size(807, 476);
            this.itemslistViewCustomers.TabIndex = 0;
            this.itemslistViewCustomers.UseCompatibleStateImageBehavior = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.ForestGreen;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(502, 559);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(90, 60);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1139, 656);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.itemslistViewCustomers);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView itemslistViewCustomers;
        private System.Windows.Forms.Button closeButton;
    }
}