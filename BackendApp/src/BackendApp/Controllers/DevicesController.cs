using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Context;
using BackendApp.Entities;
using BackendApp.Models;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/Device")]
    public class DevicesController : Controller
    {
        UnitOfWork.UnitOfWork _unitOfWork = new UnitOfWork.UnitOfWork(new AppDbContext());

        /// <summary>
        /// Gets a specific Device by it's <c>id</c>
        /// </summary>
        /// <remarks>
        /// Action for getting specific Device and it's properties
        /// <para>Sample request:</para>
        ///
        ///     GET /api/Device/GetDevice/{id}
        ///     {
        ///        "id": "1"
        ///     }
        ///
        /// <para>Sample request would get all info about Device with specified <c>id</c> value </para>
        /// </remarks>
        /// <param name="input">The input used to get specific Device</param>
        /// <returns>Device info</returns>
        /// <response code="200">Returns Device info</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("GetDevice/{id}")]
        public DeviceEntity GetDevice(int id)
        {
            try
            {
                return _unitOfWork.DeviceRepo.GetDevice(id);
            }
            catch (Exception ex)
            {
                // TO DO
                return null;
            }
        }

        /// <summary>
        /// Gets all Devices
        /// </summary>
        [HttpGet("GetAllDevices")]
        public List<DeviceEntity> GetAllDevices(int id)
        {
            try
            {
                return _unitOfWork.DeviceRepo.GetAllDevices();
            }
            catch (Exception ex)
            {
                // TO DO
                return null;
            }
        }

        /*
        public List<DeviceEntity> FindDevicesByFilter()
        {
            // TO DO
            return null;
        }
        */

        /// <summary>
        /// Adding new Device
        /// </summary>
        [HttpPost("AddDevice")]
        public void AddDevice(DeviceEntity deviceEntity)
        {
            try
            {
                _unitOfWork.DeviceRepo.AddDevice(deviceEntity);
                _unitOfWork.Save();
                _unitOfWork.DeviceRepo.AddDevicePropertyValues(deviceEntity);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // TO DO
            }
        }

        /// <summary>
        /// Editing Device specified by it's <c>id</c>
        /// </summary>
        [HttpPut("EditDevice")]
        public void EditDevice(DeviceEntity deviceEntity)
        {
            try
            {
                _unitOfWork.DeviceRepo.EditDevice(deviceEntity);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // TO DO
            }
        }

        /// <summary>
        /// Deleting Device specified by it's <c>id</c>
        /// </summary>
        [HttpDelete("DeleteDevice")]
        public void DeleteDevice(int id)
        {
            try
            {
                _unitOfWork.DeviceRepo.DeleteDevice(id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // TO DO
            }
        }
    }
}
