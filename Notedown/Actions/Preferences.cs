using System;
using Eto.Forms;
using Eto.Drawing;

namespace Notedown.Actions
{
	public class Preferences : ButtonAction
	{
		public static string ActionID = "preferences";
		
		public Preferences()
		{
			this.ID = ActionID;
			this.MenuText = "Preferences";
			this.ToolBarText = "Preferences";
            this.Icon = new Icon(null, "Notedown.Resources.toolbar-preferences.ico");
		}
		
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
            
            // open preferences
            var dialog = new Dialogs.Preferences();
            dialog.ShowDialog(Application.Instance.MainForm);
            if (dialog.DialogResult == DialogResult.Ok)
            {
                Notedown.Preferences.Folder = dialog.TextBoxFolder.Text;
                Notedown.Preferences.Save();
                ((MainForm)Application.Instance.MainForm).OnLoad(null);
            }
		}
	}
}

