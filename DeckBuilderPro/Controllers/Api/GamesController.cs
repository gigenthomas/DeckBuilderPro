using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IRepository;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.Controllers.Api
{
    public class GamesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Game> Get()
        {
            return this._unitOfWork.Repository<Game>().Query().Get();
        }

        // GET api/games/5
        [HttpGet]
        public Game Get(int id)
        {
            var game = this._unitOfWork.Repository<Game>().FindById(id);
            if (game == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return game;
        }

        // POST api/games
        [HttpPost]
        public HttpResponseMessage Post(Game game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unitOfWork.Repository<Game>().Insert(game);
                    this._unitOfWork.Commit();

                    HttpResponseMessage result =
                        Request.CreateResponse(HttpStatusCode.Created, game);

                    result.Headers.Location =
                        new Uri(Url.Link("DefaultApi", new { id = game.Id }));

                    return result;
                }
                else
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        // PUT api/games/5
        public HttpResponseMessage Put(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != game.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var existingGame = this._unitOfWork.Repository<Game>().FindById(id);

            // Keep original CreatedOn value
            
            this._unitOfWork.Repository<Game>().Update(game);

            try
            {
                this._unitOfWork.Commit();

                // Return an explicit value to avoid the fail callback
                // being incorrectly invoked.
                return Request.
                    CreateResponse(HttpStatusCode.OK,
                    "{success:'true', verb:'PUT'}");
            }
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    return Request.
            //        CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // DELETE api/games/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var game = this._unitOfWork.Repository<Game>().FindById(id);

            if (game == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unitOfWork.Repository<Game>().Delete(game);

            try
            {
                this._unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, game);
            }
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    return Request.
            //        CreateErrorResponse(HttpStatusCode.NotFound, ex);
            //}
            //Added me
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }


    }
}
