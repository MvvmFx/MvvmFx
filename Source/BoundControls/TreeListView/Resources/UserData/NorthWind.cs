using Gizmox.WebGUI.Forms;

namespace TreeListView.Resources.UserData {
    
    
        public partial class NorthWind {
                public NorthWind(string XMLDataFile) : base()
        {
            if (XMLDataFile.Contains(@"~")) {
                this.ReadXml(VWGContext.Current.Server.MapPath(XMLDataFile));
            }
            else {
                this.ReadXml(XMLDataFile);
            }
        }

        public void FillWithNorthwindXML(string XMLDataFile)
        {
            if (XMLDataFile.Contains(@"~"))
            {
                this.ReadXml(VWGContext.Current.Server.MapPath(XMLDataFile));
            }
            else
            {
                this.ReadXml(XMLDataFile);
            }
        }
    }
}
