namespace RegionSyd.Model
{
    public class AssignmentCombo
    {
        private int _comboId;
        public int ComboId
        {
            get { return _comboId; }
            set { _comboId = value; }
        }

        public int RegionalId1 { get; set; }
        public int RegionalId2 { get; set; }
        public int RegionalId3 { get; set; }
        public int RegionalId4 { get; set; }
        public int RegionalId5 { get; set; }

        public string RegionalComboString { get; set; }
    }
}
