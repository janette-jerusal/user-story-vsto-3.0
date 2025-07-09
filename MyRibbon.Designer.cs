namespace UserStorySimilarityAddIn
{
    partial class MyRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        private RibbonTab tab;
        private RibbonGroup group;
        private RibbonButton btnCompare;

        public MyRibbon() : base(Globals.Factory.GetRibbonFactory()) { InitializeComponent(); }

        private void InitializeComponent()
        {
            this.tab = this.Factory.CreateRibbonTab();
            this.group = this.Factory.CreateRibbonGroup();
            this.btnCompare = this.Factory.CreateRibbonButton();
            
            this.tab.Label = "User Story Tools";
            this.tab.Groups.Add(this.group);

            this.group.Label = "Similarity Tools";
            this.group.Items.Add(this.btnCompare);

            this.btnCompare.Label = "Compare Stories";
            this.btnCompare.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCompare_Click);

            this.Tabs.Add(this.tab);
        }

        partial void btnCompare_Click(object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e);
    }

    partial class ThisRibbonCollection
    {
        internal MyRibbon MyRibbon => this.GetRibbon<MyRibbon>();
    }
}
