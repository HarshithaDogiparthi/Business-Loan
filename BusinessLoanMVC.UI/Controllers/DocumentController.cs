using BusinessLoanMVC.DataService;
using BusinessLoanMVC.UI.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessLoanMVC.UI.Controllers
{
    public class DocumentController : Controller
    {
        public DocumentRepository documentRepository;
      public  DocumentController()
        {
            documentRepository = new DocumentRepository();
        }
       
        public Guid UploadDocument( Document doc, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    int filelength = upload.ContentLength;
                    byte[] Myfile = new byte[filelength];
                    upload.InputStream.Read(Myfile, 0, filelength);
                    doc.DocumentId = Guid.NewGuid();
                    doc.DocumentUpload = Myfile;
                    documentRepository.AddDocument(doc);

                   
                }
            }

            return doc.DocumentId;

        }
        public ActionResult DownloadDocument(Guid Id)
        {
          
           Document obj= documentRepository.GetDocumentById(Id);

            byte[] byteArray = obj.DocumentUpload;

            return new FileContentResult(byteArray, "application/pdf");

        }
    }
}