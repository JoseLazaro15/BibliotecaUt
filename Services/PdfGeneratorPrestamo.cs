namespace PracticaBiblioteca.Services
{
    public class PdfGeneratorPrestamo
    {
        public byte[] GeneratePdf()
        {
            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                document.Add(new Paragraph("Este es un PDF simple."));

                document.Close();
                return stream.ToArray();
            }
        }


    }
}
