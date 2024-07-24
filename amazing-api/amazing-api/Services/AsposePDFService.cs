using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace amazing_api.Services
{
    public class AsposePDFService
    {
        public AsposePDFService () { }

        public bool GeneratePDF()
        {

            try
            {
                // initialize document object
                Document document = new Document();
                // add a page
                Page page = document.Pages.Add();

                // Create HtmlFragment with HTML content
                HtmlFragment htmlFragment = new HtmlFragment(this.GetHTMLPDF());

                // Define the header content
                HeaderFooter header = new HeaderFooter();
                // Create a TextFragment for the header
                TextFragment headerText = new TextFragment("โรงเรียนบ้านหนองงูเห่า");
                headerText.TextState.Font = FontRepository.FindFont("Arial");
                headerText.TextState.FontSize = 12;
                headerText.HorizontalAlignment = HorizontalAlignment.Center;

                // Define the header content
                HeaderFooter footer = new HeaderFooter();
                // Create a TextFragment for the header
                TextFragment footerText = new TextFragment("1");
                footerText.TextState.Font = FontRepository.FindFont("Arial");
                footerText.TextState.FontSize = 12;
                footerText.HorizontalAlignment = HorizontalAlignment.Center;

                //Add Image
                string imagePath = "https://png.pngtree.com/png-clipart/20230217/ourmid/pngtree-paper-red-pin-transparent-vector-png-image_6605001.png";
                Image image = new Image();
                image.File = imagePath;

                // Set image position and size
                image.FixWidth = 200; // Width of the image in points
                image.FixHeight = 200; // Height of the image in points
                image.HorizontalAlignment = HorizontalAlignment.Center;
                image.VerticalAlignment = VerticalAlignment.Center;

                // Add the Image to the Page
                header.Paragraphs.Add(headerText);
                page.Header = header;

                
                page.Paragraphs.Add(htmlFragment);
                page.Paragraphs.Add(image);
                page.Paragraphs.Add(htmlFragment);

                footer.Paragraphs.Add(footerText);
                page.Footer = footer;


                // save PDF document
                document.Save("output.pdf");

                return true;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

    
        public string GetHTMLPDF()
        {
            string html = string.Empty;

            void startHtml()
            {
                html = html + "<html><body>";
            }

            void endHtml()
            {
                html = html + "</body></html>";
            };

 
            startHtml();
            html = html += "<div>Preawpan PH</div>";
            endHtml();

            return html;
        }

    }
}
