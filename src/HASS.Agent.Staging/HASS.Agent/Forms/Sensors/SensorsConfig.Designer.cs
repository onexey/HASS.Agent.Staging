﻿
using HASS.Agent.Forms.Service;
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Sensors
{
    partial class SensorsConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorsConfig));
            this.BtnRemove = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnModify = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.LvSensors = new System.Windows.Forms.ListView();
            this.ClmId = new System.Windows.Forms.ColumnHeader();
            this.ClmName = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmType = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmRefresh = new System.Windows.Forms.ColumnHeader("refresh_16_header");
            this.ClmValue = new System.Windows.Forms.ColumnHeader();
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.LblRefresh = new System.Windows.Forms.Label();
            this.PbRefresh = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRemove
            // 
            this.BtnRemove.AccessibleDescription = "Removes the selected sensor from the list.";
            this.BtnRemove.AccessibleName = "Remove";
            this.BtnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Location = new System.Drawing.Point(253, 516);
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
            this.BtnRemove.Text = Languages.SensorsConfig_BtnRemove;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
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
            this.BtnModify.Location = new System.Drawing.Point(456, 516);
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
            this.BtnModify.Text = Languages.SensorsConfig_BtnModify;
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
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
            this.BtnAdd.Location = new System.Drawing.Point(659, 516);
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
            this.BtnAdd.Text = Languages.SensorsConfig_BtnAdd;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            this.BtnStore.Location = new System.Drawing.Point(0, 557);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(856, 47);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 3;
            this.BtnStore.Text = Languages.SensorsConfig_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // LvSensors
            // 
            this.LvSensors.AccessibleDescription = "Contains the currently configured sensors.";
            this.LvSensors.AccessibleName = "Stored sensors";
            this.LvSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.LvSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvSensors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvSensors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmId,
            this.ClmName,
            this.ClmType,
            this.ClmRefresh,
            this.ClmValue,
            this.ClmEmpty});
            this.LvSensors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvSensors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvSensors.FullRowSelect = true;
            this.LvSensors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvSensors.HideSelection = true;
            this.LvSensors.LargeImageList = this.ImgLv;
            this.LvSensors.Location = new System.Drawing.Point(0, 2);
            this.LvSensors.Name = "LvSensors";
            this.LvSensors.OwnerDraw = true;
            this.LvSensors.Size = new System.Drawing.Size(856, 508);
            this.LvSensors.SmallImageList = this.ImgLv;
            this.LvSensors.TabIndex = 27;
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
            this.ClmName.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsConfig_ClmName;
            this.ClmName.Width = 320;
            // 
            // ClmType
            // 
            this.ClmType.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsConfig_ClmType;
            this.ClmType.Width = 300;
            // 
            // ClmRefresh
            // 
            this.ClmRefresh.Text = Languages.SensorsConfig_LblRefresh;
            // 
            // ClmValue
            // 
            this.ClmValue.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsConfig_ClmValue;
            this.ClmValue.Width = 150;
            // 
            // ClmEmpty
            // 
            this.ClmEmpty.Text = "filler column";
            this.ClmEmpty.Width = 10000;
            // 
            // ImgLv
            // 
            this.ImgLv.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ImgLv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLv.ImageStream")));
            this.ImgLv.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgLv.Images.SetKeyName(0, "refresh_16_header");
            // 
            // LblRefresh
            // 
            this.LblRefresh.AccessibleDescription = "Refresh column description.";
            this.LblRefresh.AccessibleName = "Refresh info";
            this.LblRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblRefresh.AutoSize = true;
            this.LblRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRefresh.Location = new System.Drawing.Point(22, 527);
            this.LblRefresh.Name = "LblRefresh";
            this.LblRefresh.Size = new System.Drawing.Size(43, 15);
            this.LblRefresh.TabIndex = 41;
            this.LblRefresh.Text = Languages.SensorsConfig_LblRefresh;
            // 
            // PbRefresh
            // 
            this.PbRefresh.AccessibleDescription = "Refresh icon image, as shown in the header of the \'refresh\' column.";
            this.PbRefresh.AccessibleName = "Refresh icon";
            this.PbRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbRefresh.Image = global::HASS.Agent.Properties.Resources.refresh_16;
            this.PbRefresh.Location = new System.Drawing.Point(0, 526);
            this.PbRefresh.Name = "PbRefresh";
            this.PbRefresh.Size = new System.Drawing.Size(16, 16);
            this.PbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbRefresh.TabIndex = 40;
            this.PbRefresh.TabStop = false;
            // 
            // SensorsConfig
            // 
            this.AccessibleDescription = "Contains all currently stored sensors, and the ability the configure them.";
            this.AccessibleName = "Sensors config";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(856, 604);
            this.Controls.Add(this.LblRefresh);
            this.Controls.Add(this.PbRefresh);
            this.Controls.Add(this.LvSensors);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnStore);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.MinimumSize = new System.Drawing.Size(657, 598);
            this.Name = "SensorsConfig";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.SensorsConfig_Title;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SensorsConfig_FormClosing);
            this.Load += new System.EventHandler(this.SensorsConfig_Load);
            this.ResizeBegin += new System.EventHandler(this.SensorsConfig_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.SensorsConfig_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SensorsConfig_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.SensorsConfig_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.PbRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnRemove;
        private Syncfusion.WinForms.Controls.SfButton BtnModify;
        private Syncfusion.WinForms.Controls.SfButton BtnAdd;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private ListView LvSensors;
        private ColumnHeader ClmId;
        private ColumnHeader ClmName;
        private ColumnHeader ClmType;
        private ColumnHeader ClmRefresh;
        private ColumnHeader ClmEmpty;
        private ImageList ImgLv;
        private Label LblRefresh;
        private PictureBox PbRefresh;
        private ColumnHeader ClmValue;
    }
}

