using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RibbonReportDesigner {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			DevExpress.UserSkins.BonusSkins.Register();
			DevExpress.Skins.SkinManager.EnableFormSkins();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = false;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Black";
            MainForm mainForm = new MainForm();
            mainForm.CreateNewReport();
			Application.Run(mainForm);
		}
	}
}
