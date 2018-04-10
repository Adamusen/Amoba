namespace Amoba
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.újJátékToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.játékVsAIToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.pveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pvpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mentésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betöltésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.kilépésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nézetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alapZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.origoKijelzéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.határkeretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.nézetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.újJátékToolStripMenuItem,
            this.játékVsAIToolStripMenuItem,
            this.pveToolStripMenuItem,
            this.pvpToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mentésToolStripMenuItem,
            this.betöltésToolStripMenuItem,
            this.toolStripMenuItem3,
            this.kilépésToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // újJátékToolStripMenuItem
            // 
            this.újJátékToolStripMenuItem.Name = "újJátékToolStripMenuItem";
            this.újJátékToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.újJátékToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.újJátékToolStripMenuItem.Text = "Új játék";
            this.újJátékToolStripMenuItem.Click += new System.EventHandler(this.újJátékToolStripMenuItem_Click);
            // 
            // játékVsAIToolStripMenuItem
            // 
            this.játékVsAIToolStripMenuItem.Name = "játékVsAIToolStripMenuItem";
            this.játékVsAIToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
            // 
            // pveToolStripMenuItem
            // 
            this.pveToolStripMenuItem.Enabled = false;
            this.pveToolStripMenuItem.Name = "pveToolStripMenuItem";
            this.pveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pveToolStripMenuItem.Text = "Gép be";
            this.pveToolStripMenuItem.Click += new System.EventHandler(this.pveToolStripMenuItem_Click);
            // 
            // pvpToolStripMenuItem
            // 
            this.pvpToolStripMenuItem.Name = "pvpToolStripMenuItem";
            this.pvpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pvpToolStripMenuItem.Text = "Gép ki";
            this.pvpToolStripMenuItem.Click += new System.EventHandler(this.pvpToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mentésToolStripMenuItem
            // 
            this.mentésToolStripMenuItem.Name = "mentésToolStripMenuItem";
            this.mentésToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mentésToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mentésToolStripMenuItem.Text = "Mentés";
            this.mentésToolStripMenuItem.Click += new System.EventHandler(this.mentésToolStripMenuItem_Click);
            // 
            // betöltésToolStripMenuItem
            // 
            this.betöltésToolStripMenuItem.Name = "betöltésToolStripMenuItem";
            this.betöltésToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.betöltésToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.betöltésToolStripMenuItem.Text = "Betöltés";
            this.betöltésToolStripMenuItem.Click += new System.EventHandler(this.betöltésToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // kilépésToolStripMenuItem
            // 
            this.kilépésToolStripMenuItem.Name = "kilépésToolStripMenuItem";
            this.kilépésToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kilépésToolStripMenuItem.Text = "Kilépés";
            this.kilépésToolStripMenuItem.Click += new System.EventHandler(this.kilépésToolStripMenuItem_Click);
            // 
            // nézetToolStripMenuItem
            // 
            this.nézetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.alapZoomToolStripMenuItem,
            this.toolStripMenuItem2,
            this.origoKijelzéseToolStripMenuItem,
            this.határkeretToolStripMenuItem});
            this.nézetToolStripMenuItem.Name = "nézetToolStripMenuItem";
            this.nézetToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.nézetToolStripMenuItem.Text = "Nézet";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.zoomInToolStripMenuItem.Text = "Nagyítás";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.zoomOutToolStripMenuItem.Text = "Kicsinyítés";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // alapZoomToolStripMenuItem
            // 
            this.alapZoomToolStripMenuItem.Name = "alapZoomToolStripMenuItem";
            this.alapZoomToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.alapZoomToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.alapZoomToolStripMenuItem.Text = "Alap zoom";
            this.alapZoomToolStripMenuItem.Click += new System.EventHandler(this.alapZoomToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // origoKijelzéseToolStripMenuItem
            // 
            this.origoKijelzéseToolStripMenuItem.Name = "origoKijelzéseToolStripMenuItem";
            this.origoKijelzéseToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.origoKijelzéseToolStripMenuItem.Text = "Origo kijelzése";
            this.origoKijelzéseToolStripMenuItem.Click += new System.EventHandler(this.origoKijelzéseToolStripMenuItem_Click);
            // 
            // határkeretToolStripMenuItem
            // 
            this.határkeretToolStripMenuItem.Name = "határkeretToolStripMenuItem";
            this.határkeretToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.határkeretToolStripMenuItem.Text = "Határkeret";
            this.határkeretToolStripMenuItem.Click += new System.EventHandler(this.határkeretToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem újJátékToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nézetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alapZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator játékVsAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pvpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mentésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem betöltésToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem origoKijelzéseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem határkeretToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;

    }
}

