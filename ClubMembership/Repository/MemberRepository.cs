using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Models.DBObjects;

namespace ClubMembership.Repository
{
    public class MemberRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public MemberRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public MemberRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private MemberModel MapDBObjectToModel(Member dbObject)
        {
            var model = new MemberModel();

            if (dbObject != null)
            {
                model.IdMember = dbObject.IdMember;
                model.Name = dbObject.Name;
                model.Title = dbObject.Title;
                model.Position = dbObject.Position;
                model.Description = dbObject.Description;
                model.Resume = dbObject.Resume;
            }

            return model;
        }

        private Member MapModelToDBObject(MemberModel model)
        {
            var dbObject = new Member();

            if (model != null)
            {
                dbObject.IdMember = model.IdMember;
                dbObject.Name = model.Name;
                dbObject.Title = model.Title;
                dbObject.Position = model.Position;
                dbObject.Description = model.Description;
                dbObject.Resume = model.Resume;
            }

            return dbObject;
        }

        public List<MemberModel> getAllMembers()
        {
            var list = new List<MemberModel>();

            foreach (var dbObject in _DbContext.Members)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public MemberModel getMemberById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.Members.FirstOrDefault(x => x.IdMember == id));
        }

        public void InsertMember(MemberModel model)
        {
            model.IdMember = Guid.NewGuid();
            _DbContext.Members.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateMember(MemberModel model)
        {
            var dbObject = _DbContext.Members.FirstOrDefault(x => x.IdMember == model.IdMember);
            if (dbObject != null)
            {
                dbObject.IdMember = model.IdMember;
                dbObject.Name = model.Name;
                dbObject.Title = model.Title;
                dbObject.Position = model.Position;
                dbObject.Description = model.Description;
                dbObject.Resume = model.Resume;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteMember(MemberModel model)
        {
            var dbObject = _DbContext.Members.FirstOrDefault(x => x.IdMember == model.IdMember);
            if (dbObject != null)
            {
                _DbContext.Members.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
