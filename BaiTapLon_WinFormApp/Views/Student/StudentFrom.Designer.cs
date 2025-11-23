using System.Windows.Forms;

namespace EnglishCenterManagement.UI.Views
{
    partial class StudentFrom
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentFrom));
            panelHeader = new Panel();
            guna2TextBoxHeader = new Guna.UI2.WinForms.Guna2TextBox();
            pictureBoxHeader = new PictureBox();
            flowActions = new FlowLayoutPanel();
            flowRightActions = new FlowLayoutPanel();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            panelControl = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeader).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(guna2TextBoxHeader);
            panelHeader.Controls.Add(pictureBoxHeader);
            panelHeader.Controls.Add(flowActions);
            panelHeader.Controls.Add(flowRightActions);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1437, 100);
            panelHeader.TabIndex = 0;
            // 
            // guna2TextBoxHeader
            // 
            guna2TextBoxHeader.BorderRadius = 10;
            guna2TextBoxHeader.CustomizableEdges = customizableEdges1;
            guna2TextBoxHeader.DefaultText = "";
            guna2TextBoxHeader.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBoxHeader.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBoxHeader.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBoxHeader.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBoxHeader.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBoxHeader.Font = new Font("Segoe UI", 9F);
            guna2TextBoxHeader.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBoxHeader.Location = new Point(176, 12);
            guna2TextBoxHeader.Margin = new Padding(3, 4, 3, 4);
            guna2TextBoxHeader.Name = "guna2TextBoxHeader";
            guna2TextBoxHeader.PlaceholderText = "Search";
            guna2TextBoxHeader.SelectedText = "";
            guna2TextBoxHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBoxHeader.Size = new Size(286, 41);
            guna2TextBoxHeader.TabIndex = 4;
            // 
            // pictureBoxHeader
            // 
            pictureBoxHeader.Image = (Image)resources.GetObject("pictureBoxHeader.Image");
            pictureBoxHeader.Location = new Point(0, 12);
            pictureBoxHeader.Name = "pictureBoxHeader";
            pictureBoxHeader.Size = new Size(155, 50);
            pictureBoxHeader.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHeader.TabIndex = 0;
            pictureBoxHeader.TabStop = false;
            // 
            // flowActions
            // 
            flowActions.Anchor = AnchorStyles.None;
            flowActions.AutoSize = true;
            flowActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowActions.Location = new Point(1437, 100);
            flowActions.Name = "flowActions";
            flowActions.Size = new Size(0, 0);
            flowActions.TabIndex = 2;
            flowActions.WrapContents = false;
            // 
            // flowRightActions
            // 
            flowRightActions.AutoSize = true;
            flowRightActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowRightActions.Dock = DockStyle.Right;
            flowRightActions.Location = new Point(1437, 0);
            flowRightActions.Margin = new Padding(0);
            flowRightActions.Name = "flowRightActions";
            flowRightActions.Size = new Size(0, 100);
            flowRightActions.TabIndex = 3;
            flowRightActions.WrapContents = false;
            // 
            // panelControl
            // 
            panelControl.Location = new Point(316, 106);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(1109, 652);
            panelControl.TabIndex = 1;
            // 
            // StudentFrom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 770);
            Controls.Add(panelControl);
            Controls.Add(panelHeader);
            Name = "StudentFrom";
            Text = "StudentFrom";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pictureBoxHeader;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private FlowLayoutPanel flowActions;
        private FlowLayoutPanel flowRightActions;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxHeader;
        private Panel panelControl;
    }
}