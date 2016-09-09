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


            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        ///     Create a new user. Post with form-data, including the user info and a profile picture.
        /// </summary>
        /// <returns>IHttpActionResult.</returns>
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser()
        {
            var request = HttpContext.Current.Request;

            var user = new User();
            try
            {
                user.RegisterTime = DateTime.Now;
                user.LoginTime = DateTime.Now;
                user.Account = request.Form["Account"];
                user.Email = request.Form["Email"];
                user.Name = request.Form["Name"];
                user.Password = request.Form["Password"]; //encrypt later
                if (request.Files.Count > 0)
                {
                    var imgBytes = new byte[request.Files[0].ContentLength];
                    request.Files[0].InputStream.Read(imgBytes, 0, request.Files[0].ContentLength);
                    user.ProfilePhoto = imgBytes;
                }
                FormDataEntityValidation.ValidateEntity(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            try
            {
                _userRepo.Create(user);
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

            if (user == null)
            {
                return NotFound();
            }
            _userRepo.Delete(user);

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userRepo.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            return _userRepo.Get(x => x.Id == id) != null;
        }
    }
}