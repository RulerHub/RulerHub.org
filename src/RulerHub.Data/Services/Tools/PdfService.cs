   using iText.Kernel.Pdf;
   using iText.Layout;
   using iText.Layout.Element;
   using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Data.Services.Tools;

   public class PdfService
   {
       public byte[] GeneratePdf(List<Warehouse> warehouses)
       {
           using (var stream = new MemoryStream())
           {
               var writer = new PdfWriter(stream);
               var pdf = new PdfDocument(writer);
               var document = new Document(pdf);

               document.Add(new Paragraph("Lista de Almacenes"));

               foreach (var warehouse in warehouses)
               {
                   document.Add(new Paragraph($"Nombre: {warehouse.Name}"));
                   document.Add(new Paragraph($"Dirección: {warehouse.Categories}"));
                   document.Add(new Paragraph($"Teléfono: {warehouse.Departments}"));
                   document.Add(new Paragraph($"Email: {warehouse.Items}"));
                   document.Add(new Paragraph(" "));
               }

               document.Close();
               return stream.ToArray();
           }
       }
   }
   