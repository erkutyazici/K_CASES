namespace Case2.Models
{
    public class InvoiceJsonModel
    {
        public string description { get; set; }

        public InvoiceBoundingPolyJsonModel boundingPoly { get; set; }
    }

    public class InvoiceBoundingPolyJsonModel
    {
        public List<InvoiceBoundingPolyVerticesModel> vertices { get; set; }
    }

    public class InvoiceBoundingPolyVerticesModel
    {
        public int x { get; set; }

        public int y { get; set; }
    }
}
