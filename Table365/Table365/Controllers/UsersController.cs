using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Table365.Core.Models.POCO;
using Table365.Core.Repository;

namespace Table365.Controllers
{
    /// <summary>
    ///     User API
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly UserRepository _userRepo = new UserRepository();

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns>IQueryable&lt;User&gt;.</returns>
        public IQueryable<User> GetUsers()
        {
            return _userRepo.GetAll();
            //return db.Users;
        }

        /// <summary>
        ///     Get user by id.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(Guid id)
        {
            var user = _userRepo.Get(x => x.Id == id);
            //var user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        /// <summary>
        ///     Update user.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <param name="user">The user.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(Guid id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userRepo.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                throw;
            }


            //db.Entry(user).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    throw;
            //}

            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        ///     Create a new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //db.Users.Add(user);

            try
            {
                _userRepo.Create(user);
                //db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = user.Id}, user);
        }


        /// <summary>
        ///     Delete the user by id.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(Guid id)
        {
            var user = _userRepo.Get(x => x.Id == id);


            //var user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _userRepo.Delete(user);

            //db.Users.Remove(user);
            //db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userRepo.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            return _userRepo.Get(x => x.Id == id) != null;
            //return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}