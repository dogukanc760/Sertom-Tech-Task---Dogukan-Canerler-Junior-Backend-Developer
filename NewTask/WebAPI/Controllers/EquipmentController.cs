using Business.Abstract;

using Entities.Concrete;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        [Authorize(Roles = "Equipments.ListById")]
        [Route("getEquipmentById")]
        public IActionResult GetById(int id)
        {
            if (!id.Equals(null) || id > 0)
            {
                var result = _equipmentService.GetById(id);
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
        [Authorize(Roles = "Equipments.List")]
        [Route("getEquipmentsList")]
        public IActionResult GetList()
        {

            var result = _equipmentService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Id Bilgisi Gerekli!");

        }

        [HttpGet]
        [Authorize(Roles = "Equipments.ListByOrd")]
        [Route("getEquipmentsListByOrd")]
        public IActionResult GetListByOrd(bool ordType)
        {
            if (ordType.Equals(ordType))
            {
                return NotFound("Nice Try, You Should Try Again.");
            }
            var result = _equipmentService.GetListByOrd(ordType);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Sıralama Türü İçin True yada False değerlikli bir ordType parametresi geçmelisin...");

        }

        [HttpGet]
        [Authorize(Roles = "Equipments.ListForPage")]
        [Route("getEquipmentsListForPage")]
        public IActionResult GetListForPage(int takeCount, int pageCount)
        {
            if (takeCount.Equals(null) || takeCount == 0)
            {
                takeCount = 5;
            }
            if (pageCount.Equals(null) || pageCount == 0)
            {
                pageCount = 5;
            }
            var result = _equipmentService.GetListByPage(takeCount, pageCount);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Sayfalama Bilgisi Gerekli!");

        }


        [HttpGet]
        [Authorize(Roles = "Equipments.ListByClinic")]
        [Route("getEquipmentsByClinic")]
        public IActionResult GetListByClinic(int clinicId)
        {

            if (clinicId.Equals(null) || clinicId < 1)
            {
                return NotFound("Klinik Bilgisi Hatalı.");
            }
            var result = _equipmentService.GetListByClinic(clinicId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Klinik Id Bilgisi Gerekli!");

        }


        [HttpGet]
        [Authorize(Roles = "Equipments.ListByClinicDetail")]
        [Route("getEquipmentsByClinicDetail")]
        public IActionResult GetListByClinicDetail(int clinicId)
        {

            if (clinicId.Equals(null) || clinicId < 1)
            {
                return NotFound("Klinik Bilgisi Hatalı.");
            }
            var result = _equipmentService.GetListByClinicDetail(clinicId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest("Klinik Id Bilgisi Gerekli!");

        }


        [HttpGet]
        [Authorize(Roles = "Equipments.ListByBuyDate")]
        [Route("getEquipmentsByBuyDate")]
        public IActionResult GetListByBuyDate(DateTime date)
        {
            if (date.Equals(null))
            {
                return BadRequest("Gönderdiğiniz Tarih Biçimi Hatalı veya Boş!");
            }

            var result = _equipmentService.GetListByBuyDate(date);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound("Bu Tarihte Bir Veri Bulunamadı!");

        }


        [HttpGet]
        [Authorize(Roles = "Equipments.ListByBetweenDates")]
        [Route("getEquipmentsByBuyDate")]
        public IActionResult GetListByBetweenDates(DateTime start, DateTime finish)
        {
            if (start.Equals(null) || finish.Equals(finish))
            {
                return BadRequest("Gönderdiğiniz Tarih Biçimleri Hatalı veya Boş!");
            }

            var result = _equipmentService.GetListByBetweenDates(start, finish);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound("Bu Tarih Aralığında Bir Veri Bulunamadı!");

        }


        [HttpPost("add")]
        [Authorize(Roles = "Equipments.Add")]
        public IActionResult Add(Equipment equipment)
        {
            var result = _equipmentService.Add(equipment);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest("Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.");
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Equipments.Delete")]
        public IActionResult Delete(Equipment equipment)
        {
            if (equipment.Id.Equals(null) || equipment.Id < 1)
            {
                return BadRequest("Go Home Lamer");
            }
            var result = _equipmentService.Add(equipment);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest("Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.");
        }
        [HttpPost("update")]
        [Authorize(Roles = "Equipments.Update")]
        public IActionResult Update(Equipment equipment)
        {
            if (equipment.Id.Equals(null) || equipment.Id < 1)
            {
                return BadRequest("Go Home Lamer");
            }
            var result = _equipmentService.Add(equipment);
            if (result.Success)
            {
                return Created("", result.Message);
            }
            return BadRequest("Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.");
        }

    }
}
