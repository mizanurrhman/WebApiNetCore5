using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDotNetCoreWithUnitTest.ActionResults;
using WebApiDotNetCoreWithUnitTest.Data.Models;
using WebApiDotNetCoreWithUnitTest.Data.Services;
using WebApiDotNetCoreWithUnitTest.Data.ViewModels;
using WebApiDotNetCoreWithUnitTest.Exceptions;

namespace WebApiDotNetCoreWithUnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publisherService;
        public PublishersController(PublishersService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers( string sortBy, string searchString)
        {
            try
            {
                var _result = _publisherService.GetAllPublishers(sortBy, searchString);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry ! we could not load publisher's");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publisherService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher Name :{ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public CustomActionResult GetPublisherById(int id)
        {

            var _response = _publisherService.GetPublisherById(id);
            if (_response != null)
            {
                //return Ok(_response); 
                var _responseObj = new CustomActionResultVM()
                {
                    Publisher = _response
                };
                return new CustomActionResult(_responseObj);

            }
            else
            {
                var _responseObj = new CustomActionResultVM()
                {
                    Exception = new Exception("This is coming from publisher controller ")
                };
                return new CustomActionResult(_responseObj);

                //return NotFound();
            }
        }


        /*
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            //Custom Exception handling 
            //throw new Exception("Data Not Found! & This is an exception that will be handled by middleware");

            var _response = _publisherService.GetPublisherById(id);
            if (_response != null)
                return Ok(_response);
            else
            {
                return NotFound();
            }
        }
        */

        #region returnSpecificTypeBellowExample
        /* 
        [HttpGet("get-publisher-by-id/{id}")]
        public Publisher GetPublisherById(int id)
        {

            var _response = _publisherService.GetPublisherById(id);
            if (_response != null)
            {
                return _response;
                //  return Ok(_response);
            }
            else
            {
                return null;//NotFound();
            }
        }

        // Action Result Type

        [HttpGet("get-publisher-by-id/{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {

            var _response = _publisherService.GetPublisherById(id);
            if (_response != null)
            {
                return _response;
            }
            else
            {
                return NotFound();
            }
        }


        */
        #endregion


        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }

        }
    }
}
