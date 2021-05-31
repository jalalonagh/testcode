namespace Entities.ConfirmedTransaction
{
    public class ConfirmedTransaction : BaseEntity
    {
        public int transactionId { get; set; }
        public Transaction.Transaction transaction { get; set; }
        public int phoneId { get; set; }
        public Phone.Phone phone { get; set; }
        public bool autoConfirmed { get; set; }
        public bool manualConfirmed { get; set; }
    }
}
