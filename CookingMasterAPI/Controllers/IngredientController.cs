﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Services.ServiceInterfaces;
using CookingMasterAPI.Enums.IngredientStatusEnums.QueryEnums;
using CookingMasterAPI.Models.Request.IngredientRequests;
using CookingMasterAPI.Enums.IngredientStatusEnums.CommandEnums;
using CookingMasterAPI.Data;

namespace CookingMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;
        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredientsAsync()
        {
            try
            {
                var result = await _service.GetIngredientsAsync();

                if (result.Status is GetIngredientsEnum.Success)
                {
                    return Ok(result.Ingredients);
                }

                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<Ingredient>> GetIngredientAsync(string uid)
        {
            try
            {
                var result = await _service.GetIngredientAsync(uid);
                if (result.Status is GetIngredientEnum.Success)
                {
                    return Ok(result.Ingredient);
                }
                return NotFound(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("createIngredient")]
        public async Task<IActionResult> CreateIngredientAsync(CreateIngredientRequest request)
        {
            try
            {
                var result = await _service.CreateIngredientAsync(request);
                if (result.Status is CreateIngredientEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{uid}")]
        public async Task<IActionResult> DeleteIngredientAsync(string uid)
        {
            try
            {
                var result = await _service.DeleteIngredientAsync(uid);
                if (result.Status is DeleteIngredientEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("{uid}")]
        public async Task<IActionResult> PatchIngredientAsync(string uid, [FromBody] JsonPatchDocument<Ingredient> request)
        {
            try
            {
                var result = await _service.UpdateIngredientAsync(uid, request);
                if (result.Status is UpdateIngredientEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //string userUid, string ingredientUid
        [HttpPost("createUserIngredient")]
        public async Task<IActionResult> CreateUserIngredientAsync(Tuple<string, string> Uids)
        {
            try
            {
                var result = await _service.CreateUserIngredientAsync(Uids.Item1, Uids.Item2);
                if (result.Status is CreateUserIngredientEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("deleteUserIngredient")]
        public async Task<IActionResult> DeleteUserIngredientAsync(Tuple<int, int> Ids)
        {
            try
            {
                var result = await _service.DeleteUserIngredientAsync(Ids.Item1, Ids.Item2);
                if (result.Status is DeleteUserIngredientEnum.Success)
                {
                    return Ok(result.Description);
                }
                return BadRequest(result.Description);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
