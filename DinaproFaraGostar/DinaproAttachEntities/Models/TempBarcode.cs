namespace DinaproAttachModels.Models
{
    /// <summary>
    /// origin table name is : Barecode
    /// </summary>
    public class TempBarcode
    {
        public int id { get; set; }
        public string deviceName { get; set; }
        public bool? active { get; set; }
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public string DeviceID { get; set; }
    }
}
