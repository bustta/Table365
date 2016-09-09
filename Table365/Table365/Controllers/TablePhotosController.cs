using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Table365.Core.Models.POCO;
using Table365.Core.Models.Validation;
using Table365.Core.Repository;

namespace Table365.Controllers
{
    /// <summary>
    ///     TablePhoto API
    /// </summary>
    public class TablePhotosController : ApiController
    {
        private readonly TablePhotoRepository _tablePhotoRepo = new TablePhotoRepository();

        /// <summary>
        ///     Get all table photos.
        /// </summary>
        /// <returns>IQueryable&lt;TablePhoto&gt;.</returns>
        public IQueryable<TablePhoto> GetTablePhotos()
        {
            //return db.TablePhotos;
            return _tablePhotoRepo.GetAll();
        }


        /// <summary>
        ///     Get table photo by id.
        /// </summary>
        /// <param name="id">The photo id.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(TablePhoto))]
        public IHttpActionResult GetTablePhoto(Guid id)
        {
            //var tablePhoto = db.TablePhotos.Find(id);
            var tablePhoto = _tablePhotoRepo.Get(x => x.Id == id);
            if (tablePhoto == null)
            {
                return NotFound();
            }

            return Ok(tablePhoto);
        }


        /// <summary>
        ///     Update table photo.
        /// </summary>
        /// <param name="id">The photo id.</param>
        /// <param name="tablePhoto">The photo.</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTablePhoto(Guid id, TablePhoto tablePhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tablePhoto.Id)
            {
                return BadRequest();
            }

            //db.Entry(tablePhoto).State = EntityState.Modified;

            try
            {
                //db.SaveChanges();
                _tablePhotoRepo.Update(tablePhoto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablePhotoExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        ///     Post a new photo. Post with form-data.
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        //[ResponseType(typeof(TablePhoto))]
        [ResponseType(typeof(TablePhoto))]
        public IHttpActionResult PostTablePhoto()
        {
            var request = HttpContext.Current.Request;
            var userRepo = new UserRepository();
            var userId = request.Form["User"];
            var user = userRepo.Get(x => x.Id.ToString() == userId);
            var tablePhoto = new TablePhoto
            {
                User = user,
                PostTime = DateTime.Now,
                Description = request.Form["Description"],
                Location = request.Form["Location"],
            };
            FormDataEntityValidation.ValidateEntity(tablePhoto);

            if (request.Files.Count > 0)
            {
                var imgBytes = new byte[request.Files[0].ContentLength];
                request.Files[0].InputStream.Read(imgBytes, 0, request.Files[0].ContentLength);
            }
            _tablePhotoRepo.Create(tablePhoto);

            return CreatedAtRoute("DefaultApi", new { id = tablePhoto.Id }, tablePhoto);
        }


        /// <summary>
        ///     Delete the photo by id.
        /// </summary>
        /// <param name="id">The photo id.</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(TablePhoto))]
        public IHttpActionResult DeleteTablePhoto(Guid id)
        {
            //var tablePhoto = db.TablePhotos.Find(id);
            var tablePhoto = _tablePhotoRepo.Get(x => x.Id == id);
            if (tablePhoto == null)
            {
                return NotFound();
            }
            _tablePhotoRepo.Delete(tablePhoto);
            //db.TablePhotos.Remove(tablePhoto);
            //db.SaveChanges();

            return Ok(tablePhoto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _tablePhotoRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TablePhotoExists(Guid id)
        {
            //return db.TablePhotos.Count(e => e.Id == id) > 0;
            return _tablePhotoRepo.Get(x => x.Id == id) != null;
        }
    }
}