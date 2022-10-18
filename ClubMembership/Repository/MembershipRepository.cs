using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Models.DBObjects;

namespace ClubMembership.Repository
{
    public class MembershipRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public MembershipRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public MembershipRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private MembershipModel MapDBObjectToModel(Membership dbObject)
        {
            var model = new MembershipModel();

            if (dbObject != null)
            {
                model.Idmembership = dbObject.Idmembership;
                model.Idmember = dbObject.Idmember;
                model.IdmembershipType = dbObject.IdmembershipType;
                model.StartDate = dbObject.StartDate;
                model.EndDate = dbObject.EndDate;
                model.Level = dbObject.Level;
            }

            return model;
        }

        private Membership MapModelToDBObject(MembershipModel model)
        {
            var dbObject = new Membership();

            if (model != null)
            {
                dbObject.Idmembership = model.Idmembership;
                dbObject.Idmember = model.Idmember;
                dbObject.IdmembershipType = model.IdmembershipType;
                dbObject.StartDate = model.StartDate;
                dbObject.EndDate = model.EndDate;
                dbObject.Level = model.Level;
            }

            return dbObject;
        }

        public List<MembershipModel> getAllMemberships()
        {
            var list = new List<MembershipModel>();

            foreach (var dbObject in _DbContext.Memberships)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public MembershipModel getMembershipById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.Memberships.FirstOrDefault(x => x.Idmembership == id));
        }

        public void InsertMembership(MembershipModel model)
        {
            model.Idmembership = Guid.NewGuid();
            _DbContext.Memberships.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateMembership(MembershipModel model)
        {
            var dbObject = _DbContext.Memberships.FirstOrDefault(x => x.Idmembership == model.Idmembership);
            if (dbObject != null)
            {
                dbObject.Idmembership = model.Idmembership;
                dbObject.Idmember = model.Idmember;
                dbObject.IdmembershipType = model.IdmembershipType;
                dbObject.StartDate = model.StartDate;
                dbObject.EndDate = model.EndDate;
                dbObject.Level = model.Level;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteMembership(MembershipModel model)
        {
            var dbObject = _DbContext.Memberships.FirstOrDefault(x => x.Idmembership == model.Idmembership);
            if (dbObject != null)
            {
                _DbContext.Memberships.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
