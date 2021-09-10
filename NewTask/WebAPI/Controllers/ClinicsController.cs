using Business.Abstract;

using Entities.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private IClinicsService _clinicService;
        private IEquipmentService _equipmentService;
        public ClinicsController(IClinicsService clinicsService, IEquipmentService equipmentService)
        {
            _clinicService = clinicsService;
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Authorize(Roles = "Clinics.ListById")]
        [Route("getClinicById")]
        public IActionResult GetById(int id)
        {
            if (!id.Equals(null) || id > 0)
            {
                var result = _clinicService.GetById(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                if (result == null)
                {
                    return NotFound("Bu Id Değeri İle Bir Veri Bulunamadı!");
                }
            }
            return BadRequest("Id Bilgisi Gerekli!");

        }

        [HttpGet]
        [Authorize(Roles = "Clinics.List")]
        [Route("getClinicList")]
        public IActionResult GetList()
        {

            var result = _clinicService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Id Bilgisi Gerekli!");

        }


        [HttpGet]
        [Route("getEquipmentsByClinic")]
        [Authorize(Roles = "Clinics.ListEquipment")]
        public IActionResult GetEquipmentsByClinic(int id)
        {
            if (!id.Equals(null) || id<1)
            {
                var result = _equipmentService.GetListByClinic(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                if (result == null)
                {
                    return NotFound("Bu Id Değeri İle Bir Veri Bulunamadı!");
                }
            }
          
            return BadRequest("Id Bilgisi Gerekli!");

        }

        [HttpGet]
        [Route("getEquipmentsByClinicDetail")]
        [Authorize(Roles = "Clinics.ListEquipmentDetail")]
        public IActionResult GetEquipmentsByClinicDetail(int id)
        {
            if (!id.Equals(null) || id < 1)
            {
                var result = _equipmentService.GetListByClinicDetail(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                if (result == null)
                {
                    return NotFound("Bu Id Değeri İle Bir Veri Bulunamadı!");
                }
            }

            return BadRequest("Id Bilgisi Gerekli!");

        }

        [HttpPost("add")]
        [Authorize(Roles = "Clinics.Add")]
        public IActionResult Add(Clinics clinics)
        {
            if (clinics.Id.Equals(null)||clinics.Id<1)
            {
                return BadRequest("Bilgileri Tekrar Kontrol Ediniz.");
            }
            var result = _clinicService.Add(clinics);
            if (result.Success)
            {
                return Created("",result.Message);
            }
            return BadRequest("Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.");
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Clinics.Delete")]
        public IActionResult Delete(Clinics clinics)
        {
            if (clinics.Id.Equals(null) || clinics.Id<1)
            {
                return BadRequest("Go Home Lamer");
            }
            var result = _clinicService.Delete(clinics);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest("Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.");
        }
        [HttpPost("update")]
        [Authorize(Roles = "Clinics.Update")]
        public IActionResult Update(Clinics clinics)
        {
            if (clinics.Id.Equals(null) || clinics.Id < 1)
            {
                return BadRequest("Go Home Lamer");
            }
            var result = _clinicService.Update(clinics);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest("Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.");
        }
    }
}
