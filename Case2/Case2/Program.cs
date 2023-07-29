// See https://aka.ms/new-console-template for more information
using Case2.Models;
using System.Text.Json;

var invoiceDataList = ReadInvoiceJson();

WriteInvoiceTxt(invoiceDataList);

List<InvoiceJsonModel> ReadInvoiceJson()
{
    using (StreamReader reader = new StreamReader("C:\\CASES\\Case2\\Case2\\Data\\invoice.json"))
    {
        string jsonInvoiceData = reader.ReadToEnd();

        return JsonSerializer.Deserialize<List<InvoiceJsonModel>>(jsonInvoiceData);
    }
}

void WriteInvoiceTxt(List<InvoiceJsonModel> invoiceDataList)
{
    if (invoiceDataList == null || !invoiceDataList.Any())
        return;

    // remove unnecessary line
    invoiceDataList.RemoveAt(0);

    using (StreamWriter writer = File.CreateText("C:\\CASES\\Case2\\Case2\\Data\\invoice.txt"))
    {
        writer.WriteLine("line | text");
        writer.WriteLine("---- | ----");

        int sensibilityY = 15;

        for (int i = 0; i < invoiceDataList.Count; i++)
        {
            // finding same line datas from y coordinates with +15 -15 range
            var sameLineInvoiceData = invoiceDataList.Where(x => x.boundingPoly.vertices[0].y < invoiceDataList[i].boundingPoly.vertices[0].y + sensibilityY && x.boundingPoly.vertices[0].y > invoiceDataList[i].boundingPoly.vertices[0].y - sensibilityY).ToList();

            if (sameLineInvoiceData.Any())
            {
                writer.WriteLine($"{i + 1,-4} | {String.Join(" ", sameLineInvoiceData.Select(x => x.description))}");
                
                // These same line datas removed from invoiceDataList except current data
                invoiceDataList.RemoveAll(x => x != invoiceDataList[i] && sameLineInvoiceData.Contains(x));
            }
        }
    }
}
