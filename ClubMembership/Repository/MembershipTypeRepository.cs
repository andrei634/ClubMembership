using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Models.DBObjects;

namespace ClubMembership.Repository
{
    public class MembershipTypeRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public MembershipTypeRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public MembershipTypeRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private MembershipTypeModel MapDBObjectToModel(MembershipType dbObject)
        {
            var model = new MembershipTypeModel();

            if (dbObject != null)
            {
                model.IdmemrbeshipType = dbObject.IdmemrbeshipType;
                model.Name = dbObject.Name;
                model.Description = dbObject.Description;
                model.SubscriptionLengthInMonths = dbObject.SubscriptionLengthInMonths;
            }

            return model;
        }

        private MembershipType MapModelToDBObject(MembershipTypeModel model)
        {
            var dbObject = new MembershipType();

            if (model != null)
            {
                dbObject.IdmemrbeshipType = model.IdmemrbeshipType;
                dbObject.Name = model.Name;
                dbObject.Description = model.Description;
                dbObject.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
            }

            return dbObject;
        }

        public List<MembershipTypeModel> getAllMembershipTypes()
        {
            var list = new List<MembershipTypeModel>();

            foreach (var dbObject in _DbContext.MembershipTypes)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public MembershipTypeModel getMembershipTypeById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.MembershipTypes.FirstOrDefault(x => x.IdmemrbeshipType == id));
        }

        public void InsertMembershipType(MembershipTypeModel model)
        {
            model.IdmemrbeshipType = Guid.NewGuid();
            _DbContext.MembershipTypes.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateMembershipType(MembershipTypeModel model)
        {
            var dbObject = _DbContext.MembershipTypes.FirstOrDefault(x => x.IdmemrbeshipType == model.IdmemrbeshipType);
            if (dbObject != null)
            {
                dbObject.IdmemrbeshipType = model.IdmemrbeshipType;
                dbObject.Name = model.Name;
                dbObject.Description = model.Description;
                dbObject.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteMembershipType(MembershipTypeModel model)
        {
            var dbObject = _DbContext.MembershipTypes.FirstOrDefault(x => x.IdmemrbeshipType == model.IdmemrbeshipType);
            if (dbObject != null)
            {
                var memberships = _DbContext.Memberships.Where(x => x.IdmembershipType == dbObject.IdmemrbeshipType).ToList();
                foreach(var membership in memberships)
                {
                    _DbContext.Memberships.Remove(membership);
                }
                _DbContext.MembershipTypes.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
