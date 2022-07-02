using BusinessLoanMVC.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLoanMVC.UI.Repositories
{
    public class DocumentRepository
    {
        public BusinessLoanContext context;
        public DocumentRepository()
        {
            context = new BusinessLoanContext();
        }
        public void AddDocument(Document doc)
        {
            context.Documents.Add(doc);
            context.SaveChanges();
        }
        public void EditDocumet(Document doc)
        {
            context.Entry<Document>(doc).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteDocument(string docId)
        {
            Document document = context.Documents.Find(docId);
            context.Documents.Remove(document);
            context.SaveChanges();
        }
        public Document GetDocumentById(string docId)
        {
            Document document = context.Documents.Find(docId);
            return document;
        }

    }
}