﻿using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Service
{
    partial class ServiceSensors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceSensors));
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.LvSensors = new System.Windows.Forms.ListView();
            this.ClmId = new System.Windows.Forms.ColumnHeader();
            this.ClmName = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmType = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmRefresh = new System.Windows.Forms.ColumnHeader("refresh_16_header");
            this.ClmPadding = new System.Windows.Forms.ColumnHeader();
            this.LblRefresh = new System.Windows.Forms.Label();
            this.PbRefresh = new System.Windows.Forms.PictureBox();
            this.BtnRemove = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnModify = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStored = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgLv
            // 
            this.ImgLv.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ImgLv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLv.ImageStream")));
            this.ImgLv.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgLv.Images.SetKeyName(0, "refresh_16_header");
            // 
            // LvSensors
            // 
            this.LvSensors.AccessibleDescription = "Contains the service\'s currently configured sensors.";
            this.LvSensors.AccessibleName = "Stored sensors";
            this.LvSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.LvSensors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvSensors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmId,
            this.ClmName,
            this.ClmType,
            this.ClmRefresh,
            this.ClmPadding});
            this.LvSensors.Dock = System.Windows.Forms.DockStyle.Top;
            this.LvSensors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvSensors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvSensors.FullRowSelect = true;
            this.LvSensors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvSensors.HideSelection = true;
            this.LvSensors.LargeImageList = this.ImgLv;
            this.LvSensors.Location = new System.Drawing.Point(0, 0);
            this.LvSensors.Name = "LvSensors";
            this.LvSensors.OwnerDraw = true;
            this.LvSensors.Size = new System.Drawing.Size(903, 490);
            this.LvSensors.SmallImageList = this.ImgLv;
            this.LvSensors.TabIndex = 45;
            this.LvSensors.UseCompatibleStateImageBehavior = false;
            this.LvSensors.View = System.Windows.Forms.View.Details;
            this.LvSensors.DoubleClick += new System.EventHandler(this.LvSensors_DoubleClick);
            // 
            // ClmId
            // 
            this.ClmId.Text = "id";
            this.ClmId.Width = 0;
            // 
            // ClmName
            // 
            this.ClmName.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceSensors_ClmName;
            this.ClmName.Width = 400;
            // 
            // ClmType
            // 
            this.ClmType.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceSensors_ClmType;
            this.ClmType.Width = 350;
            // 
            // ClmRefresh
            // 
            this.ClmRefresh.Text = Languages.ServiceSensors_LblRefresh;
            // 
            // ClmPadding
            // 
            this.ClmPadding.Text = "filler column";
            this.ClmPadding.Width = 10000;
            // 
            // LblRefresh
            // 
            this.LblRefresh.AccessibleDescription = "Refresh column description.";
            this.LblRefresh.AccessibleName = "Refresh info";
            this.LblRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRefresh.AutoSize = true;
            this.LblRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRefresh.Location = new System.Drawing.Point(726, 499);
            this.LblRefresh.Name = "LblRefresh";
            this.LblRefresh.Size = new System.Drawing.Size(43, 15);
            this.LblRefresh.TabIndex = 47;
            this.LblRefresh.Text = Languages.ServiceSensors_LblRefresh;
            // 
            // PbRefresh
            // 
            this.PbRefresh.AccessibleDescription = "Refresh icon image, as shown in the header of the \'refresh\' column.";
            this.PbRefresh.AccessibleName = "Refresh icon";
            this.PbRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbRefresh.Image = global::HASS.Agent.Properties.Resources.refresh_16;
            this.PbRefresh.Location = new System.Drawing.Point(704, 498);
            this.PbRefresh.Name = "PbRefresh";
            this.PbRefresh.Size = new System.Drawing.Size(16, 16);
            this.PbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbRefresh.TabIndex = 46;
            this.PbRefresh.TabStop = false;
            // 
            // BtnRemove
            // 
            this.BtnRemove.AccessibleDescription = "Removes the selected sensor from the list.";
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
            this.BtnRemove.Text = Languages.ServiceSensors_BtnRemove;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.AccessibleDescription = "Opens the \'add new sensor\' window.";
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
            this.BtnAdd.Text = Languages.ServiceSensors_BtnAdd;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.AccessibleDescription = "Modifies the currently selected sensor.";
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
            this.BtnModify.Text = Languages.ServiceSensors_BtnModify;
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleDescription = "Stores the current list of sensors, and sends them to the service.";
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
            this.BtnStore.Text = Languages.ServiceSensors_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // LblStored
            // 
            this.LblStored.AccessibleDescription = "Briefly shows a \'succesfully stored\' message.";
            this.LblStored.AccessibleName = "Sensors stored info";
            this.LblStored.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStored.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblStored.Location = new System.Drawing.Point(206, 523);
            this.LblStored.Name = "LblStored";
            this.LblStored.Size = new System.Drawing.Size(289, 35);
            this.LblStored.TabIndex = 100;
            this.LblStored.Text = Languages.ServiceSensors_LblStored;
            this.LblStored.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblStored.Visible = false;
            // 
            // ServiceSensors
            // 
            this.AccessibleDescription = "Panel containing the service sensors.";
            this.AccessibleName = "Sensors";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblStored);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.LvSensors);
            this.Controls.Add(this.LblRefresh);
            this.Controls.Add(this.PbRefresh);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnModify);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServiceSensors";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.ServiceSensors_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Sensors_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.PbRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageList ImgLv;
        private ListView LvSensors;
        private ColumnHeader ClmId;
        private ColumnHeader ClmName;
        private ColumnHeader ClmType;
        private ColumnHeader ClmRefresh;
        private ColumnHeader ClmPadding;
        private Label LblRefresh;
        private PictureBox PbRefresh;
        private Syncfusion.WinForms.Controls.SfButton BtnRemove;
        private Syncfusion.WinForms.Controls.SfButton BtnAdd;
        private Syncfusion.WinForms.Controls.SfButton BtnModify;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private Label LblStored;
    }
}
