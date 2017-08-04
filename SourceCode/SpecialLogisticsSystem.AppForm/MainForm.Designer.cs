namespace SpecialLogisticsSystem.AppForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barAndDockingController = new DevExpress.XtraBars.BarAndDockingController();
            this.biSupperBill = new DevExpress.XtraBars.BarButtonItem();
            this.lblErrorTip = new DevExpress.XtraBars.BarStaticItem();
            this.biQuit = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection32 = new DevExpress.Utils.SharedImageCollection();
            this.rpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgMain = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.biHideWhenMinimized = new DevExpress.XtraBars.BarCheckItem();
            this.biOpenSoftware = new DevExpress.XtraBars.BarButtonItem();
            this.biExit = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.Controller = this.barAndDockingController;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.biSupperBill,
            this.lblErrorTip,
            this.biQuit});
            this.ribbon.LargeImages = this.imageCollection32;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbon.MaxItemId = 98;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpMain});
            this.ribbon.Size = new System.Drawing.Size(1378, 148);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barAndDockingController
            // 
            this.barAndDockingController.AppearancesRibbon.Item.Options.UseTextOptions = true;
            this.barAndDockingController.AppearancesRibbon.Item.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.barAndDockingController.LookAndFeel.SkinName = "Black";
            this.barAndDockingController.PaintStyleName = "Skin";
            this.barAndDockingController.PropertiesBar.AllowLinkLighting = false;
            // 
            // biSupperBill
            // 
            this.biSupperBill.Caption = "托运单";
            this.biSupperBill.Id = 70;
            this.biSupperBill.LargeImageIndex = 13;
            this.biSupperBill.Name = "biSupperBill";
            this.biSupperBill.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSupperBill_ItemClick);
            // 
            // lblErrorTip
            // 
            this.lblErrorTip.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblErrorTip.Caption = "   ";
            this.lblErrorTip.Id = 78;
            this.lblErrorTip.Name = "lblErrorTip";
            this.lblErrorTip.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // biQuit
            // 
            this.biQuit.Caption = "Quit";
            this.biQuit.Id = 81;
            this.biQuit.LargeImageIndex = 18;
            this.biQuit.Name = "biQuit";
            this.biQuit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biQuit_ItemClick);
            // 
            // imageCollection32
            // 
            // 
            // 
            // 
            this.imageCollection32.ImageSource.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection32.ImageSource.ImageStream")));
            // 
            // rpMain
            // 
            this.rpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgMain});
            this.rpMain.Name = "rpMain";
            this.rpMain.Text = "Main";
            // 
            // rpgMain
            // 
            this.rpgMain.AllowTextClipping = false;
            this.rpgMain.ItemLinks.Add(this.biSupperBill);
            this.rpgMain.ItemLinks.Add(this.biQuit);
            this.rpgMain.Name = "rpgMain";
            this.rpgMain.Text = "Supper Bill";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblErrorTip);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 461);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1378, 23);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager.Controller = this.barAndDockingController;
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Black";
            // 
            // biHideWhenMinimized
            // 
            this.biHideWhenMinimized.Caption = "Hide When Minimized";
            this.biHideWhenMinimized.Id = 5;
            this.biHideWhenMinimized.Name = "biHideWhenMinimized";
            // 
            // biOpenSoftware
            // 
            this.biOpenSoftware.Caption = "Open (Ctrl+Shift+Z)";
            this.biOpenSoftware.Id = 4;
            this.biOpenSoftware.Name = "biOpenSoftware";
            // 
            // biExit
            // 
            this.biExit.Caption = "离开";
            this.biExit.Id = 6;
            this.biExit.Name = "biExit";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biOpenSoftware,
            this.biHideWhenMinimized,
            this.biExit});
            this.barManager1.MaxItemId = 7;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1378, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 484);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1378, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 484);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1378, 0);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 484);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 484);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "报表设计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMain;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController;
        private DevExpress.Utils.SharedImageCollection imageCollection32;
        private DevExpress.XtraBars.BarButtonItem biSupperBill;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarCheckItem biHideWhenMinimized;
        private DevExpress.XtraBars.BarButtonItem biOpenSoftware;
        private DevExpress.XtraBars.BarButtonItem biExit;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarStaticItem lblErrorTip;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.BarButtonItem biQuit;
    }
}