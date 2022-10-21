namespace OrderSystem.PresentationLayer
{
    partial class OrderForm
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
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.remainingCreditLabel = new System.Windows.Forms.Label();
            this.remaininhCreditHeading = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.ItemsOnCartLabel = new System.Windows.Forms.Label();
            this.itemsListView = new System.Windows.Forms.ListView();
            this.qtyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkOutButton = new System.Windows.Forms.Button();
            this.currentTotalLabel = new System.Windows.Forms.Label();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.productLabel = new System.Windows.Forms.Label();
            this.productsComboBox = new System.Windows.Forms.ComboBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerNumberLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderIDLabel = new System.Windows.Forms.Label();
            this.detailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.closeButton);
            this.detailsGroupBox.Controls.Add(this.backButton);
            this.detailsGroupBox.Controls.Add(this.remainingCreditLabel);
            this.detailsGroupBox.Controls.Add(this.remaininhCreditHeading);
            this.detailsGroupBox.Controls.Add(this.cancelButton);
            this.detailsGroupBox.Controls.Add(this.doneButton);
            this.detailsGroupBox.Controls.Add(this.ItemsOnCartLabel);
            this.detailsGroupBox.Controls.Add(this.itemsListView);
            this.detailsGroupBox.Controls.Add(this.qtyNumericUpDown);
            this.detailsGroupBox.Controls.Add(this.checkOutButton);
            this.detailsGroupBox.Controls.Add(this.currentTotalLabel);
            this.detailsGroupBox.Controls.Add(this.addToCartButton);
            this.detailsGroupBox.Controls.Add(this.productLabel);
            this.detailsGroupBox.Controls.Add(this.productsComboBox);
            this.detailsGroupBox.Controls.Add(this.totalLabel);
            this.detailsGroupBox.Controls.Add(this.quantityLabel);
            this.detailsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsGroupBox.Location = new System.Drawing.Point(37, 57);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(864, 427);
            this.detailsGroupBox.TabIndex = 13;
            this.detailsGroupBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.closeButton.Location = new System.Drawing.Point(178, 361);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(94, 35);
            this.closeButton.TabIndex = 26;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(25, 361);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(81, 36);
            this.backButton.TabIndex = 25;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // remainingCreditLabel
            // 
            this.remainingCreditLabel.AutoSize = true;
            this.remainingCreditLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingCreditLabel.Location = new System.Drawing.Point(702, 221);
            this.remainingCreditLabel.Name = "remainingCreditLabel";
            this.remainingCreditLabel.Size = new System.Drawing.Size(65, 17);
            this.remainingCreditLabel.TabIndex = 24;
            this.remainingCreditLabel.Text = "R 00.00";
            // 
            // remaininhCreditHeading
            // 
            this.remaininhCreditHeading.AutoSize = true;
            this.remaininhCreditHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remaininhCreditHeading.Location = new System.Drawing.Point(527, 221);
            this.remaininhCreditHeading.Name = "remaininhCreditHeading";
            this.remaininhCreditHeading.Size = new System.Drawing.Size(137, 17);
            this.remaininhCreditHeading.TabIndex = 23;
            this.remaininhCreditHeading.Text = "Remaining Credit:";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Bisque;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(339, 361);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(96, 35);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.BurlyWood;
            this.doneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(530, 360);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(117, 36);
            this.doneButton.TabIndex = 21;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // ItemsOnCartLabel
            // 
            this.ItemsOnCartLabel.AutoSize = true;
            this.ItemsOnCartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemsOnCartLabel.Location = new System.Drawing.Point(22, 73);
            this.ItemsOnCartLabel.Name = "ItemsOnCartLabel";
            this.ItemsOnCartLabel.Size = new System.Drawing.Size(84, 13);
            this.ItemsOnCartLabel.TabIndex = 14;
            this.ItemsOnCartLabel.Text = "Items On Cart";
            // 
            // itemsListView
            // 
            this.itemsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsListView.HideSelection = false;
            this.itemsListView.Location = new System.Drawing.Point(25, 100);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(410, 228);
            this.itemsListView.TabIndex = 13;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.SelectedIndexChanged += new System.EventHandler(this.itemsListView_SelectedIndexChanged);
            // 
            // qtyNumericUpDown
            // 
            this.qtyNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyNumericUpDown.Location = new System.Drawing.Point(243, 33);
            this.qtyNumericUpDown.Name = "qtyNumericUpDown";
            this.qtyNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.qtyNumericUpDown.TabIndex = 12;
            // 
            // checkOutButton
            // 
            this.checkOutButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkOutButton.Location = new System.Drawing.Point(717, 361);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(107, 36);
            this.checkOutButton.TabIndex = 10;
            this.checkOutButton.Text = "Check Out";
            this.checkOutButton.UseVisualStyleBackColor = false;
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // currentTotalLabel
            // 
            this.currentTotalLabel.AutoSize = true;
            this.currentTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTotalLabel.Location = new System.Drawing.Point(702, 171);
            this.currentTotalLabel.Name = "currentTotalLabel";
            this.currentTotalLabel.Size = new System.Drawing.Size(65, 17);
            this.currentTotalLabel.TabIndex = 11;
            this.currentTotalLabel.Text = "R 00.00";
            // 
            // addToCartButton
            // 
            this.addToCartButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addToCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartButton.Location = new System.Drawing.Point(347, 23);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(88, 37);
            this.addToCartButton.TabIndex = 8;
            this.addToCartButton.Text = "Add to Cart";
            this.addToCartButton.UseVisualStyleBackColor = false;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click);
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabel.Location = new System.Drawing.Point(48, 16);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(51, 13);
            this.productLabel.TabIndex = 3;
            this.productLabel.Text = "Product";
            // 
            // productsComboBox
            // 
            this.productsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsComboBox.FormattingEnabled = true;
            this.productsComboBox.Location = new System.Drawing.Point(51, 32);
            this.productsComboBox.Name = "productsComboBox";
            this.productsComboBox.Size = new System.Drawing.Size(163, 21);
            this.productsComboBox.TabIndex = 1;
            this.productsComboBox.SelectionChangeCommitted += new System.EventHandler(this.productsComboBox_SelectionChangeCommitted);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(527, 171);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(60, 17);
            this.totalLabel.TabIndex = 5;
            this.totalLabel.Text = "Total : ";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.Location = new System.Drawing.Point(240, 16);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(32, 13);
            this.quantityLabel.TabIndex = 2;
            this.quantityLabel.Text = "QTY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(394, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Customer Details:";
            // 
            // customerNumberLabel
            // 
            this.customerNumberLabel.AutoSize = true;
            this.customerNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNumberLabel.Location = new System.Drawing.Point(538, 27);
            this.customerNumberLabel.Name = "customerNumberLabel";
            this.customerNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.customerNumberLabel.TabIndex = 15;
            this.customerNumberLabel.Text = "ABCDEF001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Order ID:";
            // 
            // orderIDLabel
            // 
            this.orderIDLabel.AutoSize = true;
            this.orderIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderIDLabel.Location = new System.Drawing.Point(197, 27);
            this.orderIDLabel.Name = "orderIDLabel";
            this.orderIDLabel.Size = new System.Drawing.Size(83, 13);
            this.orderIDLabel.TabIndex = 17;
            this.orderIDLabel.Text = "XXXXXX0001";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1139, 656);
            this.Controls.Add(this.orderIDLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerNumberLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detailsGroupBox);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.NumericUpDown qtyNumericUpDown;
        private System.Windows.Forms.Button checkOutButton;
        private System.Windows.Forms.Label currentTotalLabel;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.ComboBox productsComboBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label ItemsOnCartLabel;
        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label customerNumberLabel;
        //private System.Windows.Forms.TextBox specialNoteTextBox;
        //private System.Windows.Forms.Label specialNoteLabel;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label orderIDLabel;
        private System.Windows.Forms.Label remainingCreditLabel;
        private System.Windows.Forms.Label remaininhCreditHeading;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button closeButton;
    }
}