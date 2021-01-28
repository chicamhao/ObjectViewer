namespace ObjectBuilder
{
    partial class ObjectBuiler
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
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.TransformBox = new System.Windows.Forms.GroupBox();
            this.TransformTaskControl = new System.Windows.Forms.TabControl();
            this.TranslateTab = new System.Windows.Forms.TabPage();
            this.TranslateZ = new System.Windows.Forms.TextBox();
            this.TranslateY = new System.Windows.Forms.TextBox();
            this.TranslateX = new System.Windows.Forms.TextBox();
            this.RotateTab = new System.Windows.Forms.TabPage();
            this.RotateY = new System.Windows.Forms.TextBox();
            this.RotateZ = new System.Windows.Forms.TextBox();
            this.RotateX = new System.Windows.Forms.TextBox();
            this.ScaleTab = new System.Windows.Forms.TabPage();
            this.ScaleZ = new System.Windows.Forms.TextBox();
            this.ScaleY = new System.Windows.Forms.TextBox();
            this.ScaleX = new System.Windows.Forms.TextBox();
            this.CreateCute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Pyramid = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ButtonColor = new System.Windows.Forms.Button();
            this.listBoxObjects = new System.Windows.Forms.ListBox();
            this.ButtonTexture = new System.Windows.Forms.Button();
            this.TextureFile = new System.Windows.Forms.OpenFileDialog();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.CameraLabelX = new System.Windows.Forms.Label();
            this.CameraLabelZ = new System.Windows.Forms.Label();
            this.CameraLabelY = new System.Windows.Forms.Label();
            this.Instructor = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.TransformBox.SuspendLayout();
            this.TransformTaskControl.SuspendLayout();
            this.TranslateTab.SuspendLayout();
            this.RotateTab.SuspendLayout();
            this.ScaleTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl1
            // 
            this.openGLControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.Location = new System.Drawing.Point(246, 12);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(517, 448);
            this.openGLControl1.TabIndex = 2;
            this.openGLControl1.OpenGLInitialized += new System.EventHandler(this.openGLControl1_OpenGLInitialized);
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.Resized += new System.EventHandler(this.openGLControl1_Resized);
            // 
            // TransformBox
            // 
            this.TransformBox.Controls.Add(this.TransformTaskControl);
            this.TransformBox.Location = new System.Drawing.Point(10, 99);
            this.TransformBox.Name = "TransformBox";
            this.TransformBox.Size = new System.Drawing.Size(219, 122);
            this.TransformBox.TabIndex = 3;
            this.TransformBox.TabStop = false;
            this.TransformBox.Text = "Transform";
            // 
            // TransformTaskControl
            // 
            this.TransformTaskControl.Controls.Add(this.TranslateTab);
            this.TransformTaskControl.Controls.Add(this.RotateTab);
            this.TransformTaskControl.Controls.Add(this.ScaleTab);
            this.TransformTaskControl.ItemSize = new System.Drawing.Size(56, 18);
            this.TransformTaskControl.Location = new System.Drawing.Point(6, 19);
            this.TransformTaskControl.Name = "TransformTaskControl";
            this.TransformTaskControl.Padding = new System.Drawing.Point(15, 3);
            this.TransformTaskControl.SelectedIndex = 0;
            this.TransformTaskControl.Size = new System.Drawing.Size(199, 86);
            this.TransformTaskControl.TabIndex = 4;
            // 
            // TranslateTab
            // 
            this.TranslateTab.Controls.Add(this.TranslateZ);
            this.TranslateTab.Controls.Add(this.TranslateY);
            this.TranslateTab.Controls.Add(this.TranslateX);
            this.TranslateTab.Location = new System.Drawing.Point(4, 22);
            this.TranslateTab.Name = "TranslateTab";
            this.TranslateTab.Padding = new System.Windows.Forms.Padding(3);
            this.TranslateTab.Size = new System.Drawing.Size(191, 60);
            this.TranslateTab.TabIndex = 0;
            this.TranslateTab.Text = "Translate";
            this.TranslateTab.UseVisualStyleBackColor = true;
            // 
            // TranslateZ
            // 
            this.TranslateZ.Location = new System.Drawing.Point(128, 20);
            this.TranslateZ.Name = "TranslateZ";
            this.TranslateZ.Size = new System.Drawing.Size(57, 20);
            this.TranslateZ.TabIndex = 8;
            this.TranslateZ.TextChanged += new System.EventHandler(this.TranslateZ_TextChanged);
            // 
            // TranslateY
            // 
            this.TranslateY.Location = new System.Drawing.Point(67, 20);
            this.TranslateY.Name = "TranslateY";
            this.TranslateY.Size = new System.Drawing.Size(57, 20);
            this.TranslateY.TabIndex = 7;
            this.TranslateY.TextChanged += new System.EventHandler(this.TranslateY_TextChanged);
            // 
            // TranslateX
            // 
            this.TranslateX.Location = new System.Drawing.Point(6, 20);
            this.TranslateX.Name = "TranslateX";
            this.TranslateX.Size = new System.Drawing.Size(57, 20);
            this.TranslateX.TabIndex = 6;
            this.TranslateX.TextChanged += new System.EventHandler(this.TranslateX_TextChanged);
            // 
            // RotateTab
            // 
            this.RotateTab.Controls.Add(this.RotateY);
            this.RotateTab.Controls.Add(this.RotateZ);
            this.RotateTab.Controls.Add(this.RotateX);
            this.RotateTab.Location = new System.Drawing.Point(4, 22);
            this.RotateTab.Name = "RotateTab";
            this.RotateTab.Padding = new System.Windows.Forms.Padding(3);
            this.RotateTab.Size = new System.Drawing.Size(191, 60);
            this.RotateTab.TabIndex = 1;
            this.RotateTab.Text = "Rotate";
            this.RotateTab.UseVisualStyleBackColor = true;
            // 
            // RotateY
            // 
            this.RotateY.Location = new System.Drawing.Point(67, 20);
            this.RotateY.Name = "RotateY";
            this.RotateY.Size = new System.Drawing.Size(57, 20);
            this.RotateY.TabIndex = 12;
            this.RotateY.TextChanged += new System.EventHandler(this.RotateY_TextChanged);
            // 
            // RotateZ
            // 
            this.RotateZ.Location = new System.Drawing.Point(128, 20);
            this.RotateZ.Name = "RotateZ";
            this.RotateZ.Size = new System.Drawing.Size(57, 20);
            this.RotateZ.TabIndex = 11;
            this.RotateZ.TextChanged += new System.EventHandler(this.RotateZ_TextChanged);
            // 
            // RotateX
            // 
            this.RotateX.Location = new System.Drawing.Point(6, 20);
            this.RotateX.Name = "RotateX";
            this.RotateX.Size = new System.Drawing.Size(57, 20);
            this.RotateX.TabIndex = 9;
            this.RotateX.TextChanged += new System.EventHandler(this.RotateX_TextChanged);
            // 
            // ScaleTab
            // 
            this.ScaleTab.Controls.Add(this.ScaleZ);
            this.ScaleTab.Controls.Add(this.ScaleY);
            this.ScaleTab.Controls.Add(this.ScaleX);
            this.ScaleTab.Location = new System.Drawing.Point(4, 22);
            this.ScaleTab.Name = "ScaleTab";
            this.ScaleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScaleTab.Size = new System.Drawing.Size(191, 60);
            this.ScaleTab.TabIndex = 2;
            this.ScaleTab.Text = "Scale";
            this.ScaleTab.UseVisualStyleBackColor = true;
            // 
            // ScaleZ
            // 
            this.ScaleZ.Location = new System.Drawing.Point(128, 20);
            this.ScaleZ.Name = "ScaleZ";
            this.ScaleZ.Size = new System.Drawing.Size(57, 20);
            this.ScaleZ.TabIndex = 11;
            this.ScaleZ.TextChanged += new System.EventHandler(this.ScaleZ_TextChanged);
            // 
            // ScaleY
            // 
            this.ScaleY.Location = new System.Drawing.Point(67, 20);
            this.ScaleY.Name = "ScaleY";
            this.ScaleY.Size = new System.Drawing.Size(57, 20);
            this.ScaleY.TabIndex = 10;
            this.ScaleY.TextChanged += new System.EventHandler(this.ScaleY_TextChanged);
            // 
            // ScaleX
            // 
            this.ScaleX.Location = new System.Drawing.Point(6, 20);
            this.ScaleX.Name = "ScaleX";
            this.ScaleX.Size = new System.Drawing.Size(57, 20);
            this.ScaleX.TabIndex = 9;
            this.ScaleX.TextChanged += new System.EventHandler(this.ScaleX_TextChanged);
            // 
            // CreateCute
            // 
            this.CreateCute.Location = new System.Drawing.Point(10, 12);
            this.CreateCute.Name = "CreateCute";
            this.CreateCute.Size = new System.Drawing.Size(75, 23);
            this.CreateCute.TabIndex = 4;
            this.CreateCute.Text = "Cube";
            this.CreateCute.UseVisualStyleBackColor = true;
            this.CreateCute.Click += new System.EventHandler(this.CreateCube_CLick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Prism";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreatePrism_CLick);
            // 
            // Pyramid
            // 
            this.Pyramid.Location = new System.Drawing.Point(10, 70);
            this.Pyramid.Name = "Pyramid";
            this.Pyramid.Size = new System.Drawing.Size(75, 23);
            this.Pyramid.TabIndex = 6;
            this.Pyramid.Text = "Pyramid";
            this.Pyramid.UseVisualStyleBackColor = true;
            this.Pyramid.Click += new System.EventHandler(this.CreatePyramid_Click);
            // 
            // ButtonColor
            // 
            this.ButtonColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ButtonColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonColor.Location = new System.Drawing.Point(95, 22);
            this.ButtonColor.Name = "ButtonColor";
            this.ButtonColor.Size = new System.Drawing.Size(120, 23);
            this.ButtonColor.TabIndex = 7;
            this.ButtonColor.Text = "Color";
            this.ButtonColor.UseVisualStyleBackColor = false;
            this.ButtonColor.Click += new System.EventHandler(this.ButtonColor_Click);
            // 
            // listBoxObjects
            // 
            this.listBoxObjects.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listBoxObjects.DisplayMember = "haha";
            this.listBoxObjects.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBoxObjects.FormattingEnabled = true;
            this.listBoxObjects.Location = new System.Drawing.Point(10, 227);
            this.listBoxObjects.Name = "listBoxObjects";
            this.listBoxObjects.Size = new System.Drawing.Size(230, 212);
            this.listBoxObjects.TabIndex = 8;
            this.listBoxObjects.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listObject_MouseClick);
            // 
            // ButtonTexture
            // 
            this.ButtonTexture.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ButtonTexture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonTexture.ForeColor = System.Drawing.Color.Black;
            this.ButtonTexture.Location = new System.Drawing.Point(95, 51);
            this.ButtonTexture.Name = "ButtonTexture";
            this.ButtonTexture.Size = new System.Drawing.Size(120, 23);
            this.ButtonTexture.TabIndex = 11;
            this.ButtonTexture.Text = "Texture";
            this.ButtonTexture.UseVisualStyleBackColor = false;
            this.ButtonTexture.Click += new System.EventHandler(this.ButtomTexture_Click);
            // 
            // TextureFile
            // 
            this.TextureFile.FileName = "TextureFile";
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Location = new System.Drawing.Point(165, 445);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(75, 23);
            this.ButtonRemove.TabIndex = 12;
            this.ButtonRemove.Text = "Remove";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // CameraLabelX
            // 
            this.CameraLabelX.AutoSize = true;
            this.CameraLabelX.BackColor = System.Drawing.SystemColors.WindowText;
            this.CameraLabelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraLabelX.ForeColor = System.Drawing.Color.Red;
            this.CameraLabelX.Location = new System.Drawing.Point(716, 391);
            this.CameraLabelX.Name = "CameraLabelX";
            this.CameraLabelX.Size = new System.Drawing.Size(32, 16);
            this.CameraLabelX.TabIndex = 13;
            this.CameraLabelX.Text = "sss";
            // 
            // CameraLabelZ
            // 
            this.CameraLabelZ.AutoSize = true;
            this.CameraLabelZ.BackColor = System.Drawing.SystemColors.WindowText;
            this.CameraLabelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraLabelZ.ForeColor = System.Drawing.Color.Blue;
            this.CameraLabelZ.Location = new System.Drawing.Point(716, 423);
            this.CameraLabelZ.Name = "CameraLabelZ";
            this.CameraLabelZ.Size = new System.Drawing.Size(32, 16);
            this.CameraLabelZ.TabIndex = 14;
            this.CameraLabelZ.Text = "sss";
            // 
            // CameraLabelY
            // 
            this.CameraLabelY.AutoSize = true;
            this.CameraLabelY.BackColor = System.Drawing.SystemColors.WindowText;
            this.CameraLabelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraLabelY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CameraLabelY.Location = new System.Drawing.Point(716, 407);
            this.CameraLabelY.Name = "CameraLabelY";
            this.CameraLabelY.Size = new System.Drawing.Size(32, 16);
            this.CameraLabelY.TabIndex = 15;
            this.CameraLabelY.Text = "sss";
            // 
            // Instructor
            // 
            this.Instructor.AutoSize = true;
            this.Instructor.Location = new System.Drawing.Point(17, 450);
            this.Instructor.Name = "Instructor";
            this.Instructor.Size = new System.Drawing.Size(51, 13);
            this.Instructor.TabIndex = 18;
            this.Instructor.Text = "Instructor";
            this.Instructor.Click += new System.EventHandler(this.Instructor_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(87, 445);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 19;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(689, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.WindowText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(688, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.WindowText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(689, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Z:";
            // 
            // ObjectBuiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 472);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.Instructor);
            this.Controls.Add(this.CameraLabelY);
            this.Controls.Add(this.CameraLabelZ);
            this.Controls.Add(this.CameraLabelX);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.ButtonTexture);
            this.Controls.Add(this.listBoxObjects);
            this.Controls.Add(this.ButtonColor);
            this.Controls.Add(this.Pyramid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreateCute);
            this.Controls.Add(this.TransformBox);
            this.Controls.Add(this.openGLControl1);
            this.Name = "ObjectBuiler";
            this.Text = "ObjectBuiler - 18120353";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.TransformBox.ResumeLayout(false);
            this.TransformTaskControl.ResumeLayout(false);
            this.TranslateTab.ResumeLayout(false);
            this.TranslateTab.PerformLayout();
            this.RotateTab.ResumeLayout(false);
            this.RotateTab.PerformLayout();
            this.ScaleTab.ResumeLayout(false);
            this.ScaleTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.GroupBox TransformBox;
        private System.Windows.Forms.TabControl TransformTaskControl;
        private System.Windows.Forms.TabPage TranslateTab;
        private System.Windows.Forms.TabPage RotateTab;
        private System.Windows.Forms.TabPage ScaleTab;
        private System.Windows.Forms.Button CreateCute;
        private System.Windows.Forms.TextBox TranslateZ;
        private System.Windows.Forms.TextBox TranslateY;
        private System.Windows.Forms.TextBox TranslateX;
        private System.Windows.Forms.TextBox RotateZ;
        private System.Windows.Forms.TextBox RotateX;
        private System.Windows.Forms.TextBox ScaleZ;
        private System.Windows.Forms.TextBox ScaleY;
        private System.Windows.Forms.TextBox ScaleX;
        private System.Windows.Forms.TextBox RotateY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Pyramid;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ButtonColor;
        private System.Windows.Forms.ListBox listBoxObjects;
        private System.Windows.Forms.Button ButtonTexture;
        private System.Windows.Forms.OpenFileDialog TextureFile;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Label CameraLabelX;
        private System.Windows.Forms.Label CameraLabelZ;
        private System.Windows.Forms.Label CameraLabelY;
        private System.Windows.Forms.Label Instructor;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


