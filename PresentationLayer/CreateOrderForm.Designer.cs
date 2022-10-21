namespace OrderSystem.PresentationLayer
{
    partial class CreateOrderForm
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
            this.existingCustomerContainer = new System.Windows.Forms.GroupBox();
            this.customersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.existingCustomerContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // existingCustomerContainer
            // 
            this.existingCustomerContainer.Controls.Add(this.customersComboBox);
            this.existingCustomerContainer.Controls.Add(this.label1);
            this.existingCustomerContainer.Location = new System.Drawing.Point(364, 164);
            this.existingCustomerContainer.Name = "existingCustomerContainer";
            this.existingCustomerContainer.Size = new System.Drawing.Size(345, 164);
            this.existingCustomerContainer.TabIndex = 5;
            this.existingCustomerContainer.TabStop = false;
            // 
            // customersComboBox
            // 
            this.customersComboBox.FormattingEnabled = true;
            this.customersComboBox.Location = new System.Drawing.Point(27, 80);
            this.customersComboBox.Name = "customersComboBox";
            this.customersComboBox.Size = new System.Drawing.Size(288, 21);
            this.customersComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Customer to Create order for:";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(364, 362);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(97, 44);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(361, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Create new customer order";
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.LightGreen;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(619, 362);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(90, 44);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.SpringGreen;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(500, 362);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(84, 44);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1139, 656);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.existingCustomerContainer);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateOrderForm_FormClosed);
            this.existingCustomerContainer.ResumeLayout(false);
            this.existingCustomerContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox existingCustomerContainer;
        private System.Windows.Forms.ComboBox customersComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button CloseButton;
    }
}