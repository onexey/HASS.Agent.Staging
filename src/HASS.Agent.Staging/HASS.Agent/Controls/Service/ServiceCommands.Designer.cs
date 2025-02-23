﻿using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Service
{
    partial class ServiceCommands
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceCommands));
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.LblLowIntegrity = new System.Windows.Forms.Label();
            this.PbLowIntegrity = new System.Windows.Forms.PictureBox();
            this.LvCommands = new System.Windows.Forms.ListView();
            this.ClmId = new System.Windows.Forms.ColumnHeader();
            this.ClmName = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmType = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmLowIntegrity = new System.Windows.Forms.ColumnHeader("shield_16_header");
            this.ClmPadding = new System.Windows.Forms.ColumnHeader();
            this.BtnRemove = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnModify = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStored = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbLowIntegrity)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgLv
            // 
            this.ImgLv.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ImgLv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLv.ImageStream")));
            this.ImgLv.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgLv.Images.SetKeyName(0, "shield_16_header");
            // 
            // LblLowIntegrity
            // 
            this.LblLowIntegrity.AccessibleDescription = "Low integrity column description.";
            this.LblLowIntegrity.AccessibleName = "Low integrity info";
            this.LblLowIntegrity.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblLowIntegrity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblLowIntegrity.AutoSize = true;
            this.LblLowIntegrity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLowIntegrity.Location = new System.Drawing.Point(726, 499);
            this.LblLowIntegrity.Name = "LblLowIntegrity";
            this.LblLowIntegrity.Size = new System.Drawing.Size(73, 15);
            this.LblLowIntegrity.TabIndex = 51;
            this.LblLowIntegrity.Text = Languages.ServiceCommands_LblLowIntegrity;
            // 
            // PbLowIntegrity
            // 
            this.PbLowIntegrity.AccessibleDescription = "Low integrity icon image, as shown in the header of the \'low integrity\' column.";
            this.PbLowIntegrity.AccessibleName = "Low integrity icon";
            this.PbLowIntegrity.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLowIntegrity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbLowIntegrity.Image = global::HASS.Agent.Properties.Resources.shield_16;
            this.PbLowIntegrity.Location = new System.Drawing.Point(704, 498);
            this.PbLowIntegrity.Name = "PbLowIntegrity";
            this.PbLowIntegrity.Size = new System.Drawing.Size(16, 16);
            this.PbLowIntegrity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLowIntegrity.TabIndex = 50;
            this.PbLowIntegrity.TabStop = false;
            // 
            // LvCommands
            // 
            this.LvCommands.AccessibleDescription = "Contains the service\'s currently configured commands.";
            this.LvCommands.AccessibleName = "Stored commands";
            this.LvCommands.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.LvCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmId,
            this.ClmName,
            this.ClmType,
            this.ClmLowIntegrity,
            this.ClmPadding});
            this.LvCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.LvCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvCommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvCommands.FullRowSelect = true;
            this.LvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvCommands.HideSelection = true;
            this.LvCommands.LargeImageList = this.ImgLv;
            this.LvCommands.Location = new System.Drawing.Point(0, 0);
            this.LvCommands.Name = "LvCommands";
            this.LvCommands.OwnerDraw = true;
            this.LvCommands.Size = new System.Drawing.Size(903, 490);
            this.LvCommands.SmallImageList = this.ImgLv;
            this.LvCommands.TabIndex = 49;
            this.LvCommands.UseCompatibleStateImageBehavior = false;
            this.LvCommands.View = System.Windows.Forms.View.Details;
            this.LvCommands.DoubleClick += new System.EventHandler(this.LvCommands_DoubleClick);
            // 
            // ClmId
            // 
            this.ClmId.Text = "id";
            this.ClmId.Width = 0;
            // 
            // ClmName
            // 
            this.ClmName.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceCommands_ClmName;
            this.ClmName.Width = 400;
            // 
            // ClmType
            // 
            this.ClmType.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceCommands_ClmType;
            this.ClmType.Width = 350;
            // 
            // ClmLowIntegrity
            // 
            this.ClmLowIntegrity.Text = Languages.ServiceCommands_LblLowIntegrity;
            // 
            // ClmPadding
            // 
            this.ClmPadding.Text = "filler column";
            this.ClmPadding.Width = 10000;
            // 
            // BtnRemove
            // 
            this.BtnRemove.AccessibleDescription = "Removes the selected command from the list.";
            this.BtnRemove.AccessibleName = "Remove";
            this.BtnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Location = new System.Drawing.Point(3, 523);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(197, 35);
            this.BtnRemove.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRemove.TabIndex = 2;
            this.BtnRemove.Text = Languages.ServiceCommands_BtnRemove;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.AccessibleDescription = "Modifies the currently selected command.";
            this.BtnModify.AccessibleName = "Modify";
            this.BtnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Location = new System.Drawing.Point(501, 523);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(197, 35);
            this.BtnModify.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnModify.TabIndex = 1;
            this.BtnModify.Text = Languages.ServiceCommands_BtnModify;
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.AccessibleDescription = "Opens the \'add new command\' window.";
            this.BtnAdd.AccessibleName = "Add new";
            this.BtnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Location = new System.Drawing.Point(704, 523);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(197, 35);
            this.BtnAdd.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = Languages.ServiceCommands_BtnAdd;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleDescription = "Stores the current list of commands, and sends them to the service.";
            this.BtnStore.AccessibleName = "Store";
            this.BtnStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 575);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(903, 47);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 3;
            this.BtnStore.Text = Languages.ServiceCommands_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // LblStored
            // 
            this.LblStored.AccessibleDescription = "Briefly shows a \'succesfully stored\' message.";
            this.LblStored.AccessibleName = "Commands stored info";
            this.LblStored.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStored.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblStored.Location = new System.Drawing.Point(206, 523);
            this.LblStored.Name = "LblStored";
            this.LblStored.Size = new System.Drawing.Size(289, 35);
            this.LblStored.TabIndex = 99;
            this.LblStored.Text = Languages.ServiceCommands_LblStored;
            this.LblStored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblStored.Visible = false;
            // 
            // ServiceCommands
            // 
            this.AccessibleDescription = "Panel containing the service commands.";
            this.AccessibleName = "Commands";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblStored);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.LblLowIntegrity);
            this.Controls.Add(this.PbLowIntegrity);
            this.Controls.Add(this.LvCommands);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnAdd);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServiceCommands";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.ServiceCommands_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Commands_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.PbLowIntegrity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageList ImgLv;
        private Label LblLowIntegrity;
        private PictureBox PbLowIntegrity;
        private ListView LvCommands;
        private ColumnHeader ClmId;
        private ColumnHeader ClmName;
        private ColumnHeader ClmType;
        private ColumnHeader ClmLowIntegrity;
        private ColumnHeader ClmPadding;
        private Syncfusion.WinForms.Controls.SfButton BtnRemove;
        private Syncfusion.WinForms.Controls.SfButton BtnModify;
        private Syncfusion.WinForms.Controls.SfButton BtnAdd;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private Label LblStored;
    }
}
