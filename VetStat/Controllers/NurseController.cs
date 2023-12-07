﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VetStat.Data;
using VetStat.Helpers.Validators;
using VetStat.Models;


namespace VetStat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly DataContext _db;
        public NurseController(DataContext db)
        {
            _db = db;
        }
        //api/Nurse/GetAll
        [HttpGet]
        public ActionResult<List<Nurse>> GetAll()
        {
            if (!_db.Nurse.IsNullOrEmpty())
                return Ok(_db.Nurse.ToList());
            return NoContent();
        }

        //api/Nurse/Get/:id
        [HttpGet("{id}")]
        public ActionResult<Nurse> Get(int id)
        {
            if (!_db.Nurse.Where(x => x.Id == id).IsNullOrEmpty())
                return Ok(_db.Nurse.Where(x => x.Id == id));
            else return NoContent(); 
        }

        //api/Nurse/Add
        [HttpPost]
        public ActionResult<Nurse> Add([FromBody] Nurse nurse)
        {
            try
            {
                Services.PersonValidator(nurse);
                _db.Nurse.Add(nurse);
                _db.SaveChanges();

                return Ok(nurse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/Nurse/Edit/:id
        [HttpPut("{id}")]
        public ActionResult Edit([FromBody] Nurse nurse, int id)
        {
            var _nurse = _db.Nurse.Where(x => x.Id == id).FirstOrDefault();

            try
            {
                Services.UpdateEntity(_nurse, nurse);
                _db.SaveChanges();
                return Ok(nurse);
            }

            catch (Exception err)
            {
                return BadRequest(err.Message); //Error message
            }
        }

        //api/Nurse/Delete/:id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var nurseToDelete = _db.Nurse.SingleOrDefault(x => x.Id == id);
                if (nurseToDelete != null)
                {
                    _db.Nurse.Remove(nurseToDelete);
                    _db.SaveChanges();
                    return Ok("Object deleted!");
                }
                else
                {
                    return NotFound($"Nurse with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }
        }
    }
    }
