using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Table365.Models.Context;
using Table365.Models.POCO;

namespace Table365.Controllers
{
    public class TablePhotosController : ApiController
    {
        private Table365Context db = new Table365Context();

        /// <summary>
        /// Get all table photos.
        /// </summary>
        /// <returns>IQueryable&lt;TablePhoto&gt;.</returns>
        public IQueryable<TablePhoto> GetTablePhotos()
        {
            return db.TablePhotos;
        }


        /// <summary>
        /// Get table photo by id.
        /// </summary>
        /// <param name="id">The photo id.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(TablePhoto))]
        public IHttpActionResult GetTablePhoto(Guid id)
        {
            TablePhoto tablePhoto = db.TablePhotos.Find(id);
            if (tablePhoto == null)
            {
                return NotFound();
            }

            return Ok(tablePhoto);
        }


        /// <summary>
        /// Update table photo.
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

            db.Entry(tablePhoto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablePhotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Post a new photo.
        /// </summary>
        /// <param name="tablePhoto">The photo.</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(TablePhoto))]
        public IHttpActionResult PostTablePhoto(TablePhoto tablePhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TablePhotos.Add(tablePhoto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TablePhotoExists(tablePhoto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tablePhoto.Id }, tablePhoto);
        }


        /// <summary>
        /// Delete the photo by id.
        /// </summary>
        /// <param name="id">The photo id.</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(TablePhoto))]
        public IHttpActionResult DeleteTablePhoto(Guid id)
        {
            TablePhoto tablePhoto = db.TablePhotos.Find(id);
            if (tablePhoto == null)
            {
                return NotFound();
            }

            db.TablePhotos.Remove(tablePhoto);
            db.SaveChanges();

            return Ok(tablePhoto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TablePhotoExists(Guid id)
        {
            return db.TablePhotos.Count(e => e.Id == id) > 0;
        }
    }
}