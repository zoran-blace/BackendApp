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
    [Route("api/DeviceType")]
    public class DeviceTypesController : Controller
    {
        UnitOfWork.UnitOfWork _unitOfWork = new UnitOfWork.UnitOfWork(new AppDbContext());

        /// <summary>
        /// Gets a specific Device Type by it's <c>id</c>
        /// </summary>
        /// <remarks>
        /// Action for getting specific Device Type and it's properties
        /// <para>Sample request:</para>
        ///
        ///     GET /api/Device/GetDeviceType/{id}
        ///     {
        ///        "id": "1"
        ///     }
        ///
        /// <para>Sample request would get all info about Device Type with specified <c>id</c> value </para>
        /// </remarks>
        /// <param name="input">The input used to get specific Device Type</param>
        /// <returns>Device Type info</returns>
        /// <response code="200">Returns Device Type info</response>
        /// <response code="401">If the user is not authenticated</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("GetDeviceType/{id}")]
        public DeviceTypeEntity GetDeviceType(int id)
        {
            try
            {
                return _unitOfWork.DeviceTypeRepo.GetDeviceType(id);
            }
            catch (Exception ex)
            {
                // TO DO
                return null;
            }
        }

        /// <summary>
        /// Gets all Device Types
        /// </summary>
        [HttpGet("GetAllDeviceTypes")]
        public List<DeviceTypeListEntity> GetAllDeviceTypes()
        {
            try
            {
                return _unitOfWork.DeviceTypeRepo.GetAllDeviceTypes();
            }
            catch (Exception ex)
            {
                // TO DO
                return null;
            }
        }

        /// <summary>
        /// Adding new Device Type
        /// </summary>
        [HttpPost("AddDeviceType")]
        public void AddDeviceType(DeviceTypeEntity deviceTypeEntity)
        {
            try
            {
                _unitOfWork.DeviceTypeRepo.AddDeviceType(deviceTypeEntity);
                _unitOfWork.Save();
                _unitOfWork.DeviceTypeRepo.AddDeviceTypeProperties(deviceTypeEntity);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // TO DO
            }
        }

        /// <summary>
        /// Editing new Device specified by it's <c>id</c>
        /// </summary>
        [HttpPut("EditDeviceType")]
        public void EditDeviceType(DeviceTypeEntity deviceTypeEntity)
        {
            try
            {
                _unitOfWork.DeviceTypeRepo.EditDeviceType(deviceTypeEntity);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // TO DO
            }
        }

        /// <summary>
        /// Deleting Device Type specified by it's <c>id</c>
        /// </summary>
        [HttpDelete("DeleteDeviceType")]
        public void DeleteDeviceType(int id)
        {
            try
            {
                if (_unitOfWork.DeviceTypeRepo.DeleteDeviceType(id))
                    _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // TO DO
            }
        }
    }
}
