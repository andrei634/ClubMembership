using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Models.DBObjects;

namespace ClubMembership.Repository
{
    public class CodeSnippetRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public CodeSnippetRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public CodeSnippetRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private CodeSnippetModel MapDBObjectToModel(CodeSnippet dbObject)
        {
            var model = new CodeSnippetModel();

            if (dbObject != null)
            {
                model.IdcodeSnippet = dbObject.IdcodeSnippet;
                model.Title = dbObject.Title;
                model.ContentCode = dbObject.ContentCode;
                model.Idmember = dbObject.Idmember;
                model.Revision = dbObject.Revision;
                model.IdsnippetPreviousVersion = dbObject.IdsnippetPreviousVersion;                
                model.DateTimeAdded = dbObject.DateTimeAdded;
                model.IsPublished = dbObject.IsPublished;
            }

            return model;
        }

        private CodeSnippet MapModelToDBObject(CodeSnippetModel model)
        {
            var dbObject = new CodeSnippet();

            if (model != null)
            {
                dbObject.IdcodeSnippet = model.IdcodeSnippet;
                dbObject.Title = model.Title;
                dbObject.ContentCode = model.ContentCode;
                dbObject.Idmember = model.Idmember;
                dbObject.Revision = model.Revision;
                dbObject.IdsnippetPreviousVersion = model.IdsnippetPreviousVersion;                
                dbObject.DateTimeAdded = model.DateTimeAdded;
                dbObject.IsPublished = model.IsPublished;
            }

            return dbObject;
        }

        public List<CodeSnippetModel> getAllCodeSnippets()
        {
            var list = new List<CodeSnippetModel>();

            foreach (var dbObject in _DbContext.CodeSnippets)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public CodeSnippetModel getCodeSnippetById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == id));
        }

        public void InsertCodeSnippet(CodeSnippetModel model)
        {
            model.IdcodeSnippet = Guid.NewGuid();
            _DbContext.CodeSnippets.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateCodeSnippet(CodeSnippetModel model)
        {
            var dbObject = _DbContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == model.IdcodeSnippet);
            if (dbObject != null)
            {
                dbObject.IdcodeSnippet = model.IdcodeSnippet;
                dbObject.Title = model.Title;
                dbObject.ContentCode = model.ContentCode;
                dbObject.Idmember = model.Idmember;
                dbObject.Revision = model.Revision;
                dbObject.IdsnippetPreviousVersion = model.IdsnippetPreviousVersion;
                dbObject.DateTimeAdded = model.DateTimeAdded;
                dbObject.IsPublished = model.IsPublished;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteCodeSnippet(CodeSnippetModel model)
        {
            var dbObject = _DbContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == model.IdcodeSnippet);
            if (dbObject != null)
            {
                _DbContext.CodeSnippets.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
