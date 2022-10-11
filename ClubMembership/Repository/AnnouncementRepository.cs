using ClubMembership.Data;
using ClubMembership.Models;
using ClubMembership.Models.DBObjects;

namespace ClubMembership.Repository
{
    public class AnnouncementRepository
    {
        private readonly ApplicationDbContext _DbContext;

        public AnnouncementRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public AnnouncementRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private AnnouncementModel MapDBObjectToModel(Announcemment dbObject)
        {
            var model = new AnnouncementModel();

            if(dbObject != null)
            {
                model.Idannouncemment = dbObject.Idannouncemment;
                model.ValidFrom = dbObject.ValidFrom;
                model.ValidTo = dbObject.ValidTo;
                model.Title = dbObject.Title;
                model.Text = dbObject.Text;
                model.EventDateTime = dbObject.EventDateTime;
                model.Tags = dbObject.Tags;
            }

            return model;
        }

        private Announcemment MapModelToDBObject(AnnouncementModel model)
        {
            var dbObject = new Announcemment();

            if(model != null)
            {
                dbObject.Idannouncemment = model.Idannouncemment;
                dbObject.ValidFrom = model.ValidFrom;
                dbObject.ValidTo = model.ValidTo;
                dbObject.Title = model.Title;
                dbObject.Text = model.Text;
                dbObject.EventDateTime = model.EventDateTime;
                dbObject.Tags = model.Tags;
            }

            return dbObject;
        }

        public List<AnnouncementModel> getAllAnnoucements()
        {
            var list = new List<AnnouncementModel>();

            foreach(var dbObject in _DbContext.Announcemments)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }

            return list;
        }

        public AnnouncementModel getAnnouncementById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.Announcemments.FirstOrDefault(x => x.Idannouncemment == id));
        }

        public void InsertAnnouncement(AnnouncementModel model)
        {
            model.Idannouncemment = Guid.NewGuid();
            _DbContext.Announcemments.Add(MapModelToDBObject(model));
            _DbContext.SaveChanges();
        }

        public void UpdateAnnouncement(AnnouncementModel model)
        {
            var dbObject = _DbContext.Announcemments.FirstOrDefault(x => x.Idannouncemment == model.Idannouncemment);
            if (dbObject != null)
            {
                dbObject.Idannouncemment = model.Idannouncemment;
                dbObject.ValidFrom = model.ValidFrom;
                dbObject.ValidTo = model.ValidTo;
                dbObject.Title = model.Title;
                dbObject.Text = model.Text;
                dbObject.EventDateTime = model.EventDateTime;
                dbObject.Tags = model.Tags;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteAnnouncement(AnnouncementModel model)
        {
            var dbObject = _DbContext.Announcemments.FirstOrDefault(x => x.Idannouncemment == model.Idannouncemment);
            if(dbObject != null)
            {
                _DbContext.Announcemments.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
